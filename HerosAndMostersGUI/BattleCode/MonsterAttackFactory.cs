using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns___DC_Design
{
    class MonsterAttackFactory : AttackFactory
    {
        private static Random _random = new Random();

        public MonsterAttackFactory(Stats stats) : base(stats)
        {
        }

        public override void Attack(AttackTypes atkType, Target targets)
        {
            foreach (var target in targets)
            {
                var targetStats = target.DCStats;
                switch (atkType)
                {
                    case AttackTypes.Strong:
                        BuildStrong(targetStats);
                        break;
                    case AttackTypes.Weak:
                        BuildWeak(targetStats);
                        break;
                    case AttackTypes.Defend:
                        BuildDefend(targetStats);
                        break;
                    case AttackTypes.Heal:
                        BuildHeal(targetStats);
                        break;
                    default:
                        break;
                }
            }
            
        }

        private void BuildStrong(Stats targetStats)
        {
            int damage = _random.Next(25 + base.Stats.GetStat(StatsType.Strength));
            int appliedDamage = damage - _random.Next(5 + targetStats.GetStat(StatsType.Defense));

            new StatAugmentCommand(StatsType.CurHp, targetStats, appliedDamage).RegisterCommand();
            new StatAugmentCommand(StatsType.Agility, base.Stats, 10, 0, 15).RegisterCommand();
        }

        private void BuildWeak(Stats targetStats)
        {
            int damage = _random.Next(15 + base.Stats.GetStat(StatsType.Strength));
            int appliedDamage = damage - _random.Next(5 + targetStats.GetStat(StatsType.Defense));

            new StatAugmentCommand(StatsType.CurHp, targetStats, appliedDamage).RegisterCommand();
        }

        private void BuildDefend(Stats targetStats)
        {
            
        }

        private void BuildHeal(Stats targetStats)
        {
            
        }
    }
}
