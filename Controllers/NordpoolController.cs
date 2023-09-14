using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ProoviTöö.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NordpoolController : ControllerBase
    {

        private readonly HttpClient _httpClient;

        public NordpoolController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet("{country}")]
        public async Task<IActionResult> GetNordPoolPrices(string country)
        {
            var response = await _httpClient.GetAsync("https://dashboard.elering.ee/api/nps/price");
            var responseBody = await response.Content.ReadAsStringAsync();
            var jsonDoc = JsonDocument.Parse(responseBody);
            var dataProperty = jsonDoc.RootElement.GetProperty("data");

            string prices;

            switch (country)
            {
                case "ee":
                    prices = dataProperty.GetProperty("ee").ToString();
                    return Content(prices, "application/json");

                case "lv":
                    prices = dataProperty.GetProperty("lv").ToString();
                    return Content(prices, "application/json");

                case "lt":
                    prices = dataProperty.GetProperty("lt").ToString();
                    return Content(prices, "application/json");

                case "fi":
                    prices = dataProperty.GetProperty("fi").ToString();
                    return Content(prices, "application/json");

                default:
                    return BadRequest("Invalid country code.");
            }
        }
    }
}
