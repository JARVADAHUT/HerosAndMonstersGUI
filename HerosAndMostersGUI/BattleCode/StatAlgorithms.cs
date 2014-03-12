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
            //int Agi = dc.DCStats.GetStat(StatsType.Agility);
            int agi = Hero.GetInstance().DCStats.GetStat(StatsType.Agility);

            double y = 500 + (1500 * Math.Pow(1.008, -.5 * agi));
            return y;
        }

        // No need for this method in its current state. Will change when further str logic is needed, or comment out. 
        public static int GetPercentStrength(DungeonCharacter dc, double percent)
        {
            return (int)(dc.DCStats.GetStat(StatsType.Strength) * percent);
        }

        public static  int ApplyDefence(int damage, DungeonCharacter target)
        {
            double damageReduction = 25 + (75 * Math.Pow(1.0105, -.5 * target.DCStats.GetStat(StatsType.Defense)));

            return (int)(damage * (damageReduction/100));
        }

        /*
public static double ConvertAgilityToMiliseconds2()
{
    int x = Hero.GetInstance().DCStats.GetStat(StatsType.Agility);
    double y = 2000.0 - ((1250.0 * x) / (0.75 * x + 200.0));
    return y;
}
*/

    }
}
