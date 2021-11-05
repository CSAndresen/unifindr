using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniFindr_V2.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniFindr_V2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CountrySelectionPage : ContentPage
    {
        CountrySelectionViewModel _viewModel;

        public CountrySelectionPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new CountrySelectionViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}