using DesignPatterns___DC_Design;
using HerosAndMostersGUI;
using HerosAndMostersGUI.CharacterCode;
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
        public bool Dead;
        private EnumDirection _lastMoveDirection;
        protected Inventory _creatureInventory;

        protected LivingCreature() : base(null)
        {
            _creatureInventory = new Inventory();
            Dead = false;
        }

        protected void Restart()//just kills the game
        {
            GameOver gameOverScreen = new GameOver();
            gameOverScreen.ShowDialog();
            MainWindow.CloseMainWindow();
        }

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

        public void Move()
        {
            MazeMover.Move(GetLastMove(), this);
            Hook();
        }

        public void TakeLoot(IEnumerable<InventoryItems> items) 
        {
            _creatureInventory.AddItemList(items);
        }

        public Inventory GetInventory() 
        {
            return _creatureInventory;
        }

        #region Abstract Methods

        public abstract void Die();
        public new abstract SolidColorBrush GetColor();
        public new abstract EnumMazeObject GetInteractionType();
        public new abstract void Interact(LivingCreature lc);
        public new abstract string ToString();

        #endregion

        #region Private Methods

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

        #endregion      

        #region Virtual Methods

        public virtual void Hook()
        {
            
        }

        public virtual void Exit()
        {

        }

        #endregion

    }
}
