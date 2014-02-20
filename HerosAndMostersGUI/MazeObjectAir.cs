using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
namespace MazeTest
{
    public class MazeObjectAir : IInteractionType
    {
        public MazeObjectAir()
        {

        }

        public void Interact(LivingCreature creature)
        {
            creature.Move();
        }

        public override string ToString()
        {
            return " ";
        }

        public EnumMazeObject GetInteractionType()
        {
            return EnumMazeObject.Air;
        }


        public SolidColorBrush GetColor()
        {
            return Brushes.White;
        }
    }
}
