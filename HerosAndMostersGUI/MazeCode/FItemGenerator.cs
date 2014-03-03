﻿using DesignPatterns___DC_Design;
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

            for (int y = 0; y < (int)StatsType.Max; y++)
            {
                int magnitude = GetStatMagnitude(statPool);

                stats.Add( new EffectInformation( (StatsType)y, magnitude) );

                statPool -= magnitude;
            }

            gear = new Equipable(key++, stats, GetEquippableDescription());
            gear.Slot = slot;

            return gear;
        }


        private static string GetEquippableDescription()
        {
            //do more complex name generation here
            return "gear";
        }


        private static int GetStatMagnitude(int statPool)
        {
            return statPool /= ( (int)(StatsType.Max) - 1 );
        }

        #endregion


        private static EnumItemType GetItemType()
        {
            //add more knowledge later?
            return  (EnumItemType) rnd.Next((int) EnumItemType.Max );
        }
    }
}