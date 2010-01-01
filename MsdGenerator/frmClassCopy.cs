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
    public partial class frmClassCopy : Form
    {
        public Model Main { get; set; }
        public frmClassCopy()
        {
            InitializeComponent();
        }
        void BindMainToForm()
        {
            if (Main != null)
            {
                txtNameSpace.Text = Main.NameSpace;
                txtClassName.Text = Main.ClassName;
                txtTableName.Text = Main.TableName;
            }
        }
        void BindFormToMain()
        {
            if (Main != null)
            {
                Main.NameSpace = txtNameSpace.Text.Trim();
                Main.ClassName = txtClassName.Text.Trim();
                Main.TableName = txtTableName.Text.Trim();
            }
        }

        private void txtNameSpace_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmClassCopy_Load(object sender, EventArgs e)
        {
            BindMainToForm();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            BindFormToMain();
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
