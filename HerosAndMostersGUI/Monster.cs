using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Documents;
using HerosAndMostersGUI;

namespace MazeTest
{
    public class Monster : LivingCreature
    {
        private const int _maxWeight = 60;
        private const int _maxPartySize = 4;


        public int ID { set; get; }
        public SolidColorBrush Color { set; get; }

        private List<int> _moveWeight;

        //list of int to represent how many monsters how difficult
        private List<IMonsterType> _monsterParty;
        private int _monsterLevel;

        public Monster() : base()
        {
            HiveMind.GetInstance().RegisterSubject(this);

            //4 movement directions
            _moveWeight = new List<int>(4);
            for (int x = 0; x < 4; x++)
                _moveWeight.Add(10);

            SetInteraction(this);

            _monsterParty = new List<IMonsterType>();
            _monsterParty.Add( FMonsterFactory.GetMonster() );

            Color = Brushes.Tomato;
        }

        public override void Die()
        {
            _monsterParty.Clear();
            HiveMind.GetInstance().UnregisterSubject(this);
            SetInteraction( FMazeObjectFactory.GetMazeObject(EnumMazeObject.Air) );
        }

        public override void Exit()
        {
            // do nothing you're a monster
        }

        public override EnumMazeObject GetInteractionType()
        {
            return EnumMazeObject.Monster;
        }

        public void AddMonsters(List<IMonsterType> newMonsters)
        {
            foreach(IMonsterType m in newMonsters)
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

        public override void Interact(LivingCreature creature)
        {
            if (creature.GetInteractionType() == EnumMazeObject.Monster)
            {
                Monster killer = (Monster)creature;

                if (killer.PartySize() + this.PartySize() <= _maxPartySize)
                {
                    killer.AddMonsters(_monsterParty);

                    killer.GiveGear(_creatureInventory.GearContained.GetContents());
                    killer.GiveConsumables(_creatureInventory.ConsumablesContained.GetContents());

                    this.Die();
                }
            }

            else
            {
                //enter battle arena

                //exit BA
                creature.GiveGear(_creatureInventory.GearContained.GetContents());
                creature.GiveConsumables(_creatureInventory.ConsumablesContained.GetContents());
                this.Die();
            }
            
            
            // do nothing
        }

        public override string ToString()
        {
            return "m";
        }

        public override void Hook()
        {
            if (_moveWeight[(int)(this.GetLastMove())] == _maxWeight)
                _moveWeight[(int)(this.GetLastMove())] = 10;
            else
                _moveWeight[(int)(this.GetLastMove())] = (_moveWeight[(int)(this.GetLastMove())]) + 10;
        }

        public List<int> GetMoveWeight()
        {
            return _moveWeight;
        }

        public bool Equals(Monster otherMonster)
        {
            return ID == otherMonster.ID;
        }

        public override SolidColorBrush GetColor()
        {
            return Color;
        }
    }
}
