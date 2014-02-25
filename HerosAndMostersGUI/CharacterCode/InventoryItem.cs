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
        public EnumInventoryType Category {private set; get; }
        private List<EffectsData> _properties; 
        //Meditate on this

        public InventoryItem(EnumInventoryType category)
        {
            Category = category;
            _properties = new List<EffectsData>();
        }

        public void AddEffect(StatsType stat, int magnitude)
        {
            AddEffect(stat,magnitude,0,0);
        }

        public void AddEffect(StatsType stat, int magnitude, int delay, int duration)
        {
            _properties.Add(new EffectsData(stat,magnitude,delay,duration));
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
        private class EffectsData
        {
            internal StatsType _stat { set; get; }
            internal int _magnitude { set; get; }
            internal int _delay { set; get; }
            internal int _duration { set; get; }

            internal EffectsData(StatsType stat, int magnitude, int delay, int duration)
            {
                _stat = stat;
                _magnitude = magnitude;
                _delay = delay;
                _duration = duration;
            }


        }
    }
}
