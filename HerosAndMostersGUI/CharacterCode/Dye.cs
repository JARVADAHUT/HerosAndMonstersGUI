using DesignPatterns___DC_Design;
using MazeTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace HerosAndMostersGUI.CharacterCode
{
    public class Dye : InventoryItems
    {
        SolidColorBrush _color;
        EnumItemType _type;

        public Dye(SolidColorBrush color)
        {
            _color = color;
        }

        public bool Use()
        {
            Player.GetInstance().SetColor(_color);
            return true;
        }

        public string GetDescription()
        {
            return "Dye yourself " + _color.ToString();
        }

        public List<EffectInformation> GetProperties()
        {
            throw new NotImplementedException();
        }

        public EffectInformation GetProperty(DesignPatterns___DC_Design.StatsType type)
        {
            throw new NotImplementedException();
        }

        public void SetType(DesignPatterns___DC_Design.EnumItemType type)
        {
            _type = type;
        }

        public new DesignPatterns___DC_Design.EnumItemType GetType()
        {
            return _type;
        }

        public string GetName()
        {
            return _color.ToString() + " dye";
        }
    }
}
