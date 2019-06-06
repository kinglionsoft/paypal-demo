using Microsoft.Extensions.Options;
using PayPalCheckoutSdk.Core;

namespace PayPal.Server
{
    internal class PayPalClient: PayPalHttpClient
    {
        private readonly PayPalOptions _options;

        public PayPalClient(IOptionsMonitor<PayPalOptions> optionsMonitor) : base(optionsMonitor.CurrentValue.GetEnvironment())
        {
            _options = optionsMonitor.CurrentValue;
        }
    }
}