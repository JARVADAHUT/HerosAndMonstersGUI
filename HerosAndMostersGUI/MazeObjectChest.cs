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

        public MazeObjectChest()
        {
            _myColor = Brushes.Gold;
        }

        public override string ToString()
        {
            return "c";
        }

        public void Interact(LivingCreature creature)
        {
            _myColor = Brushes.BurlyWood;
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
