using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using UniFindr_V2.Models;
using UniFindr_V2.Services;
using UniFindr_V2.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniFindr_V2
{
    public partial class App : Application
    {
        public static ApplicationData applicationData;

        public App()
        {
            InitializeComponent();
            DependencyService.Register<Repository>();
            DependencyService.Register<Repository_Country>();
            MainPage = new AppShell();
            applicationData = new ApplicationData();
        }

        protected override void OnStart()
        {
            if (Current.Properties.ContainsKey("Country"))
            {
                applicationData.PreferredCountry = Current.Properties["Country"].ToString();
            }
            if (Current.Properties.ContainsKey("Favourites"))
            {
                applicationData.FavouritedUniversities = JsonConvert.DeserializeObject<List<University>>(Current.Properties["Favourites"].ToString());
            }
        }

        protected override void OnSleep()
        { 
            if(applicationData.FavouritedUniversities != null)
            {
                Current.Properties["Country"] = applicationData.PreferredCountry.ToString();
                Current.Properties["Favourites"] = JsonConvert.SerializeObject(applicationData.FavouritedUniversities);
                Current.SavePropertiesAsync();
            }
        }

        protected override void OnResume()
        {
        }
    }
}
