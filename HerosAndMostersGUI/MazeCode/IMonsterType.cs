using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace HerosAndMostersGUI
{
    public interface IMonsterType
    {
        SolidColorBrush GetColor();
        void SetColor(SolidColorBrush brush);
        void GetMonster();
    }
}
