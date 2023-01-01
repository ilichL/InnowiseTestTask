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
using System.Net.Http.Json;

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

        public async Task<bool> PostResponseWithDTOAsync(string url, T model)
        {
            using var httpClient = clientFactory.CreateClient("defaultFactory");
            var resp = JsonConvert.SerializeObject(model);
            JsonContent content = JsonContent.Create(resp);

            var response = await httpClient.PostAsync(url, content);

            if(!response.IsSuccessStatusCode)
            {
                logger.LogError("JsonSerialize(Post) Error with response status code", response.StatusCode);
                return false;
            }
            return true;

            //var responce = await httpClient.PutAsJsonAsync(url, resp);
        }

        public async Task<bool> DeleteResponseASync(string url, Guid id)
        {//delete return just Ok response, but getFridgeById return model, what shouldI do?
            //протесттить 
            url += "{" + id + "}";
            using var httpClient = clientFactory.CreateClient("defaultFactory");
            var response = await httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                logger.LogError("JsonSerialize Error with response", response.StatusCode);
                return false;
            }

            return true;
        }

        public async Task<List<T>> GetResponseWithIdAsync(string url, Guid id)
        {//протестить 
            url += "{" + id + "}";
            using var httpClient = clientFactory.CreateClient("defaultFactory");
            var response = await httpClient.GetAsync(url);
            var responseStr = await response.Content.ReadAsStringAsync();

            if (responseStr is null)
            {
                logger.LogError("JsonSerialize Error with response");
                throw new Exception();
            }

            var deserialized = JsonConvert.DeserializeObject<List<T>>(responseStr);

            if (deserialized is null)
            {
                logger.LogError("JsonSerialize Error with ", deserialized.GetType().ToString());
                throw new Exception();
            }
            return deserialized;

        }
    }
}
