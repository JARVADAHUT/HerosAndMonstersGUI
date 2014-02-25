using System;
using System.Collections.Generic;
using HerosAndMostersGUI.CharacterCode;

namespace DesignPatterns___DC_Design
{
    public class StatAugmentCommand
    {
        public List<EffectInformation> Effects { private set; get; }
        public Target Targets { private set; get; }

        public StatAugmentCommand(IEnumerable<EffectInformation> effects, Target targets)
        {
            Effects = new List<EffectInformation>();
            Effects.AddRange(effects);
            Targets = targets;
        }

        public void RegisterCommand()
        {
            StatAugmentManager.GetInstance().OfferCommand(this);
        }

        public void AddEffect(EffectInformation effect)
        {
            Effects.Add(effect);
        }

        /*
        public void ApplyAugment()
        {
            foreach (var target in Targets)
            {
                foreach (var effect in Effects)
                {
                    target.DCStats.AugmentStat(effect.Stat, effect.Magnitude);
                }
            }
                
        }


        public void RemoveAugment()
        {
            foreach (var target in Targets)
            {
                foreach (var effect in Effects)
                {
                    target.DCStats.AugmentStat(effect.Stat, effect.Magnitude * -1);
                }
            }
        }
        */

    }
}

