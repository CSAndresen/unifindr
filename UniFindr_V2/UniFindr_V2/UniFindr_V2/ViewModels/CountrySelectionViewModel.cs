using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniFindr_V2.Models;
using UniFindr_V2.Services;
using UniFindr_V2.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace UniFindr_V2.ViewModels
{
    public class CountrySelectionViewModel : BaseViewModel
    {
        private Country selectedCountry;
        public ObservableCollection<Country> Countries { get; }
        public Command GetCountries { get; }
        public Command<Country> CountryTapped { get; }

        public CountrySelectionViewModel()
        {
            Title = "Preferred Country";
            Countries = new ObservableCollection<Country>();
            GetCountries = new Command(async () => await GetCountriesFromAPI());
            CountryTapped = new Command<Country>(OnCountrySelected);
        }

        async Task GetCountriesFromAPI()
        {
            IsBusy = true;
            try
            {
                Countries.Clear();
                var repoCountries = await Repository_Country.GetCountries(true);
                foreach (Country country in repoCountries)
                {
                    Countries.Add(country);
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
            if(Preferences.Get("Country", null) == null)
            {
                SelectedCountry = null;
            } else
            {
                selectedCountry.CountryName = Preferences.Get("Country", null);
            }
        }

        public Country SelectedCountry
        {
            get => selectedCountry;
            set
            {
                SetProperty(ref selectedCountry, value);
                if(value != null)
                {
                    Preferences.Set("Country", value.CountryName);
                }
                OnCountrySelected(value);
            }
        }

        async void OnCountrySelected(Country country)
        {
            if(country == null)
            {
                return;
            }
            await Shell.Current.GoToAsync("//Profile");
        }
    }
}
