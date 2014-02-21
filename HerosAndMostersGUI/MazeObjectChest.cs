using HerosAndMostersGUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MazeTest
{
    public class MazeObjectChest : IInteractionType
    {
        private SolidColorBrush _myColor;
        private Inventory _loot;

        public MazeObjectChest()
        {
            _myColor = Brushes.Gold;
            _loot = new Inventory();

            _loot.GearContained.Add(FGearFactory.GetGear());
        }

        public override string ToString()
        {
            return "c";
        }

        public void Interact(LivingCreature creature)
        {
            _myColor = Brushes.BurlyWood;
            creature.GiveGear(_loot.GearContained.GetContents());
        }

        public EnumMazeObject GetInteractionType()
        {
            return EnumMazeObject.Chest;
        }


        public SolidColorBrush GetColor()
        {
            return _myColor;
        }
    }
}
