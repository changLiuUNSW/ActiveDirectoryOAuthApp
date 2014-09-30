using AutoMapper;
using DataAccess.Model.SiteModels;
using ResourceMetadata.API.ViewModels;

namespace ResourceMetadata.API.Mappers
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappingProfile"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<SiteViewModel, Site>();
        }
    }
}