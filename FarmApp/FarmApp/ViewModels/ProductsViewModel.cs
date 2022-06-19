using FarmApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FarmApp.ViewModels
{
    public class ProductsViewModel
    {
        private ObservableCollection<Products> products = new ObservableCollection<Products>();
        public ObservableCollection<Products> Products { get { return products; } set { products = value; } }
        private int id;
        public ProductsViewModel(int id)
        {
            this.id = id;
            _=GetProductsAsync();
        }

        public async Task GetProductsAsync()
        {

            try
            {
                WebRequest webRequest = WebRequest
                    .Create($"https://farm-web-api.herokuapp.com/api/ProductsCategory/{id}");
                webRequest.Method = "GET";
                var response = webRequest.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                var str_reader = reader.ReadToEnd();
                products = JsonConvert.DeserializeObject<ObservableCollection<Products>>(str_reader);
                // await Application.Current.MainPage.DisplayAlert("", str_reader, "GOT IT");

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.ToString(), "GOT IT");
            }


        }
  
    }
}
