using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DesignPatterns___DC_Design;
using MazeTest;

namespace HerosAndMostersGUI
{
    /// <summary>
    /// Interaction logic for CharacterSelect.xaml
    /// </summary>
    public partial class CharacterSelect : Window
    {
        private List<EnumAttacks> attacks;
        private List<EnumAttacks> allAttacks = new List<EnumAttacks>();

        public CharacterSelect()
        {
            //allAttacks.Add(EnumAttacks.IceCone);
            //allAttacks.Add(EnumAttacks.Fireball);
            //allAttacks.Add(EnumAttacks.PitifulHeal);
            //allAttacks.Add(EnumAttacks.WeakAttack);
            //allAttacks.Add(EnumAttacks.StrongAttack);

            //AblSelect.Items.Add(allAttacks[0].Name);
            //AblSelect.SelectedIndex = 0;
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)CharGreen.IsChecked)
            {
                Player.MakePlayer("Kip Springfield", Brushes.LawnGreen, attacks);
            }
            if ((bool)CharRed.IsChecked)
            {
                Player.MakePlayer("Tom Wilde", Brushes.Red, attacks);
            }
            if ((bool)CharPurple.IsChecked)
            {
                Player.MakePlayer("El Benatar", Brushes.Purple, attacks);
            }

            this.Close();
            //Player.MakePlayer();
        }

    }
}
