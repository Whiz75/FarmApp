using FarmApp.Models;
using FarmApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FarmApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            BindingContext = new HomeViewModel();
        }

        private void CategoriesLis_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var id = e.CurrentSelection.FirstOrDefault() as Category;
            Navigation.PushModalAsync(new ProductsPage(id.Id));
            
        }
    }
}