using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MazeTest
{
    public interface IInteractionType
    {
        void Interact(LivingCreature lc);
        string ToString();
        EnumMazeObject GetInteractionType();
        SolidColorBrush GetColor();
    }
}
