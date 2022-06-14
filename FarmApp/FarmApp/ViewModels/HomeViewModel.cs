using FarmApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FarmApp.ViewModels
{
    internal class HomeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int productId;
        private string productName;
        private string productType;
        private string productDescription;
        private double productPrice;
        private int productQuantity;
        private int farmId;

        //private Products product;
        //public Products Products
        //{
        //    get { return product; }
        //    set { product = value; PropertyChanged(this, new PropertyChangedEventArgs("Products")); }
        //}
        private ObservableCollection <Products> products = new ObservableCollection<Products>();
        public ObservableCollection <Products> Products { get { return products; }set { products = value; } }

        public async Task GetProductsAsync()
        {
            var productsList = new List<Products>();

            //string json = Newtonsoft.Json.JsonConvert.SerializeObject();

            //string str_reader = null;

            try
            {
                WebRequest webRequest = WebRequest.Create("https://farm-web-api.herokuapp.com/api/Products/");
                webRequest.Method = "GET";
                webRequest.ContentType = "application/json";
                Stream stream = webRequest.GetRequestStream();
                stream.Close();

                var response = webRequest.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                var str_reader = reader.ReadToEnd();

                await Application.Current.MainPage.DisplayAlert("", str_reader, "GOT IT");

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("", ex.ToString(), "GOT IT");
            }


        }

        public HomeViewModel()
        {
           _= GetProductsAsync();
        }
    }


}
