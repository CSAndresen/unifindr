using System;
using UniFindr_V2.Services;
using UniFindr_V2.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniFindr_V2
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            DependencyService.Register<Repository>();
            DependencyService.Register<Repository_Country>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
