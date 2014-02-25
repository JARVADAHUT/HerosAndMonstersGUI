using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns___DC_Design
{
    public class Monster : DungeonCharacter
    {
        private IMonsterTurnAI monsterAI;

        public Monster(string name, Stats stats, AttackFactory factory, IMonsterTurnAI monsterAi) : base(name, stats, factory)
        {
            monsterAI = monsterAi;
            IsDead = false;
        }

        public bool IsDead { get; set; }

        /*public override void useAction(int ActionNumber)
        {
            throw new NotImplementedException();
        }
        */
        public void TakeTurn()
        {
            monsterAI.TakeTurn(this);
        }
    }
}
