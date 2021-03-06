﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MazeTest
{
    public class Maze
    {

        #region Attributes

        //singleton object
        private static Maze _thisMaze = null;

        private IMazeDisplay _displayer;
        private MazeObject _theMaze;
        private IMazeGenerator _mazeGen;
        private int _lastSize;

        public int MazeLevel { private set; get; }

        private readonly int _sizeIncreasePerMaze = 2;

        #endregion

        private Maze()
        {
            _displayer = new DefaultMazeDisplay();
            _mazeGen = new DefaultMazeGenerator();
            MazeLevel = 0;
        }

        public static Maze GetInstance()
        {
            return _thisMaze ?? (_thisMaze = new Maze());
        }

        #region Generation

        public void Generate(int size)
        {
            _theMaze = _mazeGen.Generate(size);
            _lastSize = size;
        }

        public void SetGenerator(IMazeGenerator mazeGen)
        {
            _mazeGen = mazeGen;
        }

        public void GenerateNext()
        {
            _lastSize += _sizeIncreasePerMaze;
            MazeLevel++;

            _theMaze = _mazeGen.Generate(_lastSize);
        }

        #endregion

        #region Display

        public void SetDiplayer(IMazeDisplay mazeDesp)
        {
            _displayer = mazeDesp;
        }

        public void Refresh(LivingCreature changed)
        {
            _displayer.Refresh(changed);
        }

        public void Display()
        {
            _displayer.Display(_theMaze);
        }

        #endregion

    }
}
