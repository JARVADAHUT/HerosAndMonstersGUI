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
            foreach (var effect in cmd.Effects)
            {
                var sacThread = new StatAugmentCommandThread(effect,cmd.Targets);
                ThreadPool.QueueUserWorkItem(sacThread.ThreadStart);
            }
            //var t = new Thread(new ThreadStart(sacThread.ThreadStart));
            //t.Start();
        }


        private class StatAugmentCommandThread
        {
            private EffectInformation _effect;
            private Target _targets;

            internal StatAugmentCommandThread(EffectInformation effect, Target targets)
            {
                _effect = effect;
                _targets = targets;
            }

            internal void ThreadStart(object state)
            {
                var delay = _effect.Delay;
                var duration = _effect.Duration;

                foreach (var target in _targets)
                {
                    Thread.Sleep(delay*1000);
                    target.DCStats.AugmentStat(_effect.Stat, _effect.Magnitude);
                }
                if (duration <= 0) return;
                foreach(var target in _targets)
                {
                    Thread.Sleep(duration*1000);
                    target.DCStats.AugmentStat(_effect.Stat, _effect.Magnitude * -1);
                }
            }

        }
    }

}
