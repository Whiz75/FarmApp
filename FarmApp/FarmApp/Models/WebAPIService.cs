using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FarmApp.Models
{
    public class WebAPIService
    {
        public List<Products> productsList { get; private set; }

        //Task<List<Products>> GetProductsAsyc();
        public async Task<List<Products>> RefreshDataAsync()
        {
          


            var productList = new List<Products>();
            HttpClient client = new HttpClient();

            string url = "https://farm-web-api.herokuapp.com/api/";
            client.BaseAddress = new Uri(url);

            HttpResponseMessage response = await client.GetAsync("Products");

            if (response.IsSuccessStatusCode)
            {
                string results = await response.Content.ReadAsStringAsync();
                productsList = JsonConvert.DeserializeObject<List<Products>>(results);
            }

            return await Task.FromResult(productList);
        }
    }
}
