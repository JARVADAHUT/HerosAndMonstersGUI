using System;
using System.Collections.Generic;
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

    public class EnumAttacks : IEnumerable<EnumAttacks>
    {
        static EnumAttacks()
        {
            Type type = typeof(EnumAttacks);
            var fields = type.GetFields(BindingFlags.Public|BindingFlags.Static);
            AttacksList = new List<EnumAttacks>();
            foreach (var field in fields)
            {
                AttacksList.Add((EnumAttacks)field.GetValue(typeof(EnumAttacks)));
            }
        }

        private static readonly List<EnumAttacks> AttacksList; 

        public static readonly EnumAttacks StrongAttack = new EnumAttacks("Strong Attack","Performs a strong attack against a selected opponent.");
        public static readonly EnumAttacks WeakAttack = new EnumAttacks("Weak attack","Performs a weak attack against an opponent.");
        public static readonly EnumAttacks PitifulHeal = new EnumAttacks("Pitiful heal","Performs a minute heal on selected character.");
        
        public static readonly EnumAttacks Fireball = new EnumAttacks("Fireball","Engulfs the target monster and surrounding monsters in flames!");



        private EnumAttacks(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Description { private set; get; }
        public string Name { private set; get; }

        public IEnumerator<EnumAttacks> GetEnumerator()
        {
            return AttacksList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
