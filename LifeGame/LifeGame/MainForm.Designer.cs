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
            this.cmb_Speed = new System.Windows.Forms.ComboBox();
            this.chk_ShowGridLimits = new System.Windows.Forms.CheckBox();
            this.nud_CellSize = new System.Windows.Forms.NumericUpDown();
            this.chk_UseMeanColor = new System.Windows.Forms.CheckBox();
            this.chk_UseHexagonalGrid = new System.Windows.Forms.CheckBox();
            this.lbl_CurrentIteration = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nud_GridHeight = new System.Windows.Forms.NumericUpDown();
            this.nud_GridWidth = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_NumberOfLivingCells = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bt_NewGrid = new System.Windows.Forms.Button();
            this.bt_StartStop = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.vsc_VerticalScroller = new System.Windows.Forms.VScrollBar();
            this.hsc_HorizontalScroller = new System.Windows.Forms.HScrollBar();
            this.gb_SaveOptions = new System.Windows.Forms.GroupBox();
            this.bt_LoadFrom = new System.Windows.Forms.Button();
            this.bt_SaveTo = new System.Windows.Forms.Button();
            this.gb_GridState = new System.Windows.Forms.GroupBox();
            this.bt_Hecatomb = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Ozone)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_CellSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_GridHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_GridWidth)).BeginInit();
            this.panel2.SuspendLayout();
            this.gb_SaveOptions.SuspendLayout();
            this.gb_GridState.SuspendLayout();
            this.SuspendLayout();
            // 
            // pb_Ozone
            // 
            this.pb_Ozone.BackColor = System.Drawing.Color.White;
            this.pb_Ozone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_Ozone.Location = new System.Drawing.Point(3, 3);
            this.pb_Ozone.Name = "pb_Ozone";
            this.pb_Ozone.Size = new System.Drawing.Size(724, 375);
            this.pb_Ozone.TabIndex = 0;
            this.pb_Ozone.TabStop = false;
            this.pb_Ozone.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pb_Ozone_MouseClick);
            this.pb_Ozone.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pb_Ozone_MouseDown);
            this.pb_Ozone.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pb_Ozone_MouseMove);
            this.pb_Ozone.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pb_Ozone_MouseUp);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cmb_Speed);
            this.panel1.Controls.Add(this.chk_ShowGridLimits);
            this.panel1.Controls.Add(this.nud_CellSize);
            this.panel1.Controls.Add(this.chk_UseMeanColor);
            this.panel1.Controls.Add(this.chk_UseHexagonalGrid);
            this.panel1.Controls.Add(this.lbl_CurrentIteration);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.nud_GridHeight);
            this.panel1.Controls.Add(this.nud_GridWidth);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbl_NumberOfLivingCells);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 431);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(376, 70);
            this.panel1.TabIndex = 1;
            // 
            // cmb_Speed
            // 
            this.cmb_Speed.FormattingEnabled = true;
            this.cmb_Speed.Items.AddRange(new object[] {
            "Slow speed",
            "Medium speed",
            "Max speed"});
            this.cmb_Speed.Location = new System.Drawing.Point(210, 21);
            this.cmb_Speed.Name = "cmb_Speed";
            this.cmb_Speed.Size = new System.Drawing.Size(121, 21);
            this.cmb_Speed.TabIndex = 15;
            this.cmb_Speed.Text = "Max speed";
            // 
            // chk_ShowGridLimits
            // 
            this.chk_ShowGridLimits.AutoSize = true;
            this.chk_ShowGridLimits.Location = new System.Drawing.Point(221, 48);
            this.chk_ShowGridLimits.Name = "chk_ShowGridLimits";
            this.chk_ShowGridLimits.Size = new System.Drawing.Size(98, 17);
            this.chk_ShowGridLimits.TabIndex = 14;
            this.chk_ShowGridLimits.Text = "Show grid limits";
            this.chk_ShowGridLimits.UseVisualStyleBackColor = true;
            // 
            // nud_CellSize
            // 
            this.nud_CellSize.Location = new System.Drawing.Point(159, 22);
            this.nud_CellSize.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nud_CellSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_CellSize.Name = "nud_CellSize";
            this.nud_CellSize.Size = new System.Drawing.Size(45, 20);
            this.nud_CellSize.TabIndex = 13;
            this.nud_CellSize.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nud_CellSize.ValueChanged += new System.EventHandler(this.nud_CellSize_ValueChanged);
            // 
            // chk_UseMeanColor
            // 
            this.chk_UseMeanColor.AutoSize = true;
            this.chk_UseMeanColor.Location = new System.Drawing.Point(115, 48);
            this.chk_UseMeanColor.Name = "chk_UseMeanColor";
            this.chk_UseMeanColor.Size = new System.Drawing.Size(100, 17);
            this.chk_UseMeanColor.TabIndex = 12;
            this.chk_UseMeanColor.Text = "Use mean color";
            this.chk_UseMeanColor.UseVisualStyleBackColor = true;
            this.chk_UseMeanColor.CheckedChanged += new System.EventHandler(this.chk_UseMeanColor_CheckedChanged);
            // 
            // chk_UseHexagonalGrid
            // 
            this.chk_UseHexagonalGrid.AutoSize = true;
            this.chk_UseHexagonalGrid.Location = new System.Drawing.Point(6, 48);
            this.chk_UseHexagonalGrid.Name = "chk_UseHexagonalGrid";
            this.chk_UseHexagonalGrid.Size = new System.Drawing.Size(103, 17);
            this.chk_UseHexagonalGrid.TabIndex = 11;
            this.chk_UseHexagonalGrid.Text = "Create hexa grid";
            this.chk_UseHexagonalGrid.UseVisualStyleBackColor = true;
            // 
            // lbl_CurrentIteration
            // 
            this.lbl_CurrentIteration.AutoSize = true;
            this.lbl_CurrentIteration.Location = new System.Drawing.Point(231, 3);
            this.lbl_CurrentIteration.Name = "lbl_CurrentIteration";
            this.lbl_CurrentIteration.Size = new System.Drawing.Size(0, 13);
            this.lbl_CurrentIteration.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(174, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Iteration :";
            // 
            // nud_GridHeight
            // 
            this.nud_GridHeight.Increment = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nud_GridHeight.Location = new System.Drawing.Point(108, 22);
            this.nud_GridHeight.Maximum = new decimal(new int[] {
            248,
            0,
            0,
            0});
            this.nud_GridHeight.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nud_GridHeight.Name = "nud_GridHeight";
            this.nud_GridHeight.Size = new System.Drawing.Size(45, 20);
            this.nud_GridHeight.TabIndex = 8;
            this.nud_GridHeight.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // nud_GridWidth
            // 
            this.nud_GridWidth.Increment = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nud_GridWidth.Location = new System.Drawing.Point(60, 22);
            this.nud_GridWidth.Maximum = new decimal(new int[] {
            248,
            0,
            0,
            0});
            this.nud_GridWidth.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nud_GridWidth.Name = "nud_GridWidth";
            this.nud_GridWidth.Size = new System.Drawing.Size(45, 20);
            this.nud_GridWidth.TabIndex = 7;
            this.nud_GridWidth.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Grid size :";
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
            // bt_NewGrid
            // 
            this.bt_NewGrid.Location = new System.Drawing.Point(6, 45);
            this.bt_NewGrid.Name = "bt_NewGrid";
            this.bt_NewGrid.Size = new System.Drawing.Size(92, 23);
            this.bt_NewGrid.TabIndex = 5;
            this.bt_NewGrid.Text = "New";
            this.bt_NewGrid.UseVisualStyleBackColor = true;
            this.bt_NewGrid.Click += new System.EventHandler(this.bt_NewGrid_Click);
            // 
            // bt_StartStop
            // 
            this.bt_StartStop.Location = new System.Drawing.Point(6, 19);
            this.bt_StartStop.Name = "bt_StartStop";
            this.bt_StartStop.Size = new System.Drawing.Size(90, 23);
            this.bt_StartStop.TabIndex = 4;
            this.bt_StartStop.Text = "Start";
            this.bt_StartStop.UseVisualStyleBackColor = true;
            this.bt_StartStop.Click += new System.EventHandler(this.bt_StartStop_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.vsc_VerticalScroller);
            this.panel2.Controls.Add(this.hsc_HorizontalScroller);
            this.panel2.Controls.Add(this.pb_Ozone);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(747, 398);
            this.panel2.TabIndex = 2;
            // 
            // vsc_VerticalScroller
            // 
            this.vsc_VerticalScroller.Dock = System.Windows.Forms.DockStyle.Right;
            this.vsc_VerticalScroller.Location = new System.Drawing.Point(730, 0);
            this.vsc_VerticalScroller.Name = "vsc_VerticalScroller";
            this.vsc_VerticalScroller.Size = new System.Drawing.Size(17, 381);
            this.vsc_VerticalScroller.SmallChange = 10;
            this.vsc_VerticalScroller.TabIndex = 2;
            this.vsc_VerticalScroller.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vsc_VerticalScroller_Scroll);
            // 
            // hsc_HorizontalScroller
            // 
            this.hsc_HorizontalScroller.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hsc_HorizontalScroller.Location = new System.Drawing.Point(0, 381);
            this.hsc_HorizontalScroller.Name = "hsc_HorizontalScroller";
            this.hsc_HorizontalScroller.Size = new System.Drawing.Size(747, 17);
            this.hsc_HorizontalScroller.SmallChange = 10;
            this.hsc_HorizontalScroller.TabIndex = 1;
            this.hsc_HorizontalScroller.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsc_HorizontalScroller_Scroll);
            // 
            // gb_SaveOptions
            // 
            this.gb_SaveOptions.Controls.Add(this.bt_LoadFrom);
            this.gb_SaveOptions.Controls.Add(this.bt_SaveTo);
            this.gb_SaveOptions.Location = new System.Drawing.Point(12, 507);
            this.gb_SaveOptions.Name = "gb_SaveOptions";
            this.gb_SaveOptions.Size = new System.Drawing.Size(200, 51);
            this.gb_SaveOptions.TabIndex = 3;
            this.gb_SaveOptions.TabStop = false;
            this.gb_SaveOptions.Text = "Save && Load";
            // 
            // bt_LoadFrom
            // 
            this.bt_LoadFrom.Location = new System.Drawing.Point(102, 19);
            this.bt_LoadFrom.Name = "bt_LoadFrom";
            this.bt_LoadFrom.Size = new System.Drawing.Size(92, 23);
            this.bt_LoadFrom.TabIndex = 1;
            this.bt_LoadFrom.Text = "Load from..";
            this.bt_LoadFrom.UseVisualStyleBackColor = true;
            this.bt_LoadFrom.Click += new System.EventHandler(this.bt_LoadFrom_Click);
            // 
            // bt_SaveTo
            // 
            this.bt_SaveTo.Location = new System.Drawing.Point(6, 19);
            this.bt_SaveTo.Name = "bt_SaveTo";
            this.bt_SaveTo.Size = new System.Drawing.Size(90, 23);
            this.bt_SaveTo.TabIndex = 0;
            this.bt_SaveTo.Text = "Save to..";
            this.bt_SaveTo.UseVisualStyleBackColor = true;
            this.bt_SaveTo.Click += new System.EventHandler(this.bt_SaveTo_Click);
            // 
            // gb_GridState
            // 
            this.gb_GridState.Controls.Add(this.bt_Hecatomb);
            this.gb_GridState.Controls.Add(this.bt_StartStop);
            this.gb_GridState.Controls.Add(this.bt_NewGrid);
            this.gb_GridState.Location = new System.Drawing.Point(394, 431);
            this.gb_GridState.Name = "gb_GridState";
            this.gb_GridState.Size = new System.Drawing.Size(200, 70);
            this.gb_GridState.TabIndex = 4;
            this.gb_GridState.TabStop = false;
            this.gb_GridState.Text = "Grid state";
            // 
            // bt_Hecatomb
            // 
            this.bt_Hecatomb.Location = new System.Drawing.Point(102, 20);
            this.bt_Hecatomb.Name = "bt_Hecatomb";
            this.bt_Hecatomb.Size = new System.Drawing.Size(92, 23);
            this.bt_Hecatomb.TabIndex = 6;
            this.bt_Hecatomb.Text = "Hecatomb";
            this.bt_Hecatomb.UseVisualStyleBackColor = true;
            this.bt_Hecatomb.Click += new System.EventHandler(this.bt_Hecatomb_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 566);
            this.Controls.Add(this.gb_GridState);
            this.Controls.Add(this.gb_SaveOptions);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "Life game";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pb_Ozone)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_CellSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_GridHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_GridWidth)).EndInit();
            this.panel2.ResumeLayout(false);
            this.gb_SaveOptions.ResumeLayout(false);
            this.gb_GridState.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox gb_SaveOptions;
        private System.Windows.Forms.Button bt_LoadFrom;
        private System.Windows.Forms.Button bt_SaveTo;
        private System.Windows.Forms.Label lbl_CurrentIteration;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chk_UseHexagonalGrid;
        private System.Windows.Forms.CheckBox chk_UseMeanColor;
        private System.Windows.Forms.NumericUpDown nud_CellSize;
        private System.Windows.Forms.GroupBox gb_GridState;
        private System.Windows.Forms.Button bt_Hecatomb;
        private System.Windows.Forms.CheckBox chk_ShowGridLimits;
        private System.Windows.Forms.ComboBox cmb_Speed;
    }
}

