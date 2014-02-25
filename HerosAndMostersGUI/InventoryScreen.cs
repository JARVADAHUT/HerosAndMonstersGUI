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

        // <------------------------------------------------- NESTED CLASS FOR TESTING ONLY

        List<NestedStats> equiped;
        List<NestedStats> invItems;

        internal class NestedStats
        {
            public int Str { get; set; }
            public int Agi { get; set; }
            public int Int { get; set; }
            public int Def { get; set; }

            public NestedStats(int str, int agi, int intel, int def)
            {
                this.Str = str;
                this.Agi = agi;
                this.Int = intel;
                this.Def = def;
            }

            public override String ToString()
            {
                return "Strength: " + this.Str + ", Agility: " + this.Agi + ", Intelect: " + this.Int + ", Defense: " + this.Def;
            }

        }

        void generateLists()
        {
            Random rnd = new Random();
            equiped = new List<NestedStats>();
            invItems = new List<NestedStats>();

            for (int x = 0; x < 6; x++)
                equiped.Add(new NestedStats(rnd.Next(20), rnd.Next(20), rnd.Next(20), rnd.Next(20)));
            for (int x = 0; x < 15; x++)
                invItems.Add(new NestedStats(rnd.Next(20), rnd.Next(20), rnd.Next(20), rnd.Next(20)));
        }

        // <------------------------------------------------- NESTED CLASS FOR TESTING ONLY

        public InventoryScreen(DispatcherTimer hive)
        {
            _hive = hive;
            InitializeComponent();
            this.ControlBox = false;
            generateLists(); // <------------------------------ REMOVE 

            EquipedGear.DataSource = equiped;
            Inventory.DataSource = invItems;

            //EquipedGear.DataSource = Player.GetInstance().GetEquippedGear();
            //InventoryItems.DataSource = Player.GetInstance().

        }

        private void InventoryScreen_Load(object sender, EventArgs e)
        {
       
        }

        private void Swap_Click(object sender, EventArgs e)
        {
            // not implemented
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            _hive.IsEnabled = true;
            Dispose(true);
        }
    }
}
