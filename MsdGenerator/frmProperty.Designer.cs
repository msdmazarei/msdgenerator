namespace MsdGenerator
{
    partial class frmProperty
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
            this.txtPropertyName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPropertyType = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPropertyTypeNameSpace = new System.Windows.Forms.TextBox();
            this.chkIsAssociation = new System.Windows.Forms.CheckBox();
            this.chkIsCollection = new System.Windows.Forms.CheckBox();
            this.chkIsPrimaryKey = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGenerator = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtColumnName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkVersionField = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAssocColName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPropertyRef = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtKeyColumn = new System.Windows.Forms.TextBox();
            this.btnAddIntermediate = new System.Windows.Forms.Button();
            this.btnAddClass = new System.Windows.Forms.Button();
            this.btnManageDFS = new System.Windows.Forms.Button();
            this.btnDescriptors = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "PropertyName";
            // 
            // txtPropertyName
            // 
            this.txtPropertyName.Location = new System.Drawing.Point(93, 10);
            this.txtPropertyName.Name = "txtPropertyName";
            this.txtPropertyName.Size = new System.Drawing.Size(295, 20);
            this.txtPropertyName.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "PropertyType";
            // 
            // txtPropertyType
            // 
            this.txtPropertyType.Location = new System.Drawing.Point(93, 69);
            this.txtPropertyType.Name = "txtPropertyType";
            this.txtPropertyType.Size = new System.Drawing.Size(295, 20);
            this.txtPropertyType.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "PropertyType_NameSpace";
            // 
            // txtPropertyTypeNameSpace
            // 
            this.txtPropertyTypeNameSpace.Location = new System.Drawing.Point(154, 36);
            this.txtPropertyTypeNameSpace.Name = "txtPropertyTypeNameSpace";
            this.txtPropertyTypeNameSpace.Size = new System.Drawing.Size(234, 20);
            this.txtPropertyTypeNameSpace.TabIndex = 1;
            // 
            // chkIsAssociation
            // 
            this.chkIsAssociation.AutoSize = true;
            this.chkIsAssociation.Location = new System.Drawing.Point(93, 95);
            this.chkIsAssociation.Name = "chkIsAssociation";
            this.chkIsAssociation.Size = new System.Drawing.Size(88, 17);
            this.chkIsAssociation.TabIndex = 3;
            this.chkIsAssociation.Text = "IsAssociation";
            this.chkIsAssociation.UseVisualStyleBackColor = true;
            this.chkIsAssociation.CheckedChanged += new System.EventHandler(this.chkIsAssociation_CheckedChanged);
            // 
            // chkIsCollection
            // 
            this.chkIsCollection.AutoSize = true;
            this.chkIsCollection.Location = new System.Drawing.Point(93, 118);
            this.chkIsCollection.Name = "chkIsCollection";
            this.chkIsCollection.Size = new System.Drawing.Size(80, 17);
            this.chkIsCollection.TabIndex = 4;
            this.chkIsCollection.Text = "IsCollection";
            this.chkIsCollection.UseVisualStyleBackColor = true;
            this.chkIsCollection.CheckedChanged += new System.EventHandler(this.chkIsCollection_CheckedChanged);
            // 
            // chkIsPrimaryKey
            // 
            this.chkIsPrimaryKey.AutoSize = true;
            this.chkIsPrimaryKey.Location = new System.Drawing.Point(93, 141);
            this.chkIsPrimaryKey.Name = "chkIsPrimaryKey";
            this.chkIsPrimaryKey.Size = new System.Drawing.Size(86, 17);
            this.chkIsPrimaryKey.TabIndex = 5;
            this.chkIsPrimaryKey.Text = "IsPrimaryKey";
            this.chkIsPrimaryKey.UseVisualStyleBackColor = true;
            this.chkIsPrimaryKey.CheckedChanged += new System.EventHandler(this.chkIsPrimaryKey_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Generator";
            // 
            // txtGenerator
            // 
            this.txtGenerator.Location = new System.Drawing.Point(93, 179);
            this.txtGenerator.Name = "txtGenerator";
            this.txtGenerator.Size = new System.Drawing.Size(295, 20);
            this.txtGenerator.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Real ColumnName";
            // 
            // txtColumnName
            // 
            this.txtColumnName.Location = new System.Drawing.Point(124, 205);
            this.txtColumnName.Name = "txtColumnName";
            this.txtColumnName.Size = new System.Drawing.Size(264, 20);
            this.txtColumnName.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(313, 339);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkVersionField
            // 
            this.chkVersionField.AutoSize = true;
            this.chkVersionField.Location = new System.Drawing.Point(235, 95);
            this.chkVersionField.Name = "chkVersionField";
            this.chkVersionField.Size = new System.Drawing.Size(83, 17);
            this.chkVersionField.TabIndex = 3;
            this.chkVersionField.Text = "VersionField";
            this.chkVersionField.UseVisualStyleBackColor = true;
            this.chkVersionField.CheckedChanged += new System.EventHandler(this.chkVersionField_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 234);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Assoc Column Name";
            // 
            // txtAssocColName
            // 
            this.txtAssocColName.Location = new System.Drawing.Point(124, 231);
            this.txtAssocColName.Name = "txtAssocColName";
            this.txtAssocColName.Size = new System.Drawing.Size(264, 20);
            this.txtAssocColName.TabIndex = 8;
            this.txtAssocColName.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 260);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Property Ref.";
            // 
            // txtPropertyRef
            // 
            this.txtPropertyRef.Location = new System.Drawing.Point(124, 257);
            this.txtPropertyRef.Name = "txtPropertyRef";
            this.txtPropertyRef.Size = new System.Drawing.Size(264, 20);
            this.txtPropertyRef.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 286);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "KeyColumn";
            // 
            // txtKeyColumn
            // 
            this.txtKeyColumn.Location = new System.Drawing.Point(124, 283);
            this.txtKeyColumn.Name = "txtKeyColumn";
            this.txtKeyColumn.Size = new System.Drawing.Size(264, 20);
            this.txtKeyColumn.TabIndex = 10;
            // 
            // btnAddIntermediate
            // 
            this.btnAddIntermediate.Enabled = false;
            this.btnAddIntermediate.Location = new System.Drawing.Point(154, 339);
            this.btnAddIntermediate.Name = "btnAddIntermediate";
            this.btnAddIntermediate.Size = new System.Drawing.Size(141, 23);
            this.btnAddIntermediate.TabIndex = 12;
            this.btnAddIntermediate.Text = "Add InterMediate Class";
            this.btnAddIntermediate.UseVisualStyleBackColor = true;
            this.btnAddIntermediate.Click += new System.EventHandler(this.btnAddIntermediate_Click);
            // 
            // btnAddClass
            // 
            this.btnAddClass.Location = new System.Drawing.Point(43, 339);
            this.btnAddClass.Name = "btnAddClass";
            this.btnAddClass.Size = new System.Drawing.Size(75, 23);
            this.btnAddClass.TabIndex = 13;
            this.btnAddClass.Text = "Add Class";
            this.btnAddClass.UseVisualStyleBackColor = true;
            this.btnAddClass.Click += new System.EventHandler(this.btnAddClass_Click);
            // 
            // btnManageDFS
            // 
            this.btnManageDFS.Location = new System.Drawing.Point(43, 369);
            this.btnManageDFS.Name = "btnManageDFS";
            this.btnManageDFS.Size = new System.Drawing.Size(105, 23);
            this.btnManageDFS.TabIndex = 14;
            this.btnManageDFS.Text = "Manage DFS";
            this.btnManageDFS.UseVisualStyleBackColor = true;
            this.btnManageDFS.Click += new System.EventHandler(this.btnManageDFS_Click);
            // 
            // btnDescriptors
            // 
            this.btnDescriptors.Location = new System.Drawing.Point(154, 369);
            this.btnDescriptors.Name = "btnDescriptors";
            this.btnDescriptors.Size = new System.Drawing.Size(141, 23);
            this.btnDescriptors.TabIndex = 15;
            this.btnDescriptors.Text = "Manage Descriptors";
            this.btnDescriptors.UseVisualStyleBackColor = true;
            this.btnDescriptors.Click += new System.EventHandler(this.btnDescriptors_Click);
            // 
            // frmProperty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 422);
            this.Controls.Add(this.btnDescriptors);
            this.Controls.Add(this.btnManageDFS);
            this.Controls.Add(this.btnAddClass);
            this.Controls.Add(this.btnAddIntermediate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chkIsPrimaryKey);
            this.Controls.Add(this.chkIsCollection);
            this.Controls.Add(this.chkVersionField);
            this.Controls.Add(this.chkIsAssociation);
            this.Controls.Add(this.txtPropertyTypeNameSpace);
            this.Controls.Add(this.txtKeyColumn);
            this.Controls.Add(this.txtPropertyRef);
            this.Controls.Add(this.txtAssocColName);
            this.Controls.Add(this.txtColumnName);
            this.Controls.Add(this.txtGenerator);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtPropertyType);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPropertyName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmProperty";
            this.Text = "frmProperty";
            this.Load += new System.EventHandler(this.frmProperty_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPropertyName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPropertyType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPropertyTypeNameSpace;
        private System.Windows.Forms.CheckBox chkIsAssociation;
        private System.Windows.Forms.CheckBox chkIsCollection;
        private System.Windows.Forms.CheckBox chkIsPrimaryKey;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtGenerator;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtColumnName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkVersionField;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAssocColName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPropertyRef;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtKeyColumn;
        private System.Windows.Forms.Button btnAddIntermediate;
        private System.Windows.Forms.Button btnAddClass;
        private System.Windows.Forms.Button btnManageDFS;
        private System.Windows.Forms.Button btnDescriptors;
    }
}