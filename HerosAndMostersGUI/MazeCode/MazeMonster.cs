using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Documents;
using DesignPatterns___DC_Design;
using HerosAndMostersGUI;

namespace MazeTest
{
    public class MazeMonster : LivingCreature
    {

        #region Attributes

        private const int MaxWeight = 60;
        private const int MaxPartySize = 4;
        private const int LevelVariance = 3;

        public int ID { set; get; }
        public SolidColorBrush Color { set; get; }

        //list of int to represent how many monsters how difficult
        private List<int> _monsterParty;
        private List<int> _moveWeight;

        #endregion

        public MazeMonster() : base()
        {
            HiveMind.GetInstance().RegisterSubject(this);

            //4 movement directions
            _moveWeight = new List<int>(4);
            for (int x = 0; x < 4; x++)
                _moveWeight.Add(10);

            SetInteraction(this);

            _monsterParty = new List<int>();
            _monsterParty.Add( GetMonsterLevel() );
            Color = Brushes.Tomato;

            if (Maze.GetInstance().MazeLevel > 5) // After level 5, possibly spawn groups of monsters (size 2)
            {
                Random rnd = new Random();
                int num = rnd.Next(4);
                if (num == 0)
                {
                    _monsterParty.Add(GetMonsterLevel());
                    Color = Brushes.DeepPink;
                }

            }

        }

        public override void Die()
        {
            _monsterParty.Clear();
            HiveMind.GetInstance().UnregisterSubject(this);
            Dead = true;
            SetInteraction( FMazeObjectFactory.GetMazeObject(EnumMazeObject.Air) );
        }

        public void AddMonsters(List<int> newMonsters)
        {
            foreach (int m in newMonsters)
                _monsterParty.Add(m);

            if (_monsterParty.Count < 4)
                Color = Brushes.DeepPink;
            else
                Color = Brushes.Red;
        }

        public int PartySize()
        {
            return _monsterParty.Count;
        }

        public List<int> GetParty()
        {
            return _monsterParty;
        }

        public override void Hook()
        {
            if (_moveWeight[(int)(this.GetLastMove())] == MaxWeight)
                _moveWeight[(int)(this.GetLastMove())] = 10;
            else
                _moveWeight[(int)(this.GetLastMove())] = (_moveWeight[(int)(this.GetLastMove())]) + 10;
        }

        public List<int> GetMoveWeight()
        {
            return _moveWeight;
        }

        public bool Equals(MazeMonster otherMonster)
        {
            return ID == otherMonster.ID;
        }

        #region Private 

        private int GetMonsterLevel()
        {
            Random rnd = new Random();
            int level = Maze.GetInstance().MazeLevel + rnd.Next(-LevelVariance, LevelVariance + 1);

            if (level < 0)
                level = 0;

            return level;
        }

        #endregion

        #region IInteractionType

        public override void Interact(LivingCreature creature)
        {
            if (!Dead)
            {

                if (creature.GetInteractionType() == EnumMazeObject.Monster)
                {
                    MazeMonster killer = (MazeMonster)creature;

                    if (killer.PartySize() + this.PartySize() <= MaxPartySize)
                    {
                        killer.AddMonsters(_monsterParty);
                        killer.TakeLoot(_creatureInventory.GetItems());
                        this.Die();
                    }
                }

                else
                {
                    //enter battle arena
                    BattleWindow theBattle = new BattleWindow(_monsterParty);

                    MainWindow.PauseHive();
                    theBattle.ShowDialog();

                    if (creature.Dead)
                    {
                        Restart();
                    }

                    MainWindow.StartHive();
                    //exit BA

                    creature.TakeLoot(_creatureInventory.GetItems());
                    this.Die();
                }

            }
        }

        

        public override SolidColorBrush GetColor()
        {
            return Color;
        }

        public override string ToString()
        {
            return "m";
        }

        public override EnumMazeObject GetInteractionType()
        {
            return EnumMazeObject.Monster;
        }

        #endregion

    }
}
