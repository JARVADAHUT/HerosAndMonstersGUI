﻿using System;
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
        private const int BaseDamage = 20;

        public StrongAttackHandler(AttackHandler nextLink) : base(nextLink)
        {
        }

        public override void HandleAttack(DesignPatterns___DC_Design.EnumAttacks attack, DesignPatterns___DC_Design.Target targets, DesignPatterns___DC_Design.DungeonCharacter attacker)
        {
            if (attack.Name.Equals("Strong Attack"))
            {
                Hero hero = Hero.GetInstance();

                // calculate raw damage
                // Strength Weight -> Each Str point = .8% - 1.2% damage increase of BaseDamage. FOR EXAMPLE: 100 Raw Str = 180%-220% * BaseDamage, OR 38-42 damage.
                int damage = _random.Next(BaseDamage * (1 + (StatAlgorithms.GetPercentStrength(hero, 0.8) / 100)), BaseDamage * (1 + (StatAlgorithms.GetPercentStrength(hero, 1.2) / 100)));
                var cmd = new StatAugmentCommand();

                // Apply defense reduction
                int appliedDamage = StatAlgorithms.ApplyDefence(damage, targets.ElementAt(DEFAULT_INDEX));
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
