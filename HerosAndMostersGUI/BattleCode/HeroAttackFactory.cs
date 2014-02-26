using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns___DC_Design
{
    class HeroAttackFactory : AttackFactory
    {
        public HeroAttackFactory(DungeonCharacter registeredCharacter) : base(registeredCharacter)
        {
        }

        public override void Attack(AttackTypes atkType, Target targets)
        {
            throw new NotImplementedException();
        }
    }
}
