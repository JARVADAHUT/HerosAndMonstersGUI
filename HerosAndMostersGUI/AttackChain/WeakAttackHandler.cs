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
    class WeakAttackHandler : AttackHandler
    {

        private const int BaseDamage = 10;
        private const double LowPercent = .5;
        private const double HighPercent = .7;

        public WeakAttackHandler(AttackHandler nextLink) : base(nextLink)
        {
        }

        public override void HandleAttack(EnumAttacks attack, Target targets, DungeonCharacter attacker)
        {
            if (attack.Equals(EnumAttacks.WeakAttack))
            {
                int str = (attacker.DCStats.GetStat(StatsType.Strength));

                int damage = _random.Next((int)(BaseDamage * StatAlgorithms.GetPercentStrength(str, LowPercent)), (int)(BaseDamage * StatAlgorithms.GetPercentStrength(str, HighPercent)));

                var cmd = new StatAugmentCommand();

                int appliedDamage = StatAlgorithms.ApplyDefence(damage, targets.ElementAt(DEFAULT_INDEX));
                cmd.AddEffect(new EffectInformation(StatsType.CurHp, -appliedDamage), targets.ElementAt(DEFAULT_INDEX));

                cmd.AddEffect(new EffectInformation(StatsType.CurResources, attack.Cost + (int)(.1275 * attacker.DCStats.GetStat(StatsType.Intelegence))), attacker);
                cmd.RegisterCommand();
            }
            else
            {
                NextLink.HandleAttack(attack,targets,attacker);
            }
        }
    }
}
