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
            this.Exit = new System.Windows.Forms.Button();
            this.Swap = new System.Windows.Forms.Button();
            this.InventoryItems = new System.Windows.Forms.DataGridView();
            this.EquipedGear = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.InventoryItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EquipedGear)).BeginInit();
            this.SuspendLayout();
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(322, 423);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(75, 23);
            this.Exit.TabIndex = 0;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // Swap
            // 
            this.Swap.Location = new System.Drawing.Point(241, 423);
            this.Swap.Name = "Swap";
            this.Swap.Size = new System.Drawing.Size(75, 23);
            this.Swap.TabIndex = 1;
            this.Swap.Text = "Swap";
            this.Swap.UseVisualStyleBackColor = true;
            this.Swap.Click += new System.EventHandler(this.Swap_Click);
            // 
            // InventoryItems
            // 
            this.InventoryItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InventoryItems.Location = new System.Drawing.Point(221, 12);
            this.InventoryItems.Name = "InventoryItems";
            this.InventoryItems.Size = new System.Drawing.Size(176, 405);
            this.InventoryItems.TabIndex = 2;
            // 
            // EquipedGear
            // 
            this.EquipedGear.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EquipedGear.Location = new System.Drawing.Point(12, 12);
            this.EquipedGear.Name = "EquipedGear";
            this.EquipedGear.Size = new System.Drawing.Size(176, 200);
            this.EquipedGear.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(15, 346);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Stat Tradeoffs";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(15, 227);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Currently Selected Gear";
            // 
            // InventoryScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 458);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.EquipedGear);
            this.Controls.Add(this.InventoryItems);
            this.Controls.Add(this.Swap);
            this.Controls.Add(this.Exit);
            this.Name = "InventoryScreen";
            this.Text = "Inventory";
            this.Load += new System.EventHandler(this.InventoryScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.InventoryItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EquipedGear)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Button Swap;
        private System.Windows.Forms.DataGridView InventoryItems;
        private System.Windows.Forms.DataGridView EquipedGear;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}