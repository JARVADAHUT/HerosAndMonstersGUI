using HerosAndMostersGUI;
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
        private EquippedGearInventory _myEquippedGear;

        private Player() : base()
        {
            SetInteraction(this);
            _myEquippedGear = new EquippedGearInventory();
        }

        public IEnumerable<Gear> GetEquippedGear()
        {
            return _myEquippedGear.EquippedGear.Values;
        }

        public static Player GetInstance()
        {
            return _thisPlayer ?? (_thisPlayer = new Player());
        }

        public void SwapGear(Gear swapMe)
        {
            Gear gearToUnequip;
            _myEquippedGear.EquippedGear.TryGetValue(swapMe.GearType, out gearToUnequip);

            _creatureInventory.GearContained.Add(gearToUnequip);
            _myEquippedGear.EquippedGear.Remove(swapMe.GearType);

            _myEquippedGear.EquippedGear.Add(swapMe.GearType, swapMe);
        }

        public override void Die()
        {
            
        }

        public override string ToString()
        {
            return "p";
        }

        public override void Interact(LivingCreature l)
        {
            l.Die();
        }


        public override void Exit()
        {
            Maze maze = Maze.GetInstance();
            this.ResetPosition();
            HiveMind.GetInstance().ClearHive();
            maze.GenerateNext();
            maze.Display();

        }

        private void ResetPosition()
        {
            _surroundings = new Surroundings();
        }

        public override EnumMazeObject GetInteractionType()
        {
            return EnumMazeObject.Player;
        }

        public override SolidColorBrush GetColor()
        {
            return Brushes.LawnGreen;
        }
    }
}
