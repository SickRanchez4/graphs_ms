using graphs_ms.Interfaces;
using graphs_ms.Models;
using Microsoft.AspNetCore.Mvc;

namespace graphs_ms.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IReportServices _reportService;

        public ReportController(IReportServices reportService)
        {
            _reportService = reportService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> GetAllCities()
        {
            var cities = await _reportService.GetCitiesAsync();
            return Ok(cities);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<City>> GetCityById(int id)
        {
            var cities = await _reportService.GetCityByIdAsync(id);
            if (cities == null)
            {
                return NotFound();
            }
            return Ok(cities);
        }
    }
}
