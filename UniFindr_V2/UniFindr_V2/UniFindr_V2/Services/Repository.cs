using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniFindr_V2.Services
{
    public class Repository : IRepository<University>
    {
        readonly List<University> favourites;
        public async Task<bool> AddFavourite(University university)
        {
            if(!favourites.Any(f => f.UniversityName == university.UniversityName))
            {
                favourites.Add(university);
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

        public async Task<IEnumerable<University>> GetFavourites()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<University>> GetUniversities_Abroad()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<University>> GetUniversities_All()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<University>> GetUniversities_Home()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveFavourite(University university)
        {
            var universityToRemove = favourites.Where(f => f.UniversityName == university.UniversityName).FirstOrDefault();
            if(universityToRemove != null)
            {
                favourites.Add(university);
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }
    }
}
