using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns___DC_Design
{
    public abstract class AttackFactory
    {
        protected DungeonCharacter RegisteredDC { get; set; }

        protected AttackFactory(DungeonCharacter dc)
        {
            RegisteredDC = dc;
        }

        public abstract void Attack(AttackTypes atkType, Target targets);
    }
}
