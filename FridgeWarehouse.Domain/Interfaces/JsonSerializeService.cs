using System.Text;

using Newtonsoft.Json;
using FridgeWarehouse.Core.DTOs;
using FridgeWarehouse.Core.Interfaces;
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


        public async Task<List<T>> ResponseWithIdASync(string url, Guid id)
        {//delete return just Ok response, but getFridgeById return model, what shouldI do?
            //протесттить 
            //передаст ли нормально id?
            using var httpClient = clientFactory.CreateClient("defaultFactory");
            //url += "{" + id + "}";
            url += "?id =" + id;
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


        public async Task<TResponse> Post<TResponse, TBodyType>(string url, TBodyType obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var body = new StringContent(json, Encoding.UTF8, ContentTypes.ApplicationJson);

            var client = new HttpClient();
            var response = await client.PostAsync(url, body);
            var stringResponse = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<TResponse>(stringResponse);

            return result;
        }
    }
}
