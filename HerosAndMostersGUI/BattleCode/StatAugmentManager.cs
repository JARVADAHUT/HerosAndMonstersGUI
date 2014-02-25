using System.Threading;

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

        public void SendCommand(StatAugmentCommand cmd)
        {

            var sacThread = new StatAugmentCommandThread(cmd);

            ThreadPool.QueueUserWorkItem(sacThread.ThreadStart);
            //var t = new Thread(new ThreadStart(sacThread.ThreadStart));
            //t.Start();
        }


        private class StatAugmentCommandThread
        {
            private StatAugmentCommand _cmd;

            internal StatAugmentCommandThread(StatAugmentCommand cmd)
            {
                _cmd = cmd;
            }

            internal void ThreadStart(object state)
            {
                var delay = _cmd.Delay;
                var duration = _cmd.Duration;

                Thread.Sleep(delay * 1000);
                _cmd.ApplyAugment();

                if (duration <= 0) return;
                
                Thread.Sleep(duration*1000);
                _cmd.RemoveAugment();
            }

        }
    }

}
