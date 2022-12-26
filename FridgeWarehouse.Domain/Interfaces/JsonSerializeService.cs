using FridgeWarehouse.Data.Entities;
using FridsgeWarehouse.Data.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using FridgeWarehouse.Core.DTOs;
using FridgeWarehouse.Core.Interfaces;
using System.Net.Http;
using Microsoft.Extensions.Logging;

namespace FridgeWarehouse.Domain.Interfaces
{
    public class JsonSerializeService<T> : IJsonSerializeService<T> where T : BaseDTO
    {
        private readonly IHttpClientFactory clientFactory;
        private readonly ILogger<JsonSerializeService<T>> logger;

        public JsonSerializeService(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public async Task<List<T>> ResponseAsync(string url)
        {
            using var httpClient = clientFactory.CreateClient("defaultFactory");
            var response = await httpClient.GetAsync(url);
            var responseStr = await response.Content.ReadAsStringAsync();

            if(responseStr is null)
            {
                logger.LogError("JsonSerialize Error with response");
                throw new Exception();
            }

            var deserialized = JsonConvert.DeserializeObject<List<T>>(responseStr); 

            if (deserialized is null)
            {
                logger.LogError("JsonSerialize Error with " ,deserialized.GetType().ToString());
                throw new Exception();
            }

            return deserialized;
        }
    }
}
