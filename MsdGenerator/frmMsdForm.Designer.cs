namespace MsdGenerator
{
    partial class frmMsdForm
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
            this.txtformtitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboOrientation = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnmanageformitemrepos = new System.Windows.Forms.Button();
            this.btnmanageformitemprofile = new System.Windows.Forms.Button();
            this.btnDeleteFormItem = new System.Windows.Forms.Button();
            this.btnSaveFormItem = new System.Windows.Forms.Button();
            this.btnRemoveCol = new System.Windows.Forms.Button();
            this.btnAddCol = new System.Windows.Forms.Button();
            this.lstCols = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cboCol = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboRepo = new System.Windows.Forms.ComboBox();
            this.cboProfile = new System.Windows.Forms.ComboBox();
            this.cboName = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHelpMessage = new System.Windows.Forms.TextBox();
            this.txtPriority = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lstFormItems = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Form Title:";
            // 
            // txtformtitle
            // 
            this.txtformtitle.Location = new System.Drawing.Point(75, 10);
            this.txtformtitle.Name = "txtformtitle";
            this.txtformtitle.Size = new System.Drawing.Size(214, 20);
            this.txtformtitle.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "titleOrientation:";
            // 
            // cboOrientation
            // 
            this.cboOrientation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOrientation.FormattingEnabled = true;
            this.cboOrientation.Items.AddRange(new object[] {
            "IRERPControlTypes_TitleOrientation.top",
            "IRERPControlTypes_TitleOrientation.left",
            "IRERPControlTypes_TitleOrientation.right"});
            this.cboOrientation.Location = new System.Drawing.Point(97, 39);
            this.cboOrientation.Name = "cboOrientation";
            this.cboOrientation.Size = new System.Drawing.Size(192, 21);
            this.cboOrientation.TabIndex = 20;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnmanageformitemrepos);
            this.groupBox1.Controls.Add(this.btnmanageformitemprofile);
            this.groupBox1.Controls.Add(this.btnDeleteFormItem);
            this.groupBox1.Controls.Add(this.btnSaveFormItem);
            this.groupBox1.Controls.Add(this.btnRemoveCol);
            this.groupBox1.Controls.Add(this.btnAddCol);
            this.groupBox1.Controls.Add(this.lstCols);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cboType);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cboCol);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cboRepo);
            this.groupBox1.Controls.Add(this.cboProfile);
            this.groupBox1.Controls.Add(this.cboName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtHelpMessage);
            this.groupBox1.Controls.Add(this.txtPriority);
            this.groupBox1.Controls.Add(this.txtTitle);
            this.groupBox1.Location = new System.Drawing.Point(13, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(597, 245);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FormItem";
            // 
            // btnmanageformitemrepos
            // 
            this.btnmanageformitemrepos.Location = new System.Drawing.Point(503, 40);
            this.btnmanageformitemrepos.Name = "btnmanageformitemrepos";
            this.btnmanageformitemrepos.Size = new System.Drawing.Size(75, 23);
            this.btnmanageformitemrepos.TabIndex = 152;
            this.btnmanageformitemrepos.Text = "Repos";
            this.btnmanageformitemrepos.UseVisualStyleBackColor = true;
            this.btnmanageformitemrepos.Click += new System.EventHandler(this.btnmanageformitemrepos_Click);
            // 
            // btnmanageformitemprofile
            // 
            this.btnmanageformitemprofile.Location = new System.Drawing.Point(503, 11);
            this.btnmanageformitemprofile.Name = "btnmanageformitemprofile";
            this.btnmanageformitemprofile.Size = new System.Drawing.Size(75, 23);
            this.btnmanageformitemprofile.TabIndex = 151;
            this.btnmanageformitemprofile.Text = "Profiles";
            this.btnmanageformitemprofile.UseVisualStyleBackColor = true;
            this.btnmanageformitemprofile.Click += new System.EventHandler(this.btnmanageformitemprofile_Click);
            // 
            // btnDeleteFormItem
            // 
            this.btnDeleteFormItem.Location = new System.Drawing.Point(165, 216);
            this.btnDeleteFormItem.Name = "btnDeleteFormItem";
            this.btnDeleteFormItem.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteFormItem.TabIndex = 150;
            this.btnDeleteFormItem.Text = "Delete";
            this.btnDeleteFormItem.UseVisualStyleBackColor = true;
            this.btnDeleteFormItem.Click += new System.EventHandler(this.btnDeleteFormItem_Click);
            // 
            // btnSaveFormItem
            // 
            this.btnSaveFormItem.Location = new System.Drawing.Point(84, 216);
            this.btnSaveFormItem.Name = "btnSaveFormItem";
            this.btnSaveFormItem.Size = new System.Drawing.Size(75, 23);
            this.btnSaveFormItem.TabIndex = 140;
            this.btnSaveFormItem.Text = "Save";
            this.btnSaveFormItem.UseVisualStyleBackColor = true;
            this.btnSaveFormItem.Click += new System.EventHandler(this.btnSaveFormItem_Click);
            // 
            // btnRemoveCol
            // 
            this.btnRemoveCol.Location = new System.Drawing.Point(391, 93);
            this.btnRemoveCol.Name = "btnRemoveCol";
            this.btnRemoveCol.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveCol.TabIndex = 120;
            this.btnRemoveCol.Text = "Remove Col";
            this.btnRemoveCol.UseVisualStyleBackColor = true;
            this.btnRemoveCol.Click += new System.EventHandler(this.btnRemoveCol_Click);
            // 
            // btnAddCol
            // 
            this.btnAddCol.Location = new System.Drawing.Point(310, 93);
            this.btnAddCol.Name = "btnAddCol";
            this.btnAddCol.Size = new System.Drawing.Size(75, 23);
            this.btnAddCol.TabIndex = 100;
            this.btnAddCol.Text = "AddCol";
            this.btnAddCol.UseVisualStyleBackColor = true;
            this.btnAddCol.Click += new System.EventHandler(this.btnAddCol_Click);
            // 
            // lstCols
            // 
            this.lstCols.FormattingEnabled = true;
            this.lstCols.Location = new System.Drawing.Point(310, 131);
            this.lstCols.Name = "lstCols";
            this.lstCols.Size = new System.Drawing.Size(192, 108);
            this.lstCols.TabIndex = 130;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Type:";
            // 
            // cboType
            // 
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.FormattingEnabled = true;
            this.cboType.Items.AddRange(new object[] {
            "IRERP_SM_TextAreaItem",
            "IRERP_SM_SelectItem",
            "IRERP_SM_TextItem"});
            this.cboType.Location = new System.Drawing.Point(50, 100);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(192, 21);
            this.cboType.TabIndex = 60;
            this.cboType.SelectedIndexChanged += new System.EventHandler(this.cboType_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(274, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(25, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Col:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(266, 43);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Repo";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(266, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Profile:";
            // 
            // cboCol
            // 
            this.cboCol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCol.FormattingEnabled = true;
            this.cboCol.Location = new System.Drawing.Point(305, 66);
            this.cboCol.Name = "cboCol";
            this.cboCol.Size = new System.Drawing.Size(192, 21);
            this.cboCol.TabIndex = 90;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Name:";
            // 
            // cboRepo
            // 
            this.cboRepo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRepo.FormattingEnabled = true;
            this.cboRepo.Location = new System.Drawing.Point(305, 39);
            this.cboRepo.Name = "cboRepo";
            this.cboRepo.Size = new System.Drawing.Size(192, 21);
            this.cboRepo.TabIndex = 80;
            this.cboRepo.SelectedIndexChanged += new System.EventHandler(this.cboProfile_SelectedIndexChanged);
            // 
            // cboProfile
            // 
            this.cboProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProfile.FormattingEnabled = true;
            this.cboProfile.Location = new System.Drawing.Point(305, 13);
            this.cboProfile.Name = "cboProfile";
            this.cboProfile.Size = new System.Drawing.Size(192, 21);
            this.cboProfile.TabIndex = 80;
            this.cboProfile.SelectedIndexChanged += new System.EventHandler(this.cboProfile_SelectedIndexChanged);
            // 
            // cboName
            // 
            this.cboName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboName.FormattingEnabled = true;
            this.cboName.Items.AddRange(new object[] {
            "IRERPControlTypes_TitleOrientation.top",
            "IRERPControlTypes_TitleOrientation.left",
            "IRERPControlTypes_TitleOrientation.right"});
            this.cboName.Location = new System.Drawing.Point(50, 13);
            this.cboName.Name = "cboName";
            this.cboName.Size = new System.Drawing.Size(192, 21);
            this.cboName.TabIndex = 30;
            this.cboName.SelectedIndexChanged += new System.EventHandler(this.cboName_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Priority:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "HelpMessage:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Title:";
            // 
            // txtHelpMessage
            // 
            this.txtHelpMessage.Location = new System.Drawing.Point(87, 130);
            this.txtHelpMessage.Multiline = true;
            this.txtHelpMessage.Name = "txtHelpMessage";
            this.txtHelpMessage.Size = new System.Drawing.Size(155, 80);
            this.txtHelpMessage.TabIndex = 70;
            // 
            // txtPriority
            // 
            this.txtPriority.Location = new System.Drawing.Point(50, 74);
            this.txtPriority.Name = "txtPriority";
            this.txtPriority.Size = new System.Drawing.Size(192, 20);
            this.txtPriority.TabIndex = 50;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(50, 45);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(192, 20);
            this.txtTitle.TabIndex = 40;
            // 
            // lstFormItems
            // 
            this.lstFormItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstFormItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lstFormItems.FullRowSelect = true;
            this.lstFormItems.Location = new System.Drawing.Point(13, 322);
            this.lstFormItems.Name = "lstFormItems";
            this.lstFormItems.Size = new System.Drawing.Size(597, 203);
            this.lstFormItems.TabIndex = 160;
            this.lstFormItems.UseCompatibleStateImageBehavior = false;
            this.lstFormItems.View = System.Windows.Forms.View.Details;
            this.lstFormItems.SelectedIndexChanged += new System.EventHandler(this.lstFormItems_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Title";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Priority";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Type";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Profile";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(295, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 52);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmMsdForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 537);
            this.Controls.Add(this.lstFormItems);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cboOrientation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtformtitle);
            this.Controls.Add(this.label1);
            this.Name = "frmMsdForm";
            this.Text = "frmMsdForm";
            this.Load += new System.EventHandler(this.frmMsdForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtformtitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboOrientation;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPriority;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtHelpMessage;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboCol;
        private System.Windows.Forms.ComboBox cboProfile;
        private System.Windows.Forms.Button btnDeleteFormItem;
        private System.Windows.Forms.Button btnSaveFormItem;
        private System.Windows.Forms.Button btnRemoveCol;
        private System.Windows.Forms.Button btnAddCol;
        private System.Windows.Forms.ListBox lstCols;
        private System.Windows.Forms.ListView lstFormItems;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboRepo;
        private System.Windows.Forms.Button btnmanageformitemrepos;
        private System.Windows.Forms.Button btnmanageformitemprofile;
    }
}