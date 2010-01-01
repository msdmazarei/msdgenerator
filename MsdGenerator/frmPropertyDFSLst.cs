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
    public partial class frmPropertyDFSLst : Form
    {
        public Property Main { get; set; }
        public frmPropertyDFSLst()
        {
            InitializeComponent();
        }
        void AddToListView(PropertyDSField i)
        {
            ListViewItem li = new ListViewItem();
            li.Text = i.DSFName;
            li.SubItems.Add(i.Hidden.ToString());
            li.SubItems.Add(i.PrimaryKey.ToString());
            li.SubItems.Add(i.Require.ToString());
            li.SubItems.Add(i.rootValue);
            li.SubItems.Add(i.name);
            li.SubItems.Add(i.title);
            li.SubItems.Add(i.TranslateTitle.ToString());
            li.SubItems.Add(i.valueMap);
            li.SubItems.Add(i.ClientType);
            li.Tag = i;
            lstDfs.Items.Add(li);
                
        }
        void CorrectLi(ListViewItem li, PropertyDSField i)
        {
            li.SubItems.Clear();
            li.Text = i.DSFName;
            li.SubItems.Add(i.Hidden.ToString());
            li.SubItems.Add(i.PrimaryKey.ToString());
            li.SubItems.Add(i.Require.ToString());
            li.SubItems.Add(i.rootValue);
            li.SubItems.Add(i.name);
            li.SubItems.Add(i.title);
            li.SubItems.Add(i.TranslateTitle.ToString());
            li.SubItems.Add(i.valueMap);
            li.SubItems.Add(i.ClientType);
            li.Tag = i;
            lstDfs.Items[li.Index] = li;
        }

        void BindMainToForm()
        {
            if (Main != null)
                if (Main.DSFields != null && Main.DSFields.Count > 0)
                    Main.DSFields
                        .ToList()
                        .ForEach(
                        x => {
                            AddToListView(x);
                        });
            if (Main.DSFields == null)
                Main.DSFields = new
                List<PropertyDSField>();
        }
        void BindFormToMain()
        {
        }
        private void frmPropertyDFSLst_Load(object sender, EventArgs e)
        {
            lstDfs.Items.Clear();
            BindMainToForm();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmDFS f = new frmDFS();
            
            f.Main = new PropertyDSField() { };
            f.Main.DSFName = "Default";
            if (Main.isPrimaryKey)
            {
                f.Main.PrimaryKey = true;
                f.Main.Hidden = true;
            }
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                AddToListView(f.Main);
                Main.DSFields.Add(f.Main);
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lstDfs.SelectedItems != null
                && lstDfs.SelectedItems.Count == 1)
            {
                ListViewItem li = lstDfs.SelectedItems[0];
                PropertyDSField fi = (PropertyDSField)li.Tag;
                frmDFS f = new frmDFS();
                f.Main = fi;
                if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    CorrectLi(li, f.Main);
                }

            }
            else
                MessageBox.Show("یک مورد را برای ویرایش انتخاب کنید");
            

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (
                lstDfs.SelectedItems != null &&
                lstDfs.SelectedItems.Count > 0)
            {
                if(
                    MessageBox.Show("آیا مطمئن هستید?","اخطار", MessageBoxButtons.YesNo) 
                    ==  
                    System.Windows.Forms.DialogResult.Yes)

                foreach (ListViewItem li in lstDfs.SelectedItems)
                {
                    PropertyDSField fi= (PropertyDSField) li.Tag;
                    lstDfs.Items.Remove(li);
                    Main.DSFields.Remove(fi);
                }

            }

            else
                MessageBox.Show("مواردی را برای حذف انتخاب کنید");
                
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
    }
}
