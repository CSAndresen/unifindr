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
    public partial class StartupPage : ContentPage
    {
        public StartupPage()
        {
            InitializeComponent();
            startupimage.Source = Device.RuntimePlatform == Device.Android
                ? ImageSource.FromFile("unuslupuslogo.png")
                : ImageSource.FromFile("Media/unuslupuslogo.png");
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            GoToNextPage();
        }

        private async void GoToNextPage()
        {
            await Shell.Current.GoToAsync("//MainMenu");
        }
    }
}