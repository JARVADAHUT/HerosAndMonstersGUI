using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns___DC_Design;

namespace HerosAndMostersGUI.CharacterCode
{
    public class ApplyEffectsUseBehavior : IUseItemBehavior
    {
        public void UseItem(GenericItems item, Target targets)
        {
            var cmd = new StatAugmentCommand();
            foreach (var target in targets)
            {
                cmd.AddEffects(item.Properties,target);
            }
            cmd.RegisterCommand();
        }
    }
}
