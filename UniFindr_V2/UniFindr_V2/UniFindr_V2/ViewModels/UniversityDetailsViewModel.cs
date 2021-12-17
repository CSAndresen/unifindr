using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using UniFindr_V2.Models;

namespace UniFindr_V2.ViewModels
{
    public class UniversityDetailsViewModel : BaseViewModel
    {
        private string universityName;
        private string universityCountry;
        private string universityArea;
        private string universityWebsite;

        public University SelectedUniversity;

        public UniversityDetailsViewModel()
        {
            Title = UniversityName;
        }

        public void OnAppearing()
        {
            IsBusy = true;
            GetUniversityAsync();
        }

        public string UniversityName
        {
            get => universityName;
            set => SetProperty(ref universityName, value);
        }

        public string UniversityCountry
        {
            get => universityCountry;
            set => SetProperty(ref universityCountry, value);
        }

        public string UniversityArea
        {
            get => universityArea;
            set => SetProperty(ref universityArea, value);
        }

        public string UniversityWebsite
        {
            get => universityWebsite;
            set => SetProperty(ref universityWebsite, value);
        }

        public async void GetUniversityAsync()
        {
            SelectedUniversity = new University();
            try
            {
                SelectedUniversity = await Repository_University.GetUniversity(App.applicationData.LastSelectedUniversity.UniversityName, App.applicationData.LastSelectedUniversity.UniversityCountry);
                UniversityName = SelectedUniversity.UniversityName;
                UniversityCountry = SelectedUniversity.UniversityCountry;
                UniversityArea = SelectedUniversity.UniversityArea;
                UniversityWebsite = SelectedUniversity.UniversityWebsite;
                Title = UniversityName;
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
    }
}
