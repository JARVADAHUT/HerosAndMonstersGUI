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

        private static readonly List<string> PrefixNames = new List<string>()
                                                   {
                                                       "Richard",
                                                       "Maridith",
                                                       "Augusta",
                                                       "Stephen",
                                                       "Homer",
                                                       "Garrick"
                                                   };

        private static readonly List<string> SuffixNames = new List<string>()
                                                   {
                                                       " the Destroyer",
                                                       " the Unstopable",
                                                       " of the Night",
                                                       " for the Horde",
                                                       " the Badass"
                                                   }; 

        private static readonly Dictionary<string,Dictionary<string,List<string>>> _names = new Dictionary<string,Dictionary<string,List<string>>>();

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
            tempStats.AddStat(StatsType.MaxResources, GetStatValue(level));

            string AItype;
            IMonsterTurnAI tempAI = GetAI(level,out AItype);
            var name = GetName(AItype);
            /*switch (level)
            {
                
                    
            }*/
            return new Monster(name,tempStats,tempAI);
        }

        private static int GetHpValue(int level)
        {
            return _random.Next(20 + (int)(3.5*level), 35 + (int)(3.5*level));
        }

        private static int GetStatValue(int level)
        {
            if (level < 5) // to reduce difficulty on earlier levels
                return _random.Next(0 + (int)(level * 1.5), 2 + (int)(level * 1.5));
            else
                return _random.Next(0 + (int)(level * 2.5), 2 + (int)(level * 2.5));
        }

        private static IMonsterTurnAI GetAI(int level, out string AItype)
        {
            AItype = "Agressive";
            return new MonsterTurnAIAgressive();
            //switch (_random.Next(3) + 1)
            //{
            //    case 1:
            //        AItype = "Agressive";
            //        return new MonsterTurnAIAgressive();
            //    case 2:
            //        AItype = "Passive";
            //        return new MonsterTurnAIPassive();
            //    case 3:
            //        AItype = "Healer";
            //        return new MonsterTurnAIHealer();
            //}
                    
            
            //AItype = "This is not working... yet";
            //return null;
        }

        private static string GetName(string aiType)
        {


            var prefix = _random.Next(PrefixNames.Count);
            var suffix = _random.Next(SuffixNames.Count);
            return PrefixNames[prefix] + SuffixNames[suffix];
        }
    }
}
