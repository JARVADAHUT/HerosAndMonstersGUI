using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTest
{
    class DefaultMazeDisplay : IMazeDisplay
    {
        public DefaultMazeDisplay()
        {

        }

        public void Display(MazeObject head)
        {
            Console.Clear();
            MazeObject displayCol = head;

            while(displayCol != null)//for (int x = 0; x < maze.Length; x++)
            {
  
                MazeObject displayRow = displayCol;
                while (displayRow != null)
                {
                    Console.Write(displayRow);

                    displayRow = displayRow.getSurroundings().GetRight();
                }

                displayCol = displayCol.getSurroundings().GetDown();
                Console.WriteLine();
            }
        }

        //public void DebugDisplay(MazeObject head)
        //{
        //    //Console.Clear();
        //    MazeObject displayCol = head;

        //    bool hadNull = false;

        //    while (displayCol != null)//for (int x = 0; x < maze.Length; x++)
        //    {

        //        MazeObject displayRow = displayCol;
        //        while (displayRow != null)
        //        {
        //            if (displayRow.getSurroundings().IsDownNull() && displayRow.ToString().Equals("a"))
        //            {
        //                Console.Write("x");
        //                hadNull = true;
        //            }
        //            else
        //                Console.Write(displayRow);

        //            displayRow = displayRow.getSurroundings().GetRight();
        //        }

        //        displayCol = displayCol.getSurroundings().GetDown();
        //        Console.WriteLine();
        //    }

        //    if(hadNull)
        //        Console.WriteLine("There was a null down reference");
        //}



        public void Refresh(LivingCreature changed)
        {
            throw new NotImplementedException();
        }
    }
}
