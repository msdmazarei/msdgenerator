
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
public class RolsOfCharacterMap : IRERPDescriptor<RolsOfCharacter> 
                            { public RolsOfCharacterMap(){Table(MsdTableName(null,"irerp","bases","RolsOfCharacter_Tb"));
LazyLoad();
Id(x=>x.id).Column("id");;
Version(x=>x.Version).Column("Version");
Map(x=>x.IsDeleted).Column("IsDeleted");
Map(x=>x.AddDate).Column("AddDate");
Map(x=>x.LastModifyDate).Column("LastModifyDate");
References<User>(x => x._____AddedBy).LazyLoad().Cascade.None().Column("AddedBy").NotFound.Ignore();
References<User>(x => x._____ModifyBy).LazyLoad().Cascade.None().Column("ModifyBy").NotFound.Ignore();
Map(x=>x.Description).Column("Description");
References<Character>(x => x._____Character).LazyLoad().Cascade.None().Column("CharacterID").NotFound.Ignore();
References<CharacterRole>(x => x._____CharacterRole).LazyLoad().Cascade.None().Column("RoleID").NotFound.Ignore();
}
}
}

