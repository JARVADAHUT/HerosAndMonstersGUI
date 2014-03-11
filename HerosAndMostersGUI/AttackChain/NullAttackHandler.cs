using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerosAndMostersGUI.AttackChain
{
    class NullAttackHandler:AttackHandler
    {
        public NullAttackHandler(AttackHandler nextLink) : base(nextLink)
        {
        }

        public override void HandleAttack(DesignPatterns___DC_Design.EnumAttacks attack, DesignPatterns___DC_Design.Target targets, DesignPatterns___DC_Design.DungeonCharacter attacker)
        {
        }
    }
}
