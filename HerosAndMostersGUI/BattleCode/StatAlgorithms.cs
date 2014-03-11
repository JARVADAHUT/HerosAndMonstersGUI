using DesignPatterns___DC_Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerosAndMostersGUI.BattleCode
{
    public class StatAlgorithms
    {
        public static double ConvertAgilityToMiliseconds(DungeonCharacter dc)
        {
            int x = dc.DCStats.GetStat(StatsType.Agility);

            //double y = 2000.0 - (  (1250.0 * x) / (0.75 * x + 200.0)  );
            double y = 1800.0 - ((1250.0 * x) / (0.75 * x + 200.0));
            return y;
        }

        public static int ScaleStrength(DungeonCharacter dc)
        {
            return dc.DCStats.GetStat(StatsType.Strength);
        }

        public static double ConvertAgilityToMiliseconds2()
        {
            int x = Hero.GetInstance().DCStats.GetStat(StatsType.Agility);
            double y = 2000.0 - ((1250.0 * x) / (0.75 * x + 200.0));
            return y;
        }

    }
}
