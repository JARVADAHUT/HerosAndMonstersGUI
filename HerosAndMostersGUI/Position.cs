using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerosAndMostersGUI
{
    public class Position
    {
        private int _xPosition;
        private int _yPosition;

        public Position(int x, int y)
        {
            _xPosition = x;
            _yPosition = y;
        }

        public int GetX()
        {
            return _xPosition;
        }

        public int GetY()
        {
            return _yPosition;
        }

        public void SetX(int x)
        {
            _xPosition = x;
        }

        public void SetY(int y)
        {
            _yPosition = y;
        }

    }
}
