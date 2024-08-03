using AutoMapper;

namespace GymApi;

public class SuscriptionsTypesService
{
    private readonly SuscriptionTypeRepository _suscriptionsTypesRepository;
    private readonly GenericsResponse _response;
    private readonly ILogger<SuscriptionsTypesService> _logger;
    private readonly IMapper _mapper;

    public SuscriptionsTypesService(SuscriptionTypeRepository suscriptionsTypesRepository, GenericsResponse response, ILogger<SuscriptionsTypesService> logger, IMapper mapper)
    {
        this._suscriptionsTypesRepository = suscriptionsTypesRepository;
        this._response = response;
        this._logger = logger;
        this._mapper = mapper;
    }

    public async Task<BaseReponse> AddSuscriptionType(AddSuscriptionTypeDto suscriptionType)
    {
        try
        {
            var susTypeMapped = this._mapper.Map<SuscriptionType>(suscriptionType);
            
            susTypeMapped.Name = susTypeMapped.Name.ToUpper();

            var suscriptionTypeAdded = await this._suscriptionsTypesRepository.AddSuscriptionType(susTypeMapped);

            var susTypeMappedDto = this._mapper.Map<SuscriptionTypeGetDto>(suscriptionTypeAdded);

            return this._response.OkResponse("Suscription type added successfully." , susTypeMappedDto);
        }
        catch (Exception e)
        {
            this._logger.LogCritical(e.Message);
            return this._response.InternalServerResponse();
        }
    }

    public async Task<BaseReponse> GetSuscriptionsTypes()
    {
        try
        {
            var suscriptionsTypes = await this._suscriptionsTypesRepository.GetAll();

            var suscriptionsMapped = this._mapper.Map<List<SuscriptionTypeGetDto>>(suscriptionsTypes);

            return this._response.OkResponse("", suscriptionsMapped);
        }
        catch (Exception e)
        {            
            this._logger.LogCritical(e.Message);
            return this._response.InternalServerResponse();
        }
    }

    public async Task<BaseReponse> GetSuscriptionType(int id)
    {
        try
        {
            var suscriptionsType = await this._suscriptionsTypesRepository.GetById(id);

            if(suscriptionsType is null) return this._response.NotFoundResponse("Type suscription does not exists.");

            var suscriptionsMapped = this._mapper.Map<SuscriptionTypeGetDto>(suscriptionsType);

            return this._response.OkResponse("", suscriptionsMapped);
        }
        catch (Exception e)
        {
            
            this._logger.LogCritical(e.Message);
            return this._response.InternalServerResponse();
        }
    }

    public async Task<BaseReponse> UpdateSuscriptionType(int id, UpdateSuscriptionTypeDto suscriptionTypeDto)
    {
        try
        {
            var suscriptionTypeSelect = await this._suscriptionsTypesRepository.GetById(id);

            if(suscriptionTypeSelect is null) return this._response.BadRequestResponse("Suscription type does not exists");

            suscriptionTypeSelect.Name = suscriptionTypeDto.Name != null && suscriptionTypeDto.Name.Length > 0 ? suscriptionTypeDto.Name : suscriptionTypeSelect.Name;
            suscriptionTypeSelect.NormalizedName = suscriptionTypeDto.Name != null && suscriptionTypeDto.Name.Length > 0 ? suscriptionTypeDto.Name.ToUpper() : suscriptionTypeSelect.NormalizedName;
            suscriptionTypeSelect.DurationInDays = suscriptionTypeDto.DurationInDays;
            suscriptionTypeSelect.Price = suscriptionTypeDto.Price;

            var suscriptionType = await this._suscriptionsTypesRepository.UpdateSuscriptionType(suscriptionTypeSelect);

            var suscriptionsMapped = this._mapper.Map<SuscriptionTypeGetDto>(suscriptionType);

            return this._response.OkResponse("", suscriptionsMapped);
        }
        catch (Exception e)
        {
            
            this._logger.LogCritical(e.Message);
            return this._response.InternalServerResponse();
        }
    }
}
