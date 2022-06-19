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

        //private ObservableCollection <Products> products = new ObservableCollection<Products>();
        //public ObservableCollection <Products> Products { get { return products; }set { products = value; } }
        private ObservableCollection<Category> category = new ObservableCollection<Category>();
        public ObservableCollection<Category> Category { get { return category; } set { category = value; } }

        public async Task GetProductsAsync()
        {
            try
            {
                WebRequest webRequest = WebRequest
                    .Create("https://farm-web-api.herokuapp.com/api/Categories/");
                var response = webRequest.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                var str_reader = reader.ReadToEnd();
                category = JsonConvert.DeserializeObject<ObservableCollection<Category>>(str_reader);
                //await Application.Current.MainPage.DisplayAlert("", str_reader, "GOT IT");

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
