using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns___DC_Design;

namespace HerosAndMostersGUI.CharacterCode
{
    public class EffectInformation : IEquatable<EffectInformation>
    {
        public StatsType Stat { set; get; }
        public int Magnitude { set; get; }
        public int Delay { set; get; }
        public int Duration { set; get; }

        public EffectInformation(StatsType stat, int magnitude, int delay = 0, int duration = 0)
        {
            Stat = stat;
            Magnitude = magnitude;
            Delay = delay;
            Duration = duration;
        }

        public EffectInformation GetInverse()
        {
            return new EffectInformation(Stat,-1*Magnitude);
        }

        public bool Equals(EffectInformation other)
        {
            return this.Stat == other.Stat;
        }
    }
}
