using AutoMapper;
using ServerTrainingTool.Application.Features.Corsi.Queries.GetCorsiByDocente;
using ServerTrainingTool.Domain;

namespace ServerTrainingTool.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() { 
            CreateMap<Tabella_Corsi, Tabella_CorsiVm>();
        }
    }
}
