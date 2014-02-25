using MazeTest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace HerosAndMostersGUI
{
    public partial class InventoryScreen : Form
    {
        DispatcherTimer _hive;

        public InventoryScreen(DispatcherTimer hive)
        {
            _hive = hive;
            InitializeComponent();

            //EquipedGear.DataSource = Player.GetInstance().GetEquippedGear();
            //InventoryItems.DataSource = Player.GetInstance().

        }

        private void InventoryScreen_Load(object sender, EventArgs e)
        {

        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            _hive.IsEnabled = true;
            this.Close();  
        }

        private void Swap_Click(object sender, EventArgs e)
        {
            // not implemented
        }
    }
}
