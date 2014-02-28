﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using DesignPatterns___DC_Design;
using HerosAndMostersGUI.CharacterCode;

namespace HerosAndMostersGUI
{

    public class Inventory
    {

        private List<GenericItems> itemList;

        public Inventory()
        {
            itemList = new List<GenericItems>();
        }

        public void AddItem(GenericItems item)
        {
            itemList.Add(item);
        }

        public void AddItemList(List<GenericItems> items)
        {
            foreach (GenericItems i in items)
            {
                itemList.Add(i);
            }
        }

        /*
        public void RemoveItem(int key)
        {
            int index = 0;
            bool found = false;
            foreach (GenericItems i in itemList)
            {
                if (i.Key == key)
                    break;

                index++;
            }

            if (found)
                itemList.RemoveAt(index);
        }
        */

        public void RemoveItem(GenericItems item)
        {
            itemList.Remove(item);
        }

        internal List<GenericItems> GetItems()
        {
            return itemList;
        }

        // SORTING ALGORITHM - PARAMS: COMPARER <<OR>> STAT TYPE OR OTHER (possibly overload)

    } // end class

} //end namespace



/*
public List<InventoryItem> GearList { private set; get; }
public List<InventoryItem> ConsumablesList { private set; get; }
public Dictionary<EnumInventoryItemType,InventoryItem> EquipedGearSet { private set; get; }
 
public Inventory()
{
    GearList = new List<InventoryItem>();
    ConsumablesList = new List<InventoryItem>();
}

public List<InventoryItem> SortInventory(Comparer<InventoryItem> comparer)
{
    var resultSet = new List<InventoryItem>();
    resultSet.AddRange(GearList);
    resultSet.AddRange(ConsumablesList);
    resultSet.Sort(comparer);

    return resultSet;
}

public void AddConsumables(params InventoryItem[] items)
{
    foreach(var x in items)
    {
        if(x.Category != EnumInventoryItemType.Consumable)
            throw new ArgumentException("You aren't using this correctly!");
        x.SetUseBehvaior(new ApplyEffectsUseBehavior());
        ConsumablesList.Add(x);
    }   
}

public void AddGear(params InventoryItem[] items)
{
    foreach (var x in items)
    {
        if(x.Category == EnumInventoryItemType.Consumable)
            throw new ArgumentException("You aren't using this correctly!");
        x.SetUseBehvaior(new ApplyEffectsUseBehavior());
        GearList.Add(x);
    }   
}

public void AddItems(params InventoryItem[] items)
{
    foreach (var x in items)
    {
        switch (x.Category)
        {
            case EnumInventoryItemType.Chest:
            case EnumInventoryItemType.Feet:
            case EnumInventoryItemType.Forearm:
            case EnumInventoryItemType.Head:
            case EnumInventoryItemType.Legs:
            case EnumInventoryItemType.Shoulders:
                AddGear(x);
                break;
            case EnumInventoryItemType.Consumable:
                AddConsumables(x);
                break;
        }
    }
}

public void UseConsumable(int index, Target targets)
{
    ConsumablesList[index].UseItem(targets);
    ConsumablesList.RemoveAt(index);
}

public void EquipGear(int index)
{
    if (EquipedGearSet.ContainsKey(GearList[index].Category))
    {
        UnEquipGear(GearList[index].Category);
    }
            
    GearList[index].UseItem(new Target(Hero.GetInstance()));
    GearList[index].SetUseBehvaior(new RemoveEffectsUseBehvaior());
    EquipedGearSet.Add(GearList[index].Category,GearList[index]);
}

public void UnEquipGear(EnumInventoryItemType type)
{
    if (EquipedGearSet.ContainsKey(type))
    {
        InventoryItem result = EquipedGearSet[type];
        EquipedGearSet.Remove(type);
        result.UseItem(new Target(Hero.GetInstance()));
        result.SetUseBehvaior(new ApplyEffectsUseBehavior());
        AddGear(result);
    }
}
*/