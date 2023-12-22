using AntDesign.TableModels;
using AntDesign;
using System.ComponentModel;
using System.Text.Json;

namespace AntTestBlazor.Client.Pages;

public sealed partial class Weather
{
    private WeatherForecast[] _forecasts;
    private IEnumerable<WeatherForecast> _selectedRows;
    private ITable _table;
    private int _pageIndex = 1;
    private int _pageSize = 10;
    private int _total = 0;
    private readonly Random _random = new ();

    protected override async Task OnInitializedAsync()
    {
        await Task.Delay(1);
        _forecasts = await GetForecastAsync(1, 50);
        _total = 50;
    }

    private static readonly string[] _summaries = ["Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"];

    public async Task OnChange(QueryModel<WeatherForecast> queryModel)
    {
        await Task.Delay(1);
        Console.WriteLine(JsonSerializer.Serialize(queryModel));
    }

    public Task<WeatherForecast[]> GetForecastAsync(int pageIndex, int pageSize)
    {
        return Task.FromResult(Enumerable.Range((pageIndex - 1) * pageSize + 1, pageSize).Select(index =>
        {
            int temperatureC = _random.Next(-20, 55);
            return new WeatherForecast
            {
                Id = index,
                Date = DateTime.Now.AddDays(index),
                TemperatureC = temperatureC,
                Summary = _summaries[_random.Next(_summaries.Length)],
                Hot = temperatureC > 30,
            };
        }).ToArray());
    }

    public void RemoveSelection(int id)
    {
        IEnumerable<WeatherForecast> selected = _selectedRows.Where(x => x.Id != id);
        _selectedRows = selected;
    }

    private void Delete(int id)
    {
        _forecasts = _forecasts.Where(x => x.Id != id).ToArray();
        _total = _forecasts.Length;
    }

    public class WeatherForecast
    {
        public int Id { get; set; }

        [DisplayName("Date")]
        public DateTime? Date { get; set; }

        [DisplayName("ºC")]
        public int TemperatureC { get; set; }

        [DisplayName("Summary")]
        public string Summary { get; set; }

        public bool Hot { get; set; }
    }
}