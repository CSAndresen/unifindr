using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using UniFindr_V2.Models;
using Xamarin.Forms;

namespace UniFindr_V2.ViewModels
{
    public class SearchResultsViewModel_All : BaseViewModel
    {
        public University selectedUniversity;
        public ObservableCollection<University> Universities { get; }
        public Command GetUniversities { get; }
        public Command<University> UniversityTapped { get; set; }

        public SearchResultsViewModel_All()
        {
            Title = "Search Results";
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
                var repoUniversities = await Repository_University.GetUniversities_All(true);
                foreach (University university in repoUniversities)
                {
                    Universities.Add(university);
                }
            }
            catch (Exception e)
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
                OnUniversitySelected(value);
            }
        }

        async void OnUniversitySelected(University university)
        {
            if (university == null)
            {
                return;
            }
            await Shell.Current.GoToAsync("//MainMenu");
        }
    }
}
