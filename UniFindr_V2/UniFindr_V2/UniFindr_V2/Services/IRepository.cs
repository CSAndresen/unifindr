using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UniFindr_V2.Services
{
    public interface IRepository<T>
    {
        // API
        Task<bool> RefreshApiCall();
        // Universities
        Task<IEnumerable<T>> GetUniversities_All(bool forceRefresh = false);
        Task<IEnumerable<T>> GetUniversities_Abroad(bool forceRefresh = false);
        Task<IEnumerable<T>> GetUniversities_Home(bool forceRefresh = false);


        // University Detail
        Task<T> GetUniversity(string name, string country);

        // Favourites
        Task<bool> AddFavourite(T university);
        Task<bool> RemoveFavourite(T university);
    }
}
