﻿using DesignPatterns___DC_Design;
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

        //List<InventoryItems> equiped;
        private Dictionary<EnumGearSlot, Equipable> equiped;
        List<InventoryItems> invItems;

        // consts
        private const float SelectedSize = 13.0f;
        private const String SelectedFont = "Microsoft Sans Black";
        private const FontStyle SelectedFontStyle = FontStyle.Regular;

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
            tabControl1.TabPages[0].Text = "Item Inventory";
            tabControl1.TabPages[1].Text = "Consumables";

        }


        private void setInventory()
        {
            this.Inventory.Enabled = true;
            this.Inventory.Font = new Font("Microsoft Sans Black", 14.0f, FontStyle.Regular);

            this.EquipedGear.Enabled = true;
            this.EquipedGear.Font = new Font("Microsoft Sans Black", 10.0f, FontStyle.Regular);
        }

        private void setCurSelectedBox()
        {
            CurSelectStrLabel.Font = new Font(SelectedFont, SelectedSize, SelectedFontStyle);
            CurSelectAgiLabel.Font = new Font(SelectedFont, SelectedSize, SelectedFontStyle);
            CurSelectIntLabel.Font = new Font(SelectedFont, SelectedSize, SelectedFontStyle);
            CurSelectDefLabel.Font = new Font(SelectedFont, SelectedSize, SelectedFontStyle);
            CurSelectMHPLabel.Font = new Font(SelectedFont, SelectedSize, SelectedFontStyle);
            CurSelectMMPLabel.Font = new Font(SelectedFont, SelectedSize, SelectedFontStyle);

            TradeoffStrLabel.Font = new Font(SelectedFont, SelectedSize, SelectedFontStyle);
            TradeoffAgiLabel.Font = new Font(SelectedFont, SelectedSize, SelectedFontStyle);
            TradeoffIntLabel.Font = new Font(SelectedFont, SelectedSize, SelectedFontStyle);
            TradeoffDefLabel.Font = new Font(SelectedFont, SelectedSize, SelectedFontStyle);
            TradeoffMHPLabel.Font = new Font(SelectedFont, SelectedSize, SelectedFontStyle);
            TradeoffMMPLabel.Font = new Font(SelectedFont, SelectedSize, SelectedFontStyle);
        }

        private void GenerateLists()
        {
            EquipedGear.DataSource = null;
            Inventory.DataSource = null;

            invItems = new List<InventoryItems>(Player.GetInstance().GetInventory());
            equiped = new Dictionary<EnumGearSlot, Equipable>(Player.GetInstance().GetEquipedInventory());

            EquipedGear.DataSource = new BindingSource(equiped, null);
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

        private void setCurSelectedandTradeoffLabels(object sender, EventArgs e) 
        {
            if (invItems.Count > 0)
            {
                try
                {
                    // curSelect adjustments
                    InventoryItems selectedItem = (InventoryItems)this.Inventory.SelectedItem;
                    CurSelectStrLabel.Text = "Strength: " + selectedItem.GetProperties().ElementAt((int)(StatsType.Strength) - 2).Magnitude;
                    CurSelectAgiLabel.Text = "Agility: " + selectedItem.GetProperties().ElementAt((int)(StatsType.Agility) - 2).Magnitude;
                    CurSelectIntLabel.Text = "Intelligence: " + selectedItem.GetProperties().ElementAt((int)(StatsType.Intelegence) - 2).Magnitude;
                    CurSelectDefLabel.Text = "Defense: " + selectedItem.GetProperties().ElementAt((int)(StatsType.Defense) - 2).Magnitude;
                    CurSelectMHPLabel.Text = "Bonus HP: " + selectedItem.GetProperties().ElementAt((int)(StatsType.MaxHp) - 2).Magnitude;
                    CurSelectMMPLabel.Text = "Bonus MP: " + selectedItem.GetProperties().ElementAt((int)(StatsType.MaxResources) - 2).Magnitude;

                    //tradeoff calculations
                    EnumGearSlot selectedType = ((Equipable)selectedItem).Slot;
                    int tStr = (selectedItem.GetProperties().ElementAt((int)(StatsType.Strength) - 2).Magnitude) - (equiped[selectedType].Properties.ElementAt((int)(StatsType.Strength) - 2).Magnitude);
                    int tAgi = (selectedItem.GetProperties().ElementAt((int)(StatsType.Agility) - 2).Magnitude) - (equiped[selectedType].Properties.ElementAt((int)(StatsType.Agility) - 2).Magnitude);
                    int tInt = (selectedItem.GetProperties().ElementAt((int)(StatsType.Intelegence) - 2).Magnitude) - (equiped[selectedType].Properties.ElementAt((int)(StatsType.Intelegence) - 2).Magnitude);
                    int tDef = (selectedItem.GetProperties().ElementAt((int)(StatsType.Defense) - 2).Magnitude) - (equiped[selectedType].Properties.ElementAt((int)(StatsType.Defense) - 2).Magnitude);
                    int tMHP = (selectedItem.GetProperties().ElementAt((int)(StatsType.MaxHp) - 2).Magnitude) - (equiped[selectedType].Properties.ElementAt((int)(StatsType.MaxHp) - 2).Magnitude);
                    int tMMP = (selectedItem.GetProperties().ElementAt((int)(StatsType.MaxResources) - 2).Magnitude) - (equiped[selectedType].Properties.ElementAt((int)(StatsType.MaxResources) - 2).Magnitude);

                    // tradeoff adjustments
                    TradeoffStrLabel.Text = "Strength: " + tStr;
                    TradeoffAgiLabel.Text = "Agility: " + tAgi;
                    TradeoffIntLabel.Text = "Intelligence: " + tInt;
                    TradeoffDefLabel.Text = "Defense: " + tDef;
                    TradeoffMHPLabel.Text = "Bonus HP: " + tMHP;
                    TradeoffMMPLabel.Text = "Bonus MP: " + tMMP;

                    SetTradeoffColors(tStr, tAgi, tInt, tDef, tMHP, tMMP);
                }
                catch (NullReferenceException)
                {

                }
            }
        }

        private void SetTradeoffColors(int str, int agi, int intel, int def, int mhp, int mmp) // <--- should be refactored
        {
            if (str > 0)
                TradeoffStrLabel.ForeColor = System.Drawing.Color.Green;
            else if (str == 0)
                TradeoffStrLabel.ForeColor = System.Drawing.Color.Black;
            else
                TradeoffStrLabel.ForeColor = System.Drawing.Color.Red;

            if (agi > 0)
                TradeoffAgiLabel.ForeColor = System.Drawing.Color.Green;
            else if (agi == 0)
                TradeoffAgiLabel.ForeColor = System.Drawing.Color.Black;
            else
                TradeoffAgiLabel.ForeColor = System.Drawing.Color.Red;

            if (intel > 0)
                TradeoffIntLabel.ForeColor = System.Drawing.Color.Green;
            else if (intel == 0)
                TradeoffIntLabel.ForeColor = System.Drawing.Color.Black;
            else
                TradeoffIntLabel.ForeColor = System.Drawing.Color.Red;

            if (def > 0)
                TradeoffDefLabel.ForeColor = System.Drawing.Color.Green;
            else if (def == 0)
                TradeoffDefLabel.ForeColor = System.Drawing.Color.Black;
            else
                TradeoffDefLabel.ForeColor = System.Drawing.Color.Red;

            if (mhp > 0)
                TradeoffMHPLabel.ForeColor = System.Drawing.Color.Green;
            else if (mhp == 0)
                TradeoffMHPLabel.ForeColor = System.Drawing.Color.Black;
            else
                TradeoffMHPLabel.ForeColor = System.Drawing.Color.Red;

            if (mmp > 0)
                TradeoffMMPLabel.ForeColor = System.Drawing.Color.Green;
            else if (mmp == 0)
                TradeoffMMPLabel.ForeColor = System.Drawing.Color.Black;
            else
                TradeoffMMPLabel.ForeColor = System.Drawing.Color.Red;
        }

        private void GenerateDefaultLabels()
        {
            CurSelectStrLabel.Text = "";
            CurSelectAgiLabel.Text = "";
            CurSelectIntLabel.Text = "";
            CurSelectDefLabel.Text = "";
            CurSelectMHPLabel.Text = "";
            CurSelectMMPLabel.Text = "";

            TradeoffStrLabel.Text = "";
            TradeoffAgiLabel.Text = "";
            TradeoffIntLabel.Text = "";
            TradeoffDefLabel.Text = "";
            TradeoffMHPLabel.Text = "";
            TradeoffMMPLabel.Text = "";

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
