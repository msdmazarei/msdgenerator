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
    public partial class frmClassProfiles : Form
    {
        public Model Main { get; set; }
        void BindMainToForm()
        {
            if (Main.Properties != null
                )
                Main.Properties.ToList()
                    .ForEach(x =>
                        {
                            cboSIProperties.Items.Add(x);
                        });
        }
        void BindFormToMain()
        {
        }
        public frmClassProfiles()
        {
            InitializeComponent();
        }
        void Init()
        {
            Variables.Profiles.ToList()
                .ForEach(x =>
                {
                    cboSIProfiles.Items.Add(x);
                    cboSIUseAsProfile.Items.Add(x);
                    cboProfileFilter.Items.Add(x);

                });
            BindMainToForm();
            Main.correct();
        }

        private void frmClassProfiles_Load(object sender, EventArgs e)
        {
            Init();
        }
        void BindToForm(Property_DSF p)
        {
            cboSIProperties.SelectedItem = p.Property;
            cboSIProfiles.SelectedItem = p.Profile;
            if (p.Property.IsAssociation)
            {
                cboSIDSF.Enabled = false;
                cboSIUseAsProfile.Enabled = true;
                cboSIUseAsProfile.SelectedItem = p.UseAsProfile;
            }
            else
            {
                cboSIUseAsProfile.Enabled = false;
                cboSIDSF.Enabled = true;
                //Load DSFs
                cboSIDSF.Items.Clear();
                if(p.Property!=null && p.Property.DSFields!=null )
                p.Property.DSFields.ToList().ForEach
                    (x => cboSIDSF.Items.Add(x));
                cboSIDSF.SelectedItem = p.DSF;
            }
        }
        void AddPropertyToListView(Property_DSF p)
        {
            ListViewItem li = new ListViewItem();
            li.Text = p.Property.PropertyName;
            li.SubItems.Add(p.DSFName);
            li.SubItems.Add(p.UseASProfileName);
            li.Tag = p;
            lstProperties.Items.Add(li);
            
        }
        private void cboProfileFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProfileFilter.SelectedItem != null)
            {
                lstProperties.Items.Clear();
                var props = Main.GetPropertiesByProfile((Profile)cboProfileFilter.SelectedItem);

                props
                    .ToList()
                    .ForEach(x =>
                        {
                            var pdsf =(
                                from x1 in x.PropertyDescs where x1.ProfileName==((Profile)(cboProfileFilter.SelectedItem)).Name select x1).FirstOrDefault();
                            if (pdsf != null)
                            {
                                pdsf.Property = x;
                                AddPropertyToListView(pdsf);
                            }
                        });

            }
        }

        private void lstProperties_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstProperties.SelectedItems != null
                &&
                lstProperties.SelectedItems.Count == 1)
            {
                ListViewItem li = lstProperties.SelectedItems[0];
                Property_DSF pdsf = (Property_DSF)li.Tag;
                BindToForm(pdsf);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (
                (cboSIDSF.SelectedItem != null || !cboSIDSF.Enabled)
                &&
                (cboSIProfiles.SelectedItem != null || !cboSIProfiles.Enabled)
                &&
                (cboSIProperties.SelectedItem != null || !cboSIProperties.Enabled)
                &&
                (cboSIUseAsProfile.SelectedItem != null || !cboSIUseAsProfile.Enabled)
                )
            {

                bool newitem = false;
                Property SelectedProp = (Property)cboSIProperties.SelectedItem;
                Profile Prof = (Profile) cboSIProfiles.SelectedItem;
                if (SelectedProp.PropertyDescs == null)
                    SelectedProp.PropertyDescs = new List<Property_DSF>();
                Property_DSF pdsf =
                    (from x in (SelectedProp.PropertyDescs)
                     where x.ProfileName == Prof.Name
                     select x
                    ).FirstOrDefault();
                if (pdsf == null)
                {
                    //New Item
                    newitem = true;
                    pdsf = new Property_DSF();
                    pdsf.Profile = Prof;
                    if (SelectedProp.IsAssociation)
                    {
                        pdsf.UseAsProfile =
                            (Profile)cboSIUseAsProfile.SelectedItem;
                    }
                    else
                    {
                        pdsf.DSF = (PropertyDSField)cboSIDSF.SelectedItem;
                    }
                    pdsf.Property = SelectedProp;
                    SelectedProp.PropertyDescs.Add(pdsf);
                }
                else
                {
                    //Exists Item
                    if (SelectedProp.IsAssociation)
                    {
                        pdsf.UseAsProfile =
                            (Profile)cboSIUseAsProfile.SelectedItem;
                    }
                    else
                    {
                        pdsf.DSF = (PropertyDSField)cboSIDSF.SelectedItem;
                    }
                    pdsf.Property = SelectedProp;
                }
                if (cboProfileFilter.SelectedItem == cboSIProfiles.SelectedItem)
                {
                    if (newitem)
                        AddPropertyToListView(pdsf);
                    else
                    {
                        //Find Spec Li
                        foreach (ListViewItem li in lstProperties.SelectedItems)
                        {
                            var lipdsf = (Property_DSF)li.Tag;
                            if (lipdsf.ProfileName == pdsf.ProfileName &&
                                lipdsf.Property == pdsf.Property)
                            {
                                correctLi(li, pdsf);
                            }
                        }
                    }

                }
            }
            else
                MessageBox.Show("Complete Form Please.");
            //Check that Form Specs to New Item
           
        }

        void correctLi(ListViewItem li, Property_DSF p)
        {
            //ListViewItem li = new ListViewItem();
            li.SubItems.Clear();
            li.Text = p.Property.PropertyName;
            li.SubItems.Add(p.DSFName);
            li.SubItems.Add(p.UseASProfileName);
            li.Tag = p;
            lstProperties.Items[li.Index]=li;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (lstProperties.SelectedItems != null)
            {
                if(MessageBox.Show(
                    "Are You Sure?","Exclamination",MessageBoxButtons.YesNo)== System.Windows.Forms.DialogResult.Yes)
                    foreach (ListViewItem li in lstProperties.SelectedItems)
                    {
                        Property_DSF pdsf = (Property_DSF)li.Tag;
                        pdsf.Property.PropertyDescs.Remove(pdsf);
                        lstProperties.Items.Remove(li);

                    }
            }
             
        }

        private void cboSIProperties_SelectedIndexChanged(object sender, EventArgs e)
        {
            Property sp = (Property)cboSIProperties.SelectedItem;
            if (sp != null)
            {
                cboSIDSF.Items.Clear();
                if (sp.DSFields != null)
                    sp.DSFields.ToList()
                        .ForEach(x => cboSIDSF.Items.Add(x));
                if (sp.IsAssociation)
                {
                    cboSIUseAsProfile.Enabled = true;
                    cboSIDSF.Enabled = false;
                }
                else
                {
                    cboSIUseAsProfile.Enabled = false;
                    cboSIDSF.Enabled = true;
                }
            }
        }

        private void btnManageDSF_Click(object sender, EventArgs e)
        {
            if (cboSIProperties.SelectedItem != null)
            {
                Property p = (Property)cboSIProperties.SelectedItem;
                if (!p.IsAssociation)
                {
                    (new frmPropertyDFSLst() { Main = p })
                        .ShowDialog();
                    //refresh dsfes
                    cboSIDSF.Items.Clear();
                    p.DSFields.ToList()
                        .ForEach(x => cboSIDSF.Items.Add(x));
                        
                }
            }
        }
    }
}
