using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns___DC_Design;
using HerosAndMostersGUI.CharacterCode;

namespace HerosAndMostersGUI.AttackChain
{
    class IceConeAttackHandler:AttackHandler
    {
        public IceConeAttackHandler(AttackHandler nextLink) : base(nextLink)
        {
        }

        public override void HandleAttack(DesignPatterns___DC_Design.EnumAttacks attack, DesignPatterns___DC_Design.Target targets, DesignPatterns___DC_Design.DungeonCharacter attacker)
        {
            if (attack.Equals(EnumAttacks.IceCone))
            {
                int str = attacker.DCStats.GetStat(StatsType.Strength);
                int damage = _random.Next(5, str - (int)(str * 0.3));
                var cmd = new StatAugmentCommand();
                foreach (var target in targets)
                {
                    int appliedDamage = damage / ((int)(target.DCStats.GetStat(StatsType.Defense) * 0.1) + 1);//damage - _random.Next(target.DCStats.GetStat(StatsType.Defense) - 5, 5 + target.DCStats.GetStat(StatsType.Defense));
                    int agiMag = (int)(target.DCStats.GetStat(StatsType.Agility) * 0.7);

                    cmd.AddEffect(new EffectInformation(StatsType.CurHp, -appliedDamage), target);
                    cmd.AddEffect(new EffectInformation(StatsType.Agility, -agiMag, 0, 6), target);
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
