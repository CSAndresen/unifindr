using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniFindr_V2.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace UniFindr_V2.Services
{
    public class Repository : IRepository<University>
    {
        public List<University> FullUniversityList;
        public List<University> universities_abroad;
        public List<University> universities_all;
        public List<University> universities_home;

        public Repository()
        {
            FullUniversityList = SendFullApiRequest();
            universities_abroad = FillUniversitiesList_Abroad();
            universities_all = FillUniversitiesList_All();
            universities_home = FillUniversitiesList_Home();
        }

        public List<University> SendFullApiRequest()
        {
            var client = new RestClient("http://universities.hipolabs.com/search?")
            {
                Timeout = -1
            };
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            List<ApiResponse> responseContent = JsonConvert.DeserializeObject<List<ApiResponse>>(response.Content);
            FullUniversityList = new List<University>();
            FullUniversityList.Clear();
            for (int i = 0; i < responseContent.Count; i++)
            {
                FullUniversityList.Add(new University
                {
                    UniversityName = responseContent[i].name,
                    UniversityCountry = responseContent[i].country,
                    UniversityArea = responseContent[i].stateprovince,
                    UniversityWebsite = responseContent[i].web_pages[0]
                });
            }
            return FullUniversityList;
        }

        public async Task<bool> RefreshApiCall()
        {
            FillUniversitiesList_Home();
            FillUniversitiesList_Abroad();
            return await Task.FromResult(true);
        }

        public async Task<bool> AddFavourite(University university)
        {
            if (!App.applicationData.FavouritedUniversities.Any(f => f.UniversityName == university.UniversityName))
            {
                App.applicationData.FavouritedUniversities.Add(university);
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }
        public List<University> FillUniversitiesList_Abroad()
        {
            universities_abroad = new List<University>();
            universities_abroad.Clear();
            for(int i = 0; i < FullUniversityList.Count; i++)
            {
                if(!universities_abroad.Any(u => u.UniversityCountry == App.applicationData.PreferredCountry))
                {
                    universities_abroad.Add(FullUniversityList[i]);
                }
            }
            return universities_abroad;
        }

        public async Task<IEnumerable<University>> GetUniversities_Abroad(bool forceRefresh = true)
        {
            return await Task.FromResult(universities_abroad);
        }


        public List<University> FillUniversitiesList_All()
        {
            universities_all = new List<University>();
            universities_all.Clear();
            for (int i = 0; i < FullUniversityList.Count; i++)
            {
                universities_all.Add(FullUniversityList[i]);
            }
            return universities_all;
        }

        public async Task<IEnumerable<University>> GetUniversities_All(bool forceRefresh = true)
        {
            return await Task.FromResult(universities_all);
        }

        public List<University> FillUniversitiesList_Home()
        {
            universities_home = new List<University>();
            universities_home.Clear();
            for (int i = 0; i < FullUniversityList.Count; i++)
            {
                if(FullUniversityList[i].UniversityCountry == App.applicationData.PreferredCountry)
                {
                    universities_home.Add(FullUniversityList[i]);
                }
            }
            return universities_home;
        }

        public async Task<IEnumerable<University>> GetUniversities_Home(bool forceRefresh = true)
        {
            return await Task.FromResult(universities_home);
        }

        public async Task<bool> RemoveFavourite(University university)
        {
            var universityToRemove = App.applicationData.FavouritedUniversities.Where(f => f.UniversityName == university.UniversityName).FirstOrDefault();
            if (universityToRemove != null)
            {
                App.applicationData.FavouritedUniversities.Add(university);
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

        public async Task<University> GetUniversity(string name, string country)
        {
            var client = new RestClient("http://universities.hipolabs.com/search?name=" + name + "&country=" + country)
            {
                Timeout = -1
            };
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            List<ApiResponse> apiResponse = JsonConvert.DeserializeObject<List<ApiResponse>>(response.Content);
            University university = new University
            {
                UniversityName = apiResponse[0].name,
                UniversityCountry = apiResponse[0].country,
                UniversityArea = apiResponse[0].stateprovince,
                UniversityWebsite = apiResponse[0].web_pages[0]
            };
            return await Task.FromResult(university);
        }
    }
}
