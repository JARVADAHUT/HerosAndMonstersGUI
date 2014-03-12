using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns___DC_Design;

namespace HerosAndMostersGUI.BattleCode
{
    public class MonsterTurnAIAgressive : IMonsterTurnAI
    {
        public void TakeTurn(Monster monster,Target targets)
        {
            monster.Attack(new Random().Next(100) < 30 ? EnumAttacks.WeakAttack : EnumAttacks.StrongAttack,
                new Target(Hero.GetInstance()));
        }
    }
}
