using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns___DC_Design;
using HerosAndMostersGUI.CharacterCode;

namespace HerosAndMostersGUI.AttackChain
{
    class WeakAttackHandler : AttackHandler
    {
        public WeakAttackHandler(AttackHandler nextLink) : base(nextLink)
        {
        }

        public override void HandleAttack(EnumAttacks attack, Target targets, DungeonCharacter attacker)
        {
            if (attack.Name.Equals("Weak Attack"))
            {
                int mainTargetIndex = 0;
                int damage = _random.Next(5, 6 + attacker.DCStats.GetStat(StatsType.Strength));
                var cmd = new StatAugmentCommand();

                int appliedDamage = damage/
                                    ((int) (targets.ElementAt(mainTargetIndex).DCStats.GetStat(StatsType.Defense)*0.1) +
                                     1); // damage - _random.Next(5 + target.DCStats.GetStat(StatsType.Defense));
                cmd.AddEffect(new EffectInformation(StatsType.CurHp, -appliedDamage), targets.ElementAt(mainTargetIndex));

                cmd.AddEffect(new EffectInformation(StatsType.CurResources, attack.Cost), attacker);
                cmd.RegisterCommand();
            }
            else
            {
                NextLink.HandleAttack(attack,targets,attacker);
            }
        }
    }
}
