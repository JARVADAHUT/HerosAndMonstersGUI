using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns___DC_Design
{
    abstract class AttackFactory
    {
        protected Stats Stats { get; set; }

        protected AttackFactory(Stats stats)
        {
            Stats = stats;
        }

        public abstract void Attack(AttackTypes atkType, Target targets);
    }
}
