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
    public partial class frmMenuDVS : Form
    {
        public MsdMenu Main { get; set; }

        public frmMenuDVS()
        {
            InitializeComponent();
        }
        void Init()
        {
            Variables.Models
                .ToList()
                .ForEach(x =>
                    cboMasterModel.Items.Add(x));
            BindMainToForm();
            
        }
        void BindMainToForm()
        {
            if (Main.Master == null)
                Main.Master = new DVS();
            if (Main.Details == null)
                Main.Details = new List<DVS>();
            if (Main.Master.DS != null)
            {
                cboMasterModel.SelectedItem = Main.Master.DS.Model;
                cboMasterProfile.SelectedItem = Main.Master.DS.Profile;
                cboRepo.SelectedItem = Main.Master.DS.Repo;
            }
            if(Main.Details==null)
                Main.Details = new List<DVS>();

            if (Main.Details != null)
                Main.Details
                    .ToList()
                    .ForEach(x => {
                        if (Main.Master.DS != null && Main.Master.DS.Model != null) 
                        addnewDetailDvs(Main.Master.DS.Model.GetPropertyByName(x.DS.propertyname), x.DS.Profile,x.DVSTitle);
                        lstDetails.Items[lstDetails.Items.Count - 1].Tag = x;
                    });



        }
        private void frmMenuDVS_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void cboMasterModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMasterModel.SelectedIndex > -1)
            {
                Model m = (Model)cboMasterModel.SelectedItem;
                m.correct();
                cboRepo.Items.Clear();
                cboMasterProfile.Items.Clear();
                cboDetailProperty.Items.Clear();
                if (m.Repos != null)
                    m.Repos
                        .ToList()
                        .ForEach(x => cboRepo.Items.Add(x));
                m.GetAllUsedProfile()
                    .ToList()
                    .ForEach(x => cboMasterProfile.Items.Add(x));
                //fill detail property
                m.Properties
                    .Where(x => x.IsAssociation && x.IsCollection)
                    .ToList()
                    .ForEach(x => cboDetailProperty.Items.Add(x));

                    

            }
        }

        private void BtnManageModel_Click(object sender, EventArgs e)
        {
            if (cboMasterModel.SelectedIndex > -1)
            {
                Model m = (Model)cboMasterModel.SelectedItem;
                (new frmClass() { Main = m }).ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (cboMasterModel.SelectedIndex > -1 && cboRepo.SelectedIndex > -1
                && cboMasterProfile.SelectedIndex > -1)
            {
                if (Main.Master == null)
                    Main.Master = new DVS()
                    {
                        Form = new MsdForm(),
                        Grid = new Grid(),
                        DS = new DataSource()
                        {
                            Model = (Model)cboMasterModel.SelectedItem,
                            Repo = (ModelRepository)cboRepo.SelectedItem,
                            Profile = (Profile)cboMasterProfile.SelectedItem
                        }

                    };
                else
                {
                    if (Main.Master.Form == null)
                        Main.Master.Form = new MsdForm();
                    if (Main.Master.Grid == null)
                        Main.Master.Grid = new Grid();
                    if (Main.Master.DS == null)
                        Main.Master.DS = new DataSource()
                        {
                            Model = (Model)cboMasterModel.SelectedItem,
                            Repo = (ModelRepository)cboRepo.SelectedItem,
                            Profile = (Profile)cboMasterProfile.SelectedItem
                        };
                    else
                    {
                        Main.Master.DS.Model = (Model)cboMasterModel.SelectedItem;
                        Main.Master.DS.Repo = (ModelRepository)cboRepo.SelectedItem;
                        Main.Master.DS.Profile = (Profile)cboMasterProfile.SelectedItem;

                    }
                }

                
                (new frmMsdForm() { Main = Main.Master }).ShowDialog();
                   
            }
            else
                MessageBox.Show("Model && Repo && Profile Must Be Select");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Main.Master == null)
                Main.Master = new DVS()
                {
                    Form = new MsdForm(),
                    Grid = new Grid(),
                    DS = new DataSource()
                    {
                        Model = (Model)cboMasterModel.SelectedItem,
                        Repo = (ModelRepository)cboRepo.SelectedItem,
                        Profile = (Profile)cboMasterProfile.SelectedItem
                    }

                };

            (new frmGrid() { Main = Main.Master }).ShowDialog();

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (cboMasterModel.SelectedItem != null
                &&
                cboMasterProfile.SelectedItem != null
                &&
                cboRepo.SelectedItem != null)
            {
                if (Main.Master.DS == null)
                    Main.Master.DS = new DataSource();
                Main.Master.DS.Model = (Model)cboMasterModel.SelectedItem;
                    Main.Master.DS.Profile= (Profile )cboMasterProfile.SelectedItem;
                    Main.Master.DS.Repo = (ModelRepository)cboRepo.SelectedItem;
            }
            else
                MessageBox.Show("Model & Profile & repo Must be specified");
        }

        private void cboDetailProperty_SelectedIndexChanged(object sender, EventArgs e)
        {
            Property selectedProperty = (Property)cboDetailProperty.SelectedItem;
            cboDetailProfile.Items.Clear();
            if (selectedProperty.PropertyDescs != null)
                (from x in selectedProperty.PropertyDescs
                 where x.UseASProfileName != null && x.UseASProfileName != ""
                 select
                 x.UseAsProfile)
                 .ToList()
                 .ForEach(y => cboDetailProfile.Items.Add(y));
                 ; 

        }
        void addnewDetailDvs(Property p , Profile pr,string dvstitle)
        {
            ListViewItem li = new ListViewItem();
            li.Text = p.PropertyName;
            li.SubItems.Add(pr.Name);
            li.Tag = new DVS() { DS = new DataSource() { Profile = pr, Model = p.TargetModel, 
                propertyname = p.PropertyName}, DVSTitle=dvstitle };
            lstDetails.Items.Add(li);
            
        }
        void correctli(ListViewItem li, Property p, Profile pr,string dvstitle
            )
        {
            li.SubItems.Clear();
            li.Text = p.PropertyName;
            li.SubItems.Add(pr.Name);
            DVS dvs = (DVS)li.Tag;
            dvs.DS.Profile = pr;
            dvs.DS.propertyname = p.PropertyName;
            dvs.DS.Model = p.TargetModel;
            dvs.DVSTitle = dvstitle;
            li.Tag = dvs;
            if (li.Index > -1)
                lstDetails.Items[li.Index] = li;
        }
        private void btnDetailSave_Click(object sender, EventArgs e)
        {
            if (cboDetailProperty.SelectedItem != null
                &&
                cboDetailProfile.SelectedItem != null)
            {
                Property selectedProperty = (Property)cboDetailProperty.SelectedItem;
                Profile selectedProfile = (Profile)cboDetailProfile.SelectedItem;
                ListViewItem existli = null;
                lstDetails.Items.Cast<ListViewItem>()
                    .ToList()
                    .ForEach(x =>
                    {
                        if (((DVS)x.Tag).DS.propertyname == selectedProperty.PropertyName)
                            existli = x;
                    });
                if (existli != null)
                {
                    //exits item
                    correctli(existli, selectedProperty, selectedProfile,txtDVSTitle.Text);
                }
                else
                {
                    //new item
                    addnewDetailDvs(selectedProperty, selectedProfile,txtDVSTitle.Text);
                    if (Main.Details == null)
                        Main.Details = new List<DVS>();
                    Main.Details.Add((DVS)lstDetails.Items[lstDetails.Items.Count - 1].Tag);

                }

            }
            else
                MessageBox.Show("Detail Property And Profile Must Be Selected");
        }
        void bindlitodetail(ListViewItem li)
        {
            DVS dvs = (DVS)li.Tag;
            
            cboDetailProperty.SelectedItem = ((Model)cboMasterModel.SelectedItem).GetPropertyByName(dvs.DS.propertyname);
            cboDetailProfile.SelectedItem = dvs.DS.Profile;
            txtDVSTitle.Text = dvs.DVSTitle;

        }
        private void lstDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstDetails.SelectedItems != null
                &&
                lstDetails.SelectedItems.Count == 1)
            {
                  bindlitodetail(lstDetails.SelectedItems[0]);

            }

        }

        private void btnDetailForm_Click(object sender, EventArgs e)
        {
            if (lstDetails.SelectedItems != null
                &&
                lstDetails.SelectedItems.Count == 1)
            {
                DVS dvs = (DVS)lstDetails.SelectedItems[0].Tag;
                if (dvs.Form == null)
                    dvs.Form = new MsdForm();
                (new frmMsdForm() { Main = dvs }).ShowDialog();
            }
            else
                MessageBox.Show("Select One Item TO");

        }

        private void btnDetailGrid_Click(object sender, EventArgs e)
        {
            if (lstDetails.SelectedItems != null
               &&
               lstDetails.SelectedItems.Count == 1)
            {
                DVS dvs = (DVS)lstDetails.SelectedItems[0].Tag;
                if (dvs.Grid == null)
                    dvs.Grid = new Grid();
                (new frmGrid() { Main = dvs }).ShowDialog();
            }
            else
                MessageBox.Show("Select One Item TO");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lstDetails.SelectedItems != null &&
                lstDetails.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("are you sure?", "excli", MessageBoxButtons.YesNo)
                    == System.Windows.Forms.DialogResult.Yes)
                {
                    lstDetails.SelectedItems
                        .Cast<ListViewItem>()
                        .ToList()
                        .ForEach(x =>
                        {
                            DVS dvs = (DVS)x.Tag;
                            Main.Details.Remove(dvs);
                            lstDetails.Items.Remove(x);
                        });
                }

            }
        }

        private void btnManageDetailModel_Click(object sender, EventArgs e)
        {
            if (cboDetailProperty.SelectedIndex > -1)
            {
                Model m = ((Property)cboDetailProperty.SelectedItem).TargetModel;
                (new frmClass() { Main = m }).ShowDialog();
            }
        }
    }
}
