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
    class DemoralizingShoutAttack : AttackHandler
    {

        private const double PercentReduction = .15;

        public DemoralizingShoutAttack(AttackHandler nextLink) : base(nextLink)
        {
        }

        public override void HandleAttack(DesignPatterns___DC_Design.EnumAttacks attack, DesignPatterns___DC_Design.Target targets, DesignPatterns___DC_Design.DungeonCharacter attacker)
        {
            if (attack.Equals(EnumAttacks.DemoralizingShout))
            {
                int str = (attacker.DCStats.GetStat(StatsType.Strength));

                var cmd = new StatAugmentCommand();

                cmd.AddEffect(new EffectInformation(StatsType.CurResources, attack.Cost + (int)(.1275 * attacker.DCStats.GetStat(StatsType.Intelegence))), attacker);

                double reduction = StatAlgorithms.ApplyStrengthToStatReduction(PercentReduction, str);

                foreach (var target in targets)
                {
                    // reduce target combat effectivness (lower str, agi, def by 15% + percent based off str)
                    cmd.AddEffect(StatAlgorithms.ModifyStatBy(StatsType.Strength, target, reduction, 5), target); //targets.ElementAt(DEFAULT_INDEX)
                    cmd.AddEffect(StatAlgorithms.ModifyStatBy(StatsType.Agility, target, reduction, 5), target);
                    cmd.AddEffect(StatAlgorithms.ModifyStatBy(StatsType.Defense, target, reduction, 5), target);
                }

                cmd.RegisterCommand();
            }
            else
            {
                NextLink.HandleAttack(attack, targets, attacker);
            }
        }

    }
}
