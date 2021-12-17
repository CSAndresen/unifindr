using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UniFindr_V2.Models;
using UniFindr_V2.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniFindr_V2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UniversityDetailsPage : PopupPage
    {
        private University SelectedUniversity;

        private readonly Action<bool> setResultAction;

        public UniversityDetailsPage(Action<bool> setResultAction)
        {
            InitializeComponent();
            SelectedUniversity = App.applicationData.LastSelectedUniversity;
            SetUniversityInfo();
            this.setResultAction = setResultAction;
        }

        public void ReturnToList(object sender, EventArgs e)
        {
            setResultAction?.Invoke(false);
            Navigation.PopPopupAsync().ConfigureAwait(false);
        }

        public void AddToFavourites(object sender, EventArgs e)
        {
            setResultAction?.Invoke(true);
            Navigation.PopPopupAsync().ConfigureAwait(false);
        }

        private void SetUniversityInfo()
        {
            UniName.Text = SelectedUniversity.UniversityName;
            UniCountry.Text = SelectedUniversity.UniversityCountry;
            UniArea.Text = SelectedUniversity.UniversityArea;
        }

        public static async Task<bool> AddToFavourites(INavigation navigation)
        {
            TaskCompletionSource<bool> completionSource = new TaskCompletionSource<bool>();

            void callback(bool didConfirm)
            {
                completionSource.TrySetResult(didConfirm);
            }

            var popup = new UniversityDetailsPage(callback);

            await navigation.PushPopupAsync(popup);

            return await completionSource.Task;
        }

        private void OpenUniversityWebsite(object sender, EventArgs e)
        {

        }
    }
}