using HerosAndMostersGUI.BattleCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace DesignPatterns___DC_Design
{
    class MonsterTurnManager
    {
        private Queue<Monster> _monsterQueue;
        private Target _monsterTargets;

        public MonsterTurnManager()
        {
            _monsterQueue = new Queue<Monster>();
        }


        public void RegisterMonster(Monster monster)
        {
            _monsterQueue.Enqueue(monster);
        }

        public void RegisterMonsters(IEnumerable<Monster> monsters)
        {
            foreach (var m in monsters)
            {
                _monsterQueue.Enqueue(m);
                _monsterTargets.AddTarget(m);
            }
        }

        public void Start()
        {
            var queueThread = new QueueThread(_monsterQueue, _monsterTargets);
            ThreadPool.QueueUserWorkItem(queueThread.ThreadStart);
        }


        private class QueueThread
        {
            private Queue<Monster> _queue;
            private int _killThread;
            private Target _targets;

            internal QueueThread(Queue<Monster> queue,Target targets)
            {
                _queue = queue;
            }


            internal void ThreadStart(Object state)
            {
                _killThread = _queue.Count;

                while (_killThread > 0)//_queue.Count > 0)
                {
                    if (_queue.Count != 0)
                    {
                        var monster = _queue.Dequeue();
                        var mThread = new MonsterThread(monster,_targets);
                        ThreadPool.QueueUserWorkItem(mThread.ThreadStart, this);
                    }
                }



            }


            internal void EnqueueMonster(Monster monster)
            {
                if (!monster.IsDead)
                {
                    lock (this)
                    {
                        _queue.Enqueue(monster);
                    }
                }
                else
                {
                    _killThread--;
                    _targets.RemoveTarget(monster);
                }
            }




        }


        private class MonsterThread
        {
            private readonly Monster _monster;
            private readonly Target _targets;

            internal MonsterThread(Monster monster,Target targets)
            {
                _monster = monster;
                _targets = targets;
            }


            internal void ThreadStart(Object obj)
            {
                var queue = (QueueThread)obj;

                var sleepTime = (int)StatAlgorithms.ConvertAgilityToMiliseconds(_monster);

                Thread.Sleep(sleepTime);

                _monster.TakeTurn(_targets);
                queue.EnqueueMonster(_monster);
            }
        }
    }


}

