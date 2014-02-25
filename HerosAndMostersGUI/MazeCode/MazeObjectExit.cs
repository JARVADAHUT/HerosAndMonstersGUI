using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using DesignPatterns___DC_Design;

namespace MazeTest
{
    public class MazeObjectExit : IInteractionType
    {
        public MazeObjectExit()
        {
            
        }

        public void Interact(LivingCreature creature)
        {
            creature.Exit();
        }

        public override string ToString()
        {
            return "e";
        }

        public EnumMazeObject GetInteractionType()
        {
            return EnumMazeObject.Exit;
        }


        public SolidColorBrush GetColor()
        {
            return Brushes.Aqua;
        }
    }
}
