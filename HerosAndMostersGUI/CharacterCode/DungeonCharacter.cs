using System;
using System.Collections.Generic;

namespace DesignPatterns___DC_Design
{
    abstract class DungeonCharacter
    {
        private Stats _dcStats;
        public string Name { get; set; }

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
