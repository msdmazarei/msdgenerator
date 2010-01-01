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
    public partial class Form1 : Form
    {
        string FilePath = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Show Save Dialog
            if (FilePath == null)
            {
                var savediag = new SaveFileDialog();
                if (savediag.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (savediag.FileName != null && savediag.FileName.Trim() != "")
                    {
                        try
                        {
                            
                            System.IO.FileStream f = new System.IO.FileStream(savediag.FileName, System.IO.FileMode.OpenOrCreate);
                            var bytes = Variables.Serialzie(Variables.Dic);
                            f.Write(bytes, 0, bytes.Length);
                            f.Close();
                            FilePath = savediag.FileName;
                            lblfileName.Text = FilePath;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            else
            {
                try
                {
                    System.IO.FileStream f = new System.IO.FileStream(FilePath, System.IO.FileMode.Create);
                    var bytes = Variables.Serialzie(Variables.Dic);
                    f.Write(bytes, 0, bytes.Length);
                    f.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }
        void BindModelToListView(Model m)
        {
            ListViewItem li = new ListViewItem();
            li.Text = m.NameSpace;
            li.SubItems.Add(m.ClassName);
            li.SubItems.Add(m.TableName);
            li.Tag = m;

            ListViewItem q = null;
            if(lstModels.Items.Count>0)
            q=(
                from x in lstModels.Items.Cast<ListViewItem>()
                where ( ((Model)x.Tag).NameSpace+"."+ ((Model)x.Tag).ClassName )== m.NameSpace+"."+m.ClassName
                select x
                ).FirstOrDefault() ;
            if (q != null)
            {
                lstModels.Items[q.Index] = li;
            }
            else
            {
                lstModels.Items.Add(li);
            }
        }
        void CorrectListViewItem(ref ListViewItem li, ref Model m)
        {
            
            li.SubItems.Clear();
            li.Text = m.NameSpace;
            li.SubItems.Add(m.ClassName);
            li.SubItems.Add(m.TableName);
            li.Tag = m;

        }
        private void btnAddClass_Click(object sender, EventArgs e)
        {
            frmClass frm = new frmClass();
            frm.Main =Variables.GetNewModel();
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //Check That Class Name Exits Before
                Model q = null;
                if(Variables.Models.Count>0)
                q =(
                    from x in Variables.Models 
                    where 
                    (
                        (
                            (x.NameSpace+"."+x.ClassName) 
                            ==
                            (frm.Main.NameSpace+"."+frm.Main.ClassName)
                        )
                    )
                    select x
                    ).FirstOrDefault();

                if (q != null)
                    MessageBox.Show("this Class Exits Before");
                else
                {
                    BindModelToListView(frm.Main);
                    Variables.Models.Add(frm.Main);
                }
                
            }

        }

        private void btnEditClas_Click(object sender, EventArgs e)
        {
            Model selectedModel = null;
            ListViewItem sli = null;
            if (lstModels.SelectedItems != null)
            {
                sli = lstModels.SelectedItems[0];
                selectedModel = (Model)lstModels.SelectedItems[0].Tag;
            }
            if (selectedModel != null)
            {
                frmClass frm = new frmClass();
                frm.Main = selectedModel;
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    selectedModel = frm.Main;
                    CorrectListViewItem(ref sli, ref selectedModel);
                    lstModels.Items[sli.Index] = sli;
                }
            }


        }
        void LoadClasses()
        {
            if (Variables.Models != null)
                foreach (Model m in Variables.Models)
                {
                    m.Properties.ToList().ForEach(x => x.Model = m);
                    BindModelToListView(m);
                }
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            var openfile = new OpenFileDialog();
            if (openfile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (openfile.FileName != null && openfile.FileName.Trim() != "")
                {
                    System.IO.FileStream fs = new System.IO.FileStream(openfile.FileName, System.IO.FileMode.Open);

                    byte[] buf = new byte[fs.Length];
                    fs.Read(buf, 0, buf.Length);
                    fs.Close();
                    FilePath = openfile.FileName;
                    lblfileName.Text = FilePath;
                    Variables.Dic = (Dictionary<string,object>)Variables.DeSerialize(buf);
                    Variables.Models.ToList()
                        .ForEach(x => x.correct());
                    LoadClasses();
                }
            }
        }

        private void btnGenSelected_Click(object sender, EventArgs e)
        {
            //Make Ready To Generates
            if (!System.IO.Directory.Exists("Models"))
                System.IO.Directory.CreateDirectory("Models");
            if (!System.IO.Directory.Exists("Maps"))
                System.IO.Directory.CreateDirectory("Maps");
            if (!System.IO.Directory.Exists("Repository"))
                System.IO.Directory.CreateDirectory("Repository");
            if (!System.IO.Directory.Exists("Filter"))
                System.IO.Directory.CreateDirectory("Filter");

            
            
                Func<string,byte[]> f = new Func<string,byte[]>(x=> System.Text.Encoding.Unicode.GetBytes(x));

            if (lstModels.SelectedItems != null && lstModels.SelectedItems.Count > 0)
            {
                foreach (ListViewItem li in lstModels.SelectedItems)
                {
                    Model m = (Model)li.Tag;
                    //Generate Model
                    string Model = Generator.GenModel(m, Generator.ModelGenTypes.AsModel);
                    string Map = Generator.GenModel(m, Generator.ModelGenTypes.AsMap);
                    string Repo = Generator.GenModel(m, Generator.ModelGenTypes.AsRepository);
                    string Filter = Generator.GenModel(m, Generator.ModelGenTypes.AsFilter);
                    Variables.writeToFile("Models\\" + m.ClassName + ".cs",Model);
                    Variables.writeToFile("Maps\\" + m.ClassName + "Map.cs", Map);
                    Variables.writeToFile("Repository\\" + m.ClassName + "_Repository.cs", Repo);
                    Variables.writeToFile("Filter\\" + m.ClassName + "Filter.cs", Filter);

                    //var fs = new System.IO.FileStream(, System.IO.FileMode.Create);
                    
                    //byte[] buf = f(Model);
                    //fs.WriteByte(0xff); fs.WriteByte(0xfe);
                    //fs.Write(buf, 0, buf.Length);
                    //fs.Close();

                    //fs = new System.IO.FileStream("Maps\\" + m.ClassName + "Map.cs", System.IO.FileMode.Create);

                    //buf = f(Map);
                    //fs.WriteByte(0xff); fs.WriteByte(0xfe);
                    //fs.Write(buf, 0, buf.Length);
                    //fs.Close();

                    //fs = new System.IO.FileStream("Repository\\" + m.ClassName + "_Repository.cs", System.IO.FileMode.Create);
                    
                    //buf = f(Repo);
                    //fs.WriteByte(0xff); fs.WriteByte(0xfe);
                    //fs.Write(buf, 0, buf.Length);
                    //fs.Close();

                    //fs = new System.IO.FileStream("Filter\\" + m.ClassName + "Filter.cs", System.IO.FileMode.Create);
                    
                    //buf = f(Filter);
                    //fs.WriteByte(0xff); fs.WriteByte(0xfe);
                    //fs.Write(buf, 0, buf.Length);
                    //fs.Close();

                }
                MessageBox.Show("همه تولید شدند");

            }
            else
                MessageBox.Show("کلاس ها را برای تولید انتحاب کنید");
        }

        private void btnCopySelected_Click(object sender, EventArgs e)
        {
            if (lstModels.SelectedItems != null)
            {
                if (lstModels.SelectedItems.Count > 0)
                {
                    foreach (ListViewItem li in lstModels.SelectedItems)
                    {
                        Model m = (Model)li.Tag;
                        var newmodel = (Model)m.Clone();
                        //get New mOdel Name From Operator
                        frmClassCopy frm = new frmClassCopy() { Main = newmodel };
                        if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            BindModelToListView(frm.Main);
                            Variables.Models.Add(frm.Main);
                        }
                    }
                }
                else
                    MessageBox.Show("کلاس هایی را برای کپی انتحاب کنید");
            } else
                MessageBox.Show("کلاس هایی را برای کپی انتحاب کنید");
                
        }

        private void lstModels_DoubleClick(object sender, EventArgs e)
        {
            if(lstModels.SelectedItems!=null)
                if (lstModels.SelectedItems.Count == 1)
                {
                    btnEditClas_Click(sender, e);
                }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            lstModels.Items.Clear();
            LoadClasses();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lstModels.SelectedItems != null && lstModels.SelectedItems.Count > 0)
            {
                Model m = (Model)lstModels.SelectedItems[0].Tag;
                frmCondition c = new frmCondition();
                c.Model = m;
                c.ShowDialog();
            }
        }

        private void btnAddRepo_Click(object sender, EventArgs e)
        {

        }

        private void btnProfiles_Click(object sender, EventArgs e)
        {
            (new frmProfiles()).ShowDialog();
        }

        private void btnModules_Click(object sender, EventArgs e)
        {
            (new frmModule()).ShowDialog();
        } 
    }
}
