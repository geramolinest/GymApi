using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GymApi;

public class Startup
{
    private readonly IConfiguration _configuration;
    public Startup(IConfiguration configuration)
    {
        this._configuration = configuration;
    }


    public void ConfigureServices(IServiceCollection services)
    {
        // Add services to the container.

        services.AddControllers()
            .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        
        //Repositories
        services.AddScoped<ISuscriptionsTypesRepository, SuscriptionTypeRepository>();
        services.AddScoped<ISuscriptorRepository, SuscriptorsRepository>();
        services.AddScoped<ISuscriptionsRepository, SuscriptionsRepository>();
        services.AddScoped<IProductsRepository, ProductsRepository>();
        services.AddScoped<ISalesRepository, SalesRepository>();
        services.AddScoped<ISaleProductRepository, SalesProductRepository>();

        //Custom Services
        services.AddSingleton<GenericsResponse>();
        services.AddScoped<UserService>();
        services.AddScoped<RoleService>();
        services.AddScoped<SuscriptionsTypesService>();
        services.AddScoped<SuscriptorsService>();
        services.AddScoped<SuscriptionsService>();
        services.AddScoped<CheckInService>();
        services.AddScoped<ProductsService>();
        services.AddScoped<SalesService>();

        //Automapper
        services.AddAutoMapper(typeof(Startup));

        services.AddDbContext<ApplicationDBContext>(
            options => options.UseMySQL(this._configuration.GetConnectionString("MySql"))
        );

        services.AddIdentityApiEndpoints<IdentityUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDBContext>()
            .AddApiEndpoints();

        services.AddAuthentication();
        services.AddAuthorization();

    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Configure the HTTP request pipeline.
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints => endpoints.MapControllers());
    }
}
