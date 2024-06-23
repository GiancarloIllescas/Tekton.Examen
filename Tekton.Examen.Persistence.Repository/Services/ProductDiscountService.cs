using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using Tekton.Examen.Application.Interface.Services;
using Tekton.Examen.Domain.Entity;

namespace Tekton.Examen.Persistence.Services
{
    public class ProductDiscountService : IProductDiscountService
    {

        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public ProductDiscountService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<ProductDiscount> GetByIdAsync(int id)
        {
            var apiKey = _configuration["WeatherApi:ApiKey"];
            var response = await _httpClient.GetAsync($"https://66778861145714a1bd74f6cf.mockapi.io/api/v1/Discount/"+ id.ToString());

            response.EnsureSuccessStatusCode();

            ProductDiscount productDiscount = await response.Content.ReadAsAsync<ProductDiscount>();
            return productDiscount;
        }

        public ProductDiscount GetById(int id)
        {
            var apiKey = _configuration["WeatherApi:ApiKey"];
            var response = _httpClient.GetAsync($"https://66778861145714a1bd74f6cf.mockapi.io/api/v1/Discount/" + id.ToString()).GetAwaiter().GetResult(); ;

            response.EnsureSuccessStatusCode();

            ProductDiscount productDiscount =  response.Content.ReadAsAsync<ProductDiscount>().GetAwaiter().GetResult();
            return productDiscount;
        }

    }
}
