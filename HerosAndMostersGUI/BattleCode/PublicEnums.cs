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

        public static readonly EnumAttacks StrongAttack = new EnumAttacks("Strong Attack","Performs a strong attack against a selected opponent.",0);
        public static readonly EnumAttacks WeakAttack = new EnumAttacks("Weak Attack","Performs a weak attack against an opponent.",1);
        public static readonly EnumAttacks LesserHeal = new EnumAttacks("Lesser Heal","Small heal with a small cost that slightly buffs defence for 6 seconds",2);
        
        public static readonly EnumAttacks Fireball = new EnumAttacks("Fireball","Engulfs the target monster and surrounding monsters in flames!",3);
        public static readonly EnumAttacks IceCone = new EnumAttacks("Cone of Ice","Low damage that affects target and surrounding targets and lowers their agility for 6 seconds",4);
        public static readonly EnumAttacks LightningBolt = new EnumAttacks("Lightning Bolt","Large amount of damage, but increases targets agility for 6 seconds",5);
        
        public static readonly EnumAttacks HyperBeam = new EnumAttacks("Hyper Beam","Unleashes a beam of pure energy upon the enemy.",6);

        public static readonly EnumAttacks GreaterHeal = new EnumAttacks("Greater Heal", "Large heal with a large cost that slightly buffs agility for 6 seconds", 7);


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
