using AutoMapper;

namespace GymApi;

public class SuscriptionsService
{
    private readonly SuscriptionsRepository _suscriptionsRepository;
    private readonly ILogger<SuscriptionsService> _logger;
    private readonly GenericsResponse _response;
    private readonly IMapper _mapper;
    private readonly SuscriptionTypeRepository _suscriptionsTypeRepository;
    private readonly SuscriptorsRepository _suscriptorsRepository;

    public SuscriptionsService(SuscriptionsRepository suscriptionsRepository, SuscriptorsRepository suscriptorsRepository,SuscriptionTypeRepository suscriptionTypeRepository,IMapper mapper,GenericsResponse response, ILogger<SuscriptionsService> logger)
    {
        this._suscriptionsRepository = suscriptionsRepository;
        this._logger = logger;
        this._response = response;
        this._mapper = mapper;
        this._suscriptionsTypeRepository = suscriptionTypeRepository;
        this._suscriptorsRepository = suscriptorsRepository;
    }

    public async Task<BaseReponse> AddSuscription(SuscriptionAddDto suscriptionDto)
    {
        try
        {
            var suscriptor = await this._suscriptorsRepository.GetSuscriptor(suscriptionDto.SuscriptorId);

            if(suscriptor == null  ) return this._response.BadRequestResponse("Suscriptor does not exists");

            if(suscriptor.Suscription != null) return this._response.BadRequestResponse("Suscriptor has a suscription, please, just renew it");

            var suscriptionType = await this._suscriptionsTypeRepository.GetById(suscriptionDto.SuscriptionTypeId);

            if(suscriptionType == null) return this._response.BadRequestResponse("Suscription type does not exists");

            var suscriptionMapped = this._mapper.Map<Suscription>(suscriptionDto);

            suscriptor.Suscription = suscriptionMapped;

            suscriptor.Suscription.EndDate = DateTime.Now.Date.AddDays(suscriptionType.DurationInDays);

            var suscriptorSaved = await this._suscriptorsRepository.UpdateSuscriptor(suscriptor);

            var suscriptorMapped = this._mapper.Map<SuscriptorGetDto>(suscriptorSaved);

            return this._response.OkResponse("User suscribed successfully", suscriptorMapped);
        }
        catch (Exception e)
        {
            this._logger.LogCritical(e.Message,e);
            return this._response.InternalServerResponse();
        }
    }

    public async Task<BaseReponse> RenewSubscription(RenewSuscriptionDto renewSuscription)
    {
        try
        {
            var suscriptor = await this._suscriptorsRepository.GetSuscriptor(renewSuscription.SuscriptorId);

            if(suscriptor == null  ) return this._response.BadRequestResponse("Suscriptor does not exists");

            if(suscriptor.Suscription == null) return this._response.BadRequestResponse("Suscriptor does not have a suscription, please add it");

            var suscriptionType = await this._suscriptionsTypeRepository.GetById(renewSuscription.SuscriptionTypeId);

            if(suscriptionType == null) return this._response.BadRequestResponse("Suscription type does not exists");

            var suscription = suscriptor.Suscription;
            
            suscription.IsActive = true;

            suscription.StartDate = DateTime.Now;

            suscription.EndDate = suscription.EndDate.CompareTo(DateTime.Now) < 1 ? DateTime.Now.Date.AddDays(suscriptionType.DurationInDays) : suscription.EndDate.Date.AddDays(suscriptionType.DurationInDays);

            await this._suscriptionsRepository.UpdateSuscription(suscription);

            var suscriptorWithRenewedSuscription = await this._suscriptorsRepository.GetSuscriptor(suscriptor.Id);

            var suscriptorFinallyMapped = this._mapper.Map<SuscriptorGetDto>(suscriptorWithRenewedSuscription);

            return this._response.OkResponse("User suscribed successfully", suscriptorFinallyMapped);
        }
        catch (Exception e)
        {
            this._logger.LogCritical(e.Message,e);
            return this._response.InternalServerResponse();
        }
    }

}
