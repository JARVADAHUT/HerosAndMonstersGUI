using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTest
{
    public class Surroundings
    {
        private MazeObject _left;
        private MazeObject _right;
        private MazeObject _up;
        private MazeObject _down;


        public Surroundings()
        {
            _left = null;
            _right = null;
            _up = null;
            _down = null;
        }


        //setters-------------------------------


        public void setLeft(MazeObject left)
        {
            _left = left;
        }

        public void setRight(MazeObject right)
        {
            _right = right;
        }

        public void setUp(MazeObject up)
        {
            _up = up;
        }

        public void setDown(MazeObject down)
        {
            _down = down;
        }


        //getters-------------------------------


        public MazeObject GetLeft()
        {
            return _left;
        }

        public MazeObject GetRight()
        {
            return _right;
        }

        public MazeObject GetUp()
        {
            return _up;
        }

        public MazeObject GetDown()
        {
            return _down;
        }

    }
}
