using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MsdGenerator
{
    public partial class frmClass : Form
    {
        public Model Main { get; set; }
        public frmClass()
        {
            InitializeComponent();
        }
        void CorrectListViewInListView(ref ListViewItem li, ref Property p)
        {
            li.SubItems.Clear();
            li.Text = p.PropertyType;
            li.SubItems.Add(p.IsAssociation.ToString());
            li.SubItems.Add(p.IsCollection.ToString());
            li.SubItems.Add(p.PropertyName);
            li.SubItems.Add(p.isPrimaryKey.ToString());
            li.SubItems.Add(p.Generator);
            li.SubItems.Add(p.ColumnName);
            li.SubItems.Add(p.KeyColumn);
            li.SubItems.Add(p.PropertyRef);
        }
        void BindPropertyToListView(Property p)
        {
            ListViewItem li = new ListViewItem();
            
            li.Text = p.PropertyType;
            li.SubItems.Add(p.IsAssociation.ToString());
            li.SubItems.Add(p.IsCollection.ToString());
            li.SubItems.Add(p.PropertyName);
            li.SubItems.Add(p.isPrimaryKey.ToString());
            li.SubItems.Add(p.Generator);
            li.SubItems.Add(p.ColumnName);
            li.SubItems.Add(p.KeyColumn);
            li.SubItems.Add(p.PropertyRef);

            li.Tag = p;
            ListViewItem q = null;
            if(lstProperties.Items.Count>0)
            q = (
                from x in lstProperties.Items.Cast<ListViewItem>()
                where ((Property)x.Tag).PropertyName == p.PropertyName
                select x
                ).FirstOrDefault();

            if (q != null) 
            { 
                //Exits Before
                lstProperties.Items[q.Index] = li;
            }
            else
            {
                lstProperties.Items.Add(li);
            }
        }
        void BindFormToMain()
        {
            Main.NameSpace = txtNameSpace.Text.Trim();
            Main.ClassName = txtClassName.Text.Trim();
            Main.TableName = txtTableName.Text.Trim();
            Main.HasLogClass = chkHasLog.Checked;
        }
        void BindMainToForm()

        {
            txtNameSpace .Text= Main.NameSpace;
            txtClassName .Text= Main.ClassName;
            txtTableName .Text= Main.TableName;
            chkHasLog.Checked = Main.HasLogClass;
            if (Main.Properties != null)
                foreach (var m in Main.Properties)
                    BindPropertyToListView(m);




        }
       
        private void frmClass_Load(object sender, EventArgs e)
        {
           Variables. AutoComplete(txtClassName);
           Variables.AutoComplete(txtNameSpace);
           Variables.AutoComplete(txtTableName);
            //Clear List view
            lstProperties.Items.Clear() ;
            if (Main != null)
            {
                BindMainToForm();
            }

        }

        private void btnAddProperty_Click(object sender, EventArgs e)
        {
            frmProperty frm = new frmProperty();
            frm.Main = new Property() { Model = Main };
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //Check That Property Exits Before
                Property q = null ;
                if(Main.Properties.Count>0)
                q =(
                    from x in Main.Properties
                    where x.PropertyName == frm.Main.PropertyName
                    select x 
                    ).FirstOrDefault();

                if (q != null)
                {
                    MessageBox.Show("This Property Name Used Before Change Your Propert Name");
                }
                else
                {
                    frm.Main.Model = Main;
                    Main.Properties.Add(frm.Main);
                    BindPropertyToListView(frm.Main);
                    
                }

            }
            frm.Dispose();
        }

        private void btnDelProperty_Click(object sender, EventArgs e)
        {
            if (lstProperties.SelectedItems != null)
            {
                foreach (ListViewItem item in lstProperties.SelectedItems)
                {
                    Main.Properties.Remove((Property)item.Tag);
                    lstProperties.Items.Remove(item);
                }
            }
        }

        private void btnSaveClass_Click(object sender, EventArgs e)
        {
            BindFormToMain();
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnEditPropety_Click(object sender, EventArgs e)
        {
            if (lstProperties.SelectedItems != null && lstProperties.SelectedItems.Count==1)
            {
                ListViewItem li = lstProperties.SelectedItems[0];
                Property prope = (Property)li.Tag;
                frmProperty frm = new frmProperty() { Main = prope};
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    prope = frm.Main;
                    li.Tag= prope;

                    CorrectListViewInListView(ref li, ref prope);
                    lstProperties.Items[li.Index] = li;

                }
            }

        }

        private void lstProperties_DoubleClick(object sender, EventArgs e)
        {
            btnEditPropety_Click(sender, e);
        }

        private void btnManageRepos_Click(object sender, EventArgs e)
        {
            frmRepositories c = new frmRepositories();
            c.Main = Main;
            
            c.ShowDialog();
           // Main.Repos = c.Main.Repos;
        }

        private void btnManageDescs_Click(object sender, EventArgs e)
        {
            (new frmClassProfiles() {Main=Main }).ShowDialog();
        }
    }
}
