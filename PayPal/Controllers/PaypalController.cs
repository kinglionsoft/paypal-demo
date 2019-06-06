using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BraintreeHttp;
using Newtonsoft.Json;
using PayPal.Models;
using PayPalCheckoutSdk.Core;
using PayPalCheckoutSdk.Orders;

namespace PayPal.Controllers
{
    public class PaypalController : Controller
    {
        private readonly ILogger<PaypalController> _logger;
        private readonly PayPalHttpClient _paypalClient;

        public PaypalController(ILogger<PaypalController> logger, PayPalHttpClient paypalClient)
        {
            _logger = logger;
            _paypalClient = paypalClient;
        }
        
        /// <summary>
        /// 交易完成
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Complete([FromBody] PayPalTransactionCompleteInput input)
        {
            _logger.LogInformation(input.ToString());
            try
            {
                OrdersGetRequest request = new OrdersGetRequest(input.OrderId);
                // Call PayPal to get the transaction
                var response = await _paypalClient.Execute(request);
                // Save the transaction in your database. Implement logic to save transaction to your database for future reference.
                var result = response.Result<Order>();
                var resultJson = JsonConvert.SerializeObject(result);
                _logger.LogInformation("支付结果：" + resultJson);
                return Json(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "支付失败");
                return BadRequest();
            }
        }
    }
}