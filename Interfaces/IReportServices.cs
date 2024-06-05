using graphs_ms.Models;

namespace graphs_ms.Interfaces
{
    public interface IReportServices
    {
        public Task<IEnumerable<City>> GetCitiesAsync();

        public Task<City> GetCityByIdAsync(int id);
    }
}
