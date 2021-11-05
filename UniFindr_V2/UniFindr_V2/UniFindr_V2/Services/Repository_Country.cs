using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniFindr_V2.Models;

namespace UniFindr_V2.Services
{
    public class Repository_Country : IRepository_Country<Country>
    {
        readonly List<Country> Countries;

        public Repository_Country()
        {
            Countries = FillCountriesList();
        }

        public List<Country> FillCountriesList()
        {
            var client = new RestClient("http://universities.hipolabs.com/search");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            List<ApiResponse> responseContent = JsonConvert.DeserializeObject<List<ApiResponse>>(response.Content);
            List<Country> countries = new List<Country>();
            for (int i = 0; i < responseContent.Count; i++)
            {
                if (!countries.Any(c => c.CountryName == responseContent[i].country))
                {
                    countries.Add(new Country
                    {
                        CountryName = responseContent[i].country
                    });
                }
            }
            return countries;
        }

        public async Task<IEnumerable<Country>> GetCountries(bool forceRefresh = false)
        {
            return await Task.FromResult(Countries);
        }
    }
}
