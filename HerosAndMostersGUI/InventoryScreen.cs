using DesignPatterns___DC_Design;
using HerosAndMostersGUI.BattleCode;
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

        public InventoryScreen(DispatcherTimer hive, String tabPage)
        {
            // basic construction
            this.KeyPreview = true;
            _hive = hive;

            InitializeComponent();
            InitializeWindowFormat();

            this.ControlBox = false;
            GenerateLists();
            GenerateListPage2();

            if (invItems.Count < 1)
                GenerateDefaultLabels();
            
            // initializiation methods
            SetCurEquippedSelectedLabels(null, null);
            setInventory();
            setCurSelectedBox();
            SetEquippedInventory();
            SetEquippedSelectedBox();
            UpdateCharacterStats(null, null);
            SetProgressColors();

            // EVENTS
            //this.Inventory.DrawItem += new System.Windows.Forms.DrawItemEventHandler(InventoryDrawItem); //<--- InventoryDrawItem needs work
            this.Inventory.SelectedIndexChanged += new EventHandler(setCurSelectedandTradeoffLabels);
            this.EquippedInventory.SelectedIndexChanged += new EventHandler(SetCurEquippedSelectedLabels);
            this.tabControl1.Selected += new TabControlEventHandler(UpdateCharacterStats);
            this.KeyDown += new KeyEventHandler(CheckIfKeyToClose);
            this.Inventory.MouseDoubleClick += new MouseEventHandler(UseDoubleClickedItem);

            // final initialization
            setCurSelectedandTradeoffLabels(null, null);
            tabControl1.TabPages[0].Text = "Item Inventory";
            tabControl1.TabPages[1].Text = "Character";

            this.tabControl1.SelectedTab = tabControl1.TabPages[tabPage];
            this.tabControl1.SelectedTab.Focus();
            if (tabPage.Equals("tabPage1"))
                this.ActiveControl = this.Inventory;
            else
                this.ActiveControl = this.EquippedInventory;

        }

        // INITIALIZATION METHODS --------------------------------------------------------------------------------------------------------------------

        private void InitializeWindowFormat()
        {
            // make window unscalable
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // make window load to center of screen
            this.CenterToScreen();
        }

        private void SetProgressColors()
        {
            healthpbar.ForeColor = Color.FromName("Red");
            manapbar.ForeColor = Color.FromName("Blue");
            globalcdpbar.ForeColor = Color.FromName("Green");
        }

        private void setInventory()
        {
            this.Inventory.Enabled = true;
            this.Inventory.Font = new Font("Microsoft Sans Black", 14.0f, FontStyle.Regular);

            this.EquipedGear.Enabled = true;
            this.EquipedGear.Font = new Font("Microsoft Sans Black", 8.0f, FontStyle.Bold);
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

        private void SetEquippedInventory()
        {
            this.EquippedInventory.Enabled = true;
            this.EquippedInventory.Font = new Font("Microsoft Sans Black", 14.0f, FontStyle.Regular);
        }

        private void SetEquippedSelectedBox()
        {
            CurSelectedEquipStr.Font = new Font(SelectedFont, SelectedSize, SelectedFontStyle);
            CurSelectedEquipAgi.Font = new Font(SelectedFont, SelectedSize, SelectedFontStyle);
            CurSelectedEquipDef.Font = new Font(SelectedFont, SelectedSize, SelectedFontStyle);
            CurSelectedEquipInt.Font = new Font(SelectedFont, SelectedSize, SelectedFontStyle);
            CurSelectedEquipMHP.Font = new Font(SelectedFont, SelectedSize, SelectedFontStyle);
            CurSelectedEquipMMP.Font = new Font(SelectedFont, SelectedSize, SelectedFontStyle);

            CharacterStrLabel.Font = new Font(SelectedFont, SelectedSize, SelectedFontStyle);
            CharacterAgiLabel.Font = new Font(SelectedFont, SelectedSize, SelectedFontStyle);
            CharacterDefLabel.Font = new Font(SelectedFont, SelectedSize, SelectedFontStyle);
            CharacterIntLabel.Font = new Font(SelectedFont, SelectedSize, SelectedFontStyle);
            CharacterMHPLabel.Font = new Font(SelectedFont, SelectedSize, SelectedFontStyle);
            CharacterMMPLabel.Font = new Font(SelectedFont, SelectedSize, SelectedFontStyle);
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

        private void GenerateListPage2()
        {
            EquippedInventory.DataSource = null;

            equiped = new Dictionary<EnumGearSlot, Equipable>(Player.GetInstance().GetEquipedInventory());

            EquippedInventory.DataSource = new BindingSource(equiped, null);
        }

        // FORM WIRED EVENT METHODS ------------------------------------------------------------------------------------------------------

        private void InventoryScreen_Load(object sender, EventArgs e)
        {
            // do nothing
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

        private void Drop_Click(object sender, EventArgs e)
        {
            Player.GetInstance().GetInventory().RemoveItem((InventoryItems)this.Inventory.SelectedItem);

            GenerateLists();

            if (invItems.Count > 0)
                this.Inventory.SelectedIndex = 0;
            else
                GenerateDefaultLabels();

        }

        private void Tab2ExitBtn_Click(object sender, EventArgs e)
        {
            Exit_Click(sender, e);
        }

        private void Equip_Click(object sender, EventArgs e)
        {
            if (this.Inventory.Items.Count > 0)
            {
                InventoryItems itemSelected = (InventoryItems)this.Inventory.SelectedItem;    
                Player.GetInstance().GetInventory().Use(itemSelected);
                GenerateLists();
                GenerateListPage2();
            }
        }

        // EVENT METHODS ----------------------------------------------------------------------------------

        private void InventoryDrawItem(object sender, DrawItemEventArgs e) // <--------------- NOT IMPLEMENTED
        {
            InventoryItems itemTODraw = (InventoryItems)sender;
            if (itemTODraw.GetType() == EnumItemType.Equipable)
            {
                Equipable item = (Equipable)itemTODraw;
                if (item.Name.Contains("Basic"))
                {
                    //e.ForeColor = Color.FromName("DarkSlateGray"); <-- Can't do this because e is readonly
                }
                else if (item.Name.Contains("Common"))
                {

                }
                else if (item.Name.Contains("Uncommon"))
                {

                }
                else if (item.Name.Contains("Rare"))
                {
                   
                }
                else if (item.Name.Contains("Epic"))
                {
                    
                }
                else if (item.Name.Contains("Legendary"))
                {
                   
                }
            }
            else if (itemTODraw.GetType() == EnumItemType.Consumable)
            {
                // do something
            }
            else if (itemTODraw.GetType() == EnumItemType.Dye)
            {
                // do something
            }
        }

        private void UseDoubleClickedItem(object sender, MouseEventArgs e)
        {
            Equip_Click(sender, e);
        }

        private void CheckIfKeyToClose(object sender, KeyEventArgs e) // <--- LEFT AND RIGHT KEYPRESS LOGIC WILL NEED TO CHANGE IF TABS > 2
        {
            Keys keyPressed = e.KeyCode;

            if (keyPressed == Keys.Escape || keyPressed == Keys.C || keyPressed == Keys.I)
                Exit_Click(sender, e);

            if (keyPressed == Keys.Left)
            {
                this.tabControl1.SelectedTab = tabControl1.TabPages["tabPage1"];
                this.tabControl1.TabPages["tabPage1"].Focus();
                this.Inventory.Focus();
            }
            if (keyPressed == Keys.Right)
            {
                this.tabControl1.SelectedTab = tabControl1.TabPages["tabPage2"];
                this.tabControl1.TabPages["tabPage2"].Focus();
                this.EquippedInventory.Focus();
            }

        }

        private void UpdateCharacterStats(object sender, EventArgs e) // chest and forearm might be getting mixed
        {
            //Dictionary<EnumGearSlot, Equipable> curEquippedInv = Player.GetInstance().GetEquipedInventory();

            int charStr = Hero.GetInstance().DCStats.GetStat(StatsType.Strength);
            int charAgi = Hero.GetInstance().DCStats.GetStat(StatsType.Agility);
            int charDef = Hero.GetInstance().DCStats.GetStat(StatsType.Defense);
            int charInt = Hero.GetInstance().DCStats.GetStat(StatsType.Intelegence);
            int charMHP = Hero.GetInstance().DCStats.GetStat(StatsType.MaxHp);
            int charMMP = Hero.GetInstance().DCStats.GetStat(StatsType.MaxResources);

            CharacterStrLabel.Text = "Strength: " + charStr;
            CharacterAgiLabel.Text = "Agility: " + charAgi;
            CharacterDefLabel.Text = "Defense: " + charDef;
            CharacterIntLabel.Text = "Intelligence: " + charInt;
            CharacterMHPLabel.Text = "Max HP: " + charMHP;
            CharacterMMPLabel.Text = "Max MP: " + charMMP;

            int healthVal = Hero.GetInstance().DCStats.GetStat(StatsType.CurHp);
            int manaVal = Hero.GetInstance().DCStats.GetStat(StatsType.CurResources);
            double cdVal = StatAlgorithms.ConvertAgilityToMiliseconds(Hero.GetInstance())/1000; 
            int maxHealth = Hero.GetInstance().DCStats.GetStat(StatsType.MaxHp);
            int maxMana = Hero.GetInstance().DCStats.GetStat(StatsType.MaxResources);
            int maxGlobalCD = 200;

            healthpbar.Maximum = maxHealth;
            manapbar.Maximum = maxMana;
            globalcdpbar.Maximum = maxGlobalCD;

            healthpbar.Value = healthVal;
            manapbar.Value = manaVal;
            cdVal = decimal.ToDouble(decimal.Round(new decimal(cdVal), 2, MidpointRounding.AwayFromZero));
            globalcdpbar.Value = (int)(cdVal*100);

            healthlabel.Text = "Health: " + healthVal + " / " + maxHealth;
            manalabel.Text = "Mana: " + manaVal + " / " + maxMana;
            cdlabel.Text = "Global Cooldown: " + cdVal + " / " + (maxGlobalCD/100);

        }

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
                        Equipable item = (Equipable)(selectedItem);
                        EquipedGear.SelectedIndex = (int)item.Slot;
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
            CurSelectAgiLabel.Text = "Duration: " + selectedItem.GetProperty((StatsType)stat).Duration;
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
            Dye selectedDye = (Dye)selectedItem;

            CurSelectStrLabel.Text = selectedDye.GetDescription();
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

        private void SetCurEquippedSelectedLabels(object sender, EventArgs e)
        {
            if (EquippedInventory.SelectedIndex >= 0)
            {
                Dictionary<EnumGearSlot, Equipable> curEquippedInv = Player.GetInstance().GetEquipedInventory();
                InventoryItems selectedItem = curEquippedInv[(EnumGearSlot)(EquippedInventory.SelectedIndex)];

                CurSelectedEquipStr.Text = "Strength: " + selectedItem.GetProperty(StatsType.Strength).Magnitude;
                CurSelectedEquipAgi.Text = "Agility: " + selectedItem.GetProperty(StatsType.Agility).Magnitude;
                CurSelectedEquipInt.Text = "Intelligence: " + selectedItem.GetProperty(StatsType.Intelegence).Magnitude;
                CurSelectedEquipDef.Text = "Defense: " + selectedItem.GetProperty(StatsType.Defense).Magnitude;
                CurSelectedEquipMHP.Text = "Bonus HP: " + selectedItem.GetProperty(StatsType.MaxHp).Magnitude;
                CurSelectedEquipMMP.Text = "Bonus MP: " + selectedItem.GetProperty(StatsType.MaxResources).Magnitude;
            }
        }

    }
}
