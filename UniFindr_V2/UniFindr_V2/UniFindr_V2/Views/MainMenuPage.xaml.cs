using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniFindr_V2.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniFindr_V2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenuPage : ContentPage
    {
        readonly MainMenuViewModel _viewModel;

        public MainMenuPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new MainMenuViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (App.applicationData.PreferredCountry != null)
            {
                PreferredCountry.Text = App.applicationData.PreferredCountry;
            }
            else
            {
                PreferredCountry.Text = "Preferred Location not set: Please choose one to access all application features.";
            }
            _viewModel.OnAppearing();
        }
    }
}