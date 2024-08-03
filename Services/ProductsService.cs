using AutoMapper;

namespace GymApi;

public class ProductsService
{
    private readonly ProductsRepository _productsRepository;
    private readonly IMapper _mapper;
    private readonly GenericsResponse _response;
    private readonly ILogger<ProductsService> _logger;

    public ProductsService(ProductsRepository productsRepository, GenericsResponse response, IMapper mapper, ILogger<ProductsService> logger)
    {   
        this._productsRepository = productsRepository;
        this._mapper = mapper;
        this._response = response;
        this._logger = logger;
    }

    public async Task<BaseReponse> GetProductById(int id)
    {
        try
        {
            var productDB = await this._productsRepository.GetProductById(id);

            if(productDB == null) return this._response.NotFoundResponse("Product does not exists");

            var productMapped = this._mapper.Map<ProductGetDto>(productDB);

            return this._response.OkResponse("", productMapped);
        }
        catch (Exception e)
        {            
            this._logger.LogCritical(e.Message, e);
            return this._response.InternalServerResponse();
        }
    }

    public async Task<BaseReponse> GetAllProducts()
    {
        try
        {
            var productsDB = await this._productsRepository.GetAllProducts();

            var productsMapped = this._mapper.Map<List<ProductGetDto>>(productsDB);

            return this._response.OkResponse("", productsMapped);
        }
        catch (Exception e)
        {            
            this._logger.LogCritical(e.Message, e);
            return this._response.InternalServerResponse();
        }
    }

    public async Task<BaseReponse> AddProduct(AddProductDto addProduct)
    {
        try
        {


            var productMapped = this._mapper.Map<Product>(addProduct);

            var productSaved = await this._productsRepository.AddProduct(productMapped);

            var productGet = this._mapper.Map<ProductGetDto>(productSaved);

            return this._response.OkResponse("", productGet);
        }
        catch (Exception e)
        {            
            this._logger.LogCritical(e.Message, e);
            return this._response.InternalServerResponse();
        }
    }


    public async Task<BaseReponse> UpdateProduct(int id, UpdateProductDto updateProduct)
    {
        try
        {
            var productFromDb = await this._productsRepository.GetProductById(id);

            if(productFromDb is null) return this._response.BadRequestResponse("Product does not exists");

            productFromDb.Name = updateProduct.Name;
            productFromDb.Description = updateProduct.Description;
            productFromDb.Price = updateProduct.Price;

            var productUpdated = await this._productsRepository.UpdateProduct(productFromDb);

            var productGet = this._mapper.Map<ProductGetDto>(productUpdated);

            return this._response.OkResponse("", productGet);
        }
        catch (Exception e)
        {            
            this._logger.LogCritical(e.Message, e);
            return this._response.InternalServerResponse();
        }
    }

    public async Task<BaseReponse> DeleteProduct(int id)
    {
        try
        {
            var productFromDb = await this._productsRepository.GetProductById(id);

            if(productFromDb is null) return this._response.BadRequestResponse("Product does not exists");

            var idProduct = await this._productsRepository.DeleteProduct(productFromDb);

            return this._response.OkResponse($"Product deleted, id: {idProduct}");
        }
        catch (Exception e)
        {            
            this._logger.LogCritical(e.Message, e);
            return this._response.InternalServerResponse();
        }
    }

    

    


}
