using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns___DC_Design;

namespace HerosAndMostersGUI.BattleCode
{
    public class BattleBuilder
    {
        private List<Monster> _monsterList;
        private MonsterTurnManager _monsterTurnManager;

        public BattleBuilder()
        {
            _monsterList = new List<Monster>();
            _monsterTurnManager = new MonsterTurnManager();
        }

        public void AddMonsters(IEnumerable<int> monsterList)
        {
            foreach (var x in monsterList)
            {
                _monsterList.Add(MonsterFactory.GetInstance().GetMonster(x));
            }

            _monsterTurnManager.RegisterMonsters(_monsterList);
            
        }

        public void StartBattle()
        {
            _monsterTurnManager.Start(); //Placeholder, possibly move to form
        }
    }
}
