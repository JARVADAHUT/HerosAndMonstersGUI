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
            // No button calls this, not implemented
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

                    //tradeoff calculations
                    if (selectedItem.GetType() == EnumItemType.Equipable) //<---DEBUG----DEBUG : Get rid of this when potion tab is implemented ------DEBUG-----DEBUG-------DEBUG----------DEBUG----------DEBUG-------DEBUG-----------
                    {
                        SetCurAndTradeoffForEquipable(selectedItem);
                    }
                    else if (selectedItem.GetType() == EnumItemType.Consumable)
                    {
                        SetCurAndTradeoffForConsumable(selectedItem);
                    }
                    else if (selectedItem.GetType() == EnumItemType.Dye)
                    {
                        SetCurAndTradeoffForDye(selectedItem);
                    }
                }
                catch (NullReferenceException)
                {
                    // write this out to text file for debugging
                }
            }
        }

        private void SetCurAndTradeoffForEquipable(InventoryItems selectedItem)
        {
            CurSelectStrLabel.Text = "Strength: " + selectedItem.GetProperty(StatsType.Strength).Magnitude;
            CurSelectAgiLabel.Text = "Agility: " + selectedItem.GetProperty(StatsType.Agility).Magnitude;
            CurSelectIntLabel.Text = "Intelligence: " + selectedItem.GetProperty(StatsType.Intelegence).Magnitude;
            CurSelectDefLabel.Text = "Defense: " + selectedItem.GetProperty(StatsType.Defense).Magnitude;
            CurSelectMHPLabel.Text = "Bonus HP: " + selectedItem.GetProperty(StatsType.MaxHp).Magnitude;
            CurSelectMMPLabel.Text = "Bonus MP: " + selectedItem.GetProperty(StatsType.MaxResources).Magnitude;

            EnumGearSlot selectedType = ((Equipable)selectedItem).Slot;
            int tStr = (selectedItem.GetProperty(StatsType.Strength).Magnitude) - (equiped[selectedType].GetProperty(StatsType.Strength).Magnitude);
            int tAgi = (selectedItem.GetProperty(StatsType.Agility).Magnitude) - (equiped[selectedType].GetProperty(StatsType.Agility).Magnitude);
            int tInt = (selectedItem.GetProperty(StatsType.Intelegence).Magnitude) - (equiped[selectedType].GetProperty(StatsType.Intelegence).Magnitude);
            int tDef = (selectedItem.GetProperty(StatsType.Defense).Magnitude) - (equiped[selectedType].GetProperty(StatsType.Defense).Magnitude);
            int tMHP = (selectedItem.GetProperty(StatsType.MaxHp).Magnitude) - (equiped[selectedType].GetProperty(StatsType.MaxHp).Magnitude);
            int tMMP = (selectedItem.GetProperty(StatsType.MaxResources).Magnitude) - (equiped[selectedType].GetProperty(StatsType.MaxResources).Magnitude);

            // tradeoff adjustments
            TradeoffStrLabel.Text = "Strength: " + tStr;
            TradeoffAgiLabel.Text = "Agility: " + tAgi;
            TradeoffIntLabel.Text = "Intelligence: " + tInt;
            TradeoffDefLabel.Text = "Defense: " + tDef;
            TradeoffMHPLabel.Text = "Bonus HP: " + tMHP;
            TradeoffMMPLabel.Text = "Bonus MP: " + tMMP;

            SetTradeoffColors(tStr, tAgi, tInt, tDef, tMHP, tMMP);

            this.Equip.Text = "Equip";
        }

        private void SetCurAndTradeoffForConsumable(InventoryItems selectedItem)
        {
            Consumable potion = (Consumable)selectedItem;
            int stat = -1; // DEFAULT VALUE

            foreach (EffectInformation effect in potion.Properties)
            {
                if (effect.Magnitude > 0)
                    stat = (int)effect.Stat;
            }

            CurSelectStrLabel.Text = potion.GetDescription() + ": " + selectedItem.GetProperty((StatsType)stat).Magnitude;
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

            this.Equip.Text = "Drink";
        }

        private void SetCurAndTradeoffForDye(InventoryItems selectedItem)
        {
            // WILL HAVE LOGIC HERE TO DETERMINE WHAT TYPE OF COLOR DYE EFFECTS

            CurSelectStrLabel.Text = "Dye Color: Not Implemented";
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

            this.Equip.Text = "Apply";
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

        private void Equip_Click(object sender, EventArgs e)
        {
            GenericItems itemSelected = (GenericItems)(this.Inventory.SelectedItem);        // <---------- MAY CHANGE BACK TO EQUIPABLE TYPE  
            Player.GetInstance().GetInventory().Use(itemSelected);
            GenerateLists();
        }

    }
}
