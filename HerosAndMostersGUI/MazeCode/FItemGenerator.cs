using DesignPatterns___DC_Design;
using HerosAndMostersGUI.CharacterCode;
using MazeTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace HerosAndMostersGUI.MazeCode
{

    public class FItemGenerator
    {
        private static int key = 0;
        private static Random rnd = new Random();
        private const int _itemMax = 3;
        private const int _statPoolPerLevel = 5;
        private const int _plusOrMinusToPool = 5;


        public static List<InventoryItems> Generate()
        {
            int howManyItems = rnd.Next(1, _itemMax + 1);
            List<InventoryItems> theLoot = new List<InventoryItems>();


            for (int x = 0; x < howManyItems; x++)
            {
                EnumItemType itemType = GetItemType();
                InventoryItems item = new NullItem();
                
                switch (itemType)
                {
                    case EnumItemType.Equipable:
                        item = GenerateEquipable();
                        item.SetType(EnumItemType.Equipable);
                        break;

                    case EnumItemType.Consumable:
                        item = GenerateConsumable();
                        item.SetType(EnumItemType.Consumable);
                        break;

                    case EnumItemType.Dye:
                        item = GenerateDye();
                        item.SetType(EnumItemType.Dye);
                        break;

                    default:
                        item = GenerateEquipable();
                        item.SetType(EnumItemType.Equipable);
                        break;
                }//end switch
                

                theLoot.Add(item);

            }



            return theLoot;
        }

        

        private static EnumItemType GetItemType()
        {
            //add more knowledge later?
            int roll = rnd.Next(1000);

            if (roll < 600)//600
                return EnumItemType.Equipable;
            else if (roll < 900)//900
                return EnumItemType.Consumable;
            else
                return EnumItemType.Dye;
        }

        private static InventoryItems GenerateDye()
        {
            int dyeColor = rnd.Next(10);
            Dye theDye;
            switch (dyeColor)
            {
                case 0:
                    theDye = new Dye(Brushes.LawnGreen);
                    break;
                case 1:
                    theDye = new Dye(Brushes.Ivory);
                    break;
                case 2:
                    theDye = new Dye(Brushes.HotPink);
                    break;
                case 3:
                    theDye = new Dye(Brushes.Wheat);
                    break;
                case 4:
                    theDye = new Dye(Brushes.White);
                    break;
                case 5:
                    theDye = new Dye(Brushes.Tomato);
                    break;
                case 6:
                    theDye = new Dye(Brushes.Snow);
                    break;
                case 7:
                    theDye = new Dye(Brushes.Silver);
                    break;
                case 8:
                    theDye = new Dye(Brushes.Plum);
                    break;
                case 9:
                    theDye = new Dye(Brushes.OldLace);
                    break;
                default:
                    theDye = new Dye(Brushes.LightYellow);
                    break;
            }

            return theDye;
        }

        #region Generate Consumable

        private static Consumable GenerateConsumable()
        {
            StatsType whatStat = ChoosePotStat();
            int magnitude = rnd.Next( 10, ((Maze.GetInstance().MazeLevel + 1) * 10) + 1 ) + rnd.Next( -_plusOrMinusToPool, _plusOrMinusToPool );
            int duration;
            
            if(whatStat == StatsType.CurHp || whatStat == StatsType.CurResources)
                duration = 0;
            else
                duration = rnd.Next(10, 30);

            List<EffectInformation> potionEffects = new List<EffectInformation>();

            //potionEffects.Add( new EffectInformation( (StatsType) whatStat, magnitude, 0, duration ) );

            for (int x = 0; x < ((int)StatsType.Max); x++)
            {
                if (x != (int)whatStat)
                    potionEffects.Add(new EffectInformation((StatsType)x, 0));
                else
                    potionEffects.Add(new EffectInformation((StatsType)whatStat, magnitude, 0, duration));
            }

            Consumable thePotion = new Consumable(key++, potionEffects, GetPotName(whatStat));

            return thePotion;
        }


        private static StatsType ChoosePotStat()
        {
            return (StatsType)rnd.Next( (int)StatsType.Max - 2);
        }

        private static string GetPotName(StatsType whatStat)
        {
            switch (whatStat)
            {
                case StatsType.CurHp:
                    return "Health Potion";
                case StatsType.CurResources:
                    return "Mana Potion";
                case StatsType.Defense:
                    return "Potion of Defence";
                case StatsType.Agility:
                    return "Potion of Agility";
                case StatsType.Strength:
                    return "Potion of Strength";
                case StatsType.Intelegence:
                    return "Potion of Intellect";
                default:
                    return "ERROR";
            }
        }

        #endregion

        #region GetStarterGear

        public static Dictionary<EnumGearSlot, Equipable> GetStarterGear()
        {
            List<EffectInformation> blankStats = new List<EffectInformation>();

            blankStats.Add(new EffectInformation(StatsType.MaxHp, 0));
            blankStats.Add(new EffectInformation(StatsType.MaxResources, 0));
            blankStats.Add(new EffectInformation(StatsType.Agility, 0));
            blankStats.Add(new EffectInformation(StatsType.Strength, 0));
            blankStats.Add(new EffectInformation(StatsType.Intelegence, 0));
            blankStats.Add(new EffectInformation(StatsType.Defense, 0));

            Dictionary<EnumGearSlot,Equipable> gearSlots = new Dictionary<EnumGearSlot,Equipable>();

            Equipable head = new Equipable(key++, blankStats, "Burlap Sack");
            head.Slot = EnumGearSlot.Head;

            Equipable legs = new Equipable(key++, blankStats, "Saggy Pants");
            legs.Slot = EnumGearSlot.Legs;

            Equipable feet = new Equipable(key++, blankStats, "Socks");
            feet.Slot = EnumGearSlot.Feet;

            Equipable arm = new Equipable(key++, blankStats, "Livestrong Wristband");
            arm.Slot = EnumGearSlot.Forearm;

            Equipable chest = new Equipable(key++, blankStats, "T-Shirt");
            chest.Slot = EnumGearSlot.Chest;

            Equipable shoulder = new Equipable(key++, blankStats, "A Pet Bird");
            shoulder.Slot = EnumGearSlot.Shoulders;

            gearSlots.Add(head.Slot, head);
            gearSlots.Add(shoulder.Slot, shoulder);
            gearSlots.Add(chest.Slot, chest);
            gearSlots.Add(arm.Slot, arm);
            gearSlots.Add(legs.Slot, legs);
            gearSlots.Add(feet.Slot, feet);

            return gearSlots;

        }

        #endregion

        #region Generate Equippable

        private static Equipable GenerateEquipable()
        {
            List<EffectInformation> stats = new List<EffectInformation>();
            Equipable gear;
            EnumGearSlot slot = (EnumGearSlot)rnd.Next((int)EnumGearSlot.Max);
            int statPool = ((Maze.GetInstance().MazeLevel + 1) * _statPoolPerLevel) + rnd.Next(- _plusOrMinusToPool, _plusOrMinusToPool + 1);

            StatContainer statContainer = new StatContainer();

            while (statPool > 0)
            {
                int whatStat = ChooseGearStat();
                statContainer.Increment(whatStat);
                statPool -= 1;
            }


            //rarity here
            int rarity = rnd.Next(1000);
            double statScale = GetRarity(rarity);
            statContainer.Scale(statScale);
            

            stats.Add(new EffectInformation(StatsType.MaxHp, statContainer.Hp));
            stats.Add(new EffectInformation(StatsType.MaxResources, statContainer.Mp));
            stats.Add(new EffectInformation(StatsType.Agility, statContainer.Agi));
            stats.Add(new EffectInformation(StatsType.Strength, statContainer.Str));
            stats.Add(new EffectInformation(StatsType.Intelegence, statContainer.Int));
            stats.Add(new EffectInformation(StatsType.Defense, statContainer.Def));

            gear = new Equipable(key++, stats, GetRarityInText(rarity) + GetEquippableDescription(statContainer, slot) );
            gear.Slot = slot;

            return gear;
        }

        private static string GetRarityInText(double rarity)
        {
            if (rarity <= 175)//basic
                return "Basic ";
            else if (rarity <= 350)//common
                return "Common ";
            else if (rarity <= 525)//uncommon
                return "Uncommon ";
            else if (rarity <= 700)//rare
                return "Rare ";
            else if (rarity <= 875)//epic
                return "Epic ";
            else//legendary
                return "Legendary ";
        }

        private static double GetRarity(int type)
        {
            
            if (type <= 175)//basic             100
                return .5;
            else if (type <= 350)//common       700
                return 1.0;
            else if (type <= 525)//uncommon     900
                return 1.5;
            else if (type <= 700)//rare         975
                return 2;
            else if (type <= 875)//epic         999
                return 4;
            else//legendary                     1
                return 8;
        }

        private static string GetEquippableDescription(StatContainer gearStats, EnumGearSlot slot)
        {
            int max = gearStats.Next();
            int statType = 0;

            for (int x = 1; x < StatContainer.NumStats; x++)
            {
                int check = gearStats.Next();
                if (max <= check)
                {
                    max = check;
                    statType = x;
                }
            }

            return GetSlotText(slot) + gearStats.GetStatName(statType);
        }

        private static string GetSlotText(EnumGearSlot slot)
        {
            switch (slot)
            {
                case EnumGearSlot.Chest:
                    return "Chest";
                case EnumGearSlot.Legs:
                    return "Leggings";
                case EnumGearSlot.Forearm:
                    return "Gauntlets";
                case EnumGearSlot.Feet:
                    return "Boots";
                case EnumGearSlot.Head:
                    return "Helmet";
                case EnumGearSlot.Shoulders:
                    return "Spaulders";
                default:
                    return "ERROR";
            }
        }

        private static int ChooseGearStat()
        {
            return rnd.Next(StatContainer.NumStats);
        }

        #endregion

    }

    #region Stat Container

    internal class StatContainer
    {
        public int Hp { set; get; }
        public int Mp { set; get; }
        public int Def { set; get; }
        public int Agi { set; get; }
        public int Int { set; get; }
        public int Str { set; get; }

        public static int NumStats = 6;

        private int curStat;

        public StatContainer()
        {
            curStat = 0;
        }


        public int Next()
        {
            int retVal = GetStat(curStat);
            curStat = (curStat + 1) % NumStats;

            return retVal;
        }

        public string GetStatName(int i)
        {
            switch (i)
            {
                case 0:
                    return " of The Eagle";
                case 1:
                    return " of The Whale";
                case 2:
                    return " of The Turtle";
                case 3:
                    return " of The Monkey";
                case 4:
                    return " of The Owl";
                case 5:
                    return " of The Bear";
                default:
                    return "ERROR";
            }
        }

        public int GetStat(int i)
        {
            switch (i)
            {
                case 0:
                    return Hp;
                case 1:
                    return Mp;
                case 2:
                    return Def;
                case 3:
                    return Agi;
                case 4:
                    return Int;
                case 5:
                    return Str;
                default:
                    return 0;
            }
        }

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

        internal void Scale(double statScale)
        {
            Hp = (int) ( (double) Hp * statScale );
            Mp = (int)((double) Mp * statScale);
            Str = (int)((double) Str * statScale);
            Int = (int)((double) Int * statScale);
            Agi = (int)((double) Agi * statScale);
            Def = (int)((double) Def * statScale);

        }
    }

    #endregion

}
