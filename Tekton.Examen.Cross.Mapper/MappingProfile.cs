using AutoMapper;
using Tekton.Examen.Domain.Entity;
using Tekton.Examen.Application.DTO;

namespace Tekton.Examen.Cross.Mapper
{
    public class MappingProfile : Profile
    {
        
        public MappingProfile()
        {
            
            //CreateMap<Product, ProductDto>().ReverseMap();

            CreateMap<Product, ProductDto>()
                .ForMember(destination => destination.ProductId, source => source.MapFrom(src => src.ProductId))
                .ForMember(destination => destination.Name, source => source.MapFrom(src => src.Name))
                .ForMember(destination => destination.StatusName, source => source.MapFrom(src => src.StatusName))
                .ForMember(destination => destination.Stock, source => source.MapFrom(src => src.Stock))
                .ForMember(destination => destination.Description, source => source.MapFrom(src => src.Description))
                .ForMember(destination => destination.Price, source => source.MapFrom(src => src.Price));

            CreateMap<ProductDto, Product>()
                .ForMember(destination => destination.ProductId, source => source.MapFrom(src => src.ProductId))
                .ForMember(destination => destination.Name, source => source.MapFrom(src => src.Name))
                .ForMember(destination => destination.Status, source => source.MapFrom(src => src.StatusName == "Active" ? 1:0))
                .ForMember(destination => destination.Stock, source => source.MapFrom(src => src.Stock))
                .ForMember(destination => destination.Description, source => source.MapFrom(src => src.Description))
                .ForMember(destination => destination.Price, source => source.MapFrom(src => src.Price));


        }
    }
}