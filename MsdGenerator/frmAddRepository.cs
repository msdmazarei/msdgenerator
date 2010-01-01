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
    public partial class frmAddRepository : Form
    {
        public ModelRepository Main { get; set; }
        void AddToListView(AtomicCriteria a)
        {
            ListViewItem li = new ListViewItem();
            li.Text = a.Path;
            li.SubItems.Add(a.Operator);
            li.SubItems.Add(a.value);
            li.Tag = a;
            lstCriterias.Items.Add(li);
        }
        void EditListViewItem(ref ListViewItem li, AtomicCriteria a)
        {
            li.SubItems.Clear();
            li.Text = a.Path;
            li.SubItems.Add(a.Operator);
            li.SubItems.Add(a.value);
            li.Tag = a;

        }
        void RemoveListViewItem(ListViewItem li)
        {
            Main.Criterias.Remove((AtomicCriteria)li.Tag);
            lstCriterias.Items.Remove(li);
        }
        void BindFormToMain()
        {
            Main.RepoName = txtRepoName.Text.Trim();
            Main.Description = txtRepoDesc.Text.Trim();
        }
        void BindMainToForm()
        {
            if (Main != null)
            {
                txtRepoName.Text = Main.RepoName;
                txtRepoDesc.Text = Main.Description;
                if (Main.Criterias != null && Main.Criterias.Count > 0)
                    Main.Criterias.ToList()
                        .ForEach(x => AddToListView(x));
                else
                    Main.Criterias = new List<AtomicCriteria>();
            }
        }
        public frmAddRepository()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmAddRepository_Load(object sender, EventArgs e)
        {
            lstCriterias.Items.Clear();
            BindMainToForm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmCondition f = new frmCondition();
            f.Main = new AtomicCriteria();
            f.Model = Main.Model;
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                AddToListView(f.Main);
                Main.Criterias.Add(f.Main);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(lstCriterias.SelectedItems!=null && lstCriterias.SelectedItems.Count>0)

            if (MessageBox.Show("Are You Sure?", "Alert", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (ListViewItem li in lstCriterias.SelectedItems)
                    RemoveListViewItem(li);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BindFormToMain();
            if (Main.RepoName != null && Main.RepoName.Trim() != "" && Main.Criterias!=null && Main.Criterias.Count>0)
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
            else
                MessageBox.Show("نام و شرط ها الزامی هستند");
        }
    }
}
