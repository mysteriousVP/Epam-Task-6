using Microsoft.Extensions.DependencyInjection;
using DAL.Context;
using DAL.Interfaces;
using DAL;
using Microsoft.EntityFrameworkCore;
using BLL.Services;
using BLL.Interfaces;

namespace BLL.Helper
{
    public static class Extentions
    {
        public static IServiceCollection SetDependences(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProviderService, ProviderService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            services.AddDbContext<DataContext>(x => x.UseSqlServer(connectionString, b => b.MigrationsAssembly("WebAPI")));

            return services;
        }
    }
}
