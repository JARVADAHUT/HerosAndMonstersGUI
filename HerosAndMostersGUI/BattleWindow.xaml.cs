using System.Reflection;
using DesignPatterns___DC_Design;
using HerosAndMostersGUI.BattleCode;
using HerosAndMostersGUI.CharacterCode;
using MazeTest;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace HerosAndMostersGUI
{
    /// <summary>
    /// Interaction logic for BattleWindow.xaml
    /// </summary>
    public partial class BattleWindow : Window
    {

        #region Get Rid Of Controlbox

        private const int GWL_STYLE = -16;
        private const int WS_SYSMENU = 0x00080000;

        [DllImport("user32.dll")]
        private extern static int SetWindowLong(IntPtr hwnd, int index, int value);
        [DllImport("user32.dll")]
        private extern static int GetWindowLong(IntPtr hwnd, int index);

        private void MainWindow_SourceInitialized(object sender, EventArgs e)
        {
            WindowInteropHelper wih = new WindowInteropHelper(this);
            int style = GetWindowLong(wih.Handle, GWL_STYLE);
            SetWindowLong(wih.Handle, GWL_STYLE, style & ~WS_SYSMENU);
        }

        #endregion

        #region Privates

        private const int _tickSpeed = 100;
        private SolidColorBrush STROKE_COLOR = Brushes.Blue;


        private List<Rectangle> _shapeTargetList;
        private List<DungeonCharacter> _targetList;
        private DispatcherTimer _barTick;
        private int _currentTarget;
        private List<EnumAttacks> _playersAttacks = Player.GetInstance().GetAttacks();

        private double _playerGCD;// = TimeSpan.FromMilliseconds(0);
        private Stopwatch _playerGCDTicker;

        #endregion

        public BattleWindow(List<int> MonsterInformation)
        {
            SourceInitialized += MainWindow_SourceInitialized;
            InitializeComponent();

            #region Media Player Stuff

            var basePath = new Uri(Assembly.GetEntryAssembly().Location);
            var uri = new Uri(basePath, "Resources/BattleMusic.mp3");

            var mediaPlayer = MainWindow.BackgroundMusicPlayer;
            mediaPlayer.Stop();
            mediaPlayer.Volume = .5;
            mediaPlayer.Open(uri);
            mediaPlayer.Play();

            #endregion

            #region Setting Privates

            _playerGCDTicker = new Stopwatch();
            _shapeTargetList = new List<Rectangle>();
            _targetList = new List<DungeonCharacter>();
            _barTick = new DispatcherTimer();
            this.KeyDown += new KeyEventHandler(HandleKey);
            playersRec.Fill = Player.GetInstance().GetColor();

            #endregion

            #region Fill Out Buttons

            List<EnumAttacks> playersAttacks = Player.GetInstance().GetAttacks();
            btnAbility1.Content = playersAttacks.ElementAt<EnumAttacks>(0).Name;
            btnAbility2.Content = playersAttacks.ElementAt<EnumAttacks>(1).Name;
            btnAbility3.Content = playersAttacks.ElementAt<EnumAttacks>(2).Name;
            btnAbility4.Content = playersAttacks.ElementAt<EnumAttacks>(3).Name;

            #endregion

            #region Create Target Lists

            _targetList.Add(Hero.GetInstance());
            playersRec.MouseDown += playersRec_MouseDown;
            _shapeTargetList.Add(playersRec);

            BattleBuilder monsterMaker = new BattleBuilder();
            List<Monster> monsterList = monsterMaker.AddMonsters(MonsterInformation);

            TargetMonsters(MonsterInformation.Count, monsterList);

            ShowMonsters(MonsterInformation.Count);

            _currentTarget = 0;

            #endregion

            #region Set Up Tick Event

            _barTick.Tick += new EventHandler(OnTick);
            _barTick.Interval = new TimeSpan(0, 0, 0, 0, _tickSpeed);

            #endregion

            #region Set Up Player "Bars"

            pbPlayerHealth.Maximum = Hero.GetInstance().DCStats.GetStat(StatsType.MaxHp);
            pbPlayerMana.Maximum = Hero.GetInstance().DCStats.GetStat(StatsType.MaxResources);

            #endregion

            #region Activate The Battle

            _barTick.IsEnabled = true;
            monsterMaker.StartBattle();
            _playerGCDTicker.Start();
            SetTarget(1);

            #endregion

        }

        

        private void OnTick(object sender, EventArgs e)
        {

            #region Setting Player "Bars"

            int playerHp = Hero.GetInstance().DCStats.GetStat(StatsType.CurHp);
            int playerMp = Hero.GetInstance().DCStats.GetStat(StatsType.CurResources);

            pbPlayerHealth.Value = playerHp;
            pbPlayerMana.Value = playerMp;

            double maxCD = StatAlgorithms.ConvertAgilityToMiliseconds(Hero.GetInstance());
            double curCD = _playerGCDTicker.ElapsedMilliseconds;

            pbPlayerGCD.Maximum = maxCD;

            if (curCD <= maxCD)
                pbPlayerGCD.Value = curCD;
            else
                pbPlayerGCD.Value = maxCD;

            #endregion

            //player died
            if (playerHp <= 0)
            {
                Player.GetInstance().Die();
                CloseBattle();
            }

            #region Setting Monster "Bars" or Killing Them

            for (int x = 1; x < _targetList.Count; x++)
            {
                int monsterHp = _targetList.ElementAt<DungeonCharacter>(x).DCStats.GetStat(StatsType.CurHp);
                Rectangle theMonster = _shapeTargetList.ElementAt<Rectangle>(x);

                if (monsterHp <= 0)
                {
                    ((Monster)_targetList.ElementAt(x)).IsDead = true;

                    _targetList.RemoveAt(x);
                    _shapeTargetList.RemoveAt(x);
                    x--;
                    theMonster.Stroke = Brushes.Transparent;
                    theMonster.Fill = Brushes.White;
                    RemoveHealthBar(theMonster.Name);
                    _currentTarget = 0;
                    SetTarget(1);
                }
                else
                    SetHealthBar(theMonster.Name, monsterHp);

            }

            #endregion

            //all monsters died
            if (_targetList.Count <= 1)
            {
                CloseBattle();
            }

        }

        #region Monster Switches

        private void SetHealthBar(string theMonster, int hp)
        {
            switch (theMonster)
            {
                case "monster1Rec":
                    pbMonster1Health.Value = hp;
                    break;
                case "monster2Rec":
                    pbMonster2Health.Value = hp;
                    break;
                case "monster3Rec":
                    pbMonster3Health.Value = hp;
                    break;
                case "monster4Rec":
                    pbMonster4Health.Value = hp;
                    break;
            }
        }

        private void RemoveHealthBar(string x)
        {
            switch (x)
            {
                case "monster1Rec":
                    pbMonster1Health.Visibility = Visibility.Hidden;
                    break;
                case "monster2Rec":
                    pbMonster2Health.Visibility = Visibility.Hidden;
                    break;
                case "monster3Rec":
                    pbMonster3Health.Visibility = Visibility.Hidden;
                    break;
                case "monster4Rec":
                    pbMonster4Health.Visibility = Visibility.Hidden;
                    break;
            }
        }

        private void TargetMonsters(int p, List<Monster> monsterList)
        {
            //4 is on top if there is 4 monsters
            if (p == 4)
            {
                _shapeTargetList.Add(monster4Rec);
                monster4Rec.MouseDown += monster4Rec_MouseDown;
                _targetList.Add(monsterList.ElementAt<Monster>(3));
            }

            //always do
            _shapeTargetList.Add(monster1Rec);
            monster1Rec.MouseDown += monster1Rec_MouseDown;
            _targetList.Add(monsterList.ElementAt<Monster>(0));

            if (p > 1)
            {
                _shapeTargetList.Add(monster2Rec);
                monster2Rec.MouseDown += monster2Rec_MouseDown;
                _targetList.Add(monsterList.ElementAt<Monster>(1));
            }

            if (p > 2)
            {
                _shapeTargetList.Add(monster3Rec);
                monster3Rec.MouseDown += monster3Rec_MouseDown;
                _targetList.Add(monsterList.ElementAt<Monster>(2));
            }
        }

        private void ShowMonsters(int p)
        {
            pbMonster1Health.Maximum = _targetList.ElementAt<DungeonCharacter>(1).DCStats.GetStat(StatsType.MaxHp);

            if (p >= 2)
            {
                monster2Rec.Fill = Brushes.Tomato;
                pbMonster2Health.Maximum = _targetList.ElementAt<DungeonCharacter>(2).DCStats.GetStat(StatsType.MaxHp);
                pbMonster2Health.Visibility = Visibility.Visible;
            }
            if (p >= 3)
            {
                monster3Rec.Fill = Brushes.Tomato;
                pbMonster3Health.Maximum = _targetList.ElementAt<DungeonCharacter>(3).DCStats.GetStat(StatsType.MaxHp);
                pbMonster3Health.Visibility = Visibility.Visible;
            }
            if (p == 4)
            {
                monster4Rec.Fill = Brushes.Tomato;
                pbMonster4Health.Maximum = _targetList.ElementAt<DungeonCharacter>(4).DCStats.GetStat(StatsType.MaxHp);
                pbMonster4Health.Visibility = Visibility.Visible;
            }
        }

        #endregion

        #region Rectangle Click Events

        private void monster4Rec_MouseDown(object sender, MouseButtonEventArgs e)
        {
            EventTargetSet(_shapeTargetList.IndexOf(monster4Rec));
        }

        private void monster3Rec_MouseDown(object sender, MouseButtonEventArgs e)
        {
            EventTargetSet(_shapeTargetList.IndexOf(monster3Rec));
        }

        private void monster2Rec_MouseDown(object sender, MouseButtonEventArgs e)
        {
            EventTargetSet(_shapeTargetList.IndexOf(monster2Rec));
        }

        private void monster1Rec_MouseDown(object sender, MouseButtonEventArgs e)
        {
            EventTargetSet(_shapeTargetList.IndexOf(monster1Rec));
        }

        private void playersRec_MouseDown(object sender, MouseButtonEventArgs e)
        {
            EventTargetSet(_shapeTargetList.IndexOf(playersRec));
        }

        private void EventTargetSet(int targ)
        {
            SetTarget(targ - _currentTarget);
        }

        #endregion

        private void SetTarget(int targChange)
        {
            if (_currentTarget >= 0 && _currentTarget < _targetList.Count)
            {
                _shapeTargetList.ElementAt<Rectangle>(_currentTarget).Stroke = Brushes.Transparent;

                _currentTarget = (_currentTarget + targChange) % _targetList.Count;
                if (_currentTarget < 0)
                    _currentTarget = _shapeTargetList.Count - 1;

                _shapeTargetList.ElementAt<Rectangle>(_currentTarget).Stroke = STROKE_COLOR;
            }
        }

        #region Key Handler

        private void HandleKey(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.W:
                    SetTarget(1);
                    break;

                case Key.S:
                    SetTarget(-1);
                    break;

                case Key.D1:
                    DoAttack(0);
                    break;

                case Key.D2:
                    DoAttack(1);
                    break;

                case Key.D3:
                    DoAttack(2);
                    break;

                case Key.D4:
                    DoAttack(3);
                    break;
            }
        }

        #endregion

        private void CloseBattle() // <----------------------- NEWLY ADDED
        {
            StatAugmentCommand cmd = new StatAugmentCommand();
            Hero hero = Hero.GetInstance();
            cmd.AddEffect(new EffectInformation(StatsType.CurResources, hero.DCStats.GetStat(StatsType.MaxResources) - hero.DCStats.GetStat(StatsType.CurResources), 0, 0), hero);
            StatAugmentManager.GetInstance().OfferCommand(cmd);

            _barTick.IsEnabled = false;

            #region Music Player Stuff
            MainWindow.BackgroundMusicPlayer.Stop();
            var basePath = new Uri(Assembly.GetEntryAssembly().Location);
            var uri = new Uri(basePath, "Resources/soundtrack.mp3");
            MainWindow.BackgroundMusicPlayer.Open(uri);
            MainWindow.BackgroundMusicPlayer.Play();
            #endregion

            this.Close();
        }

        #region Player Ability Buttons

        private List<DungeonCharacter> GetTargets()
        {
            List<DungeonCharacter> targets = new List<DungeonCharacter>();

            targets.Add(_targetList.ElementAt<DungeonCharacter>(_currentTarget));

            if (_currentTarget == 0)
                return targets;

            if (_currentTarget + 1 < _targetList.Count)
                targets.Add(_targetList.ElementAt<DungeonCharacter>(_currentTarget + 1));

            if (_currentTarget - 1 > 0)
                targets.Add(_targetList.ElementAt<DungeonCharacter>(_currentTarget - 1));

            return targets;
        }

        private bool CheckGCD()
        {
            _playerGCD = StatAlgorithms.ConvertAgilityToMiliseconds(Hero.GetInstance());
            if (_playerGCDTicker.ElapsedMilliseconds > _playerGCD)
                return true;
            return false;
        }

        private bool CheckResource(EnumAttacks chosenAttack)
        {
            if(Hero.GetInstance().DCStats.GetStat(StatsType.CurResources) < -chosenAttack.Cost)
                return false;
            return true;
        }

        private void DoAttack(int index)
        {
            _playerGCDTicker.Stop();
            EnumAttacks chosenAttack = _playersAttacks.ElementAt<EnumAttacks>(index);
            if (CheckResource(chosenAttack) && CheckGCD())
            {
                List<DungeonCharacter> targets = GetTargets();
                if (_currentTarget < _targetList.Count && _currentTarget >= 0)
                {
                    Hero.GetInstance().Attack(chosenAttack, new Target(targets));
                    _playerGCDTicker.Reset();
                }
            }
            _playerGCDTicker.Start();
        }

        private void btnAbility1_Click(object sender, RoutedEventArgs e)
        {
            DoAttack(0);
        }

        private void btnAbility2_Click(object sender, RoutedEventArgs e)
        {
            DoAttack(1);
        }

        private void btnAbility3_Click(object sender, RoutedEventArgs e)
        {
            DoAttack(2);
        }

        private void btnAbility4_Click(object sender, RoutedEventArgs e)
        {
            DoAttack(3);
        }

        #endregion

    }
}
