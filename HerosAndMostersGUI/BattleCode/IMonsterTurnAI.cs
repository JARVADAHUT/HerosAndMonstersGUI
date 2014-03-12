using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns___DC_Design
{
    public interface IMonsterTurnAI
    {
        void TakeTurn(Monster monster,Target targets);
    }
}
