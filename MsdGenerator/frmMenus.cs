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
    public partial class frmMenus : Form
    {
        public Module Main { get; set; }
        public frmMenus()
        {
            InitializeComponent();
        }
        void BindMainToForm()
        {
            if (Main.Menus != null)
                Main.Menus
                    .ToList()
                    .ForEach(x =>
                        AddMenuToListView(x));

        }
        void AddMenuToListView(MsdMenu menu)
        {
            ListViewItem li = new ListViewItem();
            li.Tag = menu;
            li.Text = menu.MenuTitle;
            li.SubItems.Add(menu.MenuName);
            li.SubItems.Add(menu.Description);
            lstMenus.Items.Add(li);
        }
        void Correctli(ListViewItem li, MsdMenu menu)
        {
            li.SubItems.Clear();
            li.Tag = menu;
            li.Text = menu.MenuTitle;
            li.SubItems.Add(menu.MenuName);
            li.SubItems.Add(menu.Description);
            if (li.Index > -1)
                lstMenus.Items[li.Index] = li;

        }
        void bindFormToli(ListViewItem li)
        {
            MsdMenu menu = (MsdMenu)li.Tag ?? new MsdMenu() ;
            menu.Description = txtDescription.Text.Trim();
            menu.MenuName = txtMenuName.Text.Trim();
            menu.MenuTitle = txtMenuTitle.Text.Trim();
            li.Tag = menu;
        }
        void BindLitoForm(ListViewItem li)
        {
            MsdMenu menu = (MsdMenu)li.Tag;
            txtDescription.Text = menu.Description;
            txtMenuName.Text = menu.MenuName;
            txtMenuTitle.Text = menu.MenuTitle;
        }
        private void frmMenus_Load(object sender, EventArgs e)
        {
            BindMainToForm();
        }
        void ClearForm()
        {
            txtMenuTitle.Text = "";
            txtMenuName.Text = "";
            txtDescription.Text = "";

        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (txtMenuName.Text.Trim() == "")
                MessageBox.Show("enter menu name");
            else
            {
                ListViewItem si = null;
                foreach (ListViewItem li in lstMenus.Items)
                {
                    MsdMenu menu = (MsdMenu)li.Tag;
                    if (menu.MenuName == txtMenuName.Text.Trim())
                    {
                        si = li;
                        break;
                    }
                }
                if (si != null)
                {
                    //edit item
                    bindFormToli(si);
                    Correctli(si, (MsdMenu)si.Tag);
                    ClearForm();
                }
                else
                {
                    //new item
                    si = new ListViewItem();
                    bindFormToli(si);
                    AddMenuToListView((MsdMenu)si.Tag);
                    Main.Menus.Add((MsdMenu)si.Tag);
                    ClearForm();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstMenus.SelectedItems != null &&
              lstMenus.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Are You Sure?", "Excli", MessageBoxButtons.YesNo)
                    == System.Windows.Forms.DialogResult.Yes)
                {
                    foreach (ListViewItem li in lstMenus.SelectedItems)
                    {
                        lstMenus.Items.Remove(li);
                        Main.Menus.Remove((MsdMenu)li.Tag);
                    }
                }
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            lstMenus.Items.Clear();
            BindMainToForm();
        }

        private void lstMenus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstMenus.SelectedItems != null
                &&
                lstMenus.SelectedItems.Count == 1)
            {
                ListViewItem li = lstMenus.SelectedItems[0];
                BindLitoForm
                    (li);
            }
        }

        private void btnDVS_Click(object sender, EventArgs e)
        {
            if (lstMenus.SelectedItems != null
                && lstMenus.SelectedItems.Count == 1)
            {
                ListViewItem li = lstMenus.SelectedItems[0];
                MsdMenu menu = (MsdMenu)li.Tag;
                (new frmMenuDVS() { Main = menu }).ShowDialog();
            }
            else
                MessageBox.Show("Select Only 1 Item");
        }

        private void lstMenus_DoubleClick(object sender, EventArgs e)
        {
            if (lstMenus.SelectedItems != null
             && lstMenus.SelectedItems.Count == 1)
            {
                ListViewItem li = lstMenus.SelectedItems[0];
                MsdMenu menu = (MsdMenu)li.Tag;
                (new frmMenuDVS() { Main = menu }).ShowDialog();
            }
        }
    }
}
