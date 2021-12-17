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
    public partial class SearchResultsPage_Home : ContentPage
    {
        readonly SearchResultsViewModel_Home _viewModel;

        public SearchResultsPage_Home()
        {
            InitializeComponent();
            BindingContext = _viewModel = new SearchResultsViewModel_Home();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}