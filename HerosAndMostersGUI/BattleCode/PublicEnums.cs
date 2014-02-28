﻿namespace DesignPatterns___DC_Design
{
    public enum StatsType
    {
        MaxHp,
        CurHp,
        MaxResources,
        CurResources,
        Intelegence,
        Defense,
        Strength,
        Agility,

        Max //<--- For generating items, put new types before this
    }

    public enum AttackTypes
    {
        Strong,
        Weak,
        Heal,
        Defend
    }

    public enum EnumDirection
    {
        Up = 0,
        Down = 1,
        Left = 2,
        Right = 3
    }

    public enum EnumMazeObject
    {
        Wall,
        Air,
        Exit,
        Chest,
        Player,
        Monster,
        Door,
        Key
    }

    public enum EnumItemType
    {
        Equipable,
        Consumable,
        Dye,

        Max //<--- For generating items, put new types before this
    }

    public enum EnumGearSlot
    {
        Head,
        Shoulders,
        Forearm,
        Chest,
        Legs,
        Feet,

        Max //<--- For generating items, put new types before this
    }

    
}
