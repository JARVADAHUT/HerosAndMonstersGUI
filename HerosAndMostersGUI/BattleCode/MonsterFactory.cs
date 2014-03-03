using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns___DC_Design;

namespace HerosAndMostersGUI.BattleCode
{
    class MonsterFactory
    {
        private static MonsterFactory _instance;
        private static Random _random;

        private MonsterFactory()
        {
            _random = new Random();
        }

        public static MonsterFactory GetInstance()
        {
            return _instance ?? (_instance = new MonsterFactory());
        }

        public Monster GetMonster(int level)
        {
            var tempStats = new Stats();
            tempStats.AddStat(StatsType.MaxHp, GetHpValue(level));
            tempStats.AddStat(StatsType.Agility, GetStatValue(level));
            tempStats.AddStat(StatsType.Defense, GetStatValue(level));
            tempStats.AddStat(StatsType.Strength, GetStatValue(level));
            tempStats.AddStat(StatsType.Strength, GetStatValue(level));

            IMonsterTurnAI tempAI = new MonsterTurnAIAgressive();
            /*switch (level)
            {
                
                    
            }*/
            return new Monster(GetName(),tempStats,tempAI);
        }

        private static int GetHpValue(int level)
        {
            return _random.Next(40 + (5*level), 50 + (5*level));
        }

        private static int GetStatValue(int level)
        {
            return _random.Next(5 + (level * 2), 10 + (level * 2));
        }

        private static string GetName()
        {
            return "Stephen";
        }
    }
}
