using System.Threading;
using HerosAndMostersGUI.CharacterCode;

namespace DesignPatterns___DC_Design
{
    public class StatAugmentManager
    {
        private static StatAugmentManager _instanceStatAugmentManager = null;

        private StatAugmentManager()
        {
            
        }

        public static StatAugmentManager GetInstance()
        {
            return _instanceStatAugmentManager ?? (_instanceStatAugmentManager = new StatAugmentManager());
        }

        public void OfferCommand(StatAugmentCommand cmd)
        {
            foreach (var key in cmd.Effects.Keys)
            {
                foreach (var effect in cmd.Effects[key])
                {
                    var sacThread = new StatAugmentCommandThread(effect,key);
                    ThreadPool.QueueUserWorkItem(sacThread.ThreadStart);
                }
            }
            //var t = new Thread(new ThreadStart(sacThread.ThreadStart));
            //t.Start();
        }


        private class StatAugmentCommandThread
        {
            private readonly EffectInformation _effect;
            private readonly DungeonCharacter _target;

            internal StatAugmentCommandThread(EffectInformation effect, DungeonCharacter target)
            {
                _effect = effect;
                _target = target;
            }

            internal void ThreadStart(object state)
            {
                var delay = _effect.Delay;
                var duration = _effect.Duration;

                Thread.Sleep(delay*1000);
                _target.DCStats.AugmentStat(_effect.Stat, _effect.Magnitude);
                
                if (duration <= 0) return;

                Thread.Sleep(duration*1000);
                _target.DCStats.AugmentStat(_effect.Stat, _effect.Magnitude * -1);
                
            }

        }
    }

}
