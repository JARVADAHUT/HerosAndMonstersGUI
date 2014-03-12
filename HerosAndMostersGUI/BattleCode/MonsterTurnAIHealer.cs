using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns___DC_Design;

namespace HerosAndMostersGUI.BattleCode
{
    class MonsterTurnAIHealer : IMonsterTurnAI
    {
        public void TakeTurn(Monster monster,Target targets)
        {
            var _rnd = new Random();
            if (_rnd.Next(100) < 70)
            {
                monster.Attack(EnumAttacks.LesserHeal, new Target(targets[_rnd.Next(targets.Count())]));
            }
            else
            {
                monster.Attack(EnumAttacks.WeakAttack,new Target(Hero.GetInstance()));
            }
        }
    }
}
