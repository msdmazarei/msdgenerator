using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace MsdGenerator
{
    public class ModuleGenerator
    {
        public static void GenerateModuleFolders(Module modu)
        {
            string mn = modu.ModuleName;
            if (!System.IO.Directory.Exists("Modules"))
                System.IO.Directory.CreateDirectory("Modules");
            if (!System.IO.Directory.Exists("Modules\\Areas"))
                System.IO.Directory.CreateDirectory("Modules\\Areas");
            if (!System.IO.Directory.Exists("Modules\\Areas"))
                System.IO.Directory.CreateDirectory("Modules\\Areas");
            if (!System.IO.Directory.Exists("Modules\\Areas\\"+mn))
                System.IO.Directory.CreateDirectory("Modules\\Areas\\"+mn);
            if (!System.IO.Directory.Exists("Modules\\Areas\\" + mn))
                System.IO.Directory.CreateDirectory("Modules\\Areas\\" + mn);
            if (!System.IO.Directory.Exists("Modules\\Areas\\" + mn+"\\Controllers"))
                System.IO.Directory.CreateDirectory("Modules\\Areas\\" + mn + "\\Controllers");
            if (!System.IO.Directory.Exists("Modules\\Areas\\" + mn + "\\Models"))
                System.IO.Directory.CreateDirectory("Modules\\Areas\\" + mn + "\\Models");
            if (!System.IO.Directory.Exists("Modules\\Areas\\" + mn + "\\Views"))
                System.IO.Directory.CreateDirectory("Modules\\Areas\\" + mn + "\\Views");
            if (!System.IO.Directory.Exists("Modules\\Areas\\" + mn + "\\Views\\"+mn))
                System.IO.Directory.CreateDirectory("Modules\\Areas\\" + mn + "\\Views\\"+mn);
        }
        

        public static void GenerateModule(Module modu)
        {
            Dictionary<string, object> GenerateObjs = new Dictionary<string, object>();
            GenerateObjs.Add("Views", new Dictionary<string, object>()); //Views
            
            GenerateModuleFolders(modu);
            //generate registeration
            Variables.writeToFile("Modules\\Areas\\" + modu.ModuleName + "\\" + modu.ModuleName + "AreaRegistration.cs", Registeration(modu));
            Variables.writeToFile("Modules\\" + modu.ModuleName + "_MetaModel.cs", MetaModel(modu));
            Variables.writeToFile("Modules\\" + modu.ModuleName + "_MetaModelMap.cs", MetaModelMap(modu));
            Variables.writeToFile("Modules\\Areas\\" + modu.ModuleName + "\\Controllers\\" + modu.ModuleName + "Controller.cs", Controller(modu));

            string MenuGeneration = string.Format(@"
 mnuModu = new MenuItem() {{ EnName = ""{0}"", Title = ""{0}"" }};
            mnuModu.Save();
            gpmn = new GroupMenu() {{ Menu = mnuModu, Group = admingroup }};
            gpmn.Save();
",modu.ModuleName);
        
            if (modu.Menus != null)
                modu.Menus.ToList()
                    .ForEach(
                    x =>
                    {
                        MenuGeneration += string.Format(@"
            mnu = new MenuItem() {{ ParentID = mnuModu.id, Title = ""{0}"", EnName = ""{0}"", 
MethodToCall = ""\""AddTab('{0}','/{1}/{1}/{0}')\"""" }};
            mnu.Save();
            gpmn = new GroupMenu() {{ Menu = mnu, Group = admingroup }};
            gpmn.Save();
", x.MenuName,modu.ModuleName);
                        Variables.writeToFile("Modules\\Areas\\" + modu.ModuleName + "\\Views\\" + modu.ModuleName + "\\" + x.MenuName + ".cshtml", View(GenerateObjs, modu, x));
                        //fs = new FileStream("Modules\\Areas\\" + modu.ModuleName + "\\Views\\"+modu.ModuleName+"\\" + x.MenuName + ".cshtml", FileMode.Create);
                        //buf = f(View(GenerateObjs,modu,x));
                        //fs.Write(buf, 0, buf.Length);
                        //fs.Close();
                    }
                    );
            Variables.writeToFile("Modules\\Areas\\" + modu.ModuleName  + "\\menugen.cs", MenuGeneration);
        }
     
        const string newline = "\r\n";
        static List<string> Usings(List<DataSource> dses)
        {
            List<string> usings = new List<string>();
            dses.ForEach(x =>
            {
                if (x.ModelNameSpace != null && x.ModelNameSpace.Trim() != "")
                    if (!usings.Contains(x.ModelNameSpace))
                        usings.Add(x.ModelNameSpace);

            });
            return usings;

        }

        static string Controller(Module modu)
        {
            List<DataSource> Dses = (List<DataSource>)modu.GetAllUsedDataSources();

            string rtn = "";
            rtn += @"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Bases.IRERPController;
using IRERP_RestAPI.Models;
";
            Usings(Dses).ForEach(x => rtn += "using IRERP_RestAPI.Models." + x + ";"+ newline); //model usinhgs
            rtn+=string.Format(@"
namespace IRERP_RestAPI.Areas.{0}.Controllers
{{
    public class {0}Controller  : IRERPController<MetaModel.{0}_MetaModel>
    {{

",modu.ModuleName);
            var MasterModels = modu.GetAllMasterModels();
            if (MasterModels != null)
            {
                rtn += @"
public override void InitControllerSessionValues()
        {
            base.InitControllerSessionValues();";
                MasterModels.ToList().ForEach(x=>{
                    rtn+=string.Format(@"
            IRERPApplicationUtilities.RequestParameters<MetaModel.{0}>(x => x.Selected{1}.{2});

", modu.ModuleName+"_MetaModel",x.ClassName,x.PrimaryKey().PropertyName);
                });
                rtn += @"        }
";
            }
            if (modu.Menus != null)
                modu.Menus
                    .ToList()
                    .ForEach(x =>
                    {
                        rtn += string.Format(@"
    public ActionResult {0}()
        {{
            return View(MetaModelInstance);
        }}

", x.MenuName);
                    });
            rtn += @"} //Controller end
            }//namespace end";
                        
            return rtn;

        }
        static Func<Dictionary<string, object>, string, object> GetDicByKey = (x, y) => {
            if (x.Keys.Contains(y)) return x[y];
            else
                x.Add(y, new Dictionary<string, object>());
            return x[y];

        };
        static string View(Dictionary<string,object> genobjs,Module modu,MsdMenu menu)
        {
            return new MenuGenerator(modu, menu).View();
        }
        
      
     
  
        public static string MetaModel(Module modu)
        {
            string rtn = "";
            rtn = @"
using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Bases.IRERPController.IRERPControllerMetaModel;
using IRERP_RestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;" + newline;
            List<DataSource> Dses = (List<DataSource>)modu.GetAllUsedDataSources();
         
            Usings(Dses).ForEach(x => rtn += "using IRERP_RestAPI.Models." + x+";");
            rtn += string.Format(@"
namespace IRERP_RestAPI.MetaModel
{{
    public class {0}_MetaModel : ControllerMetaModelBase<{0}_MetaModel>
    {{  
        public {0}_MetaModel()
        {{
            Profile = Bases.MetaDataDescriptors.IRERPProfile.General;

        }}"+newline,modu.ModuleName);
            var MasterModels = modu.GetAllMasterModels();
            if (MasterModels != null)
                MasterModels.ToList().ForEach(x =>
                {
                    rtn += string.Format(@"

Public Virtual {0} Selected{0}
{{
get{{
  var selectedid =
                    IRERP_RestAPI.Bases.IRERPApplicationUtilities.GetFromRequest<{1}>(x => x.Selected{0}.{2});
               
                {3} id;
                if (selectedid != null)
                    if ({3}.TryParse(selectedid, out id))
                        return {4}.GetByPK(id);
                return new {0}();
 
}}
}}
", 
 x.ClassName,
 modu.ModuleName+"_MetaModel",
 x.PrimaryKey().PropertyName,
 x.PrimaryKey().PropertyType,x.GetRepositoryName());
                });
            List<DataSource> UniqDs_ProfileIndep = new List<DataSource>();
            Dses.ForEach(
                x =>
                {
                    if (UniqDs_ProfileIndep.Count > 0)
                    {
                        if (
                            (from y in UniqDs_ProfileIndep where y.Model == x.Model && y.Repo == x.Repo select y).FirstOrDefault() == null
                            )
                            UniqDs_ProfileIndep.Add(x);
                    }
                    else
                        UniqDs_ProfileIndep.Add(x);
                    
                }
            );
            //Add Properties To MetaModel
            UniqDs_ProfileIndep
                .ForEach(
                x => {
                    if(x.RepoName!=null && x.RepoName.Trim()!="")
                    rtn += string.Format(@"
                             public IList<{0}> {0}_{1}
                                    {{
                                        get
                                        {{
                                            return {2}.{1}();
                                        }}
                                    }}

                        ",x.ModelName,x.RepoName,x.Model.GetRepositoryName());
                });
            rtn += @"} //Class End
                    }//NameSpace End";
            //For Master Detail Need To Define Selecteds


            return rtn;
        }
        static Func<string, byte[]> f = new Func<string, byte[]>(x => System.Text.Encoding.Unicode.GetBytes(x));
        public static string Registeration(Module modu)
        {
            string rtn = "";
            rtn += string.Format(@"
                                    using System.Web.Mvc;

                                    namespace IRERP_RestAPI.Areas.{0}
                                    {{
                                        public class {0}AreaRegistration : AreaRegistration
                                        {{
                                            public override string AreaName
                                            {{
                                                get
                                                {{
                                                    return ""{0}"";
                                                }}
                                            }}

                                            public override void RegisterArea(AreaRegistrationContext context)
                                            {{
                                                context.MapRoute(
                                                    ""{0}_default"",
                                                    ""{0}/{{controller}}/{{action}}/{{id}}"",
                                                    new {{ action = ""Index"", id = UrlParameter.Optional }}
                                                );

                                                context.MapRoute(""{0}_DataSource"", ""{0}/{{controller}}/{{DataSource}}/{{*parts}}"",
                                        defaults: new {{ controller = ""{0}"", action = ""DataSource"" }},
                                        constraints: new {{ DataSource = ""DataSource"" }}
                                        );


                                                context.MapRoute(""{0}Area_FileFieldUpload"", ""{0}/{{controller}}/{{FileFieldUpload}}/{{*parts}}"",
                                        defaults: new {{ controller = ""{0}"", action = ""FileFieldUpload"" }},
                                        constraints: new {{ FileFieldUpload = ""FileFieldUpload"" }}
                                        );
                                            }}
                                        }}
                                    }}

                                    ",modu.ModuleName);
            return rtn;
        }
        public static string MetaModelMap(Module modu)
        {
            string rtn = string.Format(@"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IRERP_RestAPI.Bases.MetaDataDescriptors;
using IRERP_RestAPI.MetaModel;

namespace IRERP_RestAPI.MetaModelMappings
{{
    public class {0}_MetaModel_Mapping : IRERPDescriptor<{0}_MetaModel>
    {{
        public {0}_MetaModel_Mapping()
        {{
                ",modu.ModuleName);
 //Define Descriptors
            var menuhasmaster = modu.GetAllMenusHasMaster();
            List<MsdMenu> UniqMasterModelandProfile = new List<MsdMenu>();
            if (menuhasmaster == null)
                menuhasmaster = new List<MsdMenu>();
            menuhasmaster.ToList().ForEach(x => { 
                var existbefore = (from y in UniqMasterModelandProfile 
                                   where 
                                   x.Master.DS.ModelName == y.Master.DS.ModelName && x.Master.DS.ProfileName == y.Master.DS.ProfileName 
                                   select y).FirstOrDefault();
                if(existbefore==null)
                    UniqMasterModelandProfile.Add(x);
            });
            UniqMasterModelandProfile.ToList()
                .ForEach(x=>{
                    rtn += string.Format(
                                @"DescribeMember(x => x.{0}, IRERPProfile.{1}).UserAsProfile(IRERPProfile.{1});",
                                "Selected"+x.Master.DS.Model.ClassName,x.Master.DS.ProfileName)+newline;
                });
            var Dses = modu.GetAllUsedDataSources();
            Dses.ToList()
                .ForEach(x => {
                    if(x.RepoName!=null && x.RepoName.Trim()!="")
                    rtn += string.Format(
                                @"DescribeMember(x => x.{0}, IRERPProfile.{1}).UserAsProfile(IRERPProfile.{1});"
                                , x.ModelName + "_" + x.RepoName, x.ProfileName)+newline;
                }
                );

            rtn += @"
        }
    }
}";
            return rtn;
        }

    }
}
