using AutoMapper;
using DataAccess.Model.SiteModels;
using ResourceMetadata.API.ViewModels;

namespace ResourceMetadata.API.Mappers
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappingProfile"; }
        }


        protected override void Configure()
        {

            Mapper.CreateMap<Site,SiteViewModel>()
                .ForMember(vm => vm.Qc, dm=> dm.MapFrom(dModel => dModel.Sales_Rep))
                .ForMember(vm => vm.Zone, dm => dm.MapFrom(dModel => dModel.Sales_Pref));

        }
    }
}