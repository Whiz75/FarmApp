using FarmApp.Models;
using FarmApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FarmApp.ViewModels
{
    internal class SignUpViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string firstName;
        private string lastName;
        private string email;
        private string phone;
        private string farm;
        private string password;

       
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; PropertyChanged(this, new PropertyChangedEventArgs("FirstName")); }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; PropertyChanged(this, new PropertyChangedEventArgs("LastName")); }
        }
        public string Email
        {
            get { return email; }
            set { email = value; PropertyChanged(this, new PropertyChangedEventArgs("Email")); }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; PropertyChanged(this, new PropertyChangedEventArgs("Phone")); }
        }

        public string Farm
        {
            get { return farm; }
            set { farm = value; PropertyChanged(this, new PropertyChangedEventArgs("Farm")); }
        }

        public string Password
        {
            get { return password; }
            set { password = value; PropertyChanged(this, new PropertyChangedEventArgs("Password")); }
        }

        public ICommand BtnSignUpSignUp { get; set; }
        public ICommand BtnBackToSignIn { get; set; }

        public SignUpViewModel()
        {
            BtnSignUpSignUp = new Command(Register);
            BtnBackToSignIn = new Command(BackToLogin);
        }

        public async void  BackToLogin()
        {
            await App.Current.MainPage.Navigation.PushAsync(new LoginPage());
        }

        public async void Register()
        {
            HttpClient client = new HttpClient();

            Customer customer = new Customer()
            {
                FirstName = firstName,
                CreatedDate = DateTimeOffset.Now,
                LastName = lastName,
                Email = email,
                Password = password,
                Phone = phone,
               
            };

           


            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(customer);
                string uri = "https://farm-web-api.herokuapp.com/api/Customers";
                StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.SendAsync(uri, stringCont);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    await Application.Current.MainPage.DisplayAlert("", "successful", "GOT IT");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("", "unsuccessful", "GOT IT");
                }
            }
            catch(Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("", e.ToString(), "GOT IT");
            }

        }

    }
}
