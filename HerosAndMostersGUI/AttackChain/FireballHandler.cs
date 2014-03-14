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
    class FireballHandler : AttackHandler
    {

        private const int BaseDamage = 10;
        private const double LowPercent = 1;
        private const double HighPercent = 1.2;

        public FireballHandler(AttackHandler nextLink) : base(nextLink)
        {
        }

        public override void HandleAttack(DesignPatterns___DC_Design.EnumAttacks attack, DesignPatterns___DC_Design.Target targets, DesignPatterns___DC_Design.DungeonCharacter attacker)
        {
            if (attack.Equals(EnumAttacks.Fireball))
            {
                int str = (attacker.DCStats.GetStat(StatsType.Strength));
                var damage = _random.Next((int)(BaseDamage * StatAlgorithms.GetPercentStrength(str, LowPercent)), (int)(BaseDamage * StatAlgorithms.GetPercentStrength(str, HighPercent)));

                var cmd = new StatAugmentCommand();
                foreach (var target in targets)
                {
                    int appliedDamage = StatAlgorithms.ApplyDefence(damage, target);

                    cmd.AddEffect(new EffectInformation(StatsType.CurHp, -appliedDamage), target);
                }
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
