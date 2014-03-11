using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns___DC_Design;
using HerosAndMostersGUI.CharacterCode;

namespace HerosAndMostersGUI.AttackChain
{
    class LightningBoltAttackHandler:AttackHandler
    {
        public LightningBoltAttackHandler(AttackHandler nextLink) : base(nextLink)
        {
        }

        public override void HandleAttack(DesignPatterns___DC_Design.EnumAttacks attack, DesignPatterns___DC_Design.Target targets, DesignPatterns___DC_Design.DungeonCharacter attacker)
        {
            if (attack.Equals(EnumAttacks.LightningBolt))
            {
                int mainTargetIndex = 0;
                int damage = _random.Next(attacker.DCStats.GetStat(StatsType.Strength), 35 + attacker.DCStats.GetStat(StatsType.Strength));
                var cmd = new StatAugmentCommand();

                int appliedDamage = damage / ((int)(targets.ElementAt(mainTargetIndex).DCStats.GetStat(StatsType.Defense) * 0.1) + 1);//damage - _random.Next(target.DCStats.GetStat(StatsType.Defense) - 5, 5 + target.DCStats.GetStat(StatsType.Defense));
                int agiMag = (int)(targets.ElementAt(mainTargetIndex).DCStats.GetStat(StatsType.Agility) * 0.5);

                cmd.AddEffect(new EffectInformation(StatsType.CurHp, -appliedDamage), targets.ElementAt(mainTargetIndex));
                cmd.AddEffect(new EffectInformation(StatsType.Agility, agiMag, 0, 6), targets.ElementAt(mainTargetIndex));

                cmd.AddEffect(new EffectInformation(StatsType.CurResources, attack.Cost), attacker);
                cmd.RegisterCommand();
            }
            else
            {
                NextLink.HandleAttack(attack, targets, attacker);
            }
        }
    }
}
