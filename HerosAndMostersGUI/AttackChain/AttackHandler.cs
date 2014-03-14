using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns___DC_Design;
using HerosAndMostersGUI.CharacterCode;

namespace HerosAndMostersGUI.AttackChain
{
    public abstract class AttackHandler
    {
        protected AttackHandler NextLink { get; set; }
        protected static Random _random = new Random();

        protected const int DEFAULT_INDEX = 0;

        public AttackHandler(AttackHandler nextLink)
        {
            NextLink = nextLink;
        }
        public abstract void HandleAttack(EnumAttacks attack, Target targets, DungeonCharacter attacker);

        public static AttackHandler GetAttackHandlerChain()
        {
            var result = new WeakAttackHandler
            (
                new StrongAttackHandler
                (
                    new LightningBoltAttackHandler
                    (
                        new IceConeAttackHandler
                        (
                            new LesserHealAttackHandler
                            (
                                new GreaterHealAttackHandler
                                (
                                    new FireballHandler
                                    (
                                        new HyperbeamHandler
                                        (
                                            new NullAttackHandler(null)
                                        )
                                    )
                                )
                            )
                        )
                    )
                )
            );

            return result;
        }

        protected EffectInformation ModifyStatBy(StatsType stat, DungeonCharacter target, double percent, int duration)
        {
            return new EffectInformation(stat, (int)(target.DCStats.GetStat(stat) * percent), 0, duration);
        }

        
    }
}
