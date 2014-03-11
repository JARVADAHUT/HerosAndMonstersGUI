using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
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

        private void MainWindow_SourceInitialized(object sender, EventArgs e)
        {
            WindowInteropHelper wih = new WindowInteropHelper(this);
            int style = GetWindowLong(wih.Handle, GWL_STYLE);
            SetWindowLong(wih.Handle, GWL_STYLE, style & ~WS_SYSMENU);
        }

        #endregion

        private List<EnumAttacks> attacks = new List<EnumAttacks>();
        private List<EnumAttacks> allAttacks = new List<EnumAttacks>();

        private MediaPlayer _mediaPlayer;

        public CharacterSelect()
        {
            SourceInitialized += MainWindow_SourceInitialized;
            InitializeComponent();

            AblSelect.SelectionChanged += AblSelect_SelectionChanged;

            #region Music Stuff

            var basePath = new Uri(Assembly.GetEntryAssembly().Location);
            var uri = new Uri(basePath , "Resources/intro.mp3");
            _mediaPlayer = new MediaPlayer();
            _mediaPlayer.Open(uri); //Maybe this can be placed somewhere else?
            _mediaPlayer.Play();
            
            #endregion

            #region Other Startup Things

            allAttacks.AddRange(EnumAttacks.AttacksList);

            AblSelect.ItemsSource = allAttacks;
            CharAbl.ItemsSource = attacks;

            AblSelect.SelectedIndex = 0;

            this.KeyDown += new KeyEventHandler(Key_Down);

            #endregion

        }

        private void AblSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(AblSelect.SelectedIndex > -1)
                txtDescriptions.Text = allAttacks.ElementAt<EnumAttacks>(AblSelect.SelectedIndex).Description;
        }
        

        private void Key_Down(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left:
                    btnRemove.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.Right:
                    btnAdd.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;
                case Key.Up:
                    UpRadioButton();
                    break;
                case Key.Down:
                    DownRadioButton();
                    break;
                case Key.F:
                    btnReady.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;


            }
        }

        private void DownRadioButton()
        {
            if ((bool)rb1.IsChecked)
                rb2.IsChecked = true;
            else if ((bool)rb2.IsChecked)
                rb3.IsChecked = true;
            else
                rb1.IsChecked = true;
        }

        private void UpRadioButton()
        {
            if ((bool)rb1.IsChecked)
                rb3.IsChecked = true;
            else if ((bool)rb2.IsChecked)
                rb1.IsChecked = true;
            else
                rb2.IsChecked = true;
        }

        private void Button_Click_Ready(object sender, RoutedEventArgs e)
        {
            if (attacks.Count == 4)
            {
                if ((bool)rb1.IsChecked)
                {
                    Player.MakePlayer("Kip Springfield", Brushes.LawnGreen, attacks);
                }
                if ((bool)rb2.IsChecked)
                {
                    Player.MakePlayer("Tom Wilde", Brushes.Green, attacks);
                }
                if ((bool)rb3.IsChecked)
                {
                    Player.MakePlayer("El Benatar", Brushes.GreenYellow, attacks);
                }

                for (double i = .5; i > 0.0; i -= .03)
                {
                    Thread.Sleep(100);
                    _mediaPlayer.Volume = i;
                }

                _mediaPlayer.Stop();

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
