using System;
using System.Linq;
using PayPalCheckoutSdk.Core;

namespace PayPal.Server
{
    public sealed class PayPalOptions
    {
        public bool Sandbox { get; set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string CompanyName { get; set; }

        public void Verify()
        {
            if (string.IsNullOrEmpty(CompanyName)
                || new[] { 3, 7, 12 }.Contains(CompanyName.Length) == false)
            {
                throw new ArgumentException("CompanyName must be either 3, 7 or 12 characters.");
            }
        }

        public PayPalEnvironment GetEnvironment()
        {
            if (Sandbox)
            {
                return new SandboxEnvironment(ClientId, ClientSecret);
            }

            return new PayPalEnvironment(ClientId, ClientSecret, "https://api.paypal.com", "https://www.paypal.com");
        }
    }
}
