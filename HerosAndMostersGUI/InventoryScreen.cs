using DesignPatterns___DC_Design;
using HerosAndMostersGUI.CharacterCode;
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

        List<InventoryItems> equiped;
        List<InventoryItems> invItems;

        // consts
        private const float CurSelectedSize = 13.0f;
        private const String CurSelectedFont = "Microsoft Sans Black";

        public InventoryScreen(DispatcherTimer hive)
        {
            _hive = hive;
            InitializeComponent();
            this.ControlBox = false;
            GenerateLists();

            if (invItems.Count > 0)
            {
                this.Inventory.SelectedIndex = 0;
            }
            else
            {
                GenerateDefaultLabels();
            }

            setInventory();
            setCurSelectedBox();


            // EVENTS
            //this.Inventory.DrawItem += new System.Windows.Forms.DrawItemEventHandler(Inventory_DrawItem); //<--- allows variable font and text color
            this.Inventory.SelectedIndexChanged += new EventHandler(setCurSelectedandTradeoffLabels);

            // final initialization
            setCurSelectedandTradeoffLabels(null, null);

        }


        private void setInventory()
        {
            this.Inventory.Enabled = true;
            this.Inventory.Font = new Font("Microsoft Sans Black", 14.0f, FontStyle.Regular);
        }

        private void setCurSelectedBox()
        {
            CurSelectStrLabel.Font = new Font(CurSelectedFont, CurSelectedSize, FontStyle.Bold);
            CurSelectAgiLabel.Font = new Font(CurSelectedFont, CurSelectedSize, FontStyle.Bold);
            CurSelectIntLabel.Font = new Font(CurSelectedFont, CurSelectedSize, FontStyle.Bold);
            CurSelectDefLabel.Font = new Font(CurSelectedFont, CurSelectedSize, FontStyle.Bold);
            CurSelectMHPLabel.Font = new Font(CurSelectedFont, CurSelectedSize, FontStyle.Bold);
        }

        private void GenerateLists()
        {
            EquipedGear.DataSource = null;
            Inventory.DataSource = null;

            invItems = new List<InventoryItems>(Player.GetInstance().GetInventory());

            EquipedGear.DataSource = equiped;
            Inventory.DataSource = invItems;

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

        // EVENT METHODS ----------------------------------------------------------------------------------

        private void setCurSelectedandTradeoffLabels(object sender, EventArgs e) // <---- NEED TO GET AT STATS HERE
        {
            if (invItems.Count > 0)
            {
                try
                {
                    InventoryItems selectedItem = (InventoryItems)this.Inventory.SelectedItem;
                    CurSelectStrLabel.Text = "Strength: " + selectedItem.GetProperties().ElementAt((int)(StatsType.Strength) - 2).Magnitude;
                    CurSelectAgiLabel.Text = "Agility: " + selectedItem.GetProperties().ElementAt((int)(StatsType.Agility) - 2).Magnitude;
                    CurSelectIntLabel.Text = "Intelligence: " + selectedItem.GetProperties().ElementAt((int)(StatsType.Intelegence) - 2).Magnitude;
                    CurSelectDefLabel.Text = "Defense: " + selectedItem.GetProperties().ElementAt((int)(StatsType.Defense) - 2).Magnitude;
                    CurSelectMHPLabel.Text = "+Max HP: " + selectedItem.GetProperties().ElementAt((int)(StatsType.MaxHp) - 2).Magnitude;
                }
                catch (NullReferenceException)
                {

                }
            }
        }

        private void GenerateDefaultLabels()
        {
            CurSelectStrLabel.Text = "No Item Selected.";
            CurSelectAgiLabel.Text = "No Item Selected.";
            CurSelectIntLabel.Text = "No Item Selected.";
            CurSelectDefLabel.Text = "No Item Selected.";
            CurSelectMHPLabel.Text = "No Item Selected.";

        }

        private void Drop_Click(object sender, EventArgs e)
        {
            Player.GetInstance().GetInventory().RemoveItem((InventoryItems)this.Inventory.SelectedItem);

            GenerateLists();

            if (invItems.Count > 0)
                this.Inventory.SelectedIndex = 0;
            else
                GenerateDefaultLabels();

        }

    }
}
