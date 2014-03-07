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

        public static readonly EnumAttacks StrongAttack = new EnumAttacks("Strong attack","Performs a strong attack against a selected opponent.",0);
        public static readonly EnumAttacks WeakAttack = new EnumAttacks("Weak attack","Performs a weak attack against an opponent.",1);
        public static readonly EnumAttacks PitifulHeal = new EnumAttacks("Pitiful heal","Performs a minute heal on selected character.",2);
        
        public static readonly EnumAttacks Fireball = new EnumAttacks("Fireball","Engulfs the target monster and surrounding monsters in flames!",3);
        public static readonly EnumAttacks IceCone = new EnumAttacks("Cone of ice","Freezes the opponent and surrounding opponents.",4);
        public static readonly EnumAttacks HyperBeam = new EnumAttacks("Hyper beam","Unleashes a beam of pure energy upon the enemy.",5);


        private EnumAttacks(string name, string description, int value)
        {
            Name = name;
            Description = description;
            Value = value;
        }

        public string Description { private set; get; }
        public string Name { private set; get; }
        public int Value { private set; get; }
        public static IEnumerable<EnumAttacks> AttacksList { get { return _attacksList.AsReadOnly(); } } 
        

        public override string ToString()
        {
            return Name;
        }
    }
}
