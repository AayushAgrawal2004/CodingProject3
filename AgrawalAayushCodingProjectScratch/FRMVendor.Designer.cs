namespace AgrawalAayushCodingProjectScratch
{
    partial class FRMVendor
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
            this.BTNPrevious = new System.Windows.Forms.Button();
            this.BTNNext = new System.Windows.Forms.Button();
            this.BTNSave = new System.Windows.Forms.Button();
            this.BTNClose = new System.Windows.Forms.Button();
            this.CBODefaultDiscount = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TXTContact = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TXTComment = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TXTYTDSales = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TXTPhoneNumber = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TXTZipCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TXTState = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TXTCity = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TXTStreetAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TXTName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BTNPrevious
            // 
            this.BTNPrevious.Location = new System.Drawing.Point(24, 336);
            this.BTNPrevious.Margin = new System.Windows.Forms.Padding(2);
            this.BTNPrevious.Name = "BTNPrevious";
            this.BTNPrevious.Size = new System.Drawing.Size(110, 32);
            this.BTNPrevious.TabIndex = 10;
            this.BTNPrevious.Tag = "FRMVendor";
            this.BTNPrevious.Text = "Previous Vendor";
            this.BTNPrevious.UseVisualStyleBackColor = true;
            this.BTNPrevious.Click += new System.EventHandler(this.BTNPrevious_Click);
            // 
            // BTNNext
            // 
            this.BTNNext.Location = new System.Drawing.Point(160, 336);
            this.BTNNext.Margin = new System.Windows.Forms.Padding(2);
            this.BTNNext.Name = "BTNNext";
            this.BTNNext.Size = new System.Drawing.Size(110, 32);
            this.BTNNext.TabIndex = 11;
            this.BTNNext.Tag = "FRMVendor";
            this.BTNNext.Text = "Next Vendor";
            this.BTNNext.UseVisualStyleBackColor = true;
            this.BTNNext.Click += new System.EventHandler(this.BTNNext_Click);
            // 
            // BTNSave
            // 
            this.BTNSave.Location = new System.Drawing.Point(293, 336);
            this.BTNSave.Margin = new System.Windows.Forms.Padding(2);
            this.BTNSave.Name = "BTNSave";
            this.BTNSave.Size = new System.Drawing.Size(110, 32);
            this.BTNSave.TabIndex = 12;
            this.BTNSave.Tag = "FRMVendor";
            this.BTNSave.Text = "Save Vendor";
            this.BTNSave.UseVisualStyleBackColor = true;
            this.BTNSave.Click += new System.EventHandler(this.BTNSave_Click);
            // 
            // BTNClose
            // 
            this.BTNClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BTNClose.Location = new System.Drawing.Point(427, 336);
            this.BTNClose.Margin = new System.Windows.Forms.Padding(2);
            this.BTNClose.Name = "BTNClose";
            this.BTNClose.Size = new System.Drawing.Size(110, 32);
            this.BTNClose.TabIndex = 13;
            this.BTNClose.Tag = "FRMVendor";
            this.BTNClose.Text = "Close";
            this.BTNClose.UseVisualStyleBackColor = true;
            this.BTNClose.Click += new System.EventHandler(this.BTNClose_Click);
            // 
            // CBODefaultDiscount
            // 
            this.CBODefaultDiscount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBODefaultDiscount.FormattingEnabled = true;
            this.CBODefaultDiscount.Items.AddRange(new object[] {
            "10 Days",
            "15 Days",
            "20 Days"});
            this.CBODefaultDiscount.Location = new System.Drawing.Point(126, 226);
            this.CBODefaultDiscount.Margin = new System.Windows.Forms.Padding(2);
            this.CBODefaultDiscount.Name = "CBODefaultDiscount";
            this.CBODefaultDiscount.Size = new System.Drawing.Size(160, 21);
            this.CBODefaultDiscount.TabIndex = 8;
            this.CBODefaultDiscount.Tag = "Default Discount";
            this.CBODefaultDiscount.SelectedIndexChanged += new System.EventHandler(this.CBODefaultDiscount_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(31, 229);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Default Discount: ";
            // 
            // TXTContact
            // 
            this.TXTContact.Location = new System.Drawing.Point(126, 202);
            this.TXTContact.Margin = new System.Windows.Forms.Padding(2);
            this.TXTContact.Name = "TXTContact";
            this.TXTContact.Size = new System.Drawing.Size(162, 20);
            this.TXTContact.TabIndex = 7;
            this.TXTContact.Tag = "Contact";
            this.TXTContact.TextChanged += new System.EventHandler(this.TXTContact_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(73, 205);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Contact: ";
            // 
            // TXTComment
            // 
            this.TXTComment.Location = new System.Drawing.Point(126, 251);
            this.TXTComment.Margin = new System.Windows.Forms.Padding(2);
            this.TXTComment.Multiline = true;
            this.TXTComment.Name = "TXTComment";
            this.TXTComment.Size = new System.Drawing.Size(411, 76);
            this.TXTComment.TabIndex = 9;
            this.TXTComment.Tag = "Comment";
            this.TXTComment.TextChanged += new System.EventHandler(this.TXTComment_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(67, 254);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Comment: ";
            // 
            // TXTYTDSales
            // 
            this.TXTYTDSales.Location = new System.Drawing.Point(126, 177);
            this.TXTYTDSales.Margin = new System.Windows.Forms.Padding(2);
            this.TXTYTDSales.Name = "TXTYTDSales";
            this.TXTYTDSales.Size = new System.Drawing.Size(162, 20);
            this.TXTYTDSales.TabIndex = 6;
            this.TXTYTDSales.Tag = "YTD Sale";
            this.TXTYTDSales.TextChanged += new System.EventHandler(this.TXTYTDSales_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(64, 180);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "YTD Sale: ";
            // 
            // TXTPhoneNumber
            // 
            this.TXTPhoneNumber.Location = new System.Drawing.Point(126, 153);
            this.TXTPhoneNumber.Margin = new System.Windows.Forms.Padding(2);
            this.TXTPhoneNumber.Name = "TXTPhoneNumber";
            this.TXTPhoneNumber.Size = new System.Drawing.Size(115, 20);
            this.TXTPhoneNumber.TabIndex = 5;
            this.TXTPhoneNumber.Tag = "Phone Number";
            this.TXTPhoneNumber.TextChanged += new System.EventHandler(this.TXTPhoneNumber_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 156);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Phone number:";
            // 
            // TXTZipCode
            // 
            this.TXTZipCode.Location = new System.Drawing.Point(126, 129);
            this.TXTZipCode.Margin = new System.Windows.Forms.Padding(2);
            this.TXTZipCode.Name = "TXTZipCode";
            this.TXTZipCode.Size = new System.Drawing.Size(66, 20);
            this.TXTZipCode.TabIndex = 4;
            this.TXTZipCode.Tag = "Zip Code";
            this.TXTZipCode.TextChanged += new System.EventHandler(this.TXTZipCode_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(70, 132);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Zip Code:";
            // 
            // TXTState
            // 
            this.TXTState.Location = new System.Drawing.Point(126, 105);
            this.TXTState.Margin = new System.Windows.Forms.Padding(2);
            this.TXTState.Name = "TXTState";
            this.TXTState.Size = new System.Drawing.Size(66, 20);
            this.TXTState.TabIndex = 3;
            this.TXTState.Tag = "State";
            this.TXTState.TextChanged += new System.EventHandler(this.TXTState_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(88, 108);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "State:";
            // 
            // TXTCity
            // 
            this.TXTCity.Location = new System.Drawing.Point(126, 81);
            this.TXTCity.Margin = new System.Windows.Forms.Padding(2);
            this.TXTCity.Name = "TXTCity";
            this.TXTCity.Size = new System.Drawing.Size(162, 20);
            this.TXTCity.TabIndex = 2;
            this.TXTCity.Tag = "City";
            this.TXTCity.TextChanged += new System.EventHandler(this.TXTCity_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(96, 84);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "City:";
            // 
            // TXTStreetAddress
            // 
            this.TXTStreetAddress.Location = new System.Drawing.Point(126, 57);
            this.TXTStreetAddress.Margin = new System.Windows.Forms.Padding(2);
            this.TXTStreetAddress.Name = "TXTStreetAddress";
            this.TXTStreetAddress.Size = new System.Drawing.Size(162, 20);
            this.TXTStreetAddress.TabIndex = 1;
            this.TXTStreetAddress.Tag = "Street Address";
            this.TXTStreetAddress.TextChanged += new System.EventHandler(this.TXTStreetAddress_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Street Address:";
            // 
            // TXTName
            // 
            this.TXTName.Location = new System.Drawing.Point(126, 33);
            this.TXTName.Margin = new System.Windows.Forms.Padding(2);
            this.TXTName.Name = "TXTName";
            this.TXTName.Size = new System.Drawing.Size(162, 20);
            this.TXTName.TabIndex = 0;
            this.TXTName.Tag = "Name";
            this.TXTName.TextChanged += new System.EventHandler(this.TXTName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // FRMVendor
            // 
            this.AcceptButton = this.BTNSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BTNClose;
            this.ClientSize = new System.Drawing.Size(595, 395);
            this.ControlBox = false;
            this.Controls.Add(this.CBODefaultDiscount);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.TXTContact);
            this.Controls.Add(this.BTNClose);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.BTNSave);
            this.Controls.Add(this.TXTComment);
            this.Controls.Add(this.BTNNext);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.BTNPrevious);
            this.Controls.Add(this.TXTYTDSales);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TXTName);
            this.Controls.Add(this.TXTPhoneNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TXTStreetAddress);
            this.Controls.Add(this.TXTZipCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TXTCity);
            this.Controls.Add(this.TXTState);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRMVendor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vendors";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FRMVendor_FormClosing);
            this.Load += new System.EventHandler(this.FRMVendor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTNPrevious;
        private System.Windows.Forms.Button BTNNext;
        private System.Windows.Forms.Button BTNSave;
        private System.Windows.Forms.Button BTNClose;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TXTContact;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TXTComment;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TXTYTDSales;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TXTPhoneNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TXTZipCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TXTState;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TXTCity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TXTStreetAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TXTName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CBODefaultDiscount;
    }
}