using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using HerosAndMostersGUI.CharacterCode;

namespace DesignPatterns___DC_Design
{
    class MonsterAttackFactory : AttackFactory
    {
        private static Random _random = new Random();

        public MonsterAttackFactory(DungeonCharacter dc) : base(dc)
        {
        }

        public override void Attack(AttackTypes atkType, Target targets)
        {
            switch (atkType)
            {
                case AttackTypes.Strong:
                    BuildStrong(targets);
                    break;
                case AttackTypes.Weak:
                    BuildWeak(targets);
                    break;
                case AttackTypes.Defend:
                    BuildDefend(targets);
                    break;
                case AttackTypes.Heal:
                    BuildHeal(targets);
                    break;
                default:
                    break;
            }
        }

        private void BuildStrong(Target targets)
        {
            int damage = _random.Next(25 + base.RegisteredDC.DCStats.GetStat(StatsType.Strength));
            var cmd = new StatAugmentCommand();
            foreach (var target in targets)
            {
                int appliedDamage = damage - _random.Next(5 + target.DCStats.GetStat(StatsType.Defense));
                cmd.AddEffect(new EffectInformation(StatsType.CurHp, appliedDamage), target);
            }
            cmd.AddEffect(new EffectInformation(StatsType.Agility, 10,0,15), base.RegisteredDC);
            cmd.AddEffect(new EffectInformation(StatsType.CurResources,-5), base.RegisteredDC);
            cmd.RegisterCommand();
        }

        private void BuildWeak(Target targets)
        {
            int damage = _random.Next(15 + base.RegisteredDC.DCStats.GetStat(StatsType.Strength));
            var cmd = new StatAugmentCommand();
            foreach (var target in targets)
            {
                int appliedDamage = damage - _random.Next(5 + target.DCStats.GetStat(StatsType.Defense));
                cmd.AddEffect(new EffectInformation(StatsType.CurHp, appliedDamage), target);
            }
            cmd.AddEffect(new EffectInformation(StatsType.CurResources, 5), base.RegisteredDC);
            cmd.RegisterCommand();
        }

        private void BuildDefend(Target targets)
        {
            
        }

        private void BuildHeal(Target targets)
        {
            
        }
    }
}
