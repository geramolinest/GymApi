using AutoMapper;

namespace GymApi;

public class SuscriptorsService
{
    private readonly IMapper _mapper;
    private readonly GenericsResponse _response;
    private readonly SuscriptorsRepository _repository;
    private readonly ILogger<SuscriptorsService> _logger;
    private readonly SuscriptionTypeRepository _suscriptionsTypeRepository;

    public SuscriptorsService(SuscriptorsRepository repository, IMapper mapper, GenericsResponse response, ILogger<SuscriptorsService> logger, SuscriptionTypeRepository suscriptionTypeRepository)
    {
        this._mapper = mapper;
        this._response = response;
        this._repository = repository;
        this._logger = logger;
        this._suscriptionsTypeRepository = suscriptionTypeRepository;
    }

    public async Task<BaseReponse> GetSuscriptorById(int id)
    {
        try
        {
            var suscriptor = await this._repository.GetSuscriptor(id);

            if (suscriptor == null) return this._response.NotFoundResponse("Suscriptor does not exists");

            var suscriptorGet = this._mapper.Map<SuscriptorGetDto>(suscriptor);

            return this._response.OkResponse("", suscriptorGet);
        }
        catch (Exception e)
        {
            this._logger.LogCritical(e.Message, e);
            return this._response.InternalServerResponse();
        }
    }

    public async Task<BaseReponse> GetAllSuscriptors()
    {
        try
        {
            var suscriptors = await this._repository.GetSuscriptors();

            var mappedSuscriptors = this._mapper.Map<List<SuscriptorGetDto>>(suscriptors);

            return this._response.OkResponse("Suscriptors recovered successfully", mappedSuscriptors);
        }
        catch (Exception e)
        {
            this._logger.LogCritical(e.Message, e);
            return this._response.InternalServerResponse();
        }
    }

    public async Task<BaseReponse> AddSuscriptor(AddSuscriptorDto addSuscriptorDto)
    {
        try
        {
           var suscriptorFromDB = await this._repository.GetSuscriptorByEmail(addSuscriptorDto.Email);

           if(suscriptorFromDB != null) return this._response.BadRequestResponse("A suscriptor with this email already exists");
           
            var suscriptor = this._mapper.Map<Suscriptor>(addSuscriptorDto);

            suscriptor.RegisterDate = DateTime.Now.Date;
            
            suscriptor.Age = DateUtils.GetYearsFromDates(DateTime.Now, addSuscriptorDto.DateBirth);

            var suscriptorResult = await this._repository.AddSuscriptor(suscriptor);

            var suscriptorGet = this._mapper.Map<SuscriptorGetDto>(suscriptorResult);

            return this._response.OkResponse($"Welcome {suscriptor.Name.Normalize()}", suscriptorGet);
        }
        catch (Exception e)
        {
            this._logger.LogCritical(e.Message, e);
            return this._response.InternalServerResponse();
        }
    }

    public async Task<BaseReponse> UpdateSuscriptor(int id, UpdateSuscriptorDto suscriptor)
    {
        try
        {
            var suscriptorDb = await this._repository.GetSuscriptor(id);

            if (suscriptorDb == null) return this._response.BadRequestResponse("Suscriptor does not exists");
            
            suscriptorDb.Name = suscriptor.Name;

            suscriptorDb.LastName = suscriptor.LastName;

            suscriptorDb.DateBirth = suscriptor.DateBirth;

            suscriptorDb.Age = DateUtils.GetYearsFromDates(DateTime.Now, suscriptor.DateBirth);

            await this._repository.UpdateSuscriptor(suscriptorDb);

            var suscriptorDBAfterUpdate = await this._repository.GetSuscriptor(id);

            var suscriptorGet = this._mapper.Map<SuscriptorGetDto>(suscriptorDBAfterUpdate);

            return this._response.OkResponse($"Welcome {suscriptor.Name.Normalize()}", suscriptorGet);
        }
        catch (Exception e)
        {
            this._logger.LogCritical(e.Message, e);
            return this._response.InternalServerResponse();
        }
    }

    public async Task<BaseReponse> DeleteSuscriptor(int id)
    {
        try
        {
            var suscriptorDb = await this._repository.GetSuscriptor(id);

            if (suscriptorDb == null) return this._response.BadRequestResponse("Suscriptor does not exists");

            suscriptorDb.IsActive = false;

            var idDeleted = await this._repository.DeleteSuscriptor(suscriptorDb);

            return this._response.OkResponse($"Id {idDeleted} deleted");
        }
        catch (Exception e)
        {
            this._logger.LogCritical(e.Message, e);
            return this._response.InternalServerResponse();
        }
    }

    public async Task<BaseReponse> AddSucriptorWithSubscription(SuscribeSuscriptorDto suscription)
    {
        try
        {       
            
            var suscriptionType = await this._suscriptionsTypeRepository.GetById(suscription.Suscription.SuscriptionTypeId);

            if(suscriptionType == null) return this._response.BadRequestResponse("Suscription type does not exists");

            var suscriptorWithSuscriptionMapped = this._mapper.Map<Suscriptor>(suscription);

            suscriptorWithSuscriptionMapped.RegisterDate = DateTime.Now.Date;

            suscriptorWithSuscriptionMapped.Age = DateUtils.GetYearsFromDates(DateTime.Now, suscription.DateBirth);
            
            var suscripcionEntityMapped = suscriptorWithSuscriptionMapped.Suscription;
            
            suscripcionEntityMapped.EndDate = DateUtils.AddDaysToDate(suscriptorWithSuscriptionMapped.Suscription.StartDate, suscriptionType.DurationInDays);
            
            suscriptorWithSuscriptionMapped.Suscription.IsActive = suscripcionEntityMapped.EndDate.CompareTo(DateTime.Now) >= 0;
            
            var suscriptorAdded = await this._repository.AddSuscriptor(suscriptorWithSuscriptionMapped);

            var suscriptorMapped = this._mapper.Map<SuscriptorGetDto>(suscriptorAdded);
            
            return this._response.OkResponse($"Suscription renewed, see you at { suscriptorAdded.Suscription.EndDate } again", suscriptorMapped);
        }
        catch (Exception e)
        {
            this._logger.LogCritical(e.Message, e);
            return this._response.InternalServerResponse();
        }
    }
}
