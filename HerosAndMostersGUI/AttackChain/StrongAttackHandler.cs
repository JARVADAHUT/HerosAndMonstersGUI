using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns___DC_Design;
using HerosAndMostersGUI.CharacterCode;

namespace HerosAndMostersGUI.AttackChain
{
    class StrongAttackHandler : AttackHandler
    {
        public StrongAttackHandler(AttackHandler nextLink) : base(nextLink)
        {
        }

        public override void HandleAttack(DesignPatterns___DC_Design.EnumAttacks attack, DesignPatterns___DC_Design.Target targets, DesignPatterns___DC_Design.DungeonCharacter attacker)
        {
            if (attack.Name.Equals("Strong Attack"))
            {
                int mainTargetIndex = 0;
                int str = attacker.DCStats.GetStat(StatsType.Strength);
                int damage = _random.Next(str - 15, 25 + str);
                var cmd = new StatAugmentCommand();

                int appliedDamage = damage / ((int)(targets.ElementAt(mainTargetIndex).DCStats.GetStat(StatsType.Defense) * 0.1) + 1);//damage - _random.Next(target.DCStats.GetStat(StatsType.Defense) - 5, 5 + target.DCStats.GetStat(StatsType.Defense));
                cmd.AddEffect(new EffectInformation(StatsType.CurHp, -appliedDamage), targets.ElementAt(mainTargetIndex));

                cmd.AddEffect(new EffectInformation(StatsType.Agility, 10, 0, 15), attacker);
                cmd.AddEffect(new EffectInformation(StatsType.CurResources, -5), attacker);
                cmd.RegisterCommand();
            }
            else
            {
                NextLink.HandleAttack(attack, targets, attacker);
            }
        }
    }
}
