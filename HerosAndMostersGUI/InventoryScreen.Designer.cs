using System.Windows.Threading;
namespace HerosAndMostersGUI
{
    partial class InventoryScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.EquipedGear = new System.Windows.Forms.ListBox();
            this.Drop = new System.Windows.Forms.Button();
            this.Inventory = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Swap = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.CurSelectStrLabel = new System.Windows.Forms.Label();
            this.CurSelectAgiLabel = new System.Windows.Forms.Label();
            this.CurSelectDefLabel = new System.Windows.Forms.Label();
            this.CurSelectIntLabel = new System.Windows.Forms.Label();
            this.CurSelectMHPLabel = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(570, 586);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.EquipedGear);
            this.tabPage1.Controls.Add(this.Drop);
            this.tabPage1.Controls.Add(this.Inventory);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.Swap);
            this.tabPage1.Controls.Add(this.Exit);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(562, 560);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // EquipedGear
            // 
            this.EquipedGear.FormattingEnabled = true;
            this.EquipedGear.Location = new System.Drawing.Point(6, 6);
            this.EquipedGear.Name = "EquipedGear";
            this.EquipedGear.Size = new System.Drawing.Size(200, 186);
            this.EquipedGear.TabIndex = 15;
            // 
            // Drop
            // 
            this.Drop.Location = new System.Drawing.Point(234, 507);
            this.Drop.Name = "Drop";
            this.Drop.Size = new System.Drawing.Size(93, 36);
            this.Drop.TabIndex = 14;
            this.Drop.Text = "Drop";
            this.Drop.UseVisualStyleBackColor = true;
            // 
            // Inventory
            // 
            this.Inventory.BackColor = System.Drawing.SystemColors.Window;
            this.Inventory.ForeColor = System.Drawing.SystemColors.InfoText;
            this.Inventory.FormattingEnabled = true;
            this.Inventory.Location = new System.Drawing.Point(234, 6);
            this.Inventory.Name = "Inventory";
            this.Inventory.Size = new System.Drawing.Size(322, 485);
            this.Inventory.TabIndex = 13;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CurSelectMHPLabel);
            this.groupBox2.Controls.Add(this.CurSelectIntLabel);
            this.groupBox2.Controls.Add(this.CurSelectDefLabel);
            this.groupBox2.Controls.Add(this.CurSelectAgiLabel);
            this.groupBox2.Controls.Add(this.CurSelectStrLabel);
            this.groupBox2.Location = new System.Drawing.Point(6, 201);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 173);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Currently Selected Gear";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(6, 380);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 174);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Stat Tradeoffs";
            // 
            // Swap
            // 
            this.Swap.Location = new System.Drawing.Point(344, 507);
            this.Swap.Name = "Swap";
            this.Swap.Size = new System.Drawing.Size(93, 36);
            this.Swap.TabIndex = 10;
            this.Swap.Text = "Swap";
            this.Swap.UseVisualStyleBackColor = true;
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(453, 507);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(103, 36);
            this.Exit.TabIndex = 9;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(562, 560);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // CurSelectStrLabel
            // 
            this.CurSelectStrLabel.AutoSize = true;
            this.CurSelectStrLabel.Location = new System.Drawing.Point(7, 20);
            this.CurSelectStrLabel.Name = "CurSelectStrLabel";
            this.CurSelectStrLabel.Size = new System.Drawing.Size(59, 13);
            this.CurSelectStrLabel.TabIndex = 0;
            this.CurSelectStrLabel.Text = "Strength: 0";
            // 
            // CurSelectAgiLabel
            // 
            this.CurSelectAgiLabel.AutoSize = true;
            this.CurSelectAgiLabel.Location = new System.Drawing.Point(7, 46);
            this.CurSelectAgiLabel.Name = "CurSelectAgiLabel";
            this.CurSelectAgiLabel.Size = new System.Drawing.Size(46, 13);
            this.CurSelectAgiLabel.TabIndex = 1;
            this.CurSelectAgiLabel.Text = "Agility: 0";
            // 
            // CurSelectDefLabel
            // 
            this.CurSelectDefLabel.AutoSize = true;
            this.CurSelectDefLabel.Location = new System.Drawing.Point(7, 72);
            this.CurSelectDefLabel.Name = "CurSelectDefLabel";
            this.CurSelectDefLabel.Size = new System.Drawing.Size(59, 13);
            this.CurSelectDefLabel.TabIndex = 2;
            this.CurSelectDefLabel.Text = "Defense: 0";
            // 
            // CurSelectIntLabel
            // 
            this.CurSelectIntLabel.AutoSize = true;
            this.CurSelectIntLabel.Location = new System.Drawing.Point(6, 101);
            this.CurSelectIntLabel.Name = "CurSelectIntLabel";
            this.CurSelectIntLabel.Size = new System.Drawing.Size(73, 13);
            this.CurSelectIntLabel.TabIndex = 3;
            this.CurSelectIntLabel.Text = "Intelligence: 0";
            // 
            // CurSelectMHPLabel
            // 
            this.CurSelectMHPLabel.AutoSize = true;
            this.CurSelectMHPLabel.Location = new System.Drawing.Point(7, 125);
            this.CurSelectMHPLabel.Name = "CurSelectMHPLabel";
            this.CurSelectMHPLabel.Size = new System.Drawing.Size(63, 13);
            this.CurSelectMHPLabel.TabIndex = 4;
            this.CurSelectMHPLabel.Text = "+Max HP: 0";
            // 
            // InventoryScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 611);
            this.Controls.Add(this.tabControl1);
            this.Name = "InventoryScreen";
            this.Text = "Inventory";
            this.Load += new System.EventHandler(this.InventoryScreen_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListBox EquipedGear;
        private System.Windows.Forms.Button Drop;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Swap;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox Inventory;
        private System.Windows.Forms.Label CurSelectMHPLabel;
        private System.Windows.Forms.Label CurSelectIntLabel;
        private System.Windows.Forms.Label CurSelectDefLabel;
        private System.Windows.Forms.Label CurSelectAgiLabel;
        private System.Windows.Forms.Label CurSelectStrLabel;

    }
}