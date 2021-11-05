using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UniFindr_V2.Services
{
    public interface IRepository<T>
    {
        // Universities
        Task<IEnumerable<T>> GetUniversities_All();
        Task<IEnumerable<T>> GetUniversities_Abroad();
        Task<IEnumerable<T>> GetUniversities_Home();

        // Favourites
        Task<IEnumerable<University>> GetFavourites();
        Task<bool> AddFavourite(T university);
        Task<bool> RemoveFavourite(T university);
    }
}
