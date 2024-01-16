namespace AgrawalAayushCodingProjectScratch
{
    partial class FRMInventory
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
            this.LBXInventory = new System.Windows.Forms.ListBox();
            this.BTNExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LBXInventory
            // 
            this.LBXInventory.FormattingEnabled = true;
            this.LBXInventory.ItemHeight = 16;
            this.LBXInventory.Location = new System.Drawing.Point(43, 37);
            this.LBXInventory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LBXInventory.Name = "LBXInventory";
            this.LBXInventory.Size = new System.Drawing.Size(401, 372);
            this.LBXInventory.TabIndex = 0;
            // 
            // BTNExit
            // 
            this.BTNExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BTNExit.Location = new System.Drawing.Point(201, 442);
            this.BTNExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BTNExit.Name = "BTNExit";
            this.BTNExit.Size = new System.Drawing.Size(85, 34);
            this.BTNExit.TabIndex = 1;
            this.BTNExit.Text = "Exit";
            this.BTNExit.UseVisualStyleBackColor = true;
            this.BTNExit.Click += new System.EventHandler(this.BTNExit_Click);
            // 
            // FRMInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BTNExit;
            this.ClientSize = new System.Drawing.Size(503, 546);
            this.ControlBox = false;
            this.Controls.Add(this.BTNExit);
            this.Controls.Add(this.LBXInventory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRMInventory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventory";
            this.Load += new System.EventHandler(this.FRMInventory_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox LBXInventory;
        private System.Windows.Forms.Button BTNExit;
    }
}