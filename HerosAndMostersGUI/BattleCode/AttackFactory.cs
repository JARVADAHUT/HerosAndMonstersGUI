using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HerosAndMostersGUI.CharacterCode;

namespace DesignPatterns___DC_Design
{
    public class AttackFactory
    {
        public DungeonCharacter RegisteredDC { private set; get; }
        private static Random _random = new Random();

        public AttackFactory(DungeonCharacter dc)
        {
            RegisteredDC = dc;
        }

        public void Attack(EnumAttacks atkType, Target targets)
        {
            var value = atkType.Value;
            switch (value)
            {
                case 0:
                    BuildStrong(targets);
                    break;
                case 1:
                    BuildWeak(targets);
                    break;
                case 2:
                    BuildPitifulHeal(targets);
                    break;
                case 3:
                    BuildFireball(targets);
                    break;
                case 4:
                    BuildIceCone(targets);
                    break;
                case 5:
                    BuildLightningBolt(targets);
                    break;
                case 6:
                    BuildHyperBeam(targets);
                    break;
            }
        }

        private void BuildLightningBolt(Target targets)
        {
            
        }

        private void BuildHyperBeam(Target targets)
        {
            
        }

        private void BuildIceCone(Target targets)
        {
            
        }

        private void BuildFireball(Target targets)
        {
            
        }

        private void BuildPitifulHeal(Target targets)
        {
            
        }

        private void BuildStrong(Target targets)
        {
            int damage = _random.Next(RegisteredDC.DCStats.GetStat(StatsType.Strength) - 15, 25 + RegisteredDC.DCStats.GetStat(StatsType.Strength));
            var cmd = new StatAugmentCommand();
            foreach (var target in targets)
            {
                int appliedDamage = damage / ((int)(target.DCStats.GetStat(StatsType.Defense) * 0.1) + 1);//damage - _random.Next(target.DCStats.GetStat(StatsType.Defense) - 5, 5 + target.DCStats.GetStat(StatsType.Defense));
                cmd.AddEffect(new EffectInformation(StatsType.CurHp, -appliedDamage), target);
            }
            cmd.AddEffect(new EffectInformation(StatsType.Agility, 10,0,15), RegisteredDC);
            cmd.AddEffect(new EffectInformation(StatsType.CurResources,-5), RegisteredDC);
            cmd.RegisterCommand();
        }

        private void BuildWeak(Target targets)
        {
            int damage = _random.Next(15, 5 + RegisteredDC.DCStats.GetStat(StatsType.Strength));
            var cmd = new StatAugmentCommand();
            foreach (var target in targets)
            {
                int appliedDamage = damage / ((int)(target.DCStats.GetStat(StatsType.Defense) * 0.1) + 1);// damage - _random.Next(5 + target.DCStats.GetStat(StatsType.Defense));
                cmd.AddEffect(new EffectInformation(StatsType.CurHp, -appliedDamage), target);
            }
            cmd.AddEffect(new EffectInformation(StatsType.CurResources, 5), RegisteredDC);
            cmd.RegisterCommand();
        }

    }
}
