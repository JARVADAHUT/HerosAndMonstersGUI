using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns___DC_Design;
using HerosAndMostersGUI.CharacterCode;
using HerosAndMostersGUI.BattleCode;

namespace HerosAndMostersGUI.AttackChain
{
    class LightningBoltAttackHandler:AttackHandler
    {

        private const int BaseDamage = 10;
        //private const double LowPercent = .8;
        private const double HighPercent = 2.5;

        public LightningBoltAttackHandler(AttackHandler nextLink) : base(nextLink)
        {
        }

        public override void HandleAttack(DesignPatterns___DC_Design.EnumAttacks attack, DesignPatterns___DC_Design.Target targets, DesignPatterns___DC_Design.DungeonCharacter attacker)
        {
            if (attack.Equals(EnumAttacks.LightningBolt))
            {
                int str = (attacker.DCStats.GetStat(StatsType.Strength));

                int damage = _random.Next(BaseDamage, (int)(BaseDamage * StatAlgorithms.GetPercentStrength(str, HighPercent)));
                var cmd = new StatAugmentCommand();

                int appliedDamage = StatAlgorithms.ApplyDefence(damage, targets.ElementAt(DEFAULT_INDEX)); 

                cmd.AddEffect(new EffectInformation(StatsType.CurHp, -appliedDamage), targets.ElementAt(DEFAULT_INDEX));
                cmd.AddEffect(ModifyStatBy(StatsType.Agility, targets.ElementAt(DEFAULT_INDEX), 1.5, 5), targets.ElementAt(DEFAULT_INDEX));

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
