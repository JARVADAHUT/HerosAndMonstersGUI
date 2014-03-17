using System;
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
                    {StatsType.MaxResources, 80},
                    {StatsType.CurResources, 80},
                    {StatsType.Agility, 10},
                    {StatsType.Defense, 10},
                    {StatsType.Intelegence, 10},
                    {StatsType.Strength, 10}
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

    }
}
