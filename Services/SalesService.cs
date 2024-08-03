using MySqlX.XDevAPI.Common;

namespace GymApi;

public class SalesService
{
    private readonly ISalesRepository _salesRepository;
    private readonly IProductsRepository _productsRepository;
    private readonly ISaleProductRepository _salesProductRepository;
    private readonly GenericsResponse _response;
    private readonly ILogger<SalesService> _logger;
    private readonly ApplicationDBContext _context;
    private readonly ISuscriptorRepository _suscriptorsRepository;

    public SalesService(ApplicationDBContext context, ISuscriptorRepository suscriptorsRepository, ISalesRepository salesRepository, IProductsRepository productsRepository, ISaleProductRepository salesProductRepository, ILogger<SalesService> logger, GenericsResponse response)
    {
        this._salesRepository = salesRepository;
        this._productsRepository = productsRepository;
        this._salesProductRepository = salesProductRepository;
        this._response=response;
        this._logger = logger;
        this._context = context;
        this._suscriptorsRepository = suscriptorsRepository;
    }

    public async Task<BaseReponse> CreateSale(CreateSaleDto createSale)
    {
        using var transaction = await this._context.Database.BeginTransactionAsync();

        try
        {
            decimal total = 0;

            var suscriptor  = await this._suscriptorsRepository.GetSuscriptor(createSale.SuscriptorId);

            if(suscriptor == null) return this._response.BadRequestResponse("Suscriptor does not exists");

            if(createSale.productsId.Count == 0 ) return this._response.BadRequestResponse("Please provide products");

            var sale = new Sale() 
            {
                DateSale = DateTime.Now,
                SuscriptorId = createSale.SuscriptorId,
                Total= total
            };

            await this._salesRepository.AddSale(sale);

            foreach(int i in createSale.productsId)
            {
                var productDb = await this._productsRepository.GetProductById(i);

                if(productDb == null) return this._response.BadRequestResponse($"Product with id: {i} does not exists");

                await this._salesProductRepository.AddSaleProduct(new SaleProduct(){ ProductId = productDb.Id, SaleId = sale.Id});
                
                total += productDb.Price;
            }

            sale.Total = total;

            var saleUpdated = await this._salesRepository.UpdateSale(sale);

            await transaction.CommitAsync();

            return this._response.CreatedResponse("", saleUpdated);
        }
        catch (Exception e)
        {
           this._logger.LogCritical(e.Message, e);
           return this._response.InternalServerResponse();
        }
    }

    public async Task<BaseReponse> GetOrdersBySucriptor(int id)
    {
        try
        {
            var salesFromDB = await this._salesRepository.GetSalesBySuscriptor(id);

            if(salesFromDB.Count == 0) return this._response.NotFoundResponse("We cannot found orders for the specified customer");
            
            return this._response.OkResponse("", salesFromDB);
        }
         catch (Exception e)
        {
           this._logger.LogCritical(e.Message, e);
           return this._response.InternalServerResponse();
        }
    }
}
