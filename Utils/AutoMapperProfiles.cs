using AutoMapper;

namespace GymApi;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        //Suscription Type Mappers
        CreateMap<AddSuscriptionTypeDto, SuscriptionType>();
        CreateMap<SuscriptionType, SuscriptionTypeGetDto>();

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
