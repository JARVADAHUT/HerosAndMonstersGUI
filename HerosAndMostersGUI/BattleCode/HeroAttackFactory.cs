﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns___DC_Design
{
    class HeroAttackFactory : AttackFactory
    {
        public HeroAttackFactory(Stats stats) : base(stats)
        {
        }

        public override void Attack(AttackTypes atkType, Target targets)
        {
            throw new NotImplementedException();
        }
    }
}
