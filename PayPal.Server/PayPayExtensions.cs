using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PayPalCheckoutSdk.Core;

namespace PayPal.Server
{
    public static class PayPayExtensions
    {
        public static IServiceCollection AddPayPal(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<PayPalOptions>(configuration);

            //services.AddScoped<ClientTokenMiddleware>();
            //services.AddScoped<PurchaseMiddleware>();
            //services.AddScoped(typeof(IPurchaseHandler), typeof(THandler));
            //services.AddSingleton<IPayPalPayment, PayPalPayment>();
            services.AddSingleton<PayPalHttpClient, PayPalClient>();

            return services;
        }
    }
}
