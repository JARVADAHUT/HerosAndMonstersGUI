using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTest
{
    public interface IMazeDisplay
    {
        void Display(MazeObject maze);
        void Refresh(LivingCreature changed);
    }
}
