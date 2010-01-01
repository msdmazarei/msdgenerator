namespace MsdGenerator
{
    partial class frmClass
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
            this.txtNameSpace = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.TableName = new System.Windows.Forms.Label();
            this.chkHasLog = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.lstProperties = new System.Windows.Forms.ListView();
            this.colPropertyType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IsAssoc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IsCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PropertyName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.isPrimaryKey = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Generator = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.KeyColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PropRef = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAddProperty = new System.Windows.Forms.Button();
            this.btnDelProperty = new System.Windows.Forms.Button();
            this.btnSaveClass = new System.Windows.Forms.Button();
            this.btnEditPropety = new System.Windows.Forms.Button();
            this.btnManageRepos = new System.Windows.Forms.Button();
            this.btnManageDescs = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtNameSpace
            // 
            this.txtNameSpace.Location = new System.Drawing.Point(82, 13);
            this.txtNameSpace.Name = "txtNameSpace";
            this.txtNameSpace.Size = new System.Drawing.Size(301, 20);
            this.txtNameSpace.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "NameSpace";
            // 
            // txtClassName
            // 
            this.txtClassName.Location = new System.Drawing.Point(82, 36);
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.Size = new System.Drawing.Size(301, 20);
            this.txtClassName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "ClassName";
            // 
            // txtTableName
            // 
            this.txtTableName.Location = new System.Drawing.Point(82, 61);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(301, 20);
            this.txtTableName.TabIndex = 2;
            // 
            // TableName
            // 
            this.TableName.AutoSize = true;
            this.TableName.Location = new System.Drawing.Point(10, 64);
            this.TableName.Name = "TableName";
            this.TableName.Size = new System.Drawing.Size(62, 13);
            this.TableName.TabIndex = 1;
            this.TableName.Text = "TableName";
            // 
            // chkHasLog
            // 
            this.chkHasLog.AutoSize = true;
            this.chkHasLog.Location = new System.Drawing.Point(82, 88);
            this.chkHasLog.Name = "chkHasLog";
            this.chkHasLog.Size = new System.Drawing.Size(63, 17);
            this.chkHasLog.TabIndex = 3;
            this.chkHasLog.Text = "HasLog";
            this.chkHasLog.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(151, 88);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(109, 17);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "ProceeBaseClass";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // lstProperties
            // 
            this.lstProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstProperties.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colPropertyType,
            this.IsAssoc,
            this.IsCol,
            this.PropertyName,
            this.isPrimaryKey,
            this.Generator,
            this.ColumnName,
            this.KeyColumn,
            this.PropRef});
            this.lstProperties.FullRowSelect = true;
            this.lstProperties.GridLines = true;
            this.lstProperties.Location = new System.Drawing.Point(13, 116);
            this.lstProperties.Name = "lstProperties";
            this.lstProperties.Size = new System.Drawing.Size(616, 250);
            this.lstProperties.TabIndex = 3;
            this.lstProperties.UseCompatibleStateImageBehavior = false;
            this.lstProperties.View = System.Windows.Forms.View.Details;
            this.lstProperties.DoubleClick += new System.EventHandler(this.lstProperties_DoubleClick);
            // 
            // colPropertyType
            // 
            this.colPropertyType.Text = "PropertyType";
            // 
            // IsAssoc
            // 
            this.IsAssoc.Text = "IsAssociation";
            this.IsAssoc.Width = 67;
            // 
            // IsCol
            // 
            this.IsCol.Text = "IsCollection";
            // 
            // PropertyName
            // 
            this.PropertyName.Text = "PropertyName";
            this.PropertyName.Width = 85;
            // 
            // isPrimaryKey
            // 
            this.isPrimaryKey.Text = "isPrimaryKey";
            // 
            // Generator
            // 
            this.Generator.Text = "Generator";
            this.Generator.Width = 91;
            // 
            // ColumnName
            // 
            this.ColumnName.Text = "ColumnName";
            this.ColumnName.Width = 134;
            // 
            // KeyColumn
            // 
            this.KeyColumn.Text = "KeyColumn";
            // 
            // PropRef
            // 
            this.PropRef.Text = "PropertyRef";
            // 
            // btnAddProperty
            // 
            this.btnAddProperty.Location = new System.Drawing.Point(267, 88);
            this.btnAddProperty.Name = "btnAddProperty";
            this.btnAddProperty.Size = new System.Drawing.Size(116, 23);
            this.btnAddProperty.TabIndex = 5;
            this.btnAddProperty.Text = "Add Property";
            this.btnAddProperty.UseVisualStyleBackColor = true;
            this.btnAddProperty.Click += new System.EventHandler(this.btnAddProperty_Click);
            // 
            // btnDelProperty
            // 
            this.btnDelProperty.Location = new System.Drawing.Point(474, 88);
            this.btnDelProperty.Name = "btnDelProperty";
            this.btnDelProperty.Size = new System.Drawing.Size(74, 23);
            this.btnDelProperty.TabIndex = 7;
            this.btnDelProperty.Text = "Del Property";
            this.btnDelProperty.UseVisualStyleBackColor = true;
            this.btnDelProperty.Click += new System.EventHandler(this.btnDelProperty_Click);
            // 
            // btnSaveClass
            // 
            this.btnSaveClass.Location = new System.Drawing.Point(389, 11);
            this.btnSaveClass.Name = "btnSaveClass";
            this.btnSaveClass.Size = new System.Drawing.Size(66, 66);
            this.btnSaveClass.TabIndex = 8;
            this.btnSaveClass.Text = "Save Class";
            this.btnSaveClass.UseVisualStyleBackColor = true;
            this.btnSaveClass.Click += new System.EventHandler(this.btnSaveClass_Click);
            // 
            // btnEditPropety
            // 
            this.btnEditPropety.Location = new System.Drawing.Point(389, 87);
            this.btnEditPropety.Name = "btnEditPropety";
            this.btnEditPropety.Size = new System.Drawing.Size(79, 23);
            this.btnEditPropety.TabIndex = 6;
            this.btnEditPropety.Text = "Edit Property";
            this.btnEditPropety.UseVisualStyleBackColor = true;
            this.btnEditPropety.Click += new System.EventHandler(this.btnEditPropety_Click);
            // 
            // btnManageRepos
            // 
            this.btnManageRepos.Location = new System.Drawing.Point(461, 12);
            this.btnManageRepos.Name = "btnManageRepos";
            this.btnManageRepos.Size = new System.Drawing.Size(96, 23);
            this.btnManageRepos.TabIndex = 9;
            this.btnManageRepos.Text = "Manage Repos";
            this.btnManageRepos.UseVisualStyleBackColor = true;
            this.btnManageRepos.Click += new System.EventHandler(this.btnManageRepos_Click);
            // 
            // btnManageDescs
            // 
            this.btnManageDescs.Location = new System.Drawing.Point(461, 39);
            this.btnManageDescs.Name = "btnManageDescs";
            this.btnManageDescs.Size = new System.Drawing.Size(114, 23);
            this.btnManageDescs.TabIndex = 10;
            this.btnManageDescs.Text = "Manage Descriptors";
            this.btnManageDescs.UseVisualStyleBackColor = true;
            this.btnManageDescs.Click += new System.EventHandler(this.btnManageDescs_Click);
            // 
            // frmClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 370);
            this.Controls.Add(this.btnManageDescs);
            this.Controls.Add(this.btnManageRepos);
            this.Controls.Add(this.btnSaveClass);
            this.Controls.Add(this.btnEditPropety);
            this.Controls.Add(this.btnDelProperty);
            this.Controls.Add(this.btnAddProperty);
            this.Controls.Add(this.lstProperties);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.chkHasLog);
            this.Controls.Add(this.TableName);
            this.Controls.Add(this.txtTableName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtClassName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNameSpace);
            this.Name = "frmClass";
            this.Text = "frmClass";
            this.Load += new System.EventHandler(this.frmClass_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNameSpace;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtClassName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.Label TableName;
        private System.Windows.Forms.CheckBox chkHasLog;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ListView lstProperties;
        private System.Windows.Forms.Button btnAddProperty;
        private System.Windows.Forms.Button btnDelProperty;
        private System.Windows.Forms.Button btnSaveClass;
        private System.Windows.Forms.ColumnHeader colPropertyType;
        private System.Windows.Forms.ColumnHeader IsAssoc;
        private System.Windows.Forms.ColumnHeader IsCol;
        private System.Windows.Forms.ColumnHeader PropertyName;
        private System.Windows.Forms.ColumnHeader isPrimaryKey;
        private System.Windows.Forms.ColumnHeader Generator;
        private System.Windows.Forms.ColumnHeader ColumnName;
        private System.Windows.Forms.Button btnEditPropety;
        private System.Windows.Forms.ColumnHeader KeyColumn;
        private System.Windows.Forms.ColumnHeader PropRef;
        private System.Windows.Forms.Button btnManageRepos;
        private System.Windows.Forms.Button btnManageDescs;
    }
}