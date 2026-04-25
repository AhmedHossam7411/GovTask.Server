using GovTaskManagement.Application.Dtos;
using GovTaskManagement.Application.Interfaces.ServiceInterfaces;
using System.Text;
using System.Text.Json;

public class MLService : IMLService
{
    private readonly HttpClient _httpClient;

    public MLService(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    public async Task<MlPredictionResponseDto> PredictAsync(object data)
    {
        var request = new
        {
            data = new[] { data }
        };

        var json = JsonSerializer.Serialize(request);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("http://localhost:8000/predict", content);

        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<MlPredictionResponseDto>(
            responseContent,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
        );
    }
}