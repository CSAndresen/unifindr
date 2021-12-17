using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using UniFindr_V2.Models;
using UniFindr_V2.Views;
using Xamarin.Forms;

namespace UniFindr_V2.ViewModels
{
    public class SearchResultsViewModel_Home : BaseViewModel
    {
        public University selectedUniversity;
        public ObservableCollection<University> Universities { get; }
        public Command GetUniversities { get; }
        public Command<University> UniversityTapped { get; set; }

        INavigation navigation;

        public SearchResultsViewModel_Home()
        {
            Title = "Search Results";
            INavigation Navigation = navigation;
            Universities = new ObservableCollection<University>();
            GetUniversities = new Command(async () => await GetUniversitiesFromAPI());
            UniversityTapped = new Command<University>(OnUniversitySelected);
        }

        async Task GetUniversitiesFromAPI()
        {
            IsBusy = true;
            try
            {
                Universities.Clear();
                var repoUniversities = await Repository_University.GetUniversities_Home(true);
                foreach(University university in repoUniversities)
                {
                    Universities.Add(university);
                }
            } 
            catch(Exception e)
            {
                Debug.WriteLine(e);
            } 
            finally 
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            selectedUniversity = null;
        }

        public University SelectedUniversity
        {
            get => selectedUniversity;
            set
            {
                SetProperty(ref selectedUniversity, value);
                App.applicationData.LastSelectedUniversity = value;
                OnUniversitySelected(value);
            }
        }

        public async void OnUniversitySelected(University university)
        {
            if(university == null)
            {
                return;
            }
            var result = await UniversityDetailsPage.AddToFavourites(navigation);
            if (result)
            {
                await Repository_University.AddFavourite(App.applicationData.LastSelectedUniversity);
            }
        }
    }
}
