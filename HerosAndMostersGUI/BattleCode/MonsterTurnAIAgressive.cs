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
        public void TakeTurn(Monster monster)
        {

            if (new Random().Next(100) < 70)
            {
                monster.Attack(AttackTypes.Weak, new Target(Hero.GetInstance()));
            }
            else
            {
                monster.Attack(AttackTypes.Strong, new Target(Hero.GetInstance()));
            }
        }
    }
}
