namespace LifeGame
{
    partial class GridLoadingForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.pgb_BitsLoaded = new System.Windows.Forms.ProgressBar();
            this.pgb_CellsCreated = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(435, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "The grid is being loaded. Please wait during this operation that could take sever" +
    "al seconds.\r\nLoading may be long because there are tons of cells to create.";
            // 
            // pgb_BitsLoaded
            // 
            this.pgb_BitsLoaded.Location = new System.Drawing.Point(57, 65);
            this.pgb_BitsLoaded.Name = "pgb_BitsLoaded";
            this.pgb_BitsLoaded.Size = new System.Drawing.Size(394, 37);
            this.pgb_BitsLoaded.TabIndex = 1;
            // 
            // pgb_CellsCreated
            // 
            this.pgb_CellsCreated.Location = new System.Drawing.Point(57, 108);
            this.pgb_CellsCreated.Name = "pgb_CellsCreated";
            this.pgb_CellsCreated.Size = new System.Drawing.Size(394, 37);
            this.pgb_CellsCreated.TabIndex = 2;
            // 
            // GridLoadingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(499, 192);
            this.Controls.Add(this.pgb_CellsCreated);
            this.Controls.Add(this.pgb_BitsLoaded);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "GridLoadingForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Loading grid...";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GridLoadingForm_FormClosed);
            this.Shown += new System.EventHandler(this.GridLoadingForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar pgb_BitsLoaded;
        private System.Windows.Forms.ProgressBar pgb_CellsCreated;
    }
}