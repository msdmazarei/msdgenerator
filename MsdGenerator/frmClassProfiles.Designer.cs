namespace MsdGenerator
{
    partial class frmClassProfiles
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cboSIDSF = new System.Windows.Forms.ComboBox();
            this.cboSIUseAsProfile = new System.Windows.Forms.ComboBox();
            this.cboSIProfiles = new System.Windows.Forms.ComboBox();
            this.cboSIProperties = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lstProperties = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label5 = new System.Windows.Forms.Label();
            this.cboProfileFilter = new System.Windows.Forms.ComboBox();
            this.btnManageDSF = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnManageDSF);
            this.groupBox1.Controls.Add(this.btnDel);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.cboSIDSF);
            this.groupBox1.Controls.Add(this.cboSIUseAsProfile);
            this.groupBox1.Controls.Add(this.cboSIProfiles);
            this.groupBox1.Controls.Add(this.cboSIProperties);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(506, 161);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selected Item";
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(366, 67);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 6;
            this.btnDel.Text = "Delete";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(366, 38);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cboSIDSF
            // 
            this.cboSIDSF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSIDSF.FormattingEnabled = true;
            this.cboSIDSF.Location = new System.Drawing.Point(88, 115);
            this.cboSIDSF.Name = "cboSIDSF";
            this.cboSIDSF.Size = new System.Drawing.Size(227, 21);
            this.cboSIDSF.TabIndex = 4;
            // 
            // cboSIUseAsProfile
            // 
            this.cboSIUseAsProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSIUseAsProfile.FormattingEnabled = true;
            this.cboSIUseAsProfile.Location = new System.Drawing.Point(88, 91);
            this.cboSIUseAsProfile.Name = "cboSIUseAsProfile";
            this.cboSIUseAsProfile.Size = new System.Drawing.Size(227, 21);
            this.cboSIUseAsProfile.TabIndex = 3;
            // 
            // cboSIProfiles
            // 
            this.cboSIProfiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSIProfiles.FormattingEnabled = true;
            this.cboSIProfiles.Location = new System.Drawing.Point(69, 54);
            this.cboSIProfiles.Name = "cboSIProfiles";
            this.cboSIProfiles.Size = new System.Drawing.Size(227, 21);
            this.cboSIProfiles.TabIndex = 2;
            // 
            // cboSIProperties
            // 
            this.cboSIProperties.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSIProperties.FormattingEnabled = true;
            this.cboSIProperties.Location = new System.Drawing.Point(61, 22);
            this.cboSIProperties.Name = "cboSIProperties";
            this.cboSIProperties.Size = new System.Drawing.Size(227, 21);
            this.cboSIProperties.TabIndex = 1;
            this.cboSIProperties.SelectedIndexChanged += new System.EventHandler(this.cboSIProperties_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "DSF";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Use As Profile:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "For Profile:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Property:";
            // 
            // lstProperties
            // 
            this.lstProperties.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lstProperties.FullRowSelect = true;
            this.lstProperties.Location = new System.Drawing.Point(13, 213);
            this.lstProperties.Name = "lstProperties";
            this.lstProperties.Size = new System.Drawing.Size(506, 227);
            this.lstProperties.TabIndex = 8;
            this.lstProperties.UseCompatibleStateImageBehavior = false;
            this.lstProperties.View = System.Windows.Forms.View.Details;
            this.lstProperties.SelectedIndexChanged += new System.EventHandler(this.lstProperties_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "PropertyName";
            this.columnHeader1.Width = 114;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "DSF";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "UseAsProfile";
            this.columnHeader3.Width = 114;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Filter By Profile:";
            // 
            // cboProfileFilter
            // 
            this.cboProfileFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProfileFilter.FormattingEnabled = true;
            this.cboProfileFilter.Location = new System.Drawing.Point(104, 184);
            this.cboProfileFilter.Name = "cboProfileFilter";
            this.cboProfileFilter.Size = new System.Drawing.Size(135, 21);
            this.cboProfileFilter.TabIndex = 7;
            this.cboProfileFilter.SelectedIndexChanged += new System.EventHandler(this.cboProfileFilter_SelectedIndexChanged);
            // 
            // btnManageDSF
            // 
            this.btnManageDSF.Location = new System.Drawing.Point(337, 96);
            this.btnManageDSF.Name = "btnManageDSF";
            this.btnManageDSF.Size = new System.Drawing.Size(104, 23);
            this.btnManageDSF.TabIndex = 7;
            this.btnManageDSF.Text = "Manage DSFes";
            this.btnManageDSF.UseVisualStyleBackColor = true;
            this.btnManageDSF.Click += new System.EventHandler(this.btnManageDSF_Click);
            // 
            // frmClassProfiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 452);
            this.Controls.Add(this.lstProperties);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cboProfileFilter);
            this.Controls.Add(this.label5);
            this.Name = "frmClassProfiles";
            this.Text = "frmClassProfiles";
            this.Load += new System.EventHandler(this.frmClassProfiles_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboSIDSF;
        private System.Windows.Forms.ComboBox cboSIUseAsProfile;
        private System.Windows.Forms.ComboBox cboSIProfiles;
        private System.Windows.Forms.ComboBox cboSIProperties;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView lstProperties;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboProfileFilter;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnManageDSF;
    }
}