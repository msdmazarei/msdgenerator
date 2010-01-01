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
    public partial class frmCondition : Form
    {
        void BindMainToForm()
        {
            picker.SelectedProperty = Main.Path;
            cboOperator.SelectedText = Main.Operator;
            txtValue.Text = Main.value;
        }
        void BindFormToMain()
        {
            Main.Path = picker.SelectedProperty;
            Main.Operator =(string) cboOperator.SelectedItem;
            Main.value = txtValue.Text;
        }
        public AtomicCriteria Main { get; set; }
        public frmCondition()
        {
            InitializeComponent();
        }
        public Model Model { get { return picker.Model; } set { picker.Model = value; } }
        private void frmCondition_Load(object sender, EventArgs e)
        {
            picker.PropertySelected += new UserControls.PickModelProperty.ItemSelected(x => label1.Text = x);
            BindMainToForm();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            BindFormToMain();
            if (Main.Path != null && Main.Path.Trim() != "" && Main.Operator != null && Main.Operator.Trim() != "")
            {
                DialogResult = System.Windows.Forms.DialogResult.OK
                    ;
                Close();
            }
            else
                MessageBox.Show("انتخاب اپراتور و فیلد الزامی است");
        }
    }
}
