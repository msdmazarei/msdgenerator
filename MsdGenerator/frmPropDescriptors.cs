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
    public partial class frmPropDescriptors : Form
    {
        public Property Main { get; set; }
        void CorrectLi(ListViewItem li, Property_DSF i)
        {
            li.SubItems.Clear();
            li.Text = i.ProfileName;
            li.SubItems.Add(i.DSFName);
            li.SubItems.Add(i.UseASProfileName);
            li.Tag = i;
            lstDescriptors.Items[li.Index] = li;

        }
        void AddToListView(Property_DSF i)
        {
            ListViewItem li = new ListViewItem();
            li.Text = i.ProfileName;
            li.SubItems.Add(i.DSFName);
            li.SubItems.Add(i.UseASProfileName);
            li.Tag = i;
            lstDescriptors.Items.Add(li);
            
        }
        void BindMainToForm()
        {
            if (Main != null)
                if (Main.PropertyDescs != null
                    && Main.PropertyDescs.Count > 0)
                    Main.PropertyDescs.
                        ToList().ForEach(
                        x => AddToListView(x)
                            );

        }
        void BindFormToMain()
        {
        }

        public frmPropDescriptors()
        {
            InitializeComponent();
        }

        private void frmPropDescriptors_Load(object sender, EventArgs e)
        {
            BindMainToForm();
            if (
                Main.PropertyDescs == null)
                Main.PropertyDescs = new List<Property_DSF>();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAEPropertyDescriptor f = new frmAEPropertyDescriptor();
            f.Main = new Property_DSF();
            f.Main.Property = Main;
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                AddToListView(f.Main);
                Main.PropertyDescs.Add(f.Main);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lstDescriptors.SelectedItems != null
                &&
                lstDescriptors.SelectedItems.Count == 1)
            {
                ListViewItem li = lstDescriptors.SelectedItems[0];
                Property_DSF p = (Property_DSF)li.Tag;
                frmAEPropertyDescriptor f = new frmAEPropertyDescriptor();
                f.Main = p;
                if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    CorrectLi(li, p);
                }

            }
            else
                MessageBox.Show("یک مورد را برای ویرایش انتخاب کنید");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstDescriptors.SelectedItems != null
                &&
                lstDescriptors.SelectedItems.Count > 0)
            {
                if (
                    MessageBox.Show("آیا از حذف موارد مطمئن هستید?", "اخطار", MessageBoxButtons.YesNo)
                    ==
                    System.Windows.Forms.DialogResult.Yes
                    )
                {
                    foreach (ListViewItem li in lstDescriptors.SelectedItems)
                    {
                        Main.PropertyDescs.Remove((Property_DSF)li.Tag);
                        lstDescriptors.Items.Remove(li);
                    }
                }

            }
            else
                MessageBox.Show("برای حذف مواردی را انتخاب کنید");
        }
    }
}
