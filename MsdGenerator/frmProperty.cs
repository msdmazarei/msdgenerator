using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MsdGenerator
{
    public partial class frmProperty : Form
    {
        void ShowHideTextBoxes()
        {
            txtGenerator.Visible = chkIsPrimaryKey.Checked;
            txtColumnName.Visible = !chkIsCollection.Checked;
            txtKeyColumn.Visible = chkIsCollection.Checked;
            txtPropertyRef.Visible = chkIsAssociation.Checked;
            if (chkIsAssociation.Checked)
                btnManageDFS.Enabled = false;
            else
                btnManageDFS.Enabled = true;


        }
        public Property Main { get; set; }
        void BindMainToForm()
        {
            txtPropertyName .Text= Main.PropertyName;
            txtColumnName .Text= Main.ColumnName;
            txtPropertyTypeNameSpace .Text= Main.PropertyTypeNameSpace;
            txtGenerator .Text= Main.Generator;
            chkIsAssociation.Checked = Main.IsAssociation;
            chkIsCollection.Checked = Main.IsCollection;
            chkIsPrimaryKey.Checked = Main.isPrimaryKey;
            txtPropertyType.Text = Main.PropertyType;
            txtAssocColName.Text = Main.AssociationColumnName;
            txtPropertyRef.Text = Main.PropertyRef;
            txtKeyColumn.Text = Main.KeyColumn;

        }
        void BindFormToMain()
        {
            Main.PropertyType = txtPropertyType.Text.Trim();
            Main.PropertyName = txtPropertyName.Text.Trim();
            Main.ColumnName = txtColumnName.Text.Trim();
            Main.PropertyTypeNameSpace = txtPropertyTypeNameSpace.Text.Trim();
            Main.Generator = txtGenerator.Text.Trim();
            Main.IsAssociation = chkIsAssociation.Checked;
            Main.IsCollection = chkIsCollection.Checked;
            Main.isPrimaryKey = chkIsPrimaryKey.Checked;
            Main.AssociationColumnName = txtAssocColName.Text.Trim();
            Main.PropertyRef = txtPropertyRef.Text.Trim();
            Main.KeyColumn = txtKeyColumn.Text.Trim();
        }
        public frmProperty()
        {
            InitializeComponent();
        }

        private void frmProperty_Load(object sender, EventArgs e)
        {
            Variables.AutoComplete(txtAssocColName);
            Variables.AutoComplete(txtColumnName);
            Variables.AutoComplete(txtGenerator);
            Variables.AutoComplete(txtKeyColumn);
            Variables.AutoComplete(txtPropertyName);
            Variables.AutoComplete(txtPropertyRef);
            Variables.AutoComplete(txtPropertyType);
            Variables.AutoComplete(txtPropertyTypeNameSpace);
            if (Main != null)
                BindMainToForm();
            ShowHideTextBoxes();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            BindFormToMain();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void chkIsAssociation_CheckedChanged(object sender, EventArgs e)
        {
            ShowHideTextBoxes();
        }

        private void chkIsCollection_CheckedChanged(object sender, EventArgs e)
        {
            ShowHideTextBoxes();
            btnAddIntermediate.Enabled = chkIsCollection.Checked;
        }

        private void chkIsPrimaryKey_CheckedChanged(object sender, EventArgs e)
        {
            ShowHideTextBoxes();
        }

        private void chkVersionField_CheckedChanged(object sender, EventArgs e)
        {
            ShowHideTextBoxes();
        }

        private void btnAddClass_Click(object sender, EventArgs e)
        {
            frmClass frm = new frmClass();
            frm.Main = Variables.GetNewModel();
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //Check That Class Name Exits Before
                Model q = null;
                if (Variables.Models.Count > 0)
                    q = (
                        from x in Variables.Models
                        where
                        (
                            (
                                (x.NameSpace + "." + x.ClassName)
                                ==
                                (frm.Main.NameSpace + "." + frm.Main.ClassName)
                            )
                        )
                        select x
                        ).FirstOrDefault();

                if (q != null)
                    MessageBox.Show("this Class Exits Before");
                else
                {
                    //BindModelToListView(frm.Main);
                    Variables.Models.Add(frm.Main);
                }

            }

        }

        private void btnAddIntermediate_Click(object sender, EventArgs e)
        {
            BindFormToMain();
            frmAddInterMediate inter = new frmAddInterMediate();
            inter.Inter = Variables.GetNewModel();
            inter.Inter.NameSpace = Main.Model.NameSpace;
            inter.Inter.ClassName = Main.Model.ClassName + "_" + Main.PropertyName;
            inter.First = new Property() { PropertyTypeNameSpace = Main.Model.NameSpace, PropertyType = Main.Model.ClassName };
            inter.Second = new Property() { PropertyTypeNameSpace = Main.PropertyTypeNameSpace, PropertyType = Main.PropertyType };
            if (inter.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Variables.Models.Add(inter.Inter);
            }
        }

        private void btnManageDFS_Click(object sender, EventArgs e)
        {
            (new frmPropertyDFSLst() { Main = Main})
                .ShowDialog();
        }

        private void btnDescriptors_Click(object sender, EventArgs e)
        {
            (new
            frmPropDescriptors() { 
                Main = Main
            }
            ).ShowDialog();
        }
    }
}
