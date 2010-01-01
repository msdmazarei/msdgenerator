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
    public partial class frmProfiles : Form
    {
        public frmProfiles()
        {
            InitializeComponent();
        }
        void BindMainToForm()
        {
            //Load All Profiles
            Variables.Profiles
                .ToList()
                .ForEach(x =>
                lstProfiles.Items.Add(x));
        }
        void BindFormToMain()
        {
        }
        void LoadFormBySelected()
        {
            if (lstProfiles.SelectedIndex > -1)
            {
                txtProfile.Text = ((Profile)lstProfiles.SelectedItem).Name;
                txtDesc.Text = ((Profile)lstProfiles.SelectedItem).Description;
            }

        }
        private void frmProfiles_Load(object sender, EventArgs e)
        {
            BindMainToForm();
        }

        private void lstProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {

            LoadFormBySelected();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Check That This Profil
            if (txtProfile.Text.NotEmpty())
            {
                bool existbefore = Variables.Profiles.Count > 0 &&
                    (from x in Variables.Profiles where x.Name == txtProfile.Text.Trim() select x).Count() > 0;
                if (existbefore)
                    MessageBox.Show("از قبل وجود دارد");
                else
                {
                    Profile newitem = new Profile()
                    {
                        Name = txtProfile.Text.Trim(),
                        Description = txtDesc.Text.Trim()
                    };
                    lstProfiles.Items.Add(newitem);
                    Variables.Profiles.Add(newitem);
                         
                }

            }
            else
                MessageBox.Show("پروفایل بایستی حتما نام داشته باشد");
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lstProfiles.SelectedItem != null)
            {
                if (txtProfile.Text.NotEmpty())
                {
                    bool existbefore =
                        Variables.Profiles.Count > 0 &&
                        (from x in Variables.Profiles where x.Name == txtProfile.Text.Trim() select x).Count() > 0;
                    if (existbefore)
                        MessageBox.Show("از قبل وجود دارد");
                    else
                    {
                        Profile item = (Profile) lstProfiles.SelectedItem;
                        item.Name = txtProfile.Text.Trim();
                        item.Description = txtDesc.Text.Trim();
                        lstProfiles.Items[lstProfiles.SelectedIndex] = item;
                    }

                }
                else
                    MessageBox.Show("پروفایل بایستی حتما نام داشته باشد");
        
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
