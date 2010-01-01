
using IRERP_RestAPI.Bases;
using MsdLib.CSharp.DALCore;
using MsdLib.Types;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using MsdLib.ExtentionFuncs.Strings;
using System.Linq;
using System.Text;
using IRERP_RestAPI.Bases.MetaDataDescriptors;
using IRERP_RestAPI.Models.Bases;
using IRERP_RestAPI.Models;
using IRERP_RestAPI.Models.Bases;
namespace IRERP_RestAPI.Mappings.Bases{
public class CharacterMap : IRERPDescriptor<Character> 
                            { public CharacterMap(){Table(MsdTableName(null,"irerp","bases","Character_Tb"));
LazyLoad();
Id(x=>x.id).Column("id");;
Version(x=>x.Version).Column("Version");
Map(x=>x.IsDeleted).Column("IsDeleted");
Map(x=>x.AddDate).Column("AddDate");
Map(x=>x.LastModifyDate).Column("LastModifyDate");
References<User>(x => x._____AddedBy).LazyLoad().Cascade.None().Column("AddedBy").NotFound.Ignore();
References<User>(x => x._____ModifyBy).LazyLoad().Cascade.None().Column("ModifyBy").NotFound.Ignore();
Map(x=>x.Description).Column("Description");
Map(x=>x.NickName).Column("NickName");
Map(x=>x.CellNumber).Column("CellNumber");
HasMany<RolsOfCharacter>(x => x._____RolsOfCharacter).LazyLoad().Cascade.None().KeyColumn("CharacterID").NotFound.Ignore();
#region General
DescribeMember(x => x.NickName, IRERPProfile.General).DataSourceFieldProperty(Hidden:false, PrimaryKey:false,Require:false,rootValue:null,title:"نام",valueMap:null);
DescribeMember(x => x.CellNumber, IRERPProfile.General).DataSourceFieldProperty(Hidden:false, PrimaryKey:false,Require:false,rootValue:null,title:"شماره موبایل",valueMap:null);
DescribeMember(x => x.RolsOfCharacter, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
#endregion

#region Abstract
DescribeMember(x => x.NickName, IRERPProfile.Abstract).DataSourceFieldProperty(Hidden:false, PrimaryKey:false,Require:false,rootValue:null,title:"نام",valueMap:null);
DescribeMember(x => x.NickName, IRERPProfile.Abstract).DataSourceFieldProperty(Hidden:false, PrimaryKey:false,Require:false,rootValue:null,title:"نام",valueMap:null);
#endregion

}
}
public class CharacterLogMap : IRERPDescriptor<CharacterLog>
                                    {
 public CharacterLogMap(){
Table(MsdTableName(null,"irerp","bases","Character_TbLog"));
LazyLoad();
Map(x=>x.id).Column("id");
Map(x=>x.Version).Column("Version");
Map(x=>x.IsDeleted).Column("IsDeleted");
Map(x=>x.AddDate).Column("AddDate");
Map(x=>x.LastModifyDate).Column("LastModifyDate");
References<User>(x => x._____AddedBy).LazyLoad().Cascade.None().Column("AddedBy").NotFound.Ignore();
References<User>(x => x._____ModifyBy).LazyLoad().Cascade.None().Column("ModifyBy").NotFound.Ignore();
Map(x=>x.Description).Column("Description");
Map(x=>x.NickName).Column("NickName");
Map(x=>x.CellNumber).Column("CellNumber");
Id(x => x.LogId).GeneratedBy.Guid().Column("Logid");
}
}
}

