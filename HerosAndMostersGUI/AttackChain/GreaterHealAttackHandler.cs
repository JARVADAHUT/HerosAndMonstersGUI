﻿using DesignPatterns___DC_Design;
using HerosAndMostersGUI.BattleCode;
using HerosAndMostersGUI.CharacterCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Greater heal heals for a large amount and increases the characters agility for a short period of time, but is very mana inneficient. 

namespace HerosAndMostersGUI.AttackChain
{
    class GreaterHealAttackHandler : AttackHandler
    {

        private const int BaseHeal = 35;
        private const double LowPercent = .8;
        private const double HighPercent = 1;

        public GreaterHealAttackHandler(AttackHandler nextLink) : base(nextLink)
        {
        }

        public override void HandleAttack(DesignPatterns___DC_Design.EnumAttacks attack, DesignPatterns___DC_Design.Target targets, DesignPatterns___DC_Design.DungeonCharacter attacker)
        {
            if (attack.Equals(EnumAttacks.GreaterHeal))
            {
                int str = (attacker.DCStats.GetStat(StatsType.Strength));
                int heal = _random.Next(BaseHeal * (int)(StatAlgorithms.GetPercentStrength(str, LowPercent)), (int)(BaseHeal * StatAlgorithms.GetPercentStrength(str, HighPercent)));
                StatAugmentCommand cmd = new StatAugmentCommand();

                cmd.AddEffect(new EffectInformation(StatsType.CurHp, heal), targets.ElementAt(DEFAULT_INDEX));

                cmd.AddEffect(StatAlgorithms.ModifyStatBy(StatsType.Agility, targets.ElementAt(DEFAULT_INDEX), .2, 4), attacker);
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
