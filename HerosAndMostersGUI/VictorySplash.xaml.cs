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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace HerosAndMostersGUI
{
    /// <summary>
    /// Interaction logic for VictorySplash.xaml
    /// </summary>
    public partial class VictorySplash : Window
    {
        private DispatcherTimer dt;

        public VictorySplash()
        {
            InitializeComponent();
            dt = new DispatcherTimer();
            dt.Tick += new EventHandler(OnTick);
            dt.Interval = new TimeSpan(0, 0, 0, 0, 300);
            dt.IsEnabled = true;
        }

        private void OnTick(object sender, EventArgs e)
        {
            MainWindow.BackgroundMusicPlayer.Volume = 0.0;
            MainWindow.BackgroundMusicPlayer.Play();

            for (var v = 0.0; v <= .5; v += 0.02)
            {
                MainWindow.BackgroundMusicPlayer.Volume = v;
                Thread.Sleep(100);
            }
            dt.IsEnabled = false;
            this.Close();
        }
    }
}
