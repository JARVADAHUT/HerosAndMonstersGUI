using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns___DC_Design;

namespace HerosAndMostersGUI.CharacterCode
{
    public class InventoryItem
    {
        public EnumInventoryType Category { private set; get; }
        private List<EffectInformation> _properties;
        public int Delay { set; get; }
        public int Duration { set; get; }

        public InventoryItem(EnumInventoryType category)
        {
            Category = category;
            _properties = new List<EffectInformation>();
        }

        public void AddEffect(StatsType stat, int magnitude)
        {
            _properties.Add(new EffectInformation(stat, magnitude));
        }

        /*
        public void RemoveEffect(StatsType stat)
        {
            foreach (var x in _properties)
            {
                if (x._stat.Equals(stat))
                    _properties.Remove(x);
            }
        }
        */

        public void UseItem(Target targets)
        {
            var cmd = new StatAugmentCommand();
            foreach (var target in targets)
            {
                cmd.AddEffects(_properties,target);
            }
            cmd.RegisterCommand();
        }
    }
}
