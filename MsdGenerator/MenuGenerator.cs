using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MsdGenerator
{
    public class MenuGenerator
    {
        public Module Module { get; set; }
        public MsdMenu Menu { get; set; }
        public List<string> DataSources;
        public MenuGenerator(Module modu, MsdMenu menu)
        {
            Module = modu;
            Menu = menu;
            DataSources = new List<string>();
        }
        public string View()
        {
            string rtn = "";
            rtn += Using();
            rtn += Title_CacheSection();
            rtn += DataSourceSection();
            rtn += FormGrid();
            rtn += Viewend    ();
            return rtn
                ;
        }
        string formname(MsdForm form,UsageLocation u)
        {
            switch (u)
            {
                case UsageLocation.FormItem:
                    return "";
                case UsageLocation.Detail:
                    return MainName + "_" + form.DVS.DS.propertyname+"Form";
                case UsageLocation.Master:
                    return MainName + "Form";
            }
            return "";
        }
        string FormSelectItems(MsdForm form, UsageLocation u)
        {
            string rtn = "";
            //Check That Exits SelectItem
            if (
                form != null &&
                form.FormItems != null &&
                form.FormItems.Count > 0
                )
                form.FormItems.Where( x => 
                        x.optionalDS != null && 
                        x.optionalDS.ModelName != null && 
                        x.optionalDS.ModelName.Trim() != ""
                        )
                    .ToList()
                    .ForEach(x =>
                    {
                        string PKInModelProperty = x.name + "." +
                        form.DVS.DS.Model.GetPropertyByName(x.name).TargetModel.PrimaryKey().PropertyName;
                        string fieldstodisp = "";
                        x.Fields.ToList().ForEach(y => fieldstodisp += "x=>x." + y + "," + newline);
                        fieldstodisp = fieldstodisp.Substring(0, fieldstodisp.Length - 1 - newline.Length);
                        rtn += string.Format(@"
  var {0} = AbbasiAdmin.GGSelectItem<{1}, {2}>(
     this.CID(""{3}""),
     x => x.{4},
     {5},
     x => x.{6},
     x => x.{7},
     {8},
     this.CID(""{9}""),
     true,
     true,
     {10}
   );
   
",
 SelectItemName(form.DVS,x,u)/*{0} FormItem Name*/,
 form.DVS.DS.ModelName/*{1} TModel*/,
 x.optionalDS.ModelName/*{2} TOptionalDS*/,
 SelectItemName(form.DVS,x,u)/*{3} Item Name*/,
 PKInModelProperty/*Model Property {4}*/,
 "\"" + x.title + "\""/*{5} Title*/,
 x.Fields[0]/*Display Filed {6}*/,
 x.optionalDS.Model.PrimaryKey().PropertyName/*Value Field{7}*/,
 "null"/*{8} selectitemproperties*/,
 DSName(x.optionalDS, UsageLocation.FormItem)/*{9} DataSource Name*/,
 fieldstodisp/*{10} picklist Fields*/
);
                    }
                    );
            return rtn;
        }

        string Form(MsdForm form, UsageLocation u)
        {
            string rtn = FormSelectItems(form,u);
             

            rtn += string.Format(@"
 var {0}= AbbasiAdmin.GetGenetalDynamicForm_Extend(this.CID(""{0}""), datasource: {1});
 {0}.titleOrientation = {2};
",
 formname(form, u),DSName(form.DVS.DS, u), form.titleOrientation);
            if (form.FormItems != null && form.FormItems.Count > 0)
            {
                rtn += string.Format(@"
{0}.fields = new IRERP_SM_FormItem[]
      {{
", formname(form,u));

                form.FormItems.ToList()
                    .ForEach(x =>
                    {
                        if (x.optionalDS != null && x.optionalDS.ModelName != null && x.optionalDS.ModelName.Trim() != ""
                            && x.type == "IRERP_SM_SelectItem")
                        {
                            rtn += SelectItemName(form.DVS,x,u)+"," + newline;

                        }
                        else if (x.type == "IRERP_SM_TextItem")
                        {
                            rtn += string.Format(
@"new IRERP_SM_TextItem(){{title={0},name=IRERP_RestAPI.Bases.IRERPApplicationUtilities.GPN<{1}>(x=>x.{2})}},
", "\"" + x.title + "\"", form.DVS.DS.ModelName, x.name);
                        }
                        else if (x.type == "IRERP_SM_TextAreaItem")
                        {
                            rtn += string.Format(
@"new IRERP_SM_TextAreaItem(){{title={0},name=IRERP_RestAPI.Bases.IRERPApplicationUtilities.GPN<{1}>(x=>x.{2})}},
", "\"" + x.title + "\"", form.DVS.DS.ModelName, x.name);

                        }
                    });
                rtn += "};" + newline;
            }
            return rtn;
        }
        string dvsname(DVS dvs, UsageLocation u)
        {
            string dvsname = "";
            if (dvs.DVSName != null && dvs.DVSName.Trim() != "") dvsname = dvs.DVSName;
            else 
                dvsname = MainName + "_" + dvs.DS.propertyname;
   
            switch (u)
            {
                case UsageLocation.FormItem:
                    return "";
                case UsageLocation.Detail:
                    return dvsname + "DetailDVS";
                case UsageLocation.Master:
                    return dvsname + "MasterDVS";
            }
            return "";
        }
        string DVS(DVS dvs,UsageLocation u)
        {
            string rtn ="";
            string dvsnam = dvsname(dvs, u);
           
            rtn = string.Format(@"var {0} = AbbasiAdmin.GetGeneralDVS(this.ViewContext, {1}, {2}, formName: ApplicationStatics.T(""{3}""));", 
                dvsnam,formname(dvs.Form,u),GridName(dvs.Grid,u),dvs.Form.FormTitle)+newline;
            rtn += string.Format(@" {0}.PageTitle = ""{1}"";", dvsnam,dvs.DVSTitle)+newline;
            return rtn;
        }
        string FormGrid()
        {
            string rtn = "";
            var menu = Menu;
            //------------Master
            //-----MasterForm
            
            if (menu.Master != null && menu.Master.Form != null)
            {
                menu.Master.Form.DVS = menu.Master;
                rtn += Form(menu.Master.Form, UsageLocation.Master);
            }
            if (menu.Master != null && menu.Master.Grid != null)
            {
                menu.Master.Grid.DVS = menu.Master;
                rtn += Grid(menu.Master.Grid, UsageLocation.Master);
            }
            rtn += DVS(menu.Master, UsageLocation.Master);


            //------------Details
            if (menu.Details != null)
                menu.Details.ToList().ForEach(x =>
                {
                    if (x.Form != null)
                    {
                        x.Form.DVS = x;
                        rtn += Form(x.Form, UsageLocation.Detail);
                    }
                    if (x.Grid != null)
                    {
                        x.Grid.DVS = x;
                        rtn += Grid(x.Grid, UsageLocation.Detail);
                    }
                    rtn += DVS(x, UsageLocation.Detail);
                });
            if (menu.Details != null && menu.Details.Count > 0)
            {
                rtn += "\r\nCurPage = AbbasiAdmin.GetGeneralMasterDetail(";
                rtn += dvsname(menu.Master, UsageLocation.Master);
                if (menu.Details != null)
                {
                    menu.Details.ToList().ForEach(x => rtn += "," + dvsname(x, UsageLocation.Detail));
                }
                rtn += ");\r\n";
                menu.Details.ToList().ForEach(x => {
                    rtn += string.Format(@"
 CurPage.Commands += AbbasiAdmin.MasterDetailScript<IRERP_RestAPI.MetaModel.{0}, {1}>(
    {2}, {3}, {4}, x => ((IRERP_RestAPI.MetaModel.{0})x).{5}.{6}, x => x.{6}
    );

", 
 Module.ModuleName+"_MetaModel",
 Menu.Master.DS.ModelName,
 GridName(Menu.Master.Grid, UsageLocation.Master),
 GridName(x.Grid, UsageLocation.Detail),
 formname(x.Form, UsageLocation.Detail),
 MetaModelPath(x.DS, UsageLocation.Detail,Menu.Master.DS).Split('.')[0],
 Menu.Master.DS.Model.PrimaryKey().PropertyName );
                });
            }
            else
            {
                rtn += "\r\nCurPage = " + dvsname(menu.Master, UsageLocation.Master)+";";
            }


            return rtn;
        }
        string GridCol(GridCol col)
        {

            string rtn = "";
            List<string> lst = new List<string>();
            if (col.name != null && col.name.Trim() != "")
                lst.Add( string.Format(@"name = this.FN<{0}>(x=>x.{1})",col.Grid.DVS.DS.ModelName,col.name ));
            if (col.title != null && col.title.Trim() != "")
                lst.Add(string.Format(@" title = ""{0}""", col.title));
            if (col.showif != null && col.showif.Trim() != "")
                lst.Add(string.Format(@"showIf = {0}", col.showif));
            if (lst.Count > 0)
                return string.Format(@"new IRERPControlTypes_ListGridFiled() {{{0}}}
", string.Join(",",lst.ToArray()))
                    ;
            else
                return null;

            string.Format(@" 
 name = this.FN<{0}>(x=>x.{1}) } ", "");
            return rtn;
        }
        string Grid(Grid grid, UsageLocation u)
        {
            string rtn = "";
            rtn += string.Format(@"
var {0}= AbbasiAdmin.GetGeneralListGrid(ID: this.CID(""{0}""), Datasource: new IRERP_SM_FromString({1}.ID, true));
", GridName(grid,u), DSName(grid.DVS.DS,u) );
            if (grid.Cols != null && grid.Cols.Count > 0
                )
            {
                rtn += GridName(grid, u) + ".fields = new IRERPControlTypes_ListGridFiled[] {";
                grid.Cols.ToList()
                   .ForEach(x => { x.Grid = grid; var col = GridCol(x); if (col != null) rtn += col + ","; });
                rtn += "};";
            }

               
            return rtn;
        }
        string GridName(Grid g, UsageLocation u)
        {
            switch (u)
            {
                case UsageLocation.FormItem:
                    return "";
                case UsageLocation.Detail:
                    return MainName + "_" + g.DVS.DS.propertyname + "Grid";
                case UsageLocation.Master:
                    return MainName + "Grid";
            }
            return "";
        }
        string Title_CacheSection()
        {
            string rtn = string.Format(@"
@{{
    ViewBag.Title = ""{0}"";
}}

@{{
    IRERPPageString CurPage = new IRERPPageString();
    ////////////////////////////// CACHE SECTION
    string viewPath = ((System.Web.Mvc.RazorView)this.ViewContext.View).ViewPath;
    string cachedView = IRERP_RestAPI.Bases.ViewCache.GetCachedView(viewPath);
    cachedView = null;
}}

@if(cachedView==null){{
        IRERP_RestAPI.MetaModel.{1}_MetaModel model = Model;
        List<IRERP_SM_DataSource> PageDataSources = new List<IRERP_SM_DataSource>();
", Menu.MenuName, Module.ModuleName);
            return rtn;
        }
        string Viewend()
        {

            string rtn= @"   string dses = """";
        PageDataSources.ForEach(x => dses += x.ToString());
        CurPage.OtherObjects = dses + CurPage.OtherObjects;
    } else { CurPage = new IRERPPageString(cachedView);}
    @Html.Raw(CurPage);
        ";
            return rtn;
        }
        string DataSourceSection()
        {
            string rtn = "";
            Func<DataSource,UsageLocation,bool> isExisted = (x, y) => DataSources.Contains(DSName(x,y));
            Action<DataSource, UsageLocation> AddToList = (x, y) => DataSources.Add(DSName(x, y));
            ///--------------------------------- Master
            ///------------MasterDataSource
            ///
            if (Menu.Master != null && Menu.Master.DS != null)
                if (!isExisted(Menu.Master.DS, UsageLocation.Master))
                {
                    rtn += string.Format(@"
                        var {2}= model.GenDS(
                                x => x.{0},
                                SpecMetaModelProfile: IRERP_RestAPI.Bases.MetaDataDescriptors.IRERPProfile.{1},
                                ControllerUrl: ((IRERP_RestAPI.Bases.IRERPController.IRERPController)this.ViewContext.Controller).ControllerUrl,
                                ID: this.CID(""{2}"")
                            );

        PageDataSources.Add({2});
        ",
                 MetaModelPath(Menu.Master.DS, UsageLocation.Master,null),
                 Menu.Master.DS.ProfileName,
                 DSName(Menu.Master.DS, UsageLocation.Master)
                 );
                    AddToList(Menu.Master.DS, UsageLocation.Master);
                }
            //--------------MasterFormItem OptionalDataSources
            if (Menu.Master != null)
                if (Menu.Master.Form != null && Menu.Master.Form.FormItems != null)
                    Menu.Master.Form.FormItems.Where(x => x.optionalDS != null)
                        .ToList()
                        .ForEach(x =>
                        {
                            if (!isExisted( x.optionalDS, UsageLocation.FormItem))
                            {
                                rtn += string.Format(@"
                        var {2}= model.GenDS(
                                x => x.{0},
                                SpecMetaModelProfile: IRERP_RestAPI.Bases.MetaDataDescriptors.IRERPProfile.{1},
                                ControllerUrl: ((IRERP_RestAPI.Bases.IRERPController.IRERPController)this.ViewContext.Controller).ControllerUrl,
                                ID: this.CID(""{2}"")
                            );

        PageDataSources.Add({2});
        ",
                             MetaModelPath(x.optionalDS, UsageLocation.FormItem,null),
                             x.optionalDS.ProfileName,
                             DSName(x.optionalDS, UsageLocation.FormItem)
                             );
                                AddToList(x.optionalDS, UsageLocation.FormItem);
                            }

                        });
            //---------------------------- Details
            if (Menu.Details != null && Menu.Details.Count > 0)
                Menu.Details.ToList()
                    .ForEach(detail =>
                    {
                        //Generate detail Ds
                        if (!isExisted( detail.DS, UsageLocation.Detail))
                        {
                            rtn += string.Format(@"
                        var {0}= model.GenDS(
                                x => x.{1},
                                SpecMetaModelProfile: IRERP_RestAPI.Bases.MetaDataDescriptors.IRERPProfile.{2},
                                ControllerUrl: ((IRERP_RestAPI.Bases.IRERPController.IRERPController)this.ViewContext.Controller).ControllerUrl,
                                ID: this.CID(""{0}DS"")
                            );

        PageDataSources.Add({0});
        ",
                         DSName(detail.DS, UsageLocation.Detail),
                         MetaModelPath(detail.DS, UsageLocation.Detail,Menu.Master.DS),
                         detail.DS.ProfileName
                         );
                            AddToList(detail.DS, UsageLocation.Detail);
                        }
                        //generate Detail OptionalDSes
                        if (detail.Form != null && detail.Form.FormItems != null && detail.Form.FormItems.Count > 0)
                            detail.Form.FormItems.ToList().ForEach(x =>
                            {
                                if ((x.optionalDS!=null)&& !isExisted(x.optionalDS, UsageLocation.FormItem))
                                {
                                    rtn += string.Format(@"
                        var {2}= model.GenDS(
                                x => x.{0},
                                SpecMetaModelProfile: IRERP_RestAPI.Bases.MetaDataDescriptors.IRERPProfile.{1},
                                ControllerUrl: ((IRERP_RestAPI.Bases.IRERPController.IRERPController)this.ViewContext.Controller).ControllerUrl,
                                ID: this.CID(""{2}"")
                            );

        PageDataSources.Add({2});
        ",
                                 MetaModelPath(x.optionalDS, UsageLocation.FormItem,null),
                                 x.optionalDS.ProfileName,
                                 DSName(x.optionalDS, UsageLocation.FormItem)
                                 );
                                    AddToList( x.optionalDS, UsageLocation.FormItem);
                                }
                            });

                    });
            return rtn;
            
            
        }
        public string MainName
        {
            get
            {
                return Menu.Master.DS.ModelName + "_" + Menu.Master.DS.RepoName;
            }
        }
        public string SelectItemName(DVS dvs, FormItem fi, UsageLocation u)
        {
            switch (u)
            {
                case UsageLocation.Detail:
                    return dvs.DS.propertyname+ "_" + fi.name + "_" + "SelectItem";
                case UsageLocation.FormItem:
                    return "";
                case UsageLocation.Master:

                    return MainName + "_" + fi.name + "_" + "SelectItem";
            }
            
            return MainName + "_" + fi.name + "_" + "SelectItem";
        }

        public enum UsageLocation
        {
            Master,
            Detail,
            FormItem
        }
        string MetaModelPath(DataSource Ds, UsageLocation u,DataSource MasterDs)
        {
            switch (u)
            {
                case UsageLocation.Master:
                    return MainName;

                case UsageLocation.Detail:
                    return "Selected"+ MasterDs.Model.ClassName+"."+Ds.propertyname;

                case UsageLocation.FormItem:
                    return Ds.ModelName + "_" + Ds.RepoName 
                        ;
            }
            return "";
        }
        public string DSName(DataSource Ds, UsageLocation u)
        {
            switch (u)
            {
                case UsageLocation.Master:
                    return MainName + "_" + Ds.ProfileName+"DS";
                  
                case UsageLocation.Detail:
                    return MainName + "_" + Ds.propertyname + "_" + Ds.ProfileName+"DS";
                    
                case UsageLocation.FormItem:
                    return Ds.ModelName + "_" + Ds.RepoName + "_" + Ds.ProfileName+"DS"
                        ;
            }
            return "";
        }
        public string DVS(DVS dvs, bool isMasterDVS)
        {
            string rtn = "";
            return rtn;

        }
        const string newline = "\r\n";
        #region Using
        List<string> Usings(List<DataSource> dses)
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
        public string Using()
        {
            string rtn = @"
@using IRERP_RestAPI.Models.Bases;
@using IRERP_RestAPI.Areas.Report.MetaModels;
@using IRERP_RestAPI.Bases.Extension.HTML;
@using IRERP_RestAPI.Bases.Extension.HTML.Controls;
@using IRERP_RestAPI.Bases.Extension.HTML.Controls.Types;
@using IRERP_RestAPI.Bases;
@using IRERP_RestAPI.Bases.Extension.Methods;
@using MsdLib.ExtentionFuncs.Strings;
@using IRERP_RestAPI.Bases.Skins;
";
            var menudses = Menu.GetAllUsedDataSources();
            Usings(menudses).ForEach(x => rtn += "@using IRERP_RestAPI.Models." + x + ";" + newline);
            return rtn;
        }
        #endregion




    }
}
