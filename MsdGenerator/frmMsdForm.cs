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
    public partial class frmMsdForm : Form
    {
        public DVS Main { get; set; }
        public FormItem SelectedItem { get; set; }
        void BindMainToForm()
        {
            cboName.Items.Clear(); 
            
            Main.DS.Model
                .GetPropertiesByProfileName(
                Main.DS.ProfileName)
                .Where (x=>!(x.IsCollection && x.IsAssociation))
                .ToList()
                .ForEach(x=>
                    cboName.Items.Add(x));
            if (Main.Form == null) Main.Form = new MsdForm();
            lstFormItems.Items.Clear();
            if (Main.Form != null
                &&
                Main.Form.FormItems != null)
                Main.Form.FormItems.ToList().ForEach(x => AddFieldItemToListView
                    (x))
                    ;
            txtformtitle.Text = Main.Form.FormTitle;
            cboOrientation.SelectedItem = Main.Form.titleOrientation;
            

            
        }
        void AddFieldItemToListView(FormItem fi)
        {
            ListViewItem li = new ListViewItem();
            li.Text = fi.name;
            li.SubItems.Add(fi.title);
            li.SubItems.Add(fi.Priority.ToString());
            li.SubItems.Add(fi.type);
            li.SubItems.Add(
                (fi.optionalDS ?? new DataSource() { ProfileName = "" })
                .ProfileName);
            li.Tag = fi;
            lstFormItems.Items.Add(li);
        }
        void correctli(ListViewItem li, FormItem fi)
        {
            li.SubItems.Clear();
            li.Text = fi.name;
            li.SubItems.Add(fi.title);
            li.SubItems.Add(fi.Priority.ToString());
            li.SubItems.Add(fi.type);
            li.SubItems.Add(
                (fi.optionalDS ?? new DataSource() { ProfileName = "" })
                .ProfileName);
            li.Tag = fi;
            if (li.Index > -1)
                lstFormItems.Items[li.Index] = li;

        }
        public frmMsdForm()
        {
            InitializeComponent();
        }

        private void frmMsdForm_Load(object sender, EventArgs e)
        {
            BindMainToForm();
        }

        private void cboName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboName.SelectedIndex > -1)
            {
                Property prop =(Property) cboName.SelectedItem;
                if (prop.IsAssociation)
                {
                    cboType.SelectedItem = "IRERP_SM_SelectItem";
                    cboType.Enabled = false;
                    cboProfile.Enabled = true;
                    cboCol.Enabled = true;
                    btnAddCol.Enabled = true;
                    btnRemoveCol.Enabled = true;
                    lstCols.Enabled = true;
                    cboRepo.Enabled = true;
                    //fill cbo col
                    cboProfile.Items.Clear();
                    prop.TargetModel
                        .GetAllUsedProfile()
                        .ToList()
                        .ForEach(x => cboProfile.Items.Add(x));
                    cboRepo.Items.Clear();
                    prop.TargetModel
                        .Repos.ToList()
                        .ForEach(x => cboRepo.Items.Add(x));

                }
                else
                {
                    cboType.Enabled = true;
                    cboProfile.Enabled = false;
                    cboCol.Enabled = false;
                    btnAddCol.Enabled = false;
                    btnRemoveCol.Enabled = false;
                    lstCols.Enabled = false;
                    cboRepo.Enabled = false;
                }
            }
        }

        private void cboProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstCols.Items.Clear();
            cboCol.Items.Clear();
            if (cboProfile.SelectedIndex > -1)
            {
                Profile p = (Profile)cboProfile.SelectedItem;
                Property sprop = (Property)cboName.SelectedItem;
                if (sprop != null)
                    sprop.TargetModel.GetDataSourcePropertyPathes(p.Name)
                        .ToList()
                        .ForEach(x => cboCol.Items.Add(x));
            }
        }

        private void btnAddCol_Click(object sender, EventArgs e)
        {
            if (cboCol.SelectedIndex > -1)
            {
                string selectedCol = cboCol.SelectedItem.ToString();
                bool exists = false;
                foreach(string str in lstCols.Items)
                    if (str == selectedCol)
                    { exists = true; break; }
                if (exists)
                    MessageBox.Show("Exists Before");
                else
                    lstCols.Items.Add(selectedCol);

            }
            else
                MessageBox.Show("Select An Col");
        }

        private void btnRemoveCol_Click(object sender, EventArgs e)
        {
            if (lstCols.SelectedItems != null &&
                lstCols.SelectedItems.Count > 0)
            {
                List<object> lis = new List<object>();
                foreach(var a in lstCols.SelectedItems)
                    lis.Add(a);

                foreach (object s in lis)
                    lstCols.Items.Remove(s);
            }
            else
            {
                MessageBox.Show("Seelct some items to remove");

            }
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        void BindFormToFormItem(ListViewItem li)
        {
            Property SelectedProperty = (Property)cboName.SelectedItem;
            FormItem fi = (FormItem)li.Tag ?? new FormItem();
            fi.name = ((Property)cboName.SelectedItem).PropertyName;
            fi.title = txtTitle.Text.Trim();
            int prio = 0;
            if (int.TryParse
                (txtPriority.Text, out prio))
                fi.Priority = prio;
            else
                fi.Priority = 10;
            if (SelectedProperty.IsAssociation)
                fi.type = "IRERP_SM_SelectItem";
            else
                fi.type = (string)cboType.SelectedItem ?? "IRERP_SM_TextItem";
            fi.MsdHelpMessage = txtHelpMessage.Text.Trim();
            if (SelectedProperty.IsAssociation)
            {
                fi.optionalDS = new DataSource();
                fi.optionalDS.Model = SelectedProperty.TargetModel;
                fi.optionalDS.Profile = (Profile)cboProfile.SelectedItem;
                fi.optionalDS.Repo = (ModelRepository)cboRepo.SelectedItem;
                if (fi.Fields == null)
                    fi.Fields = new List<string>();

                foreach (string str in lstCols.Items)
                    fi.Fields.Add(str);
            }
            li.Tag = fi;
        }
        void BindLiToFormItem(ListViewItem li)
        {
            FormItem fi = (FormItem)li.Tag;
            if (fi != null)
            {
                Property selectedProperty = null;
                cboName.Items.Cast<Property>().ToList()
                    .ForEach(x =>
                        {
                            if (x.PropertyName == fi.name)
                                selectedProperty = x;
                        });
                if (selectedProperty != null)
                    cboName.SelectedItem = selectedProperty;
                txtTitle.Text = fi.title;
                txtPriority.Text = fi.Priority.ToString();
                txtHelpMessage.Text = fi.MsdHelpMessage;
                if (fi.optionalDS != null)
                {
                    cboProfile .SelectedItem= fi.optionalDS.Profile;
                    cboRepo.SelectedItem = fi.optionalDS.Repo;
                    
                }
                lstCols.Items.Clear();
                if (fi.Fields != null)
                    fi.Fields.ToList()
                        .ForEach(x => lstCols.Items.Add(x));
                
            }

        }
                    
        private void btnSaveFormItem_Click(object sender, EventArgs e)
        {
            //check that this is new item or exits before
            
            ListViewItem existli = null;
            Property selectedProperty = (Property)cboName.SelectedItem;
            lstFormItems.Items.Cast<ListViewItem>().ToList()
                .ForEach(x =>
                {
                    if (((FormItem)x.Tag).name == selectedProperty.PropertyName)
                        existli = x;
                });
            if (existli != null)
            {
                //Exist before
                BindFormToFormItem(existli);
                correctli(existli, (FormItem)existli.Tag);
            }
            else
            {
                //new FormItem
                existli = new ListViewItem();
                BindFormToFormItem(existli);
                AddFieldItemToListView((FormItem)existli.Tag);
                Main.Form.FormItems.Add((FormItem)existli.Tag);

            }

        }


        private void btnDeleteFormItem_Click(object sender, EventArgs e)
        {
            if (lstFormItems.SelectedItems != null
                &&
                lstFormItems.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Are You Sure?", "Excli", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    lstFormItems.SelectedItems.Cast<ListViewItem>()
                        .ToList()
                        .ForEach(x => 
                            {
                                Main.Form.FormItems.Remove((FormItem)x.Tag);
                                lstFormItems.Items.Remove(x);
                            }
                            );
                }
            }
        }

        private void lstFormItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (
                lstFormItems.SelectedItems != null
                &&
                lstFormItems.SelectedItems.Count == 1
                )
            {
                ListViewItem li = lstFormItems.SelectedItems[0];
                BindLiToFormItem(li);
            }
                
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtformtitle.Text.Trim() != "" && cboOrientation.SelectedItem != null)
            {
                Main.Form.FormTitle = txtformtitle.Text.Trim();
                Main.Form.titleOrientation = cboOrientation.SelectedItem.ToString();
                if (Main.Form.FormItems == null)
                    Main.Form.FormItems = new List<FormItem>();

            }
            else MessageBox.Show("FormTitle && Orientation Must be sele");


        }

        private void btnmanageformitemprofile_Click(object sender, EventArgs e)
        {
            if (cboProfile.Enabled)
            {
                frmClassProfiles f = new frmClassProfiles();
                 Property prop =(Property) cboName.SelectedItem;

                 f.Main = prop.TargetModel;
                 f.ShowDialog();
                 cboProfile.Items.Clear();
                 prop.TargetModel
                     .GetAllUsedProfile()
                     .ToList()
                     .ForEach(x => cboProfile.Items.Add(x));

            }
        }

        private void btnmanageformitemrepos_Click(object sender, EventArgs e)
        {
            if (cboRepo.Enabled)
            {
                frmRepositories f = new frmRepositories();
                Property prop = (Property)cboName.SelectedItem;

                f.Main = prop.TargetModel;
                f.ShowDialog();
                cboRepo.Items.Clear();
                prop.TargetModel
                    .Repos.ToList()
                    .ForEach(x => cboRepo.Items.Add(x));    

            }
        }
    }
}
