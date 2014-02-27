using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns___DC_Design;

namespace HerosAndMostersGUI.CharacterCode
{
    class RemoveEffectsUseBehvaior : IUseItemBehavior
    {
        public void UseItem(InventoryItem item, Target targets)
        {
            var cmd = new StatAugmentCommand();
            var effectsResult = item.Properties.Select(effect => effect.GetInverse()).ToList();

            foreach (var target in targets)
            {
                cmd.AddEffects(effectsResult, target);
            }
            cmd.RegisterCommand();
        }
    }
}
