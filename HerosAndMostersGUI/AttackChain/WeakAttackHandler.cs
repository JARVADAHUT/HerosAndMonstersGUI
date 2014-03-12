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
        public WeakAttackHandler(AttackHandler nextLink) : base(nextLink)
        {
        }

        public override void HandleAttack(EnumAttacks attack, Target targets, DungeonCharacter attacker)
        {
            if (attack.Name.Equals("Weak Attack"))
            {
                int str = (int)StatAlgorithms.GetPercentStrength(attacker.DCStats.GetStat(StatsType.Strength), 1);

                int damage = _random.Next(5, 6 + str);

                var cmd = new StatAugmentCommand();

                int appliedDamage = StatAlgorithms.ApplyDefence(damage, targets.ElementAt(DEFAULT_INDEX));
                cmd.AddEffect(new EffectInformation(StatsType.CurHp, -appliedDamage), targets.ElementAt(DEFAULT_INDEX));

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
