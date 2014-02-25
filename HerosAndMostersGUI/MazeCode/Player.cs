using DesignPatterns___DC_Design;
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
        //private EquippedGearInventory _myEquippedGear;

        private Player() : base()
        {
            SetInteraction(this);
            //_myEquippedGear = new EquippedGearInventory();
        }
        
        public static Player GetInstance()
        {
            return _thisPlayer ?? (_thisPlayer = new Player());
        }

        public override void Die()
        {
            
        }

        public override void Exit()
        {
            Maze maze = Maze.GetInstance();
            this.ResetPosition();
            HiveMind.GetInstance().ClearHive();
            maze.GenerateNext();
            maze.Display();

        }

        #region Private

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
            return Brushes.LawnGreen;
        }

        public override string ToString()
        {
            return "p";
        }

        public override void Interact(LivingCreature lc)
        {
            lc.Die();
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
