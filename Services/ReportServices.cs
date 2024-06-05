using graphs_ms.Data;
using graphs_ms.Interfaces;
using graphs_ms.Models;
using Microsoft.EntityFrameworkCore;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot;
using OxyPlot.SkiaSharp;

namespace graphs_ms.Services
{
    public class ReportServices : IReportServices
    {
        private readonly AppDBContext _context;

        public ReportServices(AppDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            // Crear el modelo de gráfico
            var plotModel = new PlotModel { Title = "Gráfico de Barras" };

            // Añadir el eje X
            plotModel.Axes.Add(new CategoryAxis
            {
                Position = AxisPosition.Bottom,
                Key = "CategoryAxis",
                ItemsSource = new[] { "A", "B", "C", "D" }
            });

            // Añadir el eje Y
            plotModel.Axes.Add(new CategoryAxis
            {
                Position = AxisPosition.Left,
                Minimum = 0,
                Key = "ValueAxis"
            });

            // Añadir la serie de barras
            var barSeries = new BarSeries
            {
                ItemsSource = new[]
                {
                new BarItem{ Value = 10 },
                new BarItem{ Value = 20 },
                new BarItem{ Value = 30 },
                new BarItem{ Value = 40 }
            },
                LabelPlacement = LabelPlacement.Inside,
                LabelFormatString = "{0:.00}"
            };
            plotModel.Series.Add(barSeries);

            // Renderizar el gráfico a una imagen
            using (var ms = new MemoryStream())
            {
                var exporter = new PngExporter { Width = 600, Height = 400 };
                exporter.Export(plotModel, ms);

                // Convertir la imagen a base64
                ms.Seek(0, SeekOrigin.Begin);
                string base64Image = Convert.ToBase64String(ms.ToArray());

                // Mostrar la cadena base64
                Console.WriteLine(base64Image);

                ////////////////////////////////
                var cities = await _context.Cities.ToListAsync();
                return cities;
            }
        }

        public async Task<City> GetCityByIdAsync(int id)
        {
            var city = await _context.Cities.FindAsync(id);
            if (city == null)
            {
                return null;
            }

            return city;
        }
    }
}
