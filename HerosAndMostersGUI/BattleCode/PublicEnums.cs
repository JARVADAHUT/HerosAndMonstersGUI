﻿using MazeTest;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace DesignPatterns___DC_Design
{
    public enum StatsType
    {
        CurResources,
        CurHp,
        
        Agility,
        Strength,
        Intelegence,
        Defense,

        MaxHp,
        MaxResources,

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
        Chest,
        Forearm,
        Legs,
        Feet,

        Max //<--- For generating items, put new types before this
    }

    public class EnumAttacks
    {

        #region Mana Costs

        private const int ICE_CONE_COST = -10;
        private const int WEAK_ATTACK_COST = 10;
        private const int STRONG_ATTACK_COST = -10;
        private const int LIGHTNING_BOLT_COST = -10;
        private const int FIREBALL_COST = -10;
        private const int LESSER_HEAL_COST = -5;
        private const int HYPER_BEAM_COST = -10;
        private const int GREATER_HEAL_COST = -20;
        private const int DEMO_SHOUT_COST = 10;
        private const int LIFE_TAP_COST = 0;

        #endregion

        private int _cost;

        static EnumAttacks()
        {
            Type type = typeof(EnumAttacks);
            var fields = type.GetFields(BindingFlags.Public|BindingFlags.Static);
            _attacksList = new List<EnumAttacks>();
            foreach (var field in fields)
            {
                _attacksList.Add((EnumAttacks)field.GetValue(typeof(EnumAttacks)));
            }
        }

        private static readonly List<EnumAttacks> _attacksList; 

        public static readonly EnumAttacks StrongAttack = new EnumAttacks("Strong Attack","Performs a strong attack against a selected opponent and increases their Agility for *4* seconds. Cost: 10+", STRONG_ATTACK_COST,0);
        public static readonly EnumAttacks WeakAttack = new EnumAttacks("Weak Attack", "Performs a weak attack against an opponent and generates *10* mana. Generate: 10+", WEAK_ATTACK_COST, 1);
        public static readonly EnumAttacks LesserHeal = new EnumAttacks("Lesser Heal", " Cast a small, mana-efficient heal that buffs your Defence and Agility by *10%* for *4* seconds. Cost: 5+", LESSER_HEAL_COST, 2);

        public static readonly EnumAttacks Fireball = new EnumAttacks("Fireball", "Engulf the target monster and surrounding monsters in flames dealing moderate damage. Cost: 10+", FIREBALL_COST, 3);
        public static readonly EnumAttacks IceCone = new EnumAttacks("Cone of Ice", "Spray ice shards at your enemies dealing low damage that lowers target and surrounding target's Agility and Strength by *80%* for *4* seconds. Cost: 10+", ICE_CONE_COST, 4);
        public static readonly EnumAttacks LightningBolt = new EnumAttacks("Lightning Bolt", "Strike your opponent with a large range of damage which increases targets Agility by *150%* for *2* seconds. Cost: 10+", LIGHTNING_BOLT_COST, 5);

        public static readonly EnumAttacks HyperBeam = new EnumAttacks("Hyper Beam", "Unleashes a beam of pure energy upon the enemy dealing moderate damage and reducing their Strength, Agility, and Defense by *15%* for *4* seconds. Cost: 10+", HYPER_BEAM_COST, 6);
        public static readonly EnumAttacks DemoralizingShout = new EnumAttacks("Demo. Shout", "Release a deafening shout at your enemies demoralizing them, reducing their Strength, Agility, and Defense by up to *25%* based off your Strength for *5* seconds. Generate: 10+", DEMO_SHOUT_COST, 7);

        public static readonly EnumAttacks GreaterHeal = new EnumAttacks("Greater Heal", "Cast a very Large, but mana-inefficient heal that buffs your Agility by *20%* for *4* seconds. Cost: 20+", GREATER_HEAL_COST, 8);
        public static readonly EnumAttacks LifeTap = new EnumAttacks("Life Tap", "Sacrifice half your health to instantly restore mana equal to 100% of your current hp (before the sacrifice) and increase your Defense by *90%* for *6* seconds. Cost: 50% current life", LIFE_TAP_COST, 9);


        private EnumAttacks(string name, string description, int cost, int value)
        {
            Name = name;
            Description = description;
            Value = value;
            Cost = cost;
        }

        public int Cost
        {
            private set
            {
                _cost = value;
            }

            get
            {
                if (_cost < 0) // if spender ability, scale cost to maze level
                    return _cost + (int)(Maze.GetInstance().MazeLevel * 1.5);
                else
                    return _cost;
            }
        }
        public string Description { private set; get; }
        public string Name { private set; get; }
        public int Value { private set; get; }
        public static IEnumerable<EnumAttacks> AttacksList { get { return _attacksList.AsReadOnly(); } } 
        

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType().Equals(typeof (EnumAttacks)))
            {
                var that = (EnumAttacks) obj;
                return (that.Name.Equals(this.Name) && that.Description.Equals(this.Description));
            }
            return false;
        }
    }
}
