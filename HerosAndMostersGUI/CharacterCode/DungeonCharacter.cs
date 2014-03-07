using System;
using System.Collections.Generic;
using HerosAndMostersGUI;

namespace DesignPatterns___DC_Design
{
    public abstract class DungeonCharacter
    {
        private Stats _dcStats;
        public string Name { get; set; }


        public AttackFactory AttackFactory { private set; get; }

        public Stats DCStats
        {
            get { return _dcStats; }
        }

        protected DungeonCharacter(string name, Stats stats)
        {
            this.Name = name;
            this._dcStats = stats;
            AttackFactory = new AttackFactory(this);
        }

        public abstract void Attack(EnumAttacks type, Target target);
    }
}
