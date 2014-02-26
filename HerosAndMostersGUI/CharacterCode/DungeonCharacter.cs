using System;
using System.Collections.Generic;
using HerosAndMostersGUI;

namespace DesignPatterns___DC_Design
{
    public abstract class DungeonCharacter
    {
        private Stats _dcStats;
        public string Name { get; set; }
        public Inventory Inventory { get; set; }

        private AttackFactory _attackFactory;

        public Stats DCStats
        {
            get { return _dcStats; }
        }

        protected DungeonCharacter(string name, Stats stats, AttackFactory factory)
        {
            this.Name = name;
            this._dcStats = stats;
            this._attackFactory = factory;
        }
    }
}
