using System.Net.Http.Json;
using Newtonsoft.Json;
using CourseWorkMuseumBlazorApp.Data.Models;

namespace CourseWorkMuseumBlazorApp.Services;

public class ExhibitionProvider : IExhibitionProvider
{
    private HttpClient _client;
    public ExhibitionProvider(HttpClient client)
    {
        _client = client;
    }
    
    public async Task<List<Exhibition>> GetAll()
    {
        return await _client.GetFromJsonAsync<List<Exhibition>>("/api/exhibition");
    }

    public async Task<Exhibition> GetOne(int id)
    {
        return await _client.GetFromJsonAsync<Exhibition>($"/api/exhibition/{id}");
    }

    public async Task<bool> Add(Exhibition item)
    {
        string data = JsonConvert.SerializeObject(item);
        StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
        var responce = await _client.PostAsync($"/api/exhibition", httpContent);
        return await Task.FromResult(responce.IsSuccessStatusCode);
    }

    public async Task<Exhibition> Edit(Exhibition item)
    {
        string data = JsonConvert.SerializeObject(item);
        StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
        var responce = await _client.PutAsync($"/api/exhibition", httpContent);
        Exhibition exhibition = JsonConvert.DeserializeObject<Exhibition>(responce.Content.ReadAsStringAsync().Result);
        return await Task.FromResult(exhibition);
    }

    public async Task<bool> Remove(int id)
    {
        var delete = await _client.DeleteAsync($"/api/exhibition/${id}"); return await Task.FromResult(delete.IsSuccessStatusCode);
    }
}
