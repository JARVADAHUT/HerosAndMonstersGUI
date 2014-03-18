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
    class LifeTapAttack : AttackHandler
    {

        public LifeTapAttack(AttackHandler nextLink) : base(nextLink)
        {
        }

        public override void HandleAttack(DesignPatterns___DC_Design.EnumAttacks attack, DesignPatterns___DC_Design.Target targets, DesignPatterns___DC_Design.DungeonCharacter attacker)
        {
            if (attack.Equals(EnumAttacks.LifeTap))
            {
                int manaIncrease = attacker.DCStats.GetStat(StatsType.CurHp);
                int healthSacrifice = -1 * (manaIncrease / 2);
                StatAugmentCommand cmd = new StatAugmentCommand();

                cmd.AddEffect(new EffectInformation(StatsType.CurHp, healthSacrifice), attacker);

                cmd.AddEffect(StatAlgorithms.ModifyStatBy(StatsType.Defense, targets.ElementAt(DEFAULT_INDEX), .9, 6), attacker);
                cmd.AddEffect(new EffectInformation(StatsType.CurResources, manaIncrease), attacker);
                cmd.RegisterCommand();
            }
            else
            {
                NextLink.HandleAttack(attack, targets, attacker);
            }
        }

    }
}
