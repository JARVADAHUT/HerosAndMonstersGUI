using DesignPatterns___DC_Design;
using HerosAndMostersGUI.BattleCode;
using HerosAndMostersGUI.CharacterCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerosAndMostersGUI.AttackChain
{
    class HyperbeamHandler : AttackHandler
    {

        private const int BaseDamage = 10;
        private const double LowPercent = .5;
        private const double HighPercent = .7;

        public HyperbeamHandler(AttackHandler nextLink) : base(nextLink)
        {
        }

        public override void HandleAttack(DesignPatterns___DC_Design.EnumAttacks attack, DesignPatterns___DC_Design.Target targets, DesignPatterns___DC_Design.DungeonCharacter attacker)
        {
            if (attack.Equals(EnumAttacks.HyperBeam))
            {
                int str = (attacker.DCStats.GetStat(StatsType.Strength));
                // calculate raw damage
                // Strength Weight -> Each Str point = .8% - 1.2% damage increase of BaseDamage. FOR EXAMPLE: 100 Raw Str = 180%-220% * BaseDamage, OR 38-42 damage.
                int damage = _random.Next((int)(BaseDamage * StatAlgorithms.GetPercentStrength(str, LowPercent)), (int)(BaseDamage * StatAlgorithms.GetPercentStrength(str, HighPercent)));

                var cmd = new StatAugmentCommand();

                // Apply defense reduction
                int appliedDamage = StatAlgorithms.ApplyDefence(damage, targets.ElementAt(DEFAULT_INDEX));
                cmd.AddEffect(new EffectInformation(StatsType.CurHp, -appliedDamage), targets.ElementAt(DEFAULT_INDEX));

                cmd.AddEffect(ModifyStatBy(StatsType.Agility, attacker, 0.1, 15), attacker);
                cmd.AddEffect(new EffectInformation(StatsType.CurResources, attack.Cost), attacker);

                // reduce target combat effectivness (lower str, agi, def by 15%)
                cmd.AddEffect(ModifyStatBy(StatsType.Strength, targets.ElementAt(DEFAULT_INDEX), -.15, 4), targets.ElementAt(DEFAULT_INDEX));
                cmd.AddEffect(ModifyStatBy(StatsType.Agility, targets.ElementAt(DEFAULT_INDEX), -.15, 4), targets.ElementAt(DEFAULT_INDEX));
                cmd.AddEffect(ModifyStatBy(StatsType.Defense, targets.ElementAt(DEFAULT_INDEX), -.15, 4), targets.ElementAt(DEFAULT_INDEX));

                cmd.RegisterCommand();
            }
            else
            {
                NextLink.HandleAttack(attack, targets, attacker);
            }
        }
    }
}
