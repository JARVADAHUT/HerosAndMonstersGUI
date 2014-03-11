using System;
using System.Collections.Generic;
using HerosAndMostersGUI;
using HerosAndMostersGUI.AttackChain;

namespace DesignPatterns___DC_Design
{
    public abstract class DungeonCharacter
    {
        private Stats _dcStats;
        public string Name { get; set; }


        public AttackHandler AttackChain { private set; get; }

        public Stats DCStats
        {
            get { return _dcStats; }
        }

        protected DungeonCharacter(string name, Stats stats)
        {
            this.Name = name;
            this._dcStats = stats;
            AttackChain = AttackHandler.GetAttackHandlerChain();
        }

        public abstract void Attack(EnumAttacks type, Target target);
    }
}
