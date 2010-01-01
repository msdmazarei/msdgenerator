
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
using IRERP_RestAPI.Filters.Bases;
using IRERP_RestAPI.Models.Bases;
namespace IRERP_RestAPI.ModelRepositories.Bases{
public class Character_Repository : IRERPRepositoryBaseSimpleFilter<Character_Repository, Character, CharacterFilter> {
public static Character ByPK(Guid PK)
                                {
                                    var filter = new CharacterFilter();
                                    filter.AddSimpleCriteria(x=>x.id,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, PK.ToString());
                                    filter.AddSimpleCriteria(x=>x.IsDeleted,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, false.ToString());

                                    return First(filter);
                                }  
                                                public static IList<Character> ListByAddedByPK<TParent>(Guid PK)
                                                    where TParent : MsdLib.CSharp.DALCore.ModelBase
                                                {
                                                    var filter = new CharacterFilter();
                                                    filter.AddSimpleCriteria(x=>x.IsDeleted,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, false.ToString());

                                                    filter.AddSimpleCriteria(x=>x.AddedBy.id,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, PK.ToString());
                                                    return GetVList<TParent>(filter);
                                                }  
                                                public static IList<Character> ListByModifyByPK<TParent>(Guid PK)
                                                    where TParent : MsdLib.CSharp.DALCore.ModelBase
                                                {
                                                    var filter = new CharacterFilter();
                                                    filter.AddSimpleCriteria(x=>x.IsDeleted,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, false.ToString());

                                                    filter.AddSimpleCriteria(x=>x.ModifyBy.id,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, PK.ToString());
                                                    return GetVList<TParent>(filter);
                                                }
                                                    public static IList<Character> FilmActors()
                                                    {
                                                        var filter = new CharacterFilter();
                                                       
                                                filter.AddSimpleCriteria(x=>x.IsDeleted,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"false");
                                               
                                                filter.AddSimpleCriteria(x=>x.RolsOfCharacter[0].CharacterRole.RoleName,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"بازیگر فیلم");
                                               
                                                        return GetVList(filter);
                                                    }
                                                    public static IList<Character> FilmClients()
                                                    {
                                                        var filter = new CharacterFilter();
                                                       
                                                filter.AddSimpleCriteria(x=>x.IsDeleted,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"false");
                                               
                                                filter.AddSimpleCriteria(x=>x.RolsOfCharacter[0].CharacterRole.RoleName,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"مشتری فیلم");
                                               
                                                        return GetVList(filter);
                                                    }
                                                    public static IList<Character> FilmWriters()
                                                    {
                                                        var filter = new CharacterFilter();
                                                       
                                                filter.AddSimpleCriteria(x=>x.RolsOfCharacter[0].CharacterRole.RoleName,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"نویسنده فیلم");
                                               
                                                filter.AddSimpleCriteria(x=>x.IsDeleted,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"false");
                                               
                                                        return GetVList(filter);
                                                    }
                                                    public static IList<Character> FilmDirector()
                                                    {
                                                        var filter = new CharacterFilter();
                                                       
                                                filter.AddSimpleCriteria(x=>x.IsDeleted,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"false");
                                               
                                                filter.AddSimpleCriteria(x=>x.RolsOfCharacter[0].CharacterRole.RoleName,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"کارگردان فیلم");
                                               
                                                        return GetVList(filter);
                                                    }
                                                    public static IList<Character> FilmSenarists()
                                                    {
                                                        var filter = new CharacterFilter();
                                                       
                                                filter.AddSimpleCriteria(x=>x.IsDeleted,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"false");
                                               
                                                filter.AddSimpleCriteria(x=>x.RolsOfCharacter[0].CharacterRole.RoleName,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"سناریونویس فیلم");
                                               
                                                        return GetVList(filter);
                                                    }
                                                    public static IList<Character> FilmSpeakers()
                                                    {
                                                        var filter = new CharacterFilter();
                                                       
                                                filter.AddSimpleCriteria(x=>x.IsDeleted,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"false");
                                               
                                                filter.AddSimpleCriteria(x=>x.RolsOfCharacter[0].CharacterRole.RoleName,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"گوینده فیلم");
                                               
                                                        return GetVList(filter);
                                                    }
                                                    public static IList<Character> FilmExecutives()
                                                    {
                                                        var filter = new CharacterFilter();
                                                       
                                                filter.AddSimpleCriteria(x=>x.IsDeleted,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"false");
                                               
                                                filter.AddSimpleCriteria(x=>x.RolsOfCharacter[0].CharacterRole.RoleName,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"مجری فیلم");
                                               
                                                        return GetVList(filter);
                                                    }
                                                    public static IList<Character> FilmTechnicalExperts()
                                                    {
                                                        var filter = new CharacterFilter();
                                                       
                                                filter.AddSimpleCriteria(x=>x.IsDeleted,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"false");
                                               
                                                filter.AddSimpleCriteria(x=>x.RolsOfCharacter[0].CharacterRole.RoleName,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"تکنسین فنی فیلم");
                                               
                                                        return GetVList(filter);
                                                    }}

