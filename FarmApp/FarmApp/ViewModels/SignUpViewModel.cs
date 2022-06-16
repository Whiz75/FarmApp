using FarmApp.Models;
using FarmApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
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
            try
            {
                await App.Current.MainPage.Navigation.PushAsync(new LoginPage());
            }
            catch(Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Exception", e.ToString(), "GOT IT");
            }
        }

        public async void Register()
        {
            HttpClient client = new HttpClient();

            Customer customer = new Customer()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password,
                Phone = phone,
            };


            string json = Newtonsoft.Json.JsonConvert.SerializeObject(customer);

            string str_reader = null;

            try
            {
                WebRequest webRequest = WebRequest.Create("https://farm-web-api.herokuapp.com/api/Customers/");
                webRequest.Method = "POST";
                webRequest.ContentType = "application/json";
                Stream stream = webRequest.GetRequestStream();
                byte[] byteArray = Encoding.UTF8.GetBytes(json);
                await stream.WriteAsync(byteArray, 0, byteArray.Length);
                stream.Close();

                var response = webRequest.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                str_reader = reader.ReadToEnd();

                await Application.Current.MainPage.DisplayAlert("", str_reader, "GOT IT");

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("", ex.ToString(), "GOT IT");
            }
        }

    }
}
