using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;


namespace MsdGenerator
{
    //Extension Function
    public static class Exten
    {
        public static bool NotEmpty(this string str)
        {
            return str != null && str.Trim() != "";
        }
    
    }
    
    [Serializable]
    public class Variables
    {
        static  Func<string, byte[]> f = new Func<string, byte[]>(x => System.Text.Encoding.Unicode.GetBytes(x));
        public static void writeToFile(string filepath, string content)
        {
            var fs = new System.IO.FileStream(filepath, System.IO.FileMode.Create);

            byte[] buf = f(content);
            fs.WriteByte(0xff); fs.WriteByte(0xfe);
            fs.Write(buf, 0, buf.Length);
            fs.Close();

        }
        public static Profile GetProfileByName(string ProfileName)
        {
            return (from x in Variables.Profiles where x.Name == ProfileName select x).FirstOrDefault();

        }
        public static Property GetModelPrimaryKey(Model m)
        {
            if (m.Properties.Count > 0)
            {
                var q = (from x in m.Properties where x.isPrimaryKey select x).FirstOrDefault();
                if (q != null)
                    return q;
                
            }
            throw new Exception("model has no primary key");
            
        }
        public static Model GetModel(string NameSpace, string ClassName)
        {
            if (NameSpace == null)
                NameSpace = "";
            if (Variables.Models.Count > 0)
            {
                var q = (from x in Variables.Models where x.NameSpace == NameSpace && x.ClassName == ClassName select x).FirstOrDefault();
                if (q != null)
                    return q;

            }
            return null;
        }
        public static Model GetNewModel()
        {
            Model rtn = new Model();
            rtn.Properties.Add(new Property() { PropertyName = "id", ColumnName = "id", PropertyType = "Guid", isPrimaryKey = true ,Model= rtn});
            rtn.Properties.Add(new Property() { PropertyName = "Version", ColumnName = "Version", PropertyType = "long", isVersionField = true, Model = rtn });
            rtn.Properties.Add(new Property() { PropertyName = "IsDeleted", ColumnName = "IsDeleted", PropertyType = "bool", Model = rtn });
            rtn.Properties.Add(new Property() { PropertyName = "AddDate", ColumnName = "AddDate", PropertyType = "DateTime", Model = rtn });
            rtn.Properties.Add(new Property() { PropertyName = "LastModifyDate", ColumnName = "LastModifyDate", PropertyType = "DateTime", Model = rtn });
            rtn.Properties.Add(new Property() { PropertyName = "AddedBy", ColumnName = "AddedBy", IsAssociation = true, PropertyType = "User", Model = rtn });
            rtn.Properties.Add(new Property() { PropertyName = "ModifyBy", ColumnName = "ModifyBy", IsAssociation = true, PropertyType = "User", Model = rtn });
            rtn.Properties.Add(new Property() { PropertyName = "Description", ColumnName = "Description", PropertyType = "string", Model = rtn });
            
            return rtn;
        }
        public static void AutoComplete(params TextBox[] txt)
        {
            if (txt != null)
                txt.ToList().ForEach(x => AutoComplete(x));
        }
        public static Model GetModelByPropertyPath(Model m, string Path)
        {
            Model rtn = m;
            Path = Path.Replace("[0]", "");
            Path.Split('.')
                .ToList()
                .ForEach(x => { 
                    Property prop = rtn.GetPropertyByName(x);
                    rtn = Variables.GetModel(prop.PropertyTypeNameSpace, prop.PropertyType);

                });
            return rtn;
        }
        public static void AutoComplete(TextBox txt)
        {
            txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt.AutoCompleteCustomSource = new AutoCompleteStringCollection();
            txt.AutoCompleteCustomSource.AddRange(Variables.GetAllStrings());
        }
        public static string[] GetAllStrings()
        {
            List<string> lst = new List<string>();
            lst.AddRange((from x in Variables.Models select x.ClassName).ToList());
            lst.AddRange((from x in Variables.Models from y in x.Properties select y.PropertyName).ToList());
            lst.AddRange((from x in Variables.Models select x.NameSpace).ToList());
            return lst.ToArray();

            
        }
        public static Dictionary<string, object> Dic = new Dictionary<string, object>();
        public static IList<Module> Modules
        {
            get
            {
                if (Dic.Keys.Contains("Modules") && Dic["Modules"] != null)
                    return (IList<Module>)Dic["Modules"];
                Dic.Add("Modules", new List<Module>());
                return (IList<Module>)Dic["Modules"];
                    
            }
            set
            {

                if (Dic.Keys.Contains("Modules") && Dic["Modules"] != null)
                    Dic["Modules"] = value;
                else
                    Dic.Add("Modules", value);
            }
        }
        public static IList<Model> Models
        {
            get
            {
                if (Dic.Keys.Contains("Models"))
                    return (IList<Model>)Dic["Models"];
                else
                    Dic.Add("Models", new List<Model>());
                return (IList<Model>)Dic["Models"];


            }
        }
        public static IList<Profile> Profiles
        {
            get
            {
                if (Dic.Keys.Contains("Profiles"))
                    return (IList<Profile>)Dic["Profiles"];
                else
                    Dic.Add("Profiles", new List<Profile>());
                return (IList<Profile>)Dic["Profiles"];


            }
        }
        public static byte[] Serialzie(object obj)
        {
            string str = 
                Newtonsoft.Json
                .JsonConvert.SerializeObject(
                obj, 
                Formatting.Indented, 
                new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.All,
                        TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple
                      });
            return System.Text.Encoding.Unicode.GetBytes(str);
        }
        public static object DeSerialize(byte[] buf)
        {
            string str = System.Text.Encoding.Unicode.GetString(buf);
            return Newtonsoft.Json.JsonConvert.DeserializeObject(str, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple
            });
           //  return ser.Deserialize(new System.IO.MemoryStream(buf));

        }
    }

     
    [Serializable]
    public class Property : ICloneable
    {
        public void correctDescs()
        {
            if (PropertyDescs != null)
                PropertyDescs.ToList().ForEach(x => x.Property = this);
        }
        public string PropertyType { get; set; }
        public string PropertyTypeNameSpace { get; set; }
        public bool IsAssociation { get; set; }
        public bool IsCollection { get; set; }
        public string PropertyName { get; set; }
        public bool isPrimaryKey { get; set; }
        public bool isVersionField { get; set; }
        
        public string Generator { get; set; }
        public string ColumnName { get; set; }
        public string AssociationColumnName { get; set; }
        public string PropertyRef { get; set; }
        public string KeyColumn { get; set; }
        [JsonIgnore]
        public Model Model { get; set; }
        [JsonIgnore]
        public string FullNameSpace
        {
            get
               
            {
                PropertyTypeNameSpace = PropertyTypeNameSpace ?? "";

                if (PropertyTypeNameSpace == "")
                    return "IRERP_RestAPI.Models";
                if(PropertyTypeNameSpace.IndexOf('"')==0)
                    return PropertyTypeNameSpace.Replace(@"""","");
                else
                    return "IRERP_RestAPI.Models."+PropertyTypeNameSpace;
            }
        }
        [JsonIgnore]
        public bool isModelBaseNameSpace
        {
            get
            {
                if (PropertyTypeNameSpace.IndexOf('"') == 0)
                    return false;
                else
                    return true;
            }
        }
        public Property GetMasterPropForMyColumn()
        {
            var sameColumnProps = (from x in Model.Properties where x.ColumnName == ColumnName select x).ToList();
            if (sameColumnProps.Count > 1)
            {
                Property MasterProperty = null;
                MasterProperty = (from y in sameColumnProps where !y.IsAssociation select y).FirstOrDefault();
                if (MasterProperty != null)
                    return MasterProperty;//Property that is not Association is Master else first of list is master
                else
                    return sameColumnProps[0];
            }
            else
                return this;
        }
        public string ModelBaseNameSpace()
        {
            return PropertyTypeNameSpace;
        }
        public IList<Property_DSF> PropertyDescs
        {get;set;}
        public IList<PropertyDSField> DSFields
        { get; set; }

        [JsonIgnore]
        public Model TargetModel
        {
            get
            {
                return Variables.GetModel(PropertyTypeNameSpace, PropertyType);
            }
            set
            {
                PropertyType = value.ClassName;
                PropertyTypeNameSpace = value.NameSpace;
            }
        }

        public object Clone()
        {
            Property rtn = new Property();
            rtn.PropertyType = this.PropertyType;
            rtn.PropertyTypeNameSpace = PropertyTypeNameSpace;
            rtn.IsAssociation = IsAssociation;
            rtn.IsCollection = IsCollection;
            rtn.PropertyName = PropertyName;
            rtn.isPrimaryKey = isPrimaryKey;
            rtn.isVersionField = isVersionField;
            rtn.Generator = Generator;
            rtn.ColumnName = ColumnName;
            rtn.AssociationColumnName = AssociationColumnName;
            rtn.PropertyRef = PropertyRef;
            rtn.KeyColumn = KeyColumn;
            rtn.Model = Model;
            if(PropertyDescs!=null)
            {
                rtn.PropertyDescs = new List<Property_DSF>();
                PropertyDescs.ToList().ForEach(
                    x => rtn.PropertyDescs.Add((Property_DSF)x.Clone()));
                }
            if (DSFields != null)
            {
                rtn.DSFields = new List<PropertyDSField>();
                DSFields.ToList().ForEach(x => rtn.DSFields.Add((PropertyDSField)x.Clone()));

            }
            return rtn;

        }
        public override string ToString()
        {
            return PropertyName;
            //return base.ToString();
        }
    }
    [Serializable]
    public class Model : ICloneable
    {
        public List<string> GetDataSourcePropertyPathes(string ProfileName)
        {
            List<string> rtn = new List<string>();
            GetPropertiesByProfileName(ProfileName)
                .ToList()
                .ForEach(x =>
                    {
                        if (x.IsAssociation && !x.IsCollection)
                        {
                            var inter = x.TargetModel.GetDataSourcePropertyPathes(ProfileName);
                            inter.ForEach(y => 
                                {
                                    if (!rtn.Contains(x.PropertyName + "." + y))
                                        rtn.Add(x.PropertyName + "." + y);
                                }
                                );
                            //rtn.AddRange();
                        }
                        else
                            if (!x.IsAssociation)
                                if(!rtn.Contains(x.PropertyName))

                                rtn.Add(x.PropertyName);
                    });
            if (ProfileName != "Any")
            {
                GetPropertiesByProfileName("Any")
               .ToList()
               .ForEach(x =>
               {
                   if (x.IsAssociation && !x.IsCollection)
                   {
                       var inter = x.TargetModel.GetDataSourcePropertyPathes("Any");
                       inter.ForEach(y =>
                       {
                           if (!rtn.Contains(x.PropertyName + "." + y))
                               rtn.Add(x.PropertyName + "." + y);
                       }
                           );
                       //rtn.AddRange();
                   }
                   else
                       if (!x.IsAssociation)
                           if (!rtn.Contains(x.PropertyName))

                               rtn.Add(x.PropertyName);
               });
            }

            return rtn;
        }
        public void correct()
        {
            if(Properties!=null)
            Properties
                .ToList()
                .ForEach(x=>{x.Model = this; x.correctDescs();});
            if (Repos != null)
                Repos
                    .ToList()
                    .ForEach(x => x.Model = this);
        }
        public IList<Profile> GetAllUsedProfile()
        {
            if (Properties != null && Properties.Count > 0)
                return (from x in Properties
                        where x.PropertyDescs != null && x.PropertyDescs.Count > 0
                        from y in x.PropertyDescs
                        select y.Profile).Distinct().ToList();
            else
                return new List<Profile>();
        }

        public override string ToString()
        {
            return NameSpace + "." + ClassName;
        }
        public string ClassName { get; set; }
        public string NameSpace { get; set; }
        public string TableName { get; set; }
        public bool HasLogClass { get; set; }
        public IList<Property> Properties { get; set; }
        public Model()
        {
            Properties = new List<Property>();
            Repos = new List<ModelRepository>();
        }
        public string GetRepositoryName()
        {
            if (ClassName == "User" && NameSpace == "")
                return "ModelRepositories.UserRepository";
                string rtn = "";
                if (NameSpace != "")
                    rtn = "ModelRepositories." + NameSpace+ "."+ ClassName + "_Repository";
                else
                    rtn = "ModelRepositories." + ClassName + "_Repository"; 
                return rtn;
            
        }
        public Property PrimaryKey()
        {
                return Variables.GetModelPrimaryKey(this);
        }
        public Property VersionField()
        {
            Property VersionF = (from x in Properties where x.isVersionField select x).FirstOrDefault();
            return VersionF;
        }
        public Property isDeleted()
        {
            Property p = (from x in Properties where x.PropertyName.ToLower() == "isdeleted" && x.PropertyType.ToLower() == "bool" select x).FirstOrDefault();
            return p;
        }
        public Property GetPropertyByName(string PropertyName)
        {
            var q = (from x in Properties where x.PropertyName == PropertyName select x).FirstOrDefault();
            return q;
        }
        public Property GetPropertyByColName(string col)
        {
            var q = (from x in Properties where x.ColumnName == col select x).FirstOrDefault();
            return q;
        }
        public object Clone()
        {
            Model rtn = new Model();
            rtn.ClassName = ClassName;
            rtn.NameSpace = NameSpace;
            rtn.TableName = TableName;
            rtn.HasLogClass = HasLogClass;

            Properties.ToList().ForEach(x =>
            {
                Property newprop = (Property)x.Clone(); 
                newprop.Model = rtn; 
                rtn.Properties.Add(newprop);
            });
            return rtn;

        }
        public IList<ModelRepository> Repos { get; set; }
        public IList<Property_DSF> GetPropertiesDSFByProfileName(string p)
        {
            if (Properties != null && Properties.Count > 0)
                return
            (from x in Properties
             where x.PropertyDescs != null && x.PropertyDescs.Count > 0
             from y in x.PropertyDescs
             where y.ProfileName == p
             select y).Distinct().ToList();
            else
                return new List<Property_DSF>();
        }
        public IList<Property> GetPropertiesByProfileName(string p)
        {
            if (Properties != null && Properties.Count > 0)
                return
            (from x in Properties
             where x.PropertyDescs != null && x.PropertyDescs.Count > 0
             from y in x.PropertyDescs
             where y.ProfileName == p || y.ProfileName=="Any"
             select x).Distinct().ToList();
            else
                return new List<Property>();
        }
        public IList<Property> GetPropertiesByProfile(Profile p)
        {
            if (Properties != null && Properties.Count > 0)
                return
            (from x in Properties
             where x.PropertyDescs != null && x.PropertyDescs.Count > 0
             from y in x.PropertyDescs
             where y.ProfileName == p.Name
             select x).Distinct().ToList();
            else
                return new List<Property>();
        }
    }
    [Serializable]
    public class AtomicCriteria
    {
        public string Path { get; set; }
        public string Operator { get; set; }
        public string value { get; set; }
       
    }
    [Serializable]
    public class ModelRepository
    {

        [JsonIgnore]
        public Model Model { get; set; }

        public string RepoName { get; set; }
        public string Description { get; set; }
        public List<AtomicCriteria> Criterias { get; set; }
        public override string ToString()
        {
            //return base.ToString();
            return Model.ToString() + "." + RepoName;
        }

    }
    [Serializable]
    public class Profile
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public override string ToString()
        {
            return (Name ?? "") + (Description.NotEmpty()?"-":"") + (Description ?? "");
        }
    }
    [Serializable]
    public class PropertyDSField : ICloneable
    {
        public string DSFName { get; set; }
        public bool Hidden { get; set; }
        public bool PrimaryKey { get; set; }
        public bool Require { get; set; }
        public string rootValue { get; set; }
        public string name { get; set; }
        public string title { get; set; }
        public bool TranslateTitle { get; set; }
        public string valueMap { get; set; }
        public string ClientType { get; set; }
        public virtual string serverPropertyPath { get; set; }
        public override string ToString()
        {
            return DSFName;
        }


        public object Clone()
        {
            PropertyDSField rtn = new PropertyDSField();
            rtn.DSFName = DSFName;
            rtn.Hidden = Hidden;
            rtn.PrimaryKey = PrimaryKey;
            rtn.Require = Require;
            rtn.rootValue = rootValue;
            rtn.name = name;
            rtn.title = title;
            rtn.TranslateTitle = TranslateTitle;
            rtn.valueMap = valueMap;
            rtn.ClientType = ClientType;
            rtn.serverPropertyPath = serverPropertyPath;
            return rtn;
        }
    }
    [Serializable]
    public class Property_DSF :ICloneable
    {
        [JsonIgnore]
        public Property Property { get; set; }
        public string ProfileName { get; set; }
        [JsonIgnore]
        public Profile Profile { get {
            return (from x in Variables.Profiles where x.Name == ProfileName select x).FirstOrDefault();
        }
            set { ProfileName = value.Name; }
        }
        public string DSFName { get; set; }
        [JsonIgnore]
        public PropertyDSField DSF
        {
            get
            {
                if (Property.DSFields != null &&
                    Property.DSFields.Count > 0
                    )
                    return (from x in Property.DSFields where x.DSFName == DSFName select x).FirstOrDefault();
                else
                    return null;
            }
            set
            {
                DSFName = value.DSFName;
            }
        }
        public string UseASProfileName { get; set; }
        [JsonIgnore]
        public Profile UseAsProfile
        {
            get
            {
                return (from x in Variables.Profiles where x.Name == UseASProfileName select x).FirstOrDefault();
            }
            set
            {
                UseASProfileName = value.Name;
            }
        }

        public object Clone()
        {
            Property_DSF rtn = new Property_DSF();
            rtn.ProfileName = ProfileName;
            rtn.DSFName = DSFName;
            rtn.UseASProfileName = UseASProfileName;
            return rtn;
        }
    }
    [Serializable]
    public class Module
    {
        public string ModuleTitle { get; set; }
        public string ModuleName { get; set; }
        public string Description { get; set; }
        public IList<MsdMenu> Menus { get; set; }
        
        public Module()
        {
            Menus = new List<MsdMenu>();
        }
        public IList<MsdMenu> GetAllMenusHasMaster()
        {
            List<MsdMenu> rtn = new List<MsdMenu>();
            if (Menus == null)
                Menus = new List<MsdMenu>();
            rtn = (from x in Menus where x.Details != null && x.Details.Count > 0 select x).ToList();
            return rtn;
                
        }
        public IList<Model> GetAllMasterModels()
        {
            List<Model> rtn = new List<Model>();
            if (Menus == null)
                Menus = new List<MsdMenu>();
            rtn = (from x in Menus where x.Details != null && x.Details.Count > 0 select x.Master.DS.Model).ToList();
            return rtn;
        }
        public IList<DataSource> GetAllUsedDataSources()
        {
            List<DataSource> rtn = new List<DataSource>();
            if (Menus == null)
                Menus = new List<MsdMenu>();

            //Master DataSources
            Menus
                .Where(x => x.Master != null && x.Master.DS != null && !rtn.Contains(x.Master.DS))
                .ToList().ForEach(x => rtn.Add(x.Master.DS));
            //Details DataSources
            (from x in Menus
             where x.Details != null
             from y in x.Details
             where y.DS != null && !rtn.Contains(y.DS)
             select y.DS)
             .ToList()
             .ForEach(x => rtn.Add(x));
            //FormItem Optioanl DataOptionalDS
            //MasterFrom
            (from x in Menus
             where x.Master != null && x.Master.Form != null && x.Master.Form.FormItems != null && x.Master.Form.FormItems.Count > 0
             from y in x.Master.Form.FormItems
             where y.optionalDS != null && !rtn.Contains(y.optionalDS)
             select y.optionalDS)
             .ToList()
             .ForEach(x => rtn.Add(x));
            //Detail Forms
            (from x in Menus
             where x.Details != null && x.Details.Count > 0
             from y in x.Details
             where y.Form != null && y.Form.FormItems != null && y.Form.FormItems.Count > 0
             from z in y.Form.FormItems
             where z.optionalDS != null && !rtn.Contains(z.optionalDS)
             select z.optionalDS)
             .ToList()
             .ForEach(x => rtn.Add(x));
            return rtn;
        }
    }
    [Serializable]
    public class MsdMenu
    {
        public List<DataSource> GetAllUsedDataSources()
        {
            List<DataSource> rtn = new List<DataSource>();
            if (Master != null && Master.DS != null && !rtn.Contains(Master.DS))
                rtn.Add(Master.DS);
            //Details DataSources
            if(Details!=null && Details.Count>0)
            (
             from y in Details
             where y.DS != null && !rtn.Contains(y.DS)
             select y.DS)
             .ToList()
             .ForEach(x => rtn.Add(x));
            //FormItem Optioanl DataOptionalDS
            //MasterFrom
            if(Master != null && Master.Form != null && Master.Form.FormItems != null && Master.Form.FormItems.Count > 0)
            (
             from y in Master.Form.FormItems
             where y.optionalDS != null && !rtn.Contains(y.optionalDS)
             select y.optionalDS)
             .ToList()
             .ForEach(x => rtn.Add(x));
            
            if(Details != null && Details.Count > 0)
            //Detail Forms
            (
             from y in Details
             where y.Form != null && y.Form.FormItems != null && y.Form.FormItems.Count > 0
             from z in y.Form.FormItems
             where z.optionalDS != null && !rtn.Contains(z.optionalDS)
             select z.optionalDS)
             .ToList()
             .ForEach(x => rtn.Add(x));
            return rtn;
        }
     
        public string MenuName { get; set; }
        public string MenuTitle { get; set; }
        public string Description { get; set; }
        public DVS Master { get; set; }
        
        public IList<DVS> Details { get; set; }
        public MsdMenu()
        {
            Details = new List<DVS>();
        }
    }
    [Serializable]
    public class DVS
    {
        public string DVSTitle { get; set; }
        public string DVSName { get; set; }
        public DataSource DS { get; set; }
        public MsdForm Form { get; set; }
        public Grid Grid { get; set; }
       
    }
    [Serializable]
    public class DataSource
    {
        public string ClientName()
        {
            return
                  ModelName  +
                    ((RepoName != null && RepoName.Trim() != "") ? "_"+RepoName : propertyname) +
                    ((ProfileName != null && ProfileName.Trim() != "") ? "_" + ProfileName : "")
                                                  ;
        }
        public string propertyname { get; set; } //for detail dvs
        public string ModelNameSpace { get; set; }
        public string ModelName { get; set; }
        public string RepoName { get; set; }
        public string ProfileName { get; set; }
        [JsonIgnore]
        public Model Model
        {
            get
            {
                return Variables.GetModel(ModelNameSpace, ModelName);
            }
            set
            {
                if (value != null)
                {
                    ModelName = value.ClassName
                       ;
                    ModelNameSpace = value.NameSpace;
                }
            }
        }
        [JsonIgnore]
        public ModelRepository Repo
        {
            get
            {
                if (Model.Repos != null && Model.Repos.Count > 0)
                {
                    return (from x in Model.Repos where x.RepoName == RepoName select x).FirstOrDefault();
                }
                return null;
            }
            set
            {
                if (value != null)
                    RepoName = value.RepoName;
            }
        }
        [JsonIgnore]
        public Profile Profile
        {
            get
            {
                return Variables.GetProfileByName(ProfileName);
            }
            set {
                if (value != null)
                    ProfileName = value.Name;
            }
        }

        public List<string> GetDSFields()
        {
            return Model.GetDataSourcePropertyPathes(ProfileName)?? new List<string>();
        }
    }
    [Serializable]
    public class MsdForm
    {
        public string FormTitle { get; set; }
        
        public string titleOrientation { get; set; }
        public IList<FormItem> FormItems { get; set; }
        public MsdForm()
        {
            FormItems = new List<FormItem>();

        }
        [JsonIgnore]
        public DVS DVS { get; set; }
       
    }
    [Serializable]
    public class FormItem
    {
        public string name { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public string MsdHelpMessage { get; set; }
        public int Priority { get; set; }
        public DataSource optionalDS { get; set; }
        public FormItem()
        {
            Fields = new List<string>();
           
        }
        public IList<string> Fields
        {
            get
           ;
            set;
        }

    }
    [Serializable]
    public class Grid
    {
        [JsonIgnore]
        public DVS DVS { get; set; }
        public IList<GridCol> Cols { get; set; }
        public Grid()
        {
            Cols = new List<GridCol>();

        }

    }
    [Serializable]
    public class GridCol
    {
        [JsonIgnore]
        public Grid Grid { get; set; }
        public string name { get; set; }
        public string title { get; set; }
        public string showif { get; set; }
    }
}
