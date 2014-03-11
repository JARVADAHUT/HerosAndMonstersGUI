﻿using System;
using System.Collections.Generic;
using HerosAndMostersGUI;
using MazeTest;

namespace DesignPatterns___DC_Design
{
    public class Hero : DungeonCharacter
    {
        private static Hero _heroInstance = null;

        private Hero(string name, Stats stats) : base(name, stats)
        {
        }

        public static Hero GetInstance()
        {
            return _heroInstance ?? (_heroInstance = new Hero(BuildName(), BuildStats()));
        }

        private static Stats BuildStats()
        {
            var result = new Stats(new Dictionary<StatsType, int>
                {
                    {StatsType.MaxHp, 100},
                    {StatsType.CurHp, 100},
                    {StatsType.MaxResources, 100},
                    {StatsType.CurResources, 100},
                    {StatsType.Agility, 0},
                    {StatsType.Defense, 0},
                    {StatsType.Intelegence, 0},
                    {StatsType.Strength, 0}
                });
            return result;
        }

        private static string BuildName()
        {
            return "Stephen";
        }

        public Inventory GetInventory()
        {
            return Player.GetInstance().GetInventory();
        }

        public override void Attack(EnumAttacks type, Target target)
        {
            AttackChain.HandleAttack(type, target, this);
        }
    }
}
