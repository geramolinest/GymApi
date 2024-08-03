using AutoMapper;

namespace GymApi;

public class CheckInService
{
    private readonly ISuscriptorRepository _suscriptorsRepository;
    private readonly GenericsResponse _response;
    private readonly ILogger<CheckInService> _logger;
    private readonly IMapper _mapper;

    public CheckInService(ISuscriptorRepository suscriptorsRepository, IMapper mapper,GenericsResponse response, ILogger<CheckInService> logger)
    {
        this._suscriptorsRepository = suscriptorsRepository;
        this._response = response;
        this._logger = logger;  
        this._mapper = mapper;
    }

    public async Task<BaseReponse> CheckIn(int suscriptorId)
    {
        try
        {
            var suscriptor = await this._suscriptorsRepository.GetSuscriptor(suscriptorId);

            if(suscriptor == null) return this._response.BadRequestResponse("Suscriptor does not exists");

            if(suscriptor.Suscription == null) return this._response.BadRequestResponse("Suscriptor does not have suscription, please add one");


            var suscriptionExpired = suscriptor.Suscription.EndDate.CompareTo(DateTime.Now) < 0;

            if(suscriptionExpired) return this._response.BadRequestResponse("Suscription expired");

            var suscriptorGet = this._mapper.Map<SuscriptorGetDto>(suscriptor);

            return this._response.OkResponse($"Welcome {suscriptorGet.Name }, your suscription will expire in {DateUtils.GetDaysBetweenDates(suscriptor.Suscription.EndDate, DateTime.Now)} days. Expire date: {DateUtils.FormatDate(suscriptor.Suscription.EndDate)}", suscriptorGet);
        }
        catch (Exception e)
        {
            this._logger.LogCritical(e.Message, e);
            return this._response.InternalServerResponse();
        }
    }
}
