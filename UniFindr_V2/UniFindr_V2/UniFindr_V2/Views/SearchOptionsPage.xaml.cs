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
    public partial class SearchOptionsPage : ContentPage
    {
        public SearchOptionsPage()
        {
            InitializeComponent();
        }
        private void SearchHome(object sender, EventArgs e)
        {
            GoToSearchResults_Home();
        }

        private async void GoToSearchResults_Home()
        {
            await Shell.Current.GoToAsync("//SearchResults_Home");
        }

        private void SearchAbroad(object sender, EventArgs e)
        {
            GoToSearchResults_Abroad();
        }

        private async void GoToSearchResults_Abroad()
        {
            await Shell.Current.GoToAsync("//SearchResults_Abroad");
        }

        private void SearchAnywhere(object sender, EventArgs e)
        {
            GoToSearchResults_All();
        }
        private async void GoToSearchResults_All()
        {
            await Shell.Current.GoToAsync("//SearchResults_All");
        }
    }
}