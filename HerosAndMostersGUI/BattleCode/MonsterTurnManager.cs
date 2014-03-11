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
            foreach(var m in monsters)
                _monsterQueue.Enqueue(m);
        }

        public void Start()
        {
            var queueThread = new QueueThread(_monsterQueue);
            ThreadPool.QueueUserWorkItem(queueThread.ThreadStart);
        }


        private class QueueThread
        {
            private Queue<Monster> _queue;
            private int _killThread;


            internal QueueThread(Queue<Monster> queue)
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
                        var mThread = new MonsterThread(monster);
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
                }
            }




        }


        private class MonsterThread
        {
            private readonly Monster _monster;


            internal MonsterThread(Monster monster)
            {
                _monster = monster;
            }


            internal void ThreadStart(Object obj)
            {
                var queue = (QueueThread)obj;

                int sleepTime = (int)StatAlgorithms.ConvertAgilityToMiliseconds(_monster);

                Thread.Sleep(sleepTime);

                _monster.TakeTurn();
                queue.EnqueueMonster(_monster);
            }
        }
    }


}

