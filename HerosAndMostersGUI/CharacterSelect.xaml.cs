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
using System.Windows.Interop;
using System.Runtime.InteropServices;

namespace HerosAndMostersGUI
{
    /// <summary>
    /// Interaction logic for CharacterSelect.xaml
    /// </summary>
    public partial class CharacterSelect : Window
    {

        #region Get Rid Of Controlbox

        private const int GWL_STYLE = -16;
        private const int WS_SYSMENU = 0x00080000;

        [DllImport("user32.dll")]
        private extern static int SetWindowLong(IntPtr hwnd, int index, int value);
        [DllImport("user32.dll")]
        private extern static int GetWindowLong(IntPtr hwnd, int index);

        #endregion

        private List<EnumAttacks> attacks = new List<EnumAttacks>();
        private List<EnumAttacks> allAttacks = new List<EnumAttacks>();

        public CharacterSelect()
        {
            SourceInitialized += MainWindow_SourceInitialized;
            InitializeComponent();

            allAttacks.AddRange(EnumAttacks.AttacksList);

            /*
            allAttacks.Add(EnumAttacks.Fireball);
            allAttacks.Add(EnumAttacks.IceCone);
            allAttacks.Add(EnumAttacks.PitifulHeal);
            allAttacks.Add(EnumAttacks.StrongAttack);
            allAttacks.Add(EnumAttacks.StrongAttack);
            allAttacks.Add(EnumAttacks.StrongAttack);
            */

            AblSelect.ItemsSource = allAttacks;
            CharAbl.ItemsSource = attacks;

            AblSelect.SelectedIndex = 0;
            
         
        }

        void MainWindow_SourceInitialized(object sender, EventArgs e)
        {
            WindowInteropHelper wih = new WindowInteropHelper(this);
            int style = GetWindowLong(wih.Handle, GWL_STYLE);
            SetWindowLong(wih.Handle, GWL_STYLE, style & ~WS_SYSMENU);
        }
        

        private void Button_Click_Ready(object sender, RoutedEventArgs e)
        {
            if (attacks.Count == 4)
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
            }
            else
                MessageBox.Show("Choose 4 abilities before proceeding!");
            //Player.MakePlayer();
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            if (AblSelect.SelectedIndex > -1 && attacks.Count < 4)
            {
                attacks.Add(allAttacks.ElementAt<EnumAttacks>(AblSelect.SelectedIndex));
                allAttacks.RemoveAt(AblSelect.SelectedIndex);

                AblSelect.ItemsSource = null;
                AblSelect.ItemsSource = allAttacks;

                CharAbl.ItemsSource = null;
                CharAbl.ItemsSource = attacks;

                if (allAttacks.Count > 0)
                    AblSelect.SelectedIndex = 0;
                CharAbl.SelectedIndex = 0;
            }
        }

        private void Button_Click_Remove(object sender, RoutedEventArgs e)
        {
            if (CharAbl.SelectedIndex > -1)
            {
                allAttacks.Add(attacks.ElementAt<EnumAttacks>(CharAbl.SelectedIndex));
                attacks.RemoveAt(CharAbl.SelectedIndex);

                AblSelect.ItemsSource = null;
                AblSelect.ItemsSource = allAttacks;

                CharAbl.ItemsSource = null;
                CharAbl.ItemsSource = attacks;

                if (attacks.Count > 0)
                    CharAbl.SelectedIndex = 0;
            }
        }

    }
}
