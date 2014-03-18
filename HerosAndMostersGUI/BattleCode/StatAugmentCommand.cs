using System;
using System.Collections.Generic;
using System.Drawing.Text;
using HerosAndMostersGUI.CharacterCode;

namespace DesignPatterns___DC_Design
{
    public class StatAugmentCommand
    {

        public Dictionary<DungeonCharacter,List<EffectInformation>> Effects { private set; get; }

        public StatAugmentCommand()
        {
            Effects = new Dictionary<DungeonCharacter, List<EffectInformation>>();
        }

        public void RegisterCommand()
        {
            StatAugmentManager.GetInstance().OfferCommand(this);
        }

        public void AddEffect(EffectInformation effect, DungeonCharacter dc)
        {
            if (!Effects.ContainsKey(dc))
            {
                Effects.Add(dc,new List<EffectInformation>());
            }
            Effects[dc].Add(effect);
        }

        public void AddEffects(IEnumerable<EffectInformation> effects, DungeonCharacter dc)
        {
            if (!Effects.ContainsKey(dc))
            {
                Effects.Add(dc,new List<EffectInformation>());
            }
            Effects[dc].AddRange(effects);
        }

    }
}

