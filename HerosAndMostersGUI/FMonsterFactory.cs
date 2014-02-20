using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerosAndMostersGUI
{
    static class FMonsterFactory
    {
        public static IMonsterType GetMonster()
        {
            return new MonsterEasy();
        }
    }
}
