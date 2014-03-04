using DesignPatterns___DC_Design;
using HerosAndMostersGUI.CharacterCode;
using MazeTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerosAndMostersGUI.MazeCode
{
    public class FItemGenerator
    {
        private static int key = 0;
        private static Random rnd = new Random();
        private const int _itemMax = 3;
        private const int _statPoolPerLevel = 30;

        public static List<InventoryItems> Generate()
        {
            int howManyItems = rnd.Next(1, _itemMax + 1);
            List<InventoryItems> theLoot = new List<InventoryItems>();


            for (int x = 0; x < howManyItems; x++)
            {
                EnumItemType itemType = GetItemType();
                InventoryItems item = GenerateEquipable();//new NullItem();
                /*
                switch (itemType)
                {
                    case EnumItemType.Equipable:
                        item = GenerateEquipable();
                        break;

                    case EnumItemType.Consumable:

                        break;

                    case EnumItemType.Dye:

                        break;

                    default:
                        item = GenerateEquipable();
                        break;
                }//end switch
                */

                theLoot.Add(item);

            }

            
            
            return theLoot;
        }


        #region Generate Equippable

        private static Equipable GenerateEquipable()
        {
            List<EffectInformation> stats = new List<EffectInformation>();
            Equipable gear;
            EnumGearSlot slot = (EnumGearSlot) rnd.Next( (int)EnumGearSlot.Max );
            int statPool = (Maze.GetInstance().MazeLevel + 1) * _statPoolPerLevel;

            StatContainer statContainer = new StatContainer();

            while(statPool > 0)
            {
                int whatStat = ChooseStat();
                statContainer.Increment(whatStat);
                statPool -= 1;
            }

            stats.Add( new EffectInformation(StatsType.MaxHp, statContainer.Hp) );
            stats.Add( new EffectInformation(StatsType.MaxResources, statContainer.Mp) );
            stats.Add( new EffectInformation(StatsType.Agility, statContainer.Agi) );
            stats.Add( new EffectInformation(StatsType.Strength, statContainer.Str) );
            stats.Add( new EffectInformation(StatsType.Intelegence, statContainer.Int) );
            stats.Add( new EffectInformation(StatsType.Defense, statContainer.Def) );

            gear = new Equipable(key++, stats, GetEquippableDescription());
            gear.Slot = slot;

            return gear;
        }


        private static string GetEquippableDescription()
        {
            //do more complex name generation here
            return "gear";
        }


        private static int ChooseStat()
        {
            return rnd.Next(StatContainer.NumStats);
        }

        #endregion


        private static EnumItemType GetItemType()
        {
            //add more knowledge later?
            return  (EnumItemType) rnd.Next((int) EnumItemType.Max );
        }
    }

    internal class StatContainer
    {
        public int Hp { set; get; }
        public int Mp { set; get; }
        public int Def { set; get; }
        public int Agi { set; get; }
        public int Int { set; get; }
        public int Str { set; get; }

        public static int NumStats = 6;

        public void Increment(int i)
        {
            switch (i)
            {
                case 0:
                    Hp++;
                    break;
                case 1:
                    Mp++;
                    break;
                case 2:
                    Def++;
                    break;
                case 3:
                    Agi++;
                    break;
                case 4:
                    Int++;
                    break;
                case 5:
                    Str++;
                    break;
            }
        }
    }




}
