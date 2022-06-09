using FarmApp.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FarmApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));
            Routing.RegisterRoute(nameof(MenuPage), typeof(MenuPage));
        }

    }
}
