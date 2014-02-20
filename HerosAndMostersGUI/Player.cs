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

        private Player() : base()
        {
            SetInteraction(this);
            //this.dc = new Hero();
        }

        public static Player GetInstance()
        {
            return _thisPlayer ?? (_thisPlayer = new Player());
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
