using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MsdGenerator.UserControls
{
    public partial class PickModelProperty : UserControl
    {
        public delegate void ItemSelected(string selectedItem);

        public ItemSelected PropertySelected { get; set; }

        string _selProp = null;
        public string SelectedProperty { get { return _selProp; } set { _selProp = value; if (PropertySelected != null) PropertySelected(value); } }
        ToolStripItem GetToolStripItem(string Path, Property p)
        {
            var rtn = new ToolStripMenuItem(p.PropertyName);
            if (Path != null && Path.Trim() != "")
                rtn.Tag = Path + "." + p.PropertyName;
            else
                rtn.Tag = p.PropertyName;
            rtn.Click += new EventHandler((o, e) => SelectedProperty = (string)rtn.Tag);
            if (p.IsAssociation)
            {
                if (p.IsCollection)
                {
                    rtn.Tag = (string)rtn.Tag + "[0]";
                }
                else
                {
                }
                rtn.MouseHover += new EventHandler((o, e) => {
                    if (rtn.DropDownItems != null && rtn.DropDownItems.Count > 0)
                    {
                    }
                    else
                    {
                        //Get Final Model
                        Model tgtModel = Variables.GetModelByPropertyPath(Model, (string)rtn.Tag);
                        if(tgtModel!=null)
                            if(tgtModel.Properties!=null && tgtModel.Properties.Count>0)
                                tgtModel.Properties.ToList().ForEach(x=>
                                    rtn.DropDownItems.Add(GetToolStripItem((string)rtn.Tag,x)));
                    }
                 
                });
            }
            return rtn;
        }
        void LoadModel()
        {
            MainBtn.DropDownItems.Clear();
            if (Model != null)
            {
                MainBtn.Text = Model.ClassName;
                if (Model.Properties != null && Model.Properties.Count > 0)
                    Model.Properties.ToList().ForEach(x =>
                    {
                        MainBtn.DropDownItems.Add(GetToolStripItem("", x));
                    });
            }
        }
        Model _model = null;
        public Model Model { get { return _model; } set { _model = value; LoadModel(); } }
       
        public PickModelProperty()
        {
            InitializeComponent();
           
        }
    }
}
