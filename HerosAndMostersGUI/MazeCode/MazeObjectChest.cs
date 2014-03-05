using DesignPatterns___DC_Design;
using HerosAndMostersGUI;
using HerosAndMostersGUI.MazeCode;
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
        private bool _looted;

        public MazeObjectChest()
        {
            _myColor = Brushes.Gold;
            _loot = new Inventory(); // <------------------ NEWLY ADDED
            _looted = false;
            //_loot.GearContained.Add(FGearFactory.GetGear());

            _loot.AddItemList( FItemGenerator.Generate() );


        }

        public override string ToString()
        {
            return "c";
        }

        public void Interact(LivingCreature creature)
        {
            if (!_looted)
            {
                _myColor = Brushes.BurlyWood;
                creature.TakeLoot( _loot.GetItems() ); // <------------- NEWLY ADDED
                _looted = true;
            }
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
