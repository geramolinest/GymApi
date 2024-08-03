using AutoMapper;

namespace GymApi;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        //Suscription Type Mappers
        CreateMap<AddSuscriptionTypeDto, SuscriptionType>()
                .ForMember( to => to.NormalizedName, opt => opt.MapFrom(src => src.Name.ToUpper()));                
        CreateMap<SuscriptionType, SuscriptionTypeGetDto>()
                .ForMember( s => s.Name, opt => opt.MapFrom( src => StringCustomUtils.Capitalize(src.Name)));

        //Suscriptors Mappers
        CreateMap<AddSuscriptorDto, Suscriptor>();
        CreateMap<Suscriptor, SuscriptorGetDto>();
        CreateMap<UpdateSuscriptorDto, Suscriptor>();
        CreateMap<SuscribeSuscriptorDto, Suscriptor>()
            .ForMember(x => x.Suscription, opts => opts.MapFrom(x => new Suscription {
                StartDate = x.Suscription.StartDate,
                SuscriptionTypeId = x.Suscription.SuscriptionTypeId,                
            }));

        //Suscriptions Mappers
        CreateMap<AddSuscriptionDto, Suscription>();
        CreateMap<Suscription, SuscriptionGetDto>();
        CreateMap<SuscriptionAddDto, Suscription>();

        //Product Mappers
        CreateMap<Product, ProductGetDto>();
        CreateMap<AddProductDto, Product>();
    }
}
