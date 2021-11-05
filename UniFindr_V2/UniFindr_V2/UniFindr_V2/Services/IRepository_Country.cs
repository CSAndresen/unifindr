using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniFindr_V2.Services
{
    public interface IRepository_Country<T>
    {
        // Countries
        Task<IEnumerable<T>> GetCountries(bool forceRefresh = false);
    }
}
