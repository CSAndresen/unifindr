using System;
using System.Collections.Generic;
using UniFindr_V2.ViewModels;
using UniFindr_V2.Views;
using Xamarin.Forms;

namespace UniFindr_V2
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("//Profile", typeof(ProfilePage));
        }

        /* private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }*/
    }
}