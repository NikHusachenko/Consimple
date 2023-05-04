using Consimple.EntityFramework;
using Consimple.EntityFramework.Repository;
using Consimple.Services.CategoryServices;
using Consimple.Services.CategoryServices.Models;
using Consimple.Services.ClientServices;
using Consimple.Services.ClientServices.Models;
using Consimple.Services.ProductServices;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Consimple.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            IServiceCollection services = builder.Services;

            // Configurations
            services.AddControllers();
            services.AddCors();
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings:DefaultConnection").Value));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            // Validators
            services.AddScoped<IValidator<CreateClientHttpPostViewModel>, CreateClientHttpPostViewModelValidator>();
            services.AddScoped<IValidator<CreateCategoryHttpPostViewModel>, CreateCategoryHttpPostViewModelValidator>();

            // Services
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IProductService, ProductService>();
            
            var app = builder.Build();

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}