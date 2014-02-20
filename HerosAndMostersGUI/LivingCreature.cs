using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
//using DesignPatterns___DC_Design;

namespace MazeTest
{
    public abstract class LivingCreature : MazeObject, IInteractionType
    {
        //protected DungeonCharacter dc;

        private EnumDirection _lastMoveDirection;


        protected LivingCreature() : base(null)
        {

        }

        public abstract void Die();
        public abstract void Exit();
        public new abstract SolidColorBrush GetColor();
        public new abstract EnumMazeObject GetInteractionType();
        public new abstract void Interact(LivingCreature lc);
        public new abstract string ToString();


        public void Interact(EnumDirection dir)
        {
            this.SetLastMove(dir);
            MazeObject interaction = GetInteractionObject(dir);
            interaction.Interact(this);
        }

        public void SetLastMove(EnumDirection dir)
        {
            _lastMoveDirection = dir;
        }

        public EnumDirection GetLastMove()
        {
            return _lastMoveDirection;
        }

        //could this go somewhere else? -- where?
        private MazeObject GetInteractionObject(EnumDirection dir)
        {
            switch (dir)
            {
                case EnumDirection.Up:
                    return _surroundings.GetUp();

                case EnumDirection.Down:
                    return _surroundings.GetDown();

                case EnumDirection.Left:
                    return _surroundings.GetLeft();

                case EnumDirection.Right:
                    return _surroundings.GetRight();

                default:
                    throw new FieldAccessException();
            }
        }

        public void Move()
        {
            MazeMover.Move(GetLastMove(), this);
            Hook();
        }

        public virtual void Hook()
        {
            
        }

    }
}
