using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Linq.Expressions;
namespace MsdGenerator
{
    public partial class frmRepositories : Form
    {
        public frmRepositories()
        {
            InitializeComponent();
        }
        public Model Main { get; set; }
        void EditListView(ListViewItem li, ModelRepository r)
        {
            li.SubItems.Clear();
            li.Text = r.RepoName;
            li.SubItems.Add(r.Description);
            lstRepos.Items[li.Index] = li;
            li.Tag = r;
        }
        void AddRepoToListView(ModelRepository r)
        {
            ListViewItem li = new ListViewItem();
            li.Text = r.RepoName;
            li.SubItems.Add(r.Description);
            lstRepos.Items.Add(li);
            li.Tag = r;
        }
        void BindMainToForm()
        {
            if (Main != null)
                if (Main.Repos != null && Main.Repos.Count > 0)
                    Main.Repos.ToList().ForEach(x => AddRepoToListView(x));
        }
        void BindFormToMain()
        {
            Main.Repos = new
            List<ModelRepository>();

            foreach (ListViewItem li in lstRepos.Items)
                Main.Repos.Add((ModelRepository)li.Tag);
        }
        private void frmRepositories_Load(object sender, EventArgs e)
        {
            lstRepos.Items.Clear();
            BindMainToForm();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmAddRepository f = new frmAddRepository();
            f.Main = new ModelRepository();
            f.Main.Model = Main;
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                AddRepoToListView(f.Main);
                if (Main.Repos == null)
                    Main.Repos = new
                     List<ModelRepository>();
          

                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lstRepos.SelectedItems != null && lstRepos.SelectedItems.Count == 1)
            {
                ListViewItem li = lstRepos.SelectedItems[0];
                ModelRepository repo = (ModelRepository)li.Tag;
                frmAddRepository f = new frmAddRepository();
                f.Main = repo;
                f.Main.Model = Main;
                if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    EditListView(li, f.Main);

                }

            }
            else
                MessageBox.Show("تنها بک مورد را برای ویرایش انتخاب نمایید");
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            BindFormToMain();
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
    }
}
