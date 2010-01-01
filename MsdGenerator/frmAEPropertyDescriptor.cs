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
    public partial class frmAEPropertyDescriptor : Form
    {
        public Property_DSF Main { get; set; }
        void BindMainToForm()
        {
            if (Main.Profile != null)
                cboProfile.SelectedItem = Main.Profile;
            if (Main.UseAsProfile != null)
                cboUseAsProfile.SelectedItem = Main.UseAsProfile;

        }
        void BindFormToMain()
        {
            if (cboProfile.Enabled)
                Main.Profile = (Profile)cboProfile.SelectedItem;
            if (cboUseAsProfile.Enabled)
                Main.UseAsProfile = (Profile)cboUseAsProfile.SelectedItem;
            if (cboDSF.Enabled)
                Main.DSF = (PropertyDSField)cboDSF.SelectedItem;
        }
        public frmAEPropertyDescriptor()
        {
            InitializeComponent();
        }

        private void frmAEPropertyDescriptor_Load(object sender, EventArgs e)
        {
            if (Variables.Profiles != null
                && Variables.Profiles.Count > 0)
            {
                Variables.Profiles.ToList()
                    .ForEach(x =>
                    {
                        cboProfile.Items.Add(x);
                        cboUseAsProfile.Items.Add(x);
                    });
                if (Main.Property != null)
                    if (Main.Property.DSFields != null
                        &&
                        Main.Property.DSFields.Count > 0
                        )
                        Main.Property.DSFields
                            .ToList()
                            .ForEach(x =>cboDSF.Items.Add(x)
                                );

            }
            if (Main.Property.IsAssociation)
                cboDSF.Enabled = false;
            else
                cboUseAsProfile.Enabled = false;
            BindMainToForm();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (cboDSF.Enabled)
                if (cboDSF.SelectedItem == null)
                {
                    MessageBox.Show("حتما بایستی یک DSF را انتخاب کنید");
                    return;
                }
            if(cboProfile.Enabled)
                if (cboProfile.SelectedItem == null)
                {
                    MessageBox.Show("حتما بایستی یک  پروفایل را انتخاب کنید");
                    return;
                }
            if(cboUseAsProfile.Enabled)
                if (cboUseAsProfile.SelectedItem == null)
                {
                    MessageBox.Show("حتما بایستی یک پروفایل مقصد انتخاب کنید");
                    return;
                }
            BindFormToMain();
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
    }
}
