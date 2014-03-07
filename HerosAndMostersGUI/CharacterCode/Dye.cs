using DesignPatterns___DC_Design;
using MazeTest;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
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
        public String Description { set; get; }

        public Dye(SolidColorBrush color)
        {
            _color = color;
            System.Drawing.Color thisColor = GetColorFromHex(_color.Color.ToString());
            this.Description = thisColor.Name;
        }

        public bool Use()
        {
            Player.GetInstance().SetColor(_color);
            return true;
        }

        public string GetDescription()
        {      
            return "Color: " + this.Description;
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

        // http://stackoverflow.com/questions/7791710/convert-hex-code-to-color-name
        private System.Drawing.Color GetColorFromHex(String hexString)
        {
            return ColorTranslator.FromHtml(hexString);
        }

        public override String ToString()
        {

            return this.Description + " Dye";
        }
    }
}
