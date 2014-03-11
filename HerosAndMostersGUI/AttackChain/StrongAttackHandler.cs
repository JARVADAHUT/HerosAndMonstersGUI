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
    class StrongAttackHandler : AttackHandler
    {
        public StrongAttackHandler(AttackHandler nextLink) : base(nextLink)
        {
        }

        public override void HandleAttack(DesignPatterns___DC_Design.EnumAttacks attack, DesignPatterns___DC_Design.Target targets, DesignPatterns___DC_Design.DungeonCharacter attacker)
        {
            if (attack.Name.Equals("Strong Attack"))
            {
                int str = StatAlgorithms.ScaleStrength(attacker);


                int damage = _random.Next(str + 5, 25 + str);
                var cmd = new StatAugmentCommand();

                int appliedDamage = ApplyDefence(damage, targets.ElementAt(DEFAULT_INDEX));
                cmd.AddEffect(new EffectInformation(StatsType.CurHp, -appliedDamage), targets.ElementAt(DEFAULT_INDEX));

                cmd.AddEffect(ModifyStatBy(StatsType.Agility, attacker, 0.1, 15), attacker);
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
