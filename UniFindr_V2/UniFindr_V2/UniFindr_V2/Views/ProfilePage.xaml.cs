using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniFindr_V2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }
        private void GoToFavourites(object sender, EventArgs e)
        {
            FavouritesNavigation();
        }

        private async void FavouritesNavigation()
        {
            await Shell.Current.GoToAsync("//CountrySelection");
        }

        private void GoToCountrySelection(object sender, EventArgs e)
        {
            CountrySelectionNavigation();
        }

        private async void CountrySelectionNavigation()
        {
            await Shell.Current.GoToAsync("//CountrySelection");
        }
    }
}