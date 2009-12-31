namespace MsdGenerator
{
    partial class frmMenuDVS
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
            this.lstDetails = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnDetailSave = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboMasterModel = new System.Windows.Forms.ComboBox();
            this.cboRepo = new System.Windows.Forms.ComboBox();
            this.cboMasterProfile = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cboDetailProperty = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboDetailProfile = new System.Windows.Forms.ComboBox();
            this.btnDetailForm = new System.Windows.Forms.Button();
            this.btnDetailGrid = new System.Windows.Forms.Button();
            this.BtnManageModel = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.btnManageDetailModel = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDVSTitle = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Master Model:";
            // 
            // lstDetails
            // 
            this.lstDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstDetails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lstDetails.FullRowSelect = true;
            this.lstDetails.Location = new System.Drawing.Point(13, 229);
            this.lstDetails.Name = "lstDetails";
            this.lstDetails.Size = new System.Drawing.Size(492, 269);
            this.lstDetails.TabIndex = 61;
            this.lstDetails.UseCompatibleStateImageBehavior = false;
            this.lstDetails.View = System.Windows.Forms.View.Details;
            this.lstDetails.SelectedIndexChanged += new System.EventHandler(this.lstDetails_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Detail Property";
            this.columnHeader1.Width = 101;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Detail Property Profile";
            this.columnHeader2.Width = 114;
            // 
            // btnDetailSave
            // 
            this.btnDetailSave.Location = new System.Drawing.Point(366, 136);
            this.btnDetailSave.Name = "btnDetailSave";
            this.btnDetailSave.Size = new System.Drawing.Size(95, 23);
            this.btnDetailSave.TabIndex = 31;
            this.btnDetailSave.Text = "Save Detail";
            this.btnDetailSave.UseVisualStyleBackColor = true;
            this.btnDetailSave.Click += new System.EventHandler(this.btnDetailSave_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(366, 165);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 23);
            this.button1.TabIndex = 51;
            this.button1.Text = "Delete DVS";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Master Reop::";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Master Profile:";
            // 
            // cboMasterModel
            // 
            this.cboMasterModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMasterModel.FormattingEnabled = true;
            this.cboMasterModel.Location = new System.Drawing.Point(90, 13);
            this.cboMasterModel.Name = "cboMasterModel";
            this.cboMasterModel.Size = new System.Drawing.Size(176, 21);
            this.cboMasterModel.TabIndex = 1;
            this.cboMasterModel.SelectedIndexChanged += new System.EventHandler(this.cboMasterModel_SelectedIndexChanged);
            // 
            // cboRepo
            // 
            this.cboRepo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRepo.FormattingEnabled = true;
            this.cboRepo.Location = new System.Drawing.Point(90, 40);
            this.cboRepo.Name = "cboRepo";
            this.cboRepo.Size = new System.Drawing.Size(176, 21);
            this.cboRepo.TabIndex = 11;
            // 
            // cboMasterProfile
            // 
            this.cboMasterProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMasterProfile.FormattingEnabled = true;
            this.cboMasterProfile.Location = new System.Drawing.Point(90, 67);
            this.cboMasterProfile.Name = "cboMasterProfile";
            this.cboMasterProfile.Size = new System.Drawing.Size(176, 21);
            this.cboMasterProfile.TabIndex = 21;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(272, 16);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 25;
            this.button3.Text = "Master Form";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(272, 45);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 27;
            this.button4.Text = "Master Grid";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Detail Property";
            // 
            // cboDetailProperty
            // 
            this.cboDetailProperty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDetailProperty.FormattingEnabled = true;
            this.cboDetailProperty.Location = new System.Drawing.Point(89, 138);
            this.cboDetailProperty.Name = "cboDetailProperty";
            this.cboDetailProperty.Size = new System.Drawing.Size(176, 21);
            this.cboDetailProperty.TabIndex = 21;
            this.cboDetailProperty.SelectedIndexChanged += new System.EventHandler(this.cboDetailProperty_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Detail Profile";
            // 
            // cboDetailProfile
            // 
            this.cboDetailProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDetailProfile.FormattingEnabled = true;
            this.cboDetailProfile.Location = new System.Drawing.Point(89, 166);
            this.cboDetailProfile.Name = "cboDetailProfile";
            this.cboDetailProfile.Size = new System.Drawing.Size(176, 21);
            this.cboDetailProfile.TabIndex = 21;
            // 
            // btnDetailForm
            // 
            this.btnDetailForm.Location = new System.Drawing.Point(285, 136);
            this.btnDetailForm.Name = "btnDetailForm";
            this.btnDetailForm.Size = new System.Drawing.Size(75, 23);
            this.btnDetailForm.TabIndex = 25;
            this.btnDetailForm.Text = "Detail Form";
            this.btnDetailForm.UseVisualStyleBackColor = true;
            this.btnDetailForm.Click += new System.EventHandler(this.btnDetailForm_Click);
            // 
            // btnDetailGrid
            // 
            this.btnDetailGrid.Location = new System.Drawing.Point(285, 165);
            this.btnDetailGrid.Name = "btnDetailGrid";
            this.btnDetailGrid.Size = new System.Drawing.Size(75, 23);
            this.btnDetailGrid.TabIndex = 27;
            this.btnDetailGrid.Text = "Detail Grid";
            this.btnDetailGrid.UseVisualStyleBackColor = true;
            this.btnDetailGrid.Click += new System.EventHandler(this.btnDetailGrid_Click);
            // 
            // BtnManageModel
            // 
            this.BtnManageModel.Location = new System.Drawing.Point(353, 16);
            this.BtnManageModel.Name = "BtnManageModel";
            this.BtnManageModel.Size = new System.Drawing.Size(100, 23);
            this.BtnManageModel.TabIndex = 62;
            this.BtnManageModel.Text = "Manage Model";
            this.BtnManageModel.UseVisualStyleBackColor = true;
            this.BtnManageModel.Click += new System.EventHandler(this.BtnManageModel_Click);
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(353, 70);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(100, 41);
            this.btnsave.TabIndex = 63;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btnManageDetailModel
            // 
            this.btnManageDetailModel.Location = new System.Drawing.Point(89, 109);
            this.btnManageDetailModel.Name = "btnManageDetailModel";
            this.btnManageDetailModel.Size = new System.Drawing.Size(144, 23);
            this.btnManageDetailModel.TabIndex = 62;
            this.btnManageDetailModel.Text = "Manage Detail Model";
            this.btnManageDetailModel.UseVisualStyleBackColor = true;
            this.btnManageDetailModel.Click += new System.EventHandler(this.btnManageDetailModel_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 193);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Title:";
            // 
            // txtDVSTitle
            // 
            this.txtDVSTitle.Location = new System.Drawing.Point(90, 193);
            this.txtDVSTitle.Name = "txtDVSTitle";
            this.txtDVSTitle.Size = new System.Drawing.Size(176, 20);
            this.txtDVSTitle.TabIndex = 64;
            // 
            // frmMenuDVS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 510);
            this.Controls.Add(this.txtDVSTitle);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.btnManageDetailModel);
            this.Controls.Add(this.BtnManageModel);
            this.Controls.Add(this.btnDetailGrid);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnDetailForm);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.cboDetailProperty);
            this.Controls.Add(this.cboDetailProfile);
            this.Controls.Add(this.cboMasterProfile);
            this.Controls.Add(this.cboRepo);
            this.Controls.Add(this.cboMasterModel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnDetailSave);
            this.Controls.Add(this.lstDetails);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmMenuDVS";
            this.Text = "frmMenuDVS";
            this.Load += new System.EventHandler(this.frmMenuDVS_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lstDetails;
        private System.Windows.Forms.Button btnDetailSave;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboMasterModel;
        private System.Windows.Forms.ComboBox cboRepo;
        private System.Windows.Forms.ComboBox cboMasterProfile;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboDetailProperty;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboDetailProfile;
        private System.Windows.Forms.Button btnDetailForm;
        private System.Windows.Forms.Button btnDetailGrid;
        private System.Windows.Forms.Button BtnManageModel;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btnManageDetailModel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDVSTitle;
    }
}