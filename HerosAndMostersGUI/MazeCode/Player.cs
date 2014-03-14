using DesignPatterns___DC_Design;
using HerosAndMostersGUI;
using HerosAndMostersGUI.CharacterCode;
using HerosAndMostersGUI.MazeCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
//using DesignPatterns___DC_Design;

namespace MazeTest
{
    public class Player : LivingCreature
    {
        private static Player _thisPlayer = null;
        private Dictionary<EnumGearSlot, Equipable> equipedGear; // <------- NEWLY ADDED
        private SolidColorBrush _color;
        public string Name { private set; get; }
        private List<EnumAttacks> _attacks; 

        private Player(string name, SolidColorBrush color, List<EnumAttacks> playerAttacks) : base()
        {
            SetInteraction(this);
            equipedGear = new Dictionary<EnumGearSlot, Equipable>(); // <------- NEWLY ADDED
            GenerateBeginningEquipedGear();
            _color = color;
            Name = name;
            _attacks = playerAttacks;
        }
        
        public static Player GetInstance()
        {
            return _thisPlayer;
        }

        public static void MakePlayer(string name, SolidColorBrush color, List<EnumAttacks> playerAttacks)
        {
            _thisPlayer = new Player(name, color, playerAttacks);
        }


        public override void Die()
        {
            Dead = true;
        }

        public List<EnumAttacks> GetAttacks()
        {
            return _attacks;
        }

        public override void Exit()
        {
            Maze maze = Maze.GetInstance();
            this.ResetPosition();
            HiveMind.GetInstance().ClearHive();
            maze.GenerateNext();
            maze.Display();

        }

        public Dictionary<EnumGearSlot, Equipable> GetEquipedInventory() // <------- NEWLY ADDED
        {
            return equipedGear;
        }

        public void SetColor(SolidColorBrush color)
        {
            _color = color;
        }

        #region Private

        private void GenerateBeginningEquipedGear()
        {
            equipedGear = FItemGenerator.GetStarterGear();
        }

        private void ResetPosition()
        {
            _surroundings = new Surroundings();
        }

        #endregion

        #region IInteractionType

        public override EnumMazeObject GetInteractionType()
        {
            return EnumMazeObject.Player;
        }

        public override SolidColorBrush GetColor()
        {
            return _color;
        }

        public override string ToString()
        {
            return Name;
        }

        public override void Interact(LivingCreature lc)
        {
            //if you are interacting with the player you are a monster
            MazeMonster monsterParty = (MazeMonster) lc;

            //Battle
            if (!lc.Dead)
            {
                BattleWindow theBattle = new BattleWindow(monsterParty.GetParty());

                MainWindow.PauseHive();
                theBattle.ShowDialog();

                if (this.Dead)
                {
                    Restart();
                }

                MainWindow.StartHive();

                this.GetInventory().AddItemList(lc.GetInventory());
                lc.Die();
            }
        }

        #endregion

        /*
        public void SwapGear(Gear swapMe)
        {
            Gear gearToUnequip;
            _myEquippedGear.EquippedGear.TryGetValue(swapMe.GearType, out gearToUnequip);

            _creatureInventory.GearContained.Add(gearToUnequip);
            _myEquippedGear.EquippedGear.Remove(swapMe.GearType);

            _myEquippedGear.EquippedGear.Add(swapMe.GearType, swapMe);
        }
        */

        /*
        public IEnumerable<Gear> GetEquippedGear()
        {
            return _myEquippedGear.EquippedGear.Values;
        }
        */

    }
}
