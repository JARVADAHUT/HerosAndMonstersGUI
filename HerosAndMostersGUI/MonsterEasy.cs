using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace HerosAndMostersGUI
{
    public class MonsterEasy : IMonsterType
    {
        SolidColorBrush _color;

        public MonsterEasy()
        {
            _color = Brushes.HotPink;
        }

        public SolidColorBrush GetColor()
        {
            return _color;
        }

        public void GetMonster()
        {
            throw new NotImplementedException();
        }

        public void SetColor(SolidColorBrush newColor)
        {
            _color = newColor;
        }
    }
}
