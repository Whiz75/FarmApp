using FarmApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FarmApp.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string email;
        private string password;

        public string Email { 
            get { return email; } 
            set { email = value; PropertyChanged(this, new PropertyChangedEventArgs("Email")); } 
        }      

        public string Password {
            get { return password; }
            set { password = value; PropertyChanged(this, new PropertyChangedEventArgs("Password")); }
        }
        public ICommand BtnLogin { get; set; }
        public ICommand BtnSignUp { get; set; }

        public LoginViewModel()
        {
            BtnLogin = new Command(Login);
            BtnSignUp = new Command(SignUp);

        }

        private void Login()
        {
            //Application.Current.MainPage.DisplayAlert("","LOGIN CLICKED", "GOT IT");
            Application.Current.MainPage = new AppShell();
        }

        private async void SignUp()
        {
            
        }
    }
}
