using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MsdGenerator
{
    public class Generator
    {
        const string newline = "\r\n";
        static Model GetNullPTP(Property p)
        {
            Model rtn = new Model();
            rtn.NameSpace = "";
            rtn.ClassName = p.PropertyType;
            rtn.Properties.Add(new Property
            () { PropertyType = "Guid", isPrimaryKey = true, ColumnName = "id", PropertyName = "id" });
            return rtn;
        }
        public enum PropertyGenTypes
        {
            AsModelProperty,
            InModelGetAssociationSection,
            AsMap
        }
        public enum ModelGenTypes
        {
            AsModel,
            AsMap,
            AsRepository,
            AsFilter
        }
        public static string GenProperty(Property p, PropertyGenTypes GenType)
        {
            string rtn = "";
            switch (GenType)
            {
                case PropertyGenTypes.AsMap:
#region AsMap
                    if (p.IsAssociation)
                    {
                        if (p.IsCollection)
                        {
                            rtn=String.Format(
                                "HasMany<{0}>(x => x._____{1}).LazyLoad().Cascade.None().KeyColumn(\"{2}\").NotFound.Ignore();",
                                p.PropertyType,p.PropertyName,p.KeyColumn
                                );
                        }
                        else
                        {

                            //Is Not Collction
                            if (p.ColumnName != null && p.ColumnName != "") // Column in this Table
                            {
                                //Check For ReadOnly
                                var MasterPropForCol = p.GetMasterPropForMyColumn();
                                if (MasterPropForCol == p)
                                {
                                    //Not ReadOnly
                                    rtn = "References<" + p.PropertyType + ">(x => x._____" + p.PropertyName + ").LazyLoad().Cascade.None().Column(\"" + p.ColumnName + "\").NotFound.Ignore();";
                                }
                                else
                                {
                                    //ReadOnly
                                    rtn = "References<" + p.PropertyType + ">(x => x._____" + p.PropertyName + ").LazyLoad().Cascade.None().Column(\"" + p.ColumnName + "\").NotFound.Ignore().ReadOnly();";
                                }
                            }
                            else
                            {
                                //Has One Relation
                                rtn="HasOne<"+p.PropertyType+">(x => x._____"+p.PropertyName+").LazyLoad().Cascade.None().PropertyRef(x => x._____"+p.PropertyRef+");";
                            }

                        }
                    }
                    else
                    {
                        if (p.isVersionField)
                        {
                            rtn = "Version(x=>x." + p.PropertyName + ")";
                            if (p.ColumnName != null && p.ColumnName != "")
                                rtn += ".Column(\"" + p.ColumnName + "\");";
                        }
                        else if (p.isPrimaryKey)
                        {
                            rtn = "Id(x=>x." + p.PropertyName + ")";
                            if (p.ColumnName != null && p.ColumnName != "")
                                rtn += ".Column(\"" + p.ColumnName + "\");";
                            if (p.Generator != null && p.Generator != "")
                                rtn += ".GeneratedBy."+p.Generator+"()";
                            rtn += ";";
                        }
                        else
                        {
                            
                            rtn = "Map(x=>x." + p.PropertyName + ")";
                            if (p.ColumnName != null && p.ColumnName != "")
                                rtn += ".Column(\"" + p.ColumnName + "\")";
                            rtn += ";";
                        }
                        

                    }
#endregion
                    break;
                case PropertyGenTypes.AsModelProperty:
#region AsModelProperty
                    if(p.IsAssociation){
                        if(p.IsCollection)
                        {
                            //Collection
                            var propertytypemodel = Variables.GetModel(p.PropertyTypeNameSpace,p.PropertyType);
                            if(propertytypemodel==null) 

                                throw new Exception("property type is null!!!! and can not detect which type used here, Class:"+p.Model.ClassName+", Property:"+p.PropertyName+", Type:"+p.PropertyTypeNameSpace+"."+p.PropertyType);

                            rtn =
                                string.Format(
                              @"
                                LoadableVar<IList<{0}>> _{1} = new LoadableVar<IList<{0}>>();
                                public virtual IList<{0}> _____{1} {{ get; set; }}
                                public virtual IList<{0}> {1}
                                {{
                                    get
                                    {{
                                        return
                                            LoadNHRelation<{0}, {2}>(ref _{1}, x => x._____{1},
                                            {3}.ListBy{4}PK<{4}>,
                                            x => x.{5},
                                            (x, y) =>
                                            {{
                                                    y.{6} = x;
                                                    return y.Save();
                                            }},
                                            (x, y) => {{ return y.Remove(CommitTransaction: false); }}
                                       );
             
                                    }}


                                    set {{ SetRelationProperty(x => x.{1}, x => x._____{1}, _{1}, value); }}
                                }}

                                    ",
                                     p.PropertyType/*{0}*/,
                                     p.PropertyName/*{1}*/,
                                     p.Model.PrimaryKey().PropertyType/*{2}*/,
                                     propertytypemodel.GetRepositoryName()/*{3}*/,
                                     propertytypemodel.GetPropertyByColName(p.KeyColumn).PropertyName/*4*/,
                                     p.Model.PrimaryKey().PropertyName/*5*/,
                                     propertytypemodel.GetPropertyByColName(p.KeyColumn).PropertyName/*6*/
                                     

                                     );
                        } else
                        {
                            //Not Collection
                            if (p.ColumnName != "")
                            {
                                //For Refrence (column is Here in My Table)
                                var MasterPropForMyColumn = p.GetMasterPropForMyColumn();
                                if (MasterPropForMyColumn == p)
                                {
                                    #region p is master property of it's own column
                                    
                                    //p is master property of it's own column
                                    //Property Type Property
                                    var PTP = Variables.GetModel(p.PropertyTypeNameSpace, p.PropertyType);
                                    if (PTP == null)
                                        PTP = GetNullPTP(p);
                                    rtn = string.Format(@"
                                            LoadableVar<{0}> _{1}= new LoadableVar<{0}>();
                                            public virtual {0} _____{1} {{ get; set; }}
                                            public virtual {0} {1}
                                            {{
                                                get
                                                {{
                                                    return LoadNHRelation<{0}, {2}>
                                                        (ref _{1},
                                                        x => x._____{1},
                                                        {3}.ByPK,
                                                        x => x._____{1}.{4});
                                                }}
                                                set
                                                {{
                                                    SetRelationProperty(x => x.{1}, x => x._____{1}, _{1}, value);

                                                }}
                                            }}
                                    ", 
                                     p.PropertyType,
                                     p.PropertyName,
                                     PTP.PrimaryKey().PropertyType,
                                     PTP.GetRepositoryName(),
                                     PTP.PrimaryKey().PropertyName
                                     );
                                    #endregion
                                }
                                else
                                {
                                    //p is not master of it's own column
                                    //use master property is better
                                    if (MasterPropForMyColumn.IsAssociation)
                                    {
                                        #region Master Prop is an association prop
                                        
                                        //Master Prop is an association prop
                                        //Property Type Property
                                        var PTP = Variables.GetModel(p.PropertyTypeNameSpace, p.PropertyType);
                                        if (PTP == null)
                                            PTP = GetNullPTP(p);
                                        rtn = string.Format(@"
                                            LoadableVar<{0}> _{1}= new LoadableVar<{0}>();
                                            public virtual {0} _____{1} {{ get; set; }}
                                            public virtual {0} {1}
                                            {{
                                                get
                                                {{
                                                    return LoadNHRelation<{0}, {2}>
                                                        (ref _{1},
                                                        x => x._____{1},
                                                        {3}.ByPK,
                                                        x => x._____{5}.{4});
                                                }}
                                                set
                                                {{
                                                    SetRelationProperty(x => x.{1}, x => x._____{1}, _{1}, value);

                                                }}
                                            }}
                                    ",
                                         p.PropertyType,
                                         p.PropertyName,
                                         PTP.PrimaryKey().PropertyType,
                                         PTP.GetRepositoryName(),
                                         MasterPropForMyColumn.Model.PrimaryKey().PropertyName,
                                         MasterPropForMyColumn.PropertyName
                                         );
                                        #endregion
                                    }
                                    else
                                    {
                                        #region Master Prop is a simple prop

                                        // Master Prop is a simple prop
                                        var PTP = Variables.GetModel(p.PropertyTypeNameSpace, p.PropertyType);
                                        if (PTP == null)
                                            PTP = GetNullPTP(p);
                                        rtn = string.Format(@"
                                            LoadableVar<{0}> _{1}= new LoadableVar<{0}>();
                                            public virtual {0} _____{1} {{ get; set; }}
                                            public virtual {0} {1}
                                            {{
                                                get
                                                {{
                                                    return LoadNHRelation<{0}, {2}>
                                                        (ref _{1},
                                                        x => x._____{1},
                                                        {3}.ByPK,
                                                        x => x.{4});
                                                }}
                                                set
                                                {{
                                                    SetRelationProperty(x => x.{1}, x => x._____{1}, _{1}, value);

                                                }}
                                            }}
                                    ",
                                         p.PropertyType,
                                         p.PropertyName,
                                         PTP.PrimaryKey().PropertyType,
                                         PTP.GetRepositoryName(),
                                         MasterPropForMyColumn.PropertyName
                                         );

                                        #endregion
                                    }
                                }
                                
                            }
                            else
                            {
                                //For HasOne Relation(Column is Not Here And Must Used Target Type Repository
                                var PTP = Variables.GetModel(p.PropertyTypeNameSpace, p.PropertyType);
                                if (PTP == null)
                                    PTP = GetNullPTP(p);
                                        rtn = string.Format(@"
                                            LoadableVar<{0}> _{1}= new LoadableVar<{0}>();
                                            public virtual {0} _____{1} {{ get; set; }}
                                            public virtual {0} {1}
                                            {{
                                                get
                                                {{
                                                    return LoadNHRelation<{0}, {2}>
                                                        (ref _{1},
                                                        x => x._____{1},
                                                        {3}.By{5}PK,
                                                        x => x.{4});
                                                }}
                                                set
                                                {{
                                                    SetRelationProperty(x => x.{1}, x => x._____{1}, _{1}, value);

                                                }}
                                            }}
                                    ",
                                         p.PropertyType,
                                         p.PropertyName,
                                         PTP.PrimaryKey().PropertyType,
                                         PTP.GetRepositoryName(),
                                         p.Model.PrimaryKey().PropertyName,
                                         p.Model.ClassName
                                         );

                            }
                        }

                    } else{
                        //is not associate
                        rtn=String.Format("public virtual {0} {1} {{ get; set; }}",p.PropertyType,p.PropertyName);
                        rtn += newline;
                    }
#endregion
                    break;
                case PropertyGenTypes.InModelGetAssociationSection:
                    if (p.IsAssociation)
                    {
                        rtn = string.Format(@"
                          if (_GPN(x => x.{0}) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____{0}), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            ",p.PropertyName);

                    }
                    break;


            }
            return rtn+newline;
        }
        public static string GenModel(Model m, ModelGenTypes GenType)
        {
            string rtn = "";
            switch (GenType)
            {
                case ModelGenTypes.AsFilter:
                    rtn = GenModelAsFilter(m);
                    break;
                case ModelGenTypes.AsMap:
                    rtn = GenModelAsMap(m);
                    break;
                case ModelGenTypes.AsModel:
                    rtn= GenModelAsModel(m);
                    break;
                case ModelGenTypes.AsRepository:
                    rtn = GenModelAsRepository(m);
                    break;
            }
            return newline+ rtn+newline;
        }

        static string GenModelAsModel(Model m)
        {
            string rtn =GenUsing(m);
            //Name Spaces which used in this model
           
            if (m.NameSpace != "")
                rtn += "namespace IRERP_RestAPI.Models." + m.NameSpace + "{"+newline;
            else
                rtn += "namespace IRERP_RestAPI.Models{"+newline;
            rtn += "public class " + m.ClassName ;
            if (m.HasLogClass)
            {
                rtn += string.Format(":IRERP_RestAPI.Bases.ModelBaseLog<{0}, {0}Log>",m.ClassName);
            }
            else
            {
                rtn += ":IRERP_RestAPI.Bases.ModelBase<"+m.ClassName+">"+newline;
            }

            rtn += "{"+newline;
            //Add Properties
            m.Properties.ToList().ForEach(x => 
                {
                    string[] HiddenProp = new string[] { "id", "Version", "IsDeleted","" };
                    if(!HiddenProp.Contains(x.PropertyName))
                        rtn += GenProperty(x, PropertyGenTypes.AsModelProperty);
                }
                );
            rtn += @"public override Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion> GetAssociation(string PropertyPath) {";
            m.Properties.ToList().ForEach(x => rtn += GenProperty(x, PropertyGenTypes.InModelGetAssociationSection));
            rtn += "return base.GetAssociation(PropertyPath);" + newline;
            rtn += "}"+newline;
            rtn += @"  public override void LoadFromStringDictionary(Dictionary<string, string> Dic)
        {
         ";
            (from x in m.Properties where x.IsAssociation && !x.IsCollection select x).ToList().ForEach(
                x => {
                    var PTP = Variables.GetModel(x.PropertyTypeNameSpace,x.PropertyType);
                    if (PTP == null)
                        PTP = GetNullPTP(x);
                    rtn += string.Format( @"
            if (Dic.ContainsKey(_GPN(x => x.{0}.{1}).ToClientDsFieldName()))
            {{
                try
                {{
                    this.{0}= {2}.ByPK({3}.Parse(Dic[_GPN(x => x.{0}.{1}).ToClientDsFieldName()]));
                    IRERPApplicationUtilities.RemoveAllKeysStartWith(_GPN(x => x.{0}), ref Dic);

                }}
                catch {{ }}
            }}
                    ",
                     x.PropertyName,
                     PTP.PrimaryKey().PropertyName,
                     PTP.GetRepositoryName(),
                     PTP.PrimaryKey().PropertyType
                     ); }
                );

            rtn+=@"
                        base.LoadFromStringDictionary(Dic);
            }";
            rtn += newline;
            rtn += 
                string.Format(
            @"  
            public override INHibernateEntity LoadByPrimaryKeys(Dictionary<string, object> primarykeys_value)
            {{
            if (
                primarykeys_value.Keys.Contains(_GPN(x => x.{0}))
                && 
                primarykeys_value[_GPN(x => x.{0})] != null)
            {{
                return {1}.ByPK(({2})primarykeys_value[_GPN(x => x.{3})]);
            }}
            return null;

            }}",
               m.PrimaryKey().PropertyName,
               m.GetRepositoryName(),
               m.PrimaryKey().PropertyType,
               m.PrimaryKey().PropertyName);

            rtn += "}"+newline;//End Of Class
            if (m.HasLogClass)
            {
                //Define Log Class
                rtn += string.Format( 
                            @"public class {0}Log: LogModelBase<{0}Log>
                                {{
                                ",m.ClassName);
                //Add All ClassProperties
                m.Properties.ToList().ForEach(x => {
                    if (x.IsAssociation && x.IsCollection)
                        return;
                    string[] HiddenProp = new string[] { "id", "Version", "IsDeleted", "" };
                    if (!HiddenProp.Contains(x.PropertyName))
                    rtn += GenProperty(x, PropertyGenTypes.AsModelProperty);
                });
                rtn += "}"+newline;

            }
            rtn += "}"+newline;//End Of NameSpace

            return rtn;
        }
        static string GenModelAsMap(Model m)
        {
            m.correct();
            List<string> addinam = new List<string>();
            addinam.AddRange(new string[]{ "System", "System.Collections.Generic", "System.Linq", "System.Text", "IRERP_RestAPI.Bases.MetaDataDescriptors"});
            if (m.NameSpace != "")
                addinam.Add("IRERP_RestAPI.Models." + m.NameSpace);
            else
                addinam.Add("IRERP_RestAPI.Models");
            if(m.Properties!=null && m.Properties.Count>0)
                addinam.AddRange((from x in m.Properties where !addinam.Contains(x.FullNameSpace) select x.FullNameSpace).Distinct().ToList());
            string rtn = GenUsing(m,addinam.ToArray());
            if (m.NameSpace != "")
                rtn += "namespace IRERP_RestAPI.Mappings." + m.NameSpace + "{"+newline;
            else
                rtn += "namespace IRERP_RestAPI.Mappings{"+newline;
            rtn +=string.Format(@"public class {0}Map : IRERPDescriptor<{0}> 
                            {{",m.ClassName);
            rtn += string.Format(@" public {0}Map(){{", m.ClassName);
            string[] tbname = m.TableName.Replace("[", "").Replace("]", "").Split('.');
            string tbname1="";
            tbname.ToList().ForEach(x => tbname1 += @"""" + x + @""",");
            tbname1 = tbname1.Substring(0, tbname1.Length - 1);
            rtn += string.Format(@"Table(MsdTableName(null,{0}));", tbname1) + newline;
            rtn += "LazyLoad();"+newline;
            m.Properties.ToList().ForEach(x=> rtn+=GenProperty(x, PropertyGenTypes.AsMap));
            #region Descriptors
            if (m.Properties != null && m.Properties.Count > 0)
            {
                var classAllProfiles =
                    (from x in m.Properties
                     where x.PropertyDescs != null && x.PropertyDescs.Count > 0
                     from y in x.PropertyDescs
                     select y.ProfileName).Distinct().ToList();
                if (classAllProfiles != null)
                    classAllProfiles
                        .ToList()
                        .ForEach(x => { 
                            var availableProps = m.GetPropertiesDSFByProfileName(x);
                            if(availableProps!=null)
                            {
                            rtn+="#region "+x+newline
                                ;
                                availableProps
                                    .ToList()
                                    .ForEach(w=>{
                                        rtn += string.Format("DescribeMember(x => x.{0}, IRERPProfile.{1})",
                                            w.Property.PropertyName, x);
                                        if (w.Property.IsAssociation)
                                        {
                                            rtn += string.Format(".UserAsProfile(IRERPProfile.{0});"+newline, w.UseASProfileName);
                                        }
                                        else
                                        {
                                            rtn+= string.Format(
                                                                @".DataSourceFieldProperty(Hidden:{0}, PrimaryKey:{1},Require:{2},rootValue:{3},title:{4},valueMap:{5});",
                                                                    w.DSF.Hidden.ToString().ToLower(),
                                                                    w.DSF.PrimaryKey.ToString().ToLower(),
                                                                    w.DSF.Require.ToString().ToLower(),
                                                                    w.DSF.rootValue!=""?"\""+w.DSF.rootValue+"\"":"null",
                                                                    w.DSF.TranslateTitle?@"ApplicationStatics.T("""+w.DSF.title+@""")":@""""+w.DSF.title+@"""",
                                                                    w.DSF.valueMap!=""?"\""+w.DSF.valueMap+"\"":"null");
                                            rtn += newline;
                                        }
                                       
                                    });

                            
                                
                            rtn += "#endregion"+newline+newline;
                            }
                        }
                        );
                        
            }

            #endregion
            rtn += "}"+newline;//Constructor
            rtn += "}"+newline;//Class
            if (m.HasLogClass)
            {
                rtn+= string.Format(@"public class {0}LogMap : IRERPDescriptor<{0}Log>
                                    {{",m.ClassName)+newline;
                rtn += string.Format(@" public {0}LogMap(){{", m.ClassName)+newline;
                tbname = m.TableName.Replace("[", "").Replace("]", "").Split('.');
                tbname[tbname.Length - 1] += "Log";
                tbname1 = "";
                tbname.ToList().ForEach(x => tbname1 += @"""" + x + @""",");
                tbname1 = tbname1.Substring(0, tbname1.Length - 1);
                rtn += string.Format(@"Table(MsdTableName(null,{0}));", tbname1) + newline;

         //       rtn += string.Format(@"Table(""{0}Log"");", m.TableName) + newline;
                rtn += "LazyLoad();"+newline;
                m.Properties.ToList().ForEach(x => {
                    if (x.IsAssociation && x.IsCollection)
                        return;
                    if (x.isVersionField)
                    {
                        x.isVersionField = false;
                        rtn += GenProperty(x, PropertyGenTypes.AsMap);
                        x.isVersionField = true;
                    } else
                    if (x.isPrimaryKey)
                    {
                        x.isPrimaryKey = false;
                        rtn += GenProperty(x, PropertyGenTypes.AsMap);
                        x.isPrimaryKey = true;
                    }else 
                    rtn += GenProperty(x, PropertyGenTypes.AsMap);
                    

                });
                rtn += @"Id(x => x.LogId).GeneratedBy.Guid().Column(""Logid"");" + newline;
                rtn += "}"+newline;//Constructor
                rtn += "}" + newline;//Class
            }

            rtn += "}" + newline;//Name Space

                

            return rtn;
        }
        static string GenUsing(Model m,params string[] strnamespace)
        {
            string rtn = "";
            List<string> namespaces = new List<string>();
            namespaces.Add("IRERP_RestAPI.Bases");
            namespaces.Add("MsdLib.CSharp.DALCore");
            namespaces.Add("MsdLib.Types");
            namespaces.Add("NHibernate.Criterion");
            namespaces.Add("System");
            namespaces.Add("System.Collections.Generic");
            namespaces.Add("MsdLib.ExtentionFuncs.Strings");
            namespaces.Add("System.Linq");
            if (strnamespace != null)
                strnamespace.ToList().ForEach(x =>
                    {
                        if (!namespaces.Contains(x))
                            namespaces.Add(x);
                    });

            namespaces.AddRange(
                ((from x in m.Properties
                  where
                      x.PropertyTypeNameSpace != "" && x.PropertyTypeNameSpace!=null
                      &&
                      !namespaces.Contains(x.PropertyTypeNameSpace)
                  select x.FullNameSpace).Distinct().ToList()
                ));
            namespaces.ForEach(x =>

                rtn += "using " + x + ";" + newline);
            return rtn;
        }
        static string GenModelAsFilter(Model m)
        {
            List<string>addinam = new List<string>();
                addinam.AddRange(new string[]{"System","System.Collections.Generic","System.Linq","System.Text","IRERP_RestAPI.Bases.MetaDataDescriptors"});
            if(m.NameSpace!="")
                addinam.Add("IRERP_RestAPI.Models."+m.NameSpace);

            string rtn = GenUsing(m,addinam.ToArray());

            if (m.NameSpace != "")
                rtn += "namespace IRERP_RestAPI.Filters." + m.NameSpace + "{"+newline;
            else
                rtn += "namespace IRERP_RestAPI.Filters{"+newline;
            rtn += string.Format(@"public class {0}Filter : IRERPFilter<{0}Filter, {0}> {{" , m.ClassName)+newline;
            Property isDeletedF = m.isDeleted();
            if (isDeletedF != null)
            {
                rtn+=string.Format(@"public virtual bool? {0} {{get;set;}}",isDeletedF.PropertyName);

            }
            if (isDeletedF != null)
            {
                //Constructor
                rtn += string.Format(@"public {0}Filter(){{", m.ClassName) + newline;
                rtn += string.Format("{0} = false;", isDeletedF.PropertyName) + newline;
                rtn += "}" + newline;

            }
            rtn += string.Format(@"   
                public override NHibernate.IQueryOver<{0}, {0}> Query
                {{
                    get
                    {{
                        var q = base.Query;
                ",m.ClassName);
            if (isDeletedF != null)
                rtn += string.Format(@"if({0}!=null) 
                        AddSimpleCriteria(x => x.{0}, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, {0}.ToString());", isDeletedF.PropertyName);
            rtn += newline+@"  return q;
            }
            set
            {
                base.Query = value;
            }
        }";

            rtn +=newline+ "}";//End Class
            rtn += newline+"}";//End NameSpace
            return rtn;
        }
        static string GenModelAsRepository(Model m)
        {
            
            List<string> addinam = new List<string>();
            addinam.AddRange(new string[] { "System", "System.Collections.Generic", "System.Linq", "System.Text", "IRERP_RestAPI.Bases.MetaDataDescriptors" });
            if (m.NameSpace != "")
            {
                addinam.Add("IRERP_RestAPI.Models." + m.NameSpace);
                addinam.Add("IRERP_RestAPI.Filters." + m.NameSpace);
            }

            string rtn = GenUsing(m,addinam.ToArray()); 
            if (m.NameSpace != "")
                rtn += "namespace IRERP_RestAPI.ModelRepositories." + m.NameSpace + "{" + newline;
            else
                rtn += "namespace IRERP_RestAPI.ModelRepositories{" + newline;
            rtn += string.Format(@"public class {0}_Repository : IRERPRepositoryBaseSimpleFilter<{0}_Repository, {0}, {0}Filter> {{", m.ClassName) + newline;

             string isdeletedtext="";
             var isdeletedprop = (from y in m.Properties where y.PropertyName.ToLower() == "IsDeleted".ToLower() select y).FirstOrDefault();
             if (isdeletedprop != null)
                 isdeletedtext = "filter.AddSimpleCriteria(x=>x."+isdeletedprop.PropertyName+",MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, false.ToString());" + newline;

            //Gen ByPK
            rtn +=string.Format(@"public static {0} ByPK({1} PK)
                                {{
                                    var filter = new {0}Filter();
                                    filter.AddSimpleCriteria(x=>x.{2},MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, PK.ToString());
                                    {3}
                                    return First(filter);
                                }}",m.ClassName,
                                  m.PrimaryKey().PropertyType,
                                  m.PrimaryKey().PropertyName,
                                 isdeletedtext);
            //Generate ListBY{ClassName}PK
            if(m.Properties!=null && m.Properties.Count>0)
            {
                var assocPropsNotCollec = (from x in m.Properties where x.IsAssociation && !x.IsCollection select x).ToList();
                assocPropsNotCollec.ForEach(x => {
                   
                    rtn += string.Format(@"  
                                                public static IList<{0}> ListBy{1}PK<TParent>({2} PK)
                                                    where TParent : MsdLib.CSharp.DALCore.ModelBase
                                                {{
                                                    var filter = new {0}Filter();
                                                    {5}
                                                    filter.AddSimpleCriteria(x=>x.{3}.{4},MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, PK.ToString());
                                                    return GetVList<TParent>(filter);
                                                }}",
                                                   m.ClassName/*0*/,
                                                x.PropertyName/*1*/,
                                                 Variables.GetModel(x.PropertyTypeNameSpace,x.PropertyType).PrimaryKey().PropertyType/*2*/,
                                                x.PropertyName/*3*/,
                                                 Variables.GetModel(x.PropertyTypeNameSpace, x.PropertyType).PrimaryKey().PropertyName/*4*/,
                                                isdeletedtext);
                                        });
                
              
            }
            
//            (from x in Variables.Models
//                        from y in x.Properties
//                        where y.PropertyTypeNameSpace==m.NameSpace && y.PropertyType==m.ClassName 
//                        && y.IsCollection && y.IsAssociation
//                        select y).ToList().ForEach(x=>{
//                            var MasterClassProperty = x;
//                            var DetailClassProperty = m;

//                            rtn += string.Format(@"  
//                                                public static IList<{0}> ListBy{1}PK<TParent>({2} PK)
//                                                    where TParent : MsdLib.CSharp.DALCore.ModelBase
//                                                {{
//                                                    var filter = new {0}Filter();
//                                                    filter.AddSimpleCriteria(x=>x.{3}.{4},MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, PK.ToString());
//                                                    return GetVList<TParent>(filter);
//                                                }}", m.ClassName/*0*/,
//                                                   MasterClassProperty.Model.ClassName/*1*/,
//                                                   MasterClassProperty.Model.PrimaryKey().PropertyType/*2*/,
//                                                   m.GetPropertyByColName(MasterClassProperty.KeyColumn).PropertyName/*3*/,
//                                                   MasterClassProperty.Model.PrimaryKey().PropertyName/*4*/

//                                                   );
//                        });

            //Defined Repository for model
            if(m.Repos!=null)
                m.Repos.ToList()
                    .ForEach(x =>
                        {
                            rtn += string.Format(@"
                                                    public static IList<{0}> {1}()
                                                    {{
                                                        var filter = new {0}Filter();
                                                       ",
                                                        m.ClassName/*0*/,
                                                       x.RepoName/*1*/);
                            if(x.Criterias!=null)
                                x.Criterias.ToList()
                                    .ForEach(y=>{
                                        rtn+=string.Format(@"
                                                filter.AddSimpleCriteria(x=>x.{0},MsdLib.CSharp.BLLCore.MsdCriteriaOperator.{1},""{2}"");
                                               ", y.Path,y.Operator,y.value);

                                    });

                            
                            rtn+=@"
                                                        return GetVList(filter);
                                                    }"; 
           
           
           

           
                        }
                    );

            rtn += "}" + newline;
            rtn += "}" + newline;
            return rtn;
        }
    }
}
