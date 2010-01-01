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
    public partial class frmModule : Form
    {
        public frmModule()
        {
            InitializeComponent();
        }
        void BindMainToForm()
        {
            Variables.Modules.ToList()
                .ForEach(x =>
                    {
                        AddModuleToListView(x);

                    });

        }
        void AddModuleToListView(Module modu)
        {
            ListViewItem li = new ListViewItem();
            li.Text = modu.ModuleTitle;
            li.SubItems.Add(modu.ModuleName);
            li.SubItems.Add(modu.Description);
            li.Tag = modu;
            lstModules.Items.Add(li);
        }
        void correctLi(ListViewItem li, Module modu)
        {
            li.SubItems.Clear();
            li.Text = modu.ModuleTitle;
            li.SubItems.Add(modu.ModuleName);
            li.SubItems.Add(modu.Description);
            li.Tag = modu;
            if (li.Index > -1)
                lstModules.Items[li.Index] = li;

        }
        void BindLiToForm(ListViewItem li)
        {
            Module modu = (Module)li.Tag;
            txtModuleTitle.Text = modu.ModuleTitle;
            txtModuleName.Text = modu.ModuleName;
            txtDescription.Text = modu.Description;
        }
        void BindFormToLi(ListViewItem li)
        {
            Module modu = (Module)li.Tag ?? new Module();
            modu.ModuleTitle = txtModuleTitle.Text;
            modu.ModuleName = txtModuleName.Text;
            modu.Description = txtDescription.Text;
            li.Tag = modu;
        }
        private void frmModule_Load(object sender, EventArgs e)
        {
            BindMainToForm();
        }
        void clearForm()
        {
            txtDescription.Text = "";
            txtModuleName.Text = "";
            txtModuleTitle.Text = "";
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (txtModuleName.Text.Trim() == "")
                MessageBox.Show("enter module name");
            else
            {
                ListViewItem si = null;
                foreach (ListViewItem li in lstModules.Items)
                {
                    Module modu = (Module)li.Tag;
                    if (modu.ModuleName == txtModuleName.Text.Trim())
                    {
                        si = li;
                        break;
                    }
                }
                if (si != null)
                {
                    //edit item
                    BindFormToLi(si);
                    correctLi(si, (Module)si.Tag);
                    clearForm();
                }
                else
                {
                    //new item
                    si = new ListViewItem();
                    BindFormToLi(si);
                    AddModuleToListView((Module)si.Tag);
                    Variables.Modules.Add((Module)si.Tag);
                    clearForm();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstModules.SelectedItems != null &&
                lstModules.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Are You Sure?", "Excli", MessageBoxButtons.YesNo)
                    == System.Windows.Forms.DialogResult.Yes)
                {
                    foreach (ListViewItem li in lstModules.SelectedItems)
                    {
                        lstModules.Items.Remove(li);
                        Variables.Modules.Remove((Module)li.Tag);
                    }
                }
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            lstModules.Items.Clear();
            BindMainToForm();
        }

        private void btnMenus_Click(object sender, EventArgs e)
        {
            if (lstModules.SelectedItems != null &&
                lstModules.SelectedItems.Count == 1)
            {
                ListViewItem li = lstModules.SelectedItems[0];
                Module modu = (Module)li.Tag;
                (new frmMenus() { Main = modu }).ShowDialog();
            }
            else
                MessageBox.Show("Select Only 1 Item");
        }


        private void lstModules_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstModules.SelectedItems!=null && 
                lstModules.SelectedItems.Count==1)
            {
                ListViewItem li = lstModules.SelectedItems[0];
                BindLiToForm(li);
            }
        }

        private void lstModules_DoubleClick(object sender, EventArgs e)
        {
            if (lstModules.SelectedItems != null &&
               lstModules.SelectedItems.Count == 1)
            {
                ListViewItem li = lstModules.SelectedItems[0];
                BindLiToForm(li);
                Module m = (Module)li.Tag;
                (new frmMenus() { Main = m }).ShowDialog();
            }

        }

        private void btnGenerateCodes_Click(object sender, EventArgs e)
        {
            lstModules.SelectedItems
                .Cast<ListViewItem>()
                .ToList()
                .ForEach(x => 
                {
                    ModuleGenerator.GenerateModule((Module)x.Tag);
                });
            MessageBox.Show("عملیات پایان یافت");
        }
    }
}
