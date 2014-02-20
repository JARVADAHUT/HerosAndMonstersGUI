﻿using MazeTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace HerosAndMostersGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMazeDisplay
    {
        private DispatcherTimer _hive = new DispatcherTimer();

        #region Constant Game Properties

        private int _pixelSize;
        private int _constantPixelSize = 10;
        private const int _tickSpeed = 200;
        private const int _firstMazeSize = 12;
        private const int _frameSize = 1000;

        #endregion 

        public MainWindow()
        {
            InitializeComponent();
            Start(); 
        }

        private void Start()
        {
            Maze maze = Maze.GetInstance();
            maze.SetDiplayer(this);
            maze.Generate(_firstMazeSize);
            maze.Display();


            this.KeyDown += new KeyEventHandler(OnButtonKeyDown);
            _hive.Tick += new EventHandler(HiveMind.GetInstance().MoveMinions);
            _hive.Interval = new TimeSpan(0, 0, 0, 0, _tickSpeed);
            _hive.IsEnabled = true;
        }

        private void OnButtonKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.W:
                    Player.GetInstance().Interact(EnumDirection.Up);
                    break;

                case Key.A:
                    Player.GetInstance().Interact(EnumDirection.Left);
                    break;

                case Key.S:
                    Player.GetInstance().Interact(EnumDirection.Down);
                    break;

                case Key.D:
                    Player.GetInstance().Interact(EnumDirection.Right);
                    break;

                case Key.K:
                    HiveMind.GetInstance().ClearHive();
                    break;
            }

            Maze.GetInstance().Refresh(Player.GetInstance());
        }

        #region IMazeDisplay

        private void FitToFrame(int size)
        {
            _pixelSize = ((_frameSize - 38) / size) + 1;

            screen.Height = _frameSize;
            screen.Width = _frameSize - 16;

            Height = MaxHeight = MinHeight = _frameSize;
            Width = MaxWidth = MinWidth = _frameSize - 16;
        }

        private void FitToPixel(int size)
        {
            _pixelSize = _constantPixelSize;

            int screenHeight = 38 + size * _pixelSize;
            int screenWidth = 16 + size * _pixelSize;

            screen.Height = screenHeight;
            screen.Width = screenWidth;

            Height = MaxHeight = MinHeight = screenHeight;
            Width = MaxWidth = MinWidth = screenWidth;
        }

        public void Display(MazeObject maze)
        {
            //Should only do once per maze generation-----------------------

            int size = 0;

            MazeObject displayCol = maze;

            while (displayCol != null)
            {
                displayCol = displayCol.getSurroundings().GetRight();
                size++;
            }

            //can pick based off preference
            FitToFrame(size);
            //FitToPixel(size);

            //Should only do once per maze generation-----------------------

            displayCol = maze;

            int leftRightPosition = 0;
            int upDownPosition = 0;

            screen.Children.Clear();

            while (displayCol != null)
            {

                MazeObject displayRow = displayCol;
                while (displayRow != null)
                {
                    Rectangle mazeThing = new Rectangle();
                    screen.Children.Add(mazeThing);

                    mazeThing.Height = _pixelSize;
                    mazeThing.Width = _pixelSize;
                    mazeThing.Fill = displayRow.GetColor();
                    

                    Canvas.SetLeft(mazeThing, leftRightPosition);
                    Canvas.SetTop(mazeThing, upDownPosition);

                    displayRow = displayRow.getSurroundings().GetRight();

                    leftRightPosition += _pixelSize;
                }

                displayCol = displayCol.getSurroundings().GetDown();
                upDownPosition += _pixelSize;
                leftRightPosition = 0;
            }

        }

        public void Refresh(LivingCreature refresher)
        {
            MazeObjectRefresh(refresher);

            //try to make very large maze's more efficient
            if(refresher.GetLastMove() == EnumDirection.Left || refresher.GetLastMove() == EnumDirection.Right)
            {
                MazeObjectRefresh(refresher.getSurroundings().GetLeft());
                MazeObjectRefresh(refresher.getSurroundings().GetRight());
            }

            else
            {
                MazeObjectRefresh(refresher.getSurroundings().GetDown());
                MazeObjectRefresh(refresher.getSurroundings().GetUp());
            }
        }

        public void MazeObjectRefresh(MazeObject refresher)
        {

            Rectangle replacement = new Rectangle();
            replacement.Height = _pixelSize;
            replacement.Width = _pixelSize;
            replacement.Fill = refresher.GetColor();

            int left = refresher.GetPosition().GetX() * _pixelSize;
            int top = refresher.GetPosition().GetY() * _pixelSize;

            Canvas.SetLeft(replacement, left);
            Canvas.SetTop(replacement, top);

            foreach (Rectangle rec in screen.Children)
            {
                if (Canvas.GetLeft(rec) == left && Canvas.GetTop(rec) == top)
                {
                    screen.Children.Remove(rec);
                    screen.Children.Add(replacement);
                    break;
                }
            }

        }

        #endregion

    }
}
