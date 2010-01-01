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
    public partial class frmGrid : Form
    {
        public DVS Main { get; set; }
        void BindMainToForm()
        {
            if (Main.Grid == null)
                Main.Grid = new Grid();
            if (Main.Grid.Cols == null)
                Main.Grid.Cols = new List<GridCol>();
            Main.Grid.Cols.ToList()
                .ForEach(x =>  AddColToListView(x));

        }
        void AddColToListView(GridCol col)
        {
            ListViewItem li = new ListViewItem();
            li.Text = col.name;
            li.SubItems.Add(col.title);
            li.SubItems.Add(col.showif);
            li.Tag = col;
            lstcols.Items.Add(li);
        }
        void correctli(ListViewItem li, GridCol col)
        {
            li.SubItems.Clear();
            li.Text = col.name;
            li.SubItems.Add(col.title);
            li.SubItems.Add(col.showif);
            li.Tag = col;

            if (li.Index > -1)
                lstcols.Items[li.Index] = li;
        }

        public frmGrid()
        {
            InitializeComponent();
        }
        void Init()
        {
            cboName.Items.Clear();
            Main.DS.GetDSFields()
                .ToList()
                .ForEach(x => cboName.Items.Add(x));
            BindMainToForm();
        }
        private void frmGrid_Load(object sender, EventArgs e)
        {
            Init();
        }
        void FormToGridCol(ListViewItem li)
        {
            GridCol gc = (GridCol) li.Tag?? new GridCol();
            gc.name = cboName.SelectedItem.ToString();
            gc.showif = txtShowIf.Text.Trim();
            gc.title = txtTitle.Text.Trim();
            li.Tag = gc;

        }
        void GridColToForm(GridCol c)
        {
            cboName.SelectedItem = c.name;
            txtShowIf.Text = c.showif;
            txtTitle.Text = c.title;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cboName.SelectedItem != null)
            {
                string name = cboName.SelectedItem.ToString();
                ListViewItem existsli = null;
                lstcols.Items
                    .Cast<ListViewItem>()
                    .ToList()
                    .ForEach(x => { if (((GridCol)x.Tag).name == name) existsli = x; });
                if (existsli != null)
                {
                    //exists before
                    FormToGridCol(existsli);
                    correctli(existsli, (GridCol)existsli.Tag);

                }
                else
                {
                    //new item
                    existsli = new ListViewItem();
                    FormToGridCol(existsli);
                    AddColToListView((GridCol)existsli.Tag);
                    Main.Grid.Cols.Add((GridCol)existsli.Tag);

                }
            }
        }

        private void lstcols_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstcols.SelectedItems != null
                &&
                lstcols.SelectedItems.Count == 1)
            {
                ListViewItem li = lstcols.SelectedItems[0];
                GridColToForm((GridCol)li.Tag);
            }
                
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstcols.SelectedItems != null
                &&
                lstcols.SelectedItems.Count > 0)
            {
                lstcols.SelectedItems.Cast<ListViewItem>()
                    .ToList()
                    .ForEach(x => {
                        Main.Grid.Cols.Remove((GridCol)x.Tag);
                        lstcols.Items.Remove(x);
                    });
            }
            else
                MessageBox.Show("select some items to delete");
        }
    }
}
