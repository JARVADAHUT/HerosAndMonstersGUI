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
        public Stats Stats { private set; get; }
        public bool IsDead { get; set; }

        public Monster(string name, Stats stats, IMonsterTurnAI monsterAi) : base(name, stats)
        {
            monsterAI = monsterAi;
            Stats = stats;
            IsDead = false;
        }

        public void TakeTurn()
        {
            monsterAI.TakeTurn(this);
        }

        public override void Attack(AttackTypes type, Target target)
        {
            base.AttackFactory.Attack(type,target);
        }
    }
}
