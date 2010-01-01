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
    public partial class frmDFS : Form
    {
        public PropertyDSField Main { get; set; }
        void BindMainToForm()
        {
            txtDSFName.Text = Main.DSFName;
            txtName.Text = Main.name;
            txtRootValue.Text = Main.rootValue;
            txtTitle.Text = Main.title;
            txtValueMap.Text = Main.valueMap;
            txtClientType.Text = Main.ClientType;
            chkHidden.Checked = Main.Hidden;
            chkPrimaryKey.Checked = Main.PrimaryKey;
            chkRequire.Checked = Main.Require;
            chkTranslate.Checked = Main.TranslateTitle;
            
        }
        void BindFormToMain()
        {
            Main.DSFName = txtDSFName.Text.Trim();
            Main.name = txtName.Text.Trim();
            Main.rootValue = txtRootValue.Text.Trim();
            Main.title = txtTitle.Text.Trim();
            Main.valueMap = txtValueMap.Text.Trim();
            Main.ClientType = txtClientType.Text.Trim();
            Main.Hidden = chkHidden.Checked;
            Main.PrimaryKey = chkPrimaryKey.Checked;
            Main.Require = chkRequire.Checked;
            Main.TranslateTitle = chkTranslate.Checked;
         
        }
        public frmDFS()
        {
            InitializeComponent();
        }

        private void frmDFS_Load(object sender, EventArgs e)
        {
            BindMainToForm();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            
            BindFormToMain();
            if (Main.DSFName.NotEmpty())
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
            else
                MessageBox.Show("نام برای الزامی است");
        }
    }
}
