using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns___DC_Design;
using HerosAndMostersGUI.CharacterCode;

namespace HerosAndMostersGUI.AttackChain
{
    class LesserHealAttackHandler:AttackHandler
    {
        public LesserHealAttackHandler(AttackHandler nextLink) : base(nextLink)
        {
        }

        public override void HandleAttack(DesignPatterns___DC_Design.EnumAttacks attack, DesignPatterns___DC_Design.Target targets, DesignPatterns___DC_Design.DungeonCharacter attacker)
        {
            if (attack.Equals(EnumAttacks.LesserHeal))
            {
                int mainTargetIndex = 0;
                int heal = _random.Next(5, 10 + attacker.DCStats.GetStat(StatsType.Strength));
                var cmd = new StatAugmentCommand();

                cmd.AddEffect(new EffectInformation(StatsType.CurHp, heal), targets.ElementAt(mainTargetIndex));

                int magnitude = (int)(attacker.DCStats.GetStat(StatsType.Defense) * 0.1);
                cmd.AddEffect(new EffectInformation(StatsType.Defense, magnitude, 0, 6), attacker);
                cmd.AddEffect(new EffectInformation(StatsType.CurResources, attack.Cost), attacker);
                cmd.RegisterCommand();
            }
        }
    }
}
