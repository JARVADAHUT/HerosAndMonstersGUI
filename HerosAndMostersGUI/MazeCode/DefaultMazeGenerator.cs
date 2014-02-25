using DesignPatterns___DC_Design;
using HerosAndMostersGUI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MazeTest
{
    internal class DefaultMazeGenerator : IMazeGenerator
    {
        public DefaultMazeGenerator()
        {
            

        }

        private const int _minSize = 8;

        #region MazeGeration

        #region 2D Array Generation

        public MazeObject Generate(int size)
        {
            if (size < _minSize)
                throw new FormatException("Maze too small");


            int[][] maze;
            int height = size - 1;
            int width = size - 1;


            maze = new int[size][];
            for (int x = 0; x < size; x++)
                maze[x] = new int[size];
            var walls = new List<string>();
            int wallChoice;
            string coordinates;
            var rnd = new Random();
            maze[1][1] = (int) EnumMazeObject.Air;
            AddWalls(1, 1, walls, maze, height, width);

            while (walls.Count != 0)
            {
                int r, c;
                string temp;

                //randomly select a wall and get it from the list
                wallChoice = rnd.Next(walls.Count);
                coordinates = walls.ElementAt(wallChoice);

                //take the string coordinates and assign them to row and coulumn
                temp = coordinates.Substring(0, coordinates.IndexOf(','));
                r = int.Parse(temp);
                temp = coordinates.Substring(coordinates.IndexOf(',') + 1);
                c = int.Parse(temp);

                //boolean to tell if a path was made and it will try each option if needed

                //make a wall passage if no cell is air on the other side

                //Up
                if ((r + 1) < height && maze[r + 1][c] == (int) EnumMazeObject.Air)
                {
                    //the bounds around the movement are inside the array
                    if ((r - 2) >= 0 && (c - 1) >= 0 && (c + 1) <= width && maze[r][c] == (int) EnumMazeObject.Wall)
                        //the movement is possible if this is true because there is a 1 block radius to any other part
                        if (maze[r][c - 1] == (int) EnumMazeObject.Wall &&
                            /*maze[r - 1][c - 1] == (int)Surface.Wall &&*/
                            maze[r - 1][c] == (int) EnumMazeObject.Wall &&
                            /*maze[r - 1][c + 1] == (int)Surface.Wall &&*/
                            maze[r][c + 1] == (int) EnumMazeObject.Wall)
                        {
                            maze[r][c] = (int) EnumMazeObject.Air;
                            AddWalls(r, c, walls, maze, height, width);
                        }
                }
                    //Down
                else if ((r - 1) > 0 && maze[r - 1][c] == (int) EnumMazeObject.Air)
                {
                    //the bounds around the movement are inside the array
                    if ((r + 1) <= height && (c - 1) >= 0 && (c + 1) <= width)
                        //the movement is possible if this is true because there is a 1 block radius to any other part
                        if (maze[r][c - 1] == (int) EnumMazeObject.Wall &&
                            /*maze[r + 1][c - 1] == (int)Surface.Wall &&*/
                            maze[r + 1][c] == (int) EnumMazeObject.Wall &&
                            /*maze[r + 1][c + 1] == (int)Surface.Wall &&*/
                            maze[r][c + 1] == (int) EnumMazeObject.Wall)
                        {
                            maze[r][c] = (int) EnumMazeObject.Air;
                            AddWalls(r, c, walls, maze, height, width);
                        }
                }
                    //Came from Left
                else if ((c - 1) > 0 && maze[r][c - 1] == (int) EnumMazeObject.Air)
                {
                    //the bounds around the movement are inside the array
                    if ((c + 1) <= width && (r - 1) >= 0 && (r + 1) <= height)
                        //the movement is possible if this is true because there is a 1 block radius to any other part
                        if (maze[r - 1][c] == (int) EnumMazeObject.Wall &&
                            /*maze[r - 1][c + 1] == (int)Surface.Wall &&*/
                            maze[r][c + 1] == (int) EnumMazeObject.Wall &&
                            /*maze[r + 1][c + 1] == (int)Surface.Wall &&*/
                            maze[r + 1][c] == (int) EnumMazeObject.Wall)
                        {
                            maze[r][c] = (int) EnumMazeObject.Air;
                            AddWalls(r, c, walls, maze, height, width);
                        }
                }
                    //Came from Right
                else if ((c + 1) < width && maze[r][c + 1] == (int) EnumMazeObject.Air)
                {
                    //the bounds around the movement are inside the array
                    if ((c - 1) >= 0 && (r - 1) >= 0 && (r + 1) <= height)
                        //the movement is possible if this is true because there is a 1 block radius to any other part
                        if (maze[r - 1][c] == (int) EnumMazeObject.Wall &&
                            /*maze[r - 1][c - 1] == (int)Surface.Wall &&*/
                            maze[r][c - 1] == (int) EnumMazeObject.Wall &&
                            /*maze[r + 1][c - 1] == (int)Surface.Wall &&*/
                            maze[r + 1][c] == (int) EnumMazeObject.Wall)
                        {
                            maze[r][c] = (int) EnumMazeObject.Air;
                            AddWalls(r, c, walls, maze, height, width);
                        }
                }

                //remove wall from the list
                walls.RemoveAt(wallChoice);
            } //end outer while

            //put an exit in the bottom row
            for (int y = width - 1; y > 0; y--)
            {
                if (maze[height - 1][y] == (int) EnumMazeObject.Air && OneWayIn(height - 1, y, maze))
                {
                    maze[height - 1][y] = (int) EnumMazeObject.Exit;
                    break;
                }
            }


            //add chests in the maze randomly -------------------------------------- not so random at the moment

            for (int x = 1; x < height; x++)
            {
                for (int y = 1; y < width; y++)
                {
                    if (OneWayIn(x, y, maze))
                    {
                        int chance = rnd.Next(100);
                        if(chance < 10)
                            maze[x][y] = (int)EnumMazeObject.Chest;
                    }
                }
            }


            //place the player at the start (will always be a valid position)
            maze[1][1] = (int) EnumMazeObject.Player;


            //place monsters here--------------------------------------------------------
            Random rand = new Random();
            int placedCount = 0, monsterCount = (size / 3); // if 10, 3 monsters
            int leftCoord, rightCoord;

            while (placedCount != monsterCount)
            {
                leftCoord = rand.Next(2, size);
                rightCoord = rand.Next(2, size);
                if ((EnumMazeObject)(maze[leftCoord][rightCoord]) == EnumMazeObject.Air)
                {
                    maze[leftCoord][rightCoord] = (int)EnumMazeObject.Monster;
                    placedCount++;
                }
            }

            //turn into node system
            return arrayToGraph(maze);
        }

        private bool OneWayIn(int x, int y, int[][] maze)
        {
            if ((x != 1 || y != 1) && maze[x][y] == (int)EnumMazeObject.Air)
            {
                int numSurfaceAir = 0;

                if (maze[x - 1][y] == (int)EnumMazeObject.Air || maze[x - 1][y] == (int)EnumMazeObject.Chest ||
                    maze[x - 1][y] == (int)EnumMazeObject.Exit)
                    numSurfaceAir++;

                if (maze[x + 1][y] == (int)EnumMazeObject.Air || maze[x + 1][y] == (int)EnumMazeObject.Chest ||
                    maze[x + 1][y] == (int)EnumMazeObject.Exit)
                    numSurfaceAir++;

                if (maze[x][y - 1] == (int)EnumMazeObject.Air || maze[x][y - 1] == (int)EnumMazeObject.Chest ||
                    maze[x][y - 1] == (int)EnumMazeObject.Exit)
                    numSurfaceAir++;

                if (maze[x][y + 1] == (int)EnumMazeObject.Air || maze[x][y + 1] == (int)EnumMazeObject.Chest ||
                    maze[x][y + 1] == (int)EnumMazeObject.Exit)
                    numSurfaceAir++;

                if (numSurfaceAir == 1)
                    return true;
            }
            return false;
        }


        private void AddWalls(int r, int c, List<string> walls, int[][] maze, int height, int width)
        {
            //add wall above
            if ((r - 1) > 0 && (maze[r - 1][c] == (int)EnumMazeObject.Wall))
                if (maze[r - 1][c - 1] == (int)EnumMazeObject.Wall && maze[r - 2][c - 1] == (int)EnumMazeObject.Wall &&
                    maze[r - 2][c] == (int)EnumMazeObject.Wall && maze[r - 2][c + 1] == (int)EnumMazeObject.Wall &&
                    maze[r - 1][c + 1] == (int)EnumMazeObject.Wall && maze[r - 1][c] == (int)EnumMazeObject.Wall)
                    walls.Add("" + (r - 1) + "," + (c));

            //add wall below
            if ((r + 1) < (height) && (maze[r + 1][c] == (int)EnumMazeObject.Wall))
                if (maze[r + 1][c + 1] == (int)EnumMazeObject.Wall && maze[r + 2][c + 1] == (int)EnumMazeObject.Wall &&
                    maze[r + 2][c] == (int)EnumMazeObject.Wall && maze[r + 2][c - 1] == (int)EnumMazeObject.Wall &&
                    maze[r + 1][c - 1] == (int)EnumMazeObject.Wall && maze[r + 1][c] == (int)EnumMazeObject.Wall)
                    walls.Add("" + (r + 1) + "," + (c));

            //add wall to left
            if ((c - 1) > 0 && (maze[r][c - 1] == (int)EnumMazeObject.Wall))
                if (maze[r + 1][c - 1] == (int)EnumMazeObject.Wall && maze[r + 1][c - 2] == (int)EnumMazeObject.Wall &&
                    maze[r][c - 2] == (int)EnumMazeObject.Wall && maze[r - 1][c - 2] == (int)EnumMazeObject.Wall &&
                    maze[r - 1][c - 1] == (int)EnumMazeObject.Wall && maze[r][c - 1] == (int)EnumMazeObject.Wall)
                    walls.Add("" + (r) + "," + (c - 1));

            //add wall to right
            if ((c + 1) < (width) && (maze[r][c + 1] == (int)EnumMazeObject.Wall))
                if (maze[r - 1][c + 1] == (int)EnumMazeObject.Wall && maze[r - 1][c + 2] == (int)EnumMazeObject.Wall &&
                    maze[r][c + 2] == (int)EnumMazeObject.Wall && maze[r + 1][c + 2] == (int)EnumMazeObject.Wall &&
                    maze[r + 1][c + 1] == (int)EnumMazeObject.Wall && maze[r][c + 1] == (int)EnumMazeObject.Wall)
                    walls.Add("" + (r) + "," + (c + 1));
        }

        #endregion

        #region Array To Graph

        private MazeObject arrayToGraph(int[][] maze)
        {
            MazeObject head = null;

            head = FMazeObjectFactory.GetMazeObject(EnumMazeObject.Wall);
          
            MazeObject mainColTracker = head;

            for (int r = 0; r < maze.Length; r++)
            {
                MazeObject rowTracker = mainColTracker;

                for (int c = 0; c < maze[0].Length; c++)
                {

                    if (r < maze.Length - 1)
                    {
                        int down = maze[r + 1][c];
                        if (rowTracker.getSurroundings().GetDown() == null)
                        {
                            rowTracker.getSurroundings().setDown(FMazeObjectFactory.GetMazeObject( (EnumMazeObject) down ) );
                            rowTracker.getSurroundings().GetDown().SetPosition(new Position(c, r + 1));

                            rowTracker.getSurroundings().GetDown().getSurroundings().setUp(rowTracker);

                            if (c > 0)
                            {
                                MazeObject downBelow = rowTracker.getSurroundings().GetDown();
                                MazeObject downLeft = rowTracker.getSurroundings().GetLeft().getSurroundings().GetDown();

                                downBelow.getSurroundings().setLeft(downLeft);
                                downLeft.getSurroundings().setRight(downBelow);
                            }
                        }
                    }


                    if (c < maze[0].Length - 1)
                    {
                        int right = maze[r][c + 1];
                        if (rowTracker.getSurroundings().GetRight() == null)
                        {
                            rowTracker.getSurroundings().setRight( FMazeObjectFactory.GetMazeObject( (EnumMazeObject) right) );
                            rowTracker.getSurroundings().GetRight().SetPosition(new Position(c + 1, r));

                            rowTracker.getSurroundings().GetRight().getSurroundings().setLeft(rowTracker);
                        }
                    }

                    rowTracker = rowTracker.getSurroundings().GetRight();

                }//end inner for

                mainColTracker = mainColTracker.getSurroundings().GetDown();

            }//end outter for


            //Player.getInstance().setPosition( _head.getSurroundings().getDown().getSurroundings().getRight() );


            return head;
        } //end Generate

        

        #endregion

        #endregion

    }
}