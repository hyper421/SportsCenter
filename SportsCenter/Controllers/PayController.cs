using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SportsCenter.Models;
using SportsCenter.Service;

namespace SportsCenter.Controllers
{
    public class PayController : Controller
    {
        private readonly CryptoService _cryptoService;
        private readonly IConfiguration _configuration;

        public PayController(CryptoService cryptoService,IConfiguration configuration)
        {
            _cryptoService = cryptoService;
            _configuration = configuration;
        }
        public IActionResult Success([FromForm] OnlinePaymentReturn data)
        {
            //if (data.Status.ToLower() != "success")
            //{
            //    return View("Fail");
            //}
            //var result = _cryptoService.DecryptAESHex(data.TradeInfo, _configuration["Pay:HashKey"], _configuration["Pay:HashIV"]);
            //var paymentResult = JsonConvert.DeserializeObject<PaymentResult>(result);
            return View();
        }
    }
}
