using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MsdGenerator
{
    public partial class frmAddInterMediate : Form
    {
        public frmAddInterMediate()
        {
            InitializeComponent();
        }
        public Model Inter { get; set; }
        public Property First { get; set; }
        public Property Second { get; set; }
        void BindMainToForm()
        {
            if (Inter != null)
            {
                txtIntermediateNameSpace.Text = Inter.NameSpace;
                txtIntermediateClassName.Text = Inter.ClassName;
                txtIntertableName.Text = Inter.TableName;

            }
            if (First != null)
            {
                txtFirstSideNameSpace.Text = First.PropertyTypeNameSpace;
                txtFirstClassName.Text = First.PropertyType;
            }
            if (Second != null)
            {
                txtSecondNameSpace.Text = Second.PropertyTypeNameSpace;
                txtSecondClassName.Text = Second.PropertyType;
            }
        }
        void BindFormToMain() {
            Inter.ClassName = txtIntermediateClassName.Text.Trim();
            Inter.NameSpace = txtIntermediateNameSpace.Text.Trim();
            Inter.TableName = txtIntertableName.Text.Trim();
            First.PropertyType = txtFirstClassName.Text.Trim();
            First.PropertyTypeNameSpace = txtFirstSideNameSpace.Text.Trim();
            Second.PropertyType = txtSecondClassName.Text.Trim();
            Second.PropertyTypeNameSpace = txtSecondNameSpace.Text.Trim();

            First.Model = Second.Model = Inter;
            First.ColumnName = First.PropertyName = First.PropertyType;
            Second.ColumnName = Second.PropertyName = Second.PropertyType;
            First.IsAssociation = Second.IsAssociation = true;
            Inter.Properties.Add(First);
            Inter.Properties.Add(Second);
        }
        private void frmAddInterMediate_Load(object sender, EventArgs e)
        {
           
            BindMainToForm();
            Variables.AutoComplete(txtFirstClassName,txtFirstSideNameSpace,txtIntermediateClassName,txtIntermediateNameSpace
            ,txtSecondClassName,txtSecondNameSpace    );
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (Inter != null && First != null && Second != null)
            {
                BindFormToMain();
               
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                MessageBox.Show("تمامی اجزا می بایست مشخص باشد");
            }
        }
    }
}
