
using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Bases.IRERPController.IRERPControllerMetaModel;
using IRERP_RestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IRERP_RestAPI.Models.jah;using IRERP_RestAPI.Models.Bases;
namespace IRERP_RestAPI.MetaModel
{
    public class jahad_MetaModel : ControllerMetaModelBase<jahad_MetaModel>
    {  
        public jahad_MetaModel()
        {
            Profile = Bases.MetaDataDescriptors.IRERPProfile.General;

        }


Public Virtual Film SelectedFilm
{
get{
  var selectedid =
                    IRERP_RestAPI.Bases.IRERPApplicationUtilities.GetFromRequest<jahad_MetaModel>(x => x.SelectedFilm.id);
               
                Guid id;
                if (selectedid != null)
                    if (Guid.TryParse(selectedid, out id))
                        return ModelRepositories.jah.Film_Repository.GetByPK(id);
                return new Film();
 
}
}

                             public IList<Auidunce> Auidunce_GetAll
                                    {
                                        get
                                        {
                                            return ModelRepositories.jah.Auidunce_Repository.GetAll();
                                        }
                                    }

                        
                             public IList<FilmSystemType> FilmSystemType_GetAll
                                    {
                                        get
                                        {
                                            return ModelRepositories.jah.FilmSystemType_Repository.GetAll();
                                        }
                                    }

                        
                             public IList<MagNo> MagNo_GetAll
                                    {
                                        get
                                        {
                                            return ModelRepositories.jah.MagNo_Repository.GetAll();
                                        }
                                    }

                        
                             public IList<MagazineType> MagazineType_GetAll
                                    {
                                        get
                                        {
                                            return ModelRepositories.jah.MagazineType_Repository.GetAll();
                                        }
                                    }

                        
                             public IList<Matter> Matter_GetAll
                                    {
                                        get
                                        {
                                            return ModelRepositories.jah.Matter_Repository.GetAll();
                                        }
                                    }

                        
                             public IList<PictureFormat> PictureFormat_GetAll
                                    {
                                        get
                                        {
                                            return ModelRepositories.jah.PictureFormat_Repository.GetAll();
                                        }
                                    }

                        
                             public IList<PictureType> PictureType_GetAll
                                    {
                                        get
                                        {
                                            return ModelRepositories.jah.PictureType_Repository.GetAll();
                                        }
                                    }

                        
                             public IList<Resulation> Resulation_GetAll
                                    {
                                        get
                                        {
                                            return ModelRepositories.jah.Resulation_Repository.GetAll();
                                        }
                                    }

                        
                             public IList<Size> Size_GetAll
                                    {
                                        get
                                        {
                                            return ModelRepositories.jah.Size_Repository.GetAll();
                                        }
                                    }

                        
                             public IList<State> State_GetAll
                                    {
                                        get
                                        {
                                            return ModelRepositories.jah.State_Repository.GetAll();
                                        }
                                    }

                        
                             public IList<Subject> Subject_GetAll
                                    {
                                        get
                                        {
                                            return ModelRepositories.jah.Subject_Repository.GetAll();
                                        }
                                    }

                        
                             public IList<TVRD> TVRD_GetAll
                                    {
                                        get
                                        {
                                            return ModelRepositories.jah.TVRD_Repository.GetAll();
                                        }
                                    }

                        
                             public IList<Title> Title_GetAll
                                    {
                                        get
                                        {
                                            return ModelRepositories.jah.Title_Repository.GetAll();
                                        }
                                    }

                        
                             public IList<Year> Year_GetAll
                                    {
                                        get
                                        {
                                            return ModelRepositories.jah.Year_Repository.GetAll();
                                        }
                                    }

                        
                             public IList<FilmEducationalGoal> FilmEducationalGoal_GetAll
                                    {
                                        get
                                        {
                                            return ModelRepositories.jah.FilmEducationalGoal_Repository.GetAll();
                                        }
                                    }

                        
                             public IList<Film> Film_GetAll
                                    {
                                        get
                                        {
                                            return ModelRepositories.jah.Film_Repository.GetAll();
                                        }
                                    }

                        
                             public IList<FilmProductionFormat> FilmProductionFormat_GetAll
                                    {
                                        get
                                        {
                                            return ModelRepositories.jah.FilmProductionFormat_Repository.GetAll();
                                        }
                                    }

                        
                             public IList<Character> Character_FilmClients
                                    {
                                        get
                                        {
                                            return ModelRepositories.Bases.Character_Repository.FilmClients();
                                        }
                                    }

                        
                             public IList<Character> Character_FilmWriters
                                    {
                                        get
                                        {
                                            return ModelRepositories.Bases.Character_Repository.FilmWriters();
                                        }
                                    }

                        
                             public IList<Character> Character_FilmDirector
                                    {
                                        get
                                        {
                                            return ModelRepositories.Bases.Character_Repository.FilmDirector();
                                        }
                                    }

                        
                             public IList<Character> Character_FilmActors
                                    {
                                        get
                                        {
                                            return ModelRepositories.Bases.Character_Repository.FilmActors();
                                        }
                                    }

                        
                             public IList<Character> Character_FilmSenarists
                                    {
                                        get
                                        {
                                            return ModelRepositories.Bases.Character_Repository.FilmSenarists();
                                        }
                                    }

                        
                             public IList<Character> Character_FilmSpeakers
                                    {
                                        get
                                        {
                                            return ModelRepositories.Bases.Character_Repository.FilmSpeakers();
                                        }
                                    }

                        
                             public IList<Character> Character_FilmExecutives
                                    {
                                        get
                                        {
                                            return ModelRepositories.Bases.Character_Repository.FilmExecutives();
                                        }
                                    }

                        
                             public IList<Character> Character_FilmTechnicalExperts
                                    {
                                        get
                                        {
                                            return ModelRepositories.Bases.Character_Repository.FilmTechnicalExperts();
                                        }
                                    }

                        } //Class End
                    }//NameSpace End