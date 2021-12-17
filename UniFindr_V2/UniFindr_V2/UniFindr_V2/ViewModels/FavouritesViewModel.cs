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
    public class FavouritesViewModel : BaseViewModel
    {
        public ObservableCollection<University> Universities { get; }
        public Command GetUniversities { get; }
        public Command<University> UniversityTapped { get; }
        public FavouritesViewModel()
        {
            Title = "Favourite Universities";
            Universities = new ObservableCollection<University>();
            GetUniversities = new Command(async () => await GetFavouriteUniversities());
        }

        async Task GetFavouriteUniversities()
        {
            IsBusy = true;
            try
            {
                List<University> favouriteUnis = App.applicationData.FavouritedUniversities;
                Universities.Clear();
                for(int i = 0; i < favouriteUnis.Count; i++)
                {
                    Universities.Add(favouriteUnis[i]);
                }
            } catch(Exception e)
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
        }
    }
}
