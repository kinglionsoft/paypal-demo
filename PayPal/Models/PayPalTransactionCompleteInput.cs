namespace PayPal.Models
{
    public sealed class PayPalTransactionCompleteInput
    {
        public string OrderId { get; set; }

        public override string ToString()
        {
            return $"Order ID: {OrderId}";
        }
    }
}