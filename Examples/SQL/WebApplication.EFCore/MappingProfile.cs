using AutoMapper;
using Database.EFCore.Entities;

namespace WebApplication.EFCore
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ShopEntity, ShopSummary>()
                .ForMember(
                    dst => dst.ShopCategory,
                    opt => opt.MapFrom(src => src.Category.Category)
                );
        }
    }
}