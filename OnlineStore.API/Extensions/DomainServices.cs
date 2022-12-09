using OnlineStore.Domain.Contracts.Services;
using OnlineStore.Domain.Services;

namespace OnlineStore.API.Extensions
{
    public static class DomainServices
    {
        public static void AddDomainServices(this IServiceCollection services)
        {
            services.AddSingleton<IHomeService, HomeService>()
                    .AddSingleton<IProductDetailsService, ProductDetailsService>()
                    .AddSingleton<IShoppingCartService, ShoppingCartService>();
        }
    }
}
