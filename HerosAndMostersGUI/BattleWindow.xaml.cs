using DesignPatterns___DC_Design;
using MazeTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HerosAndMostersGUI
{
    /// <summary>
    /// Interaction logic for BattleWindow.xaml
    /// </summary>
    public partial class BattleWindow : Window
    {
        private List<Rectangle> _targetList = new List<Rectangle>();
        private int _currentTarget;

        private SolidColorBrush STROKE_COLOR = Brushes.Blue;

        public BattleWindow(List<int> MonsterInformation)
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(HandleKey);

            playersRec.Fill = Player.GetInstance().GetColor();
            List<EnumAttacks> playersAttacks = Player.GetInstance().GetAttacks();

            btnAbility1.Content = playersAttacks.ElementAt<EnumAttacks>(0).Name;
            btnAbility2.Content = playersAttacks.ElementAt<EnumAttacks>(1).Name;
            btnAbility3.Content = playersAttacks.ElementAt<EnumAttacks>(2).Name;
            btnAbility4.Content = playersAttacks.ElementAt<EnumAttacks>(3).Name;

            ShowMonsters(MonsterInformation.Count);
            _targetList.Add(playersRec);
            TargetMonsters(MonsterInformation.Count);
            _currentTarget = 0;


        }

        private void TargetMonsters(int p)
        {
            switch (p)
            {
                case 1:
                    _targetList.Add(monster1Rec);
                    break;
                case 2:
                    _targetList.Add(monster1Rec);
                    _targetList.Add(monster2Rec);
                    break;
                case 3:
                    _targetList.Add(monster1Rec);
                    _targetList.Add(monster2Rec);
                    _targetList.Add(monster3Rec);
                    break;
                case 4:
                    _targetList.Add(monster4Rec);
                    _targetList.Add(monster1Rec);
                    _targetList.Add(monster2Rec);
                    _targetList.Add(monster3Rec);
                    break;
            }
        }

        private void HandleKey(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Up:
                    _targetList.ElementAt<Rectangle>(_currentTarget).Stroke = Brushes.Transparent;
                    _currentTarget = (_currentTarget - 1);
                    if (_currentTarget < 0)
                        _currentTarget = _targetList.Count - 1;
                    _targetList.ElementAt<Rectangle>(_currentTarget).Stroke = STROKE_COLOR;
                    break;

                case Key.Down:
                    _targetList.ElementAt<Rectangle>(_currentTarget).Stroke = Brushes.Transparent;
                    _currentTarget = (_currentTarget + 1) % _targetList.Count;
                    _targetList.ElementAt<Rectangle>(_currentTarget).Stroke = STROKE_COLOR;
                    break;

            }
        }

        private void ShowMonsters(int p)
        {
            if (p >= 2)
            {
                monster2Rec.Fill = Brushes.Tomato;
                pbMonster2Health.Visibility = Visibility.Visible;
            }
            if(p >= 3)
            {
                monster3Rec.Fill = Brushes.Tomato;
                pbMonster3Health.Visibility = Visibility.Visible;
            }
            if(p == 4)
            {
                monster4Rec.Fill = Brushes.Tomato;
                pbMonster4Health.Visibility = Visibility.Visible;
            }
        }
    }
}
