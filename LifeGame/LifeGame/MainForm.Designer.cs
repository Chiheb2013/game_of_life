namespace LifeGame
{
    partial class MainForm
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
            this.pb_Ozone = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.nud_GridHeight = new System.Windows.Forms.NumericUpDown();
            this.nud_GridWidth = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_NewGrid = new System.Windows.Forms.Button();
            this.bt_StartStop = new System.Windows.Forms.Button();
            this.lbl_NumberOfLivingCells = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.vsc_VerticalScroller = new System.Windows.Forms.VScrollBar();
            this.hsc_HorizontalScroller = new System.Windows.Forms.HScrollBar();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Ozone)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_GridHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_GridWidth)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pb_Ozone
            // 
            this.pb_Ozone.BackColor = System.Drawing.Color.White;
            this.pb_Ozone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_Ozone.Location = new System.Drawing.Point(3, 3);
            this.pb_Ozone.Name = "pb_Ozone";
            this.pb_Ozone.Size = new System.Drawing.Size(565, 375);
            this.pb_Ozone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pb_Ozone.TabIndex = 0;
            this.pb_Ozone.TabStop = false;
            this.pb_Ozone.Paint += new System.Windows.Forms.PaintEventHandler(this.pb_Ozone_Paint);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.nud_GridHeight);
            this.panel1.Controls.Add(this.nud_GridWidth);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.bt_NewGrid);
            this.panel1.Controls.Add(this.bt_StartStop);
            this.panel1.Controls.Add(this.lbl_NumberOfLivingCells);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(138, 416);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(376, 51);
            this.panel1.TabIndex = 1;
            // 
            // nud_GridHeight
            // 
            this.nud_GridHeight.Location = new System.Drawing.Point(111, 26);
            this.nud_GridHeight.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nud_GridHeight.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_GridHeight.Name = "nud_GridHeight";
            this.nud_GridHeight.Size = new System.Drawing.Size(45, 20);
            this.nud_GridHeight.TabIndex = 8;
            this.nud_GridHeight.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // nud_GridWidth
            // 
            this.nud_GridWidth.Location = new System.Drawing.Point(60, 26);
            this.nud_GridWidth.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nud_GridWidth.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_GridWidth.Name = "nud_GridWidth";
            this.nud_GridWidth.Size = new System.Drawing.Size(45, 20);
            this.nud_GridWidth.TabIndex = 7;
            this.nud_GridWidth.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Grid size :";
            // 
            // bt_NewGrid
            // 
            this.bt_NewGrid.Location = new System.Drawing.Point(296, 23);
            this.bt_NewGrid.Name = "bt_NewGrid";
            this.bt_NewGrid.Size = new System.Drawing.Size(75, 23);
            this.bt_NewGrid.TabIndex = 5;
            this.bt_NewGrid.Text = "New";
            this.bt_NewGrid.UseVisualStyleBackColor = true;
            this.bt_NewGrid.Click += new System.EventHandler(this.bt_NewGrid_Click);
            // 
            // bt_StartStop
            // 
            this.bt_StartStop.Location = new System.Drawing.Point(296, 3);
            this.bt_StartStop.Name = "bt_StartStop";
            this.bt_StartStop.Size = new System.Drawing.Size(75, 23);
            this.bt_StartStop.TabIndex = 4;
            this.bt_StartStop.Text = "Start";
            this.bt_StartStop.UseVisualStyleBackColor = true;
            this.bt_StartStop.Click += new System.EventHandler(this.bt_StartStop_Click);
            // 
            // lbl_NumberOfLivingCells
            // 
            this.lbl_NumberOfLivingCells.AutoSize = true;
            this.lbl_NumberOfLivingCells.Location = new System.Drawing.Point(105, 3);
            this.lbl_NumberOfLivingCells.Name = "lbl_NumberOfLivingCells";
            this.lbl_NumberOfLivingCells.Size = new System.Drawing.Size(0, 13);
            this.lbl_NumberOfLivingCells.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Number of cells :";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.vsc_VerticalScroller);
            this.panel2.Controls.Add(this.hsc_HorizontalScroller);
            this.panel2.Controls.Add(this.pb_Ozone);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(588, 398);
            this.panel2.TabIndex = 2;
            // 
            // vsc_VerticalScroller
            // 
            this.vsc_VerticalScroller.Dock = System.Windows.Forms.DockStyle.Right;
            this.vsc_VerticalScroller.Location = new System.Drawing.Point(571, 0);
            this.vsc_VerticalScroller.Name = "vsc_VerticalScroller";
            this.vsc_VerticalScroller.Size = new System.Drawing.Size(17, 381);
            this.vsc_VerticalScroller.SmallChange = 5;
            this.vsc_VerticalScroller.TabIndex = 2;
            this.vsc_VerticalScroller.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vsc_VerticalScroller_Scroll);
            // 
            // hsc_HorizontalScroller
            // 
            this.hsc_HorizontalScroller.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hsc_HorizontalScroller.Location = new System.Drawing.Point(0, 381);
            this.hsc_HorizontalScroller.Name = "hsc_HorizontalScroller";
            this.hsc_HorizontalScroller.Size = new System.Drawing.Size(588, 17);
            this.hsc_HorizontalScroller.SmallChange = 5;
            this.hsc_HorizontalScroller.TabIndex = 1;
            this.hsc_HorizontalScroller.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsc_HorizontalScroller_Scroll);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 479);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "Life game";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pb_Ozone)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_GridHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_GridWidth)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_Ozone;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bt_StartStop;
        private System.Windows.Forms.Label lbl_NumberOfLivingCells;
        private System.Windows.Forms.Button bt_NewGrid;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.VScrollBar vsc_VerticalScroller;
        private System.Windows.Forms.HScrollBar hsc_HorizontalScroller;
        private System.Windows.Forms.NumericUpDown nud_GridHeight;
        private System.Windows.Forms.NumericUpDown nud_GridWidth;
        private System.Windows.Forms.Label label1;
    }
}

