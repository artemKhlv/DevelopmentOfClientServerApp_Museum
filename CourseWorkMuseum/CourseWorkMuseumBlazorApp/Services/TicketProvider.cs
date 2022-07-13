using System.Net.Http.Json;
using Newtonsoft.Json;
using CourseWorkMuseumBlazorApp.Data.Models;

namespace CourseWorkMuseumBlazorApp.Services;

public class TicketProvider : ITicketProvider
{
    private HttpClient _client;
    public TicketProvider(HttpClient client)
    {
        _client = client;
    }
    
    public async Task<List<Ticket>> GetAll()
    {
        return await _client.GetFromJsonAsync<List<Ticket>>("/api/ticket");
    }

    public async Task<Ticket> GetOne(int id)
    {
        return await _client.GetFromJsonAsync<Ticket>($"/api/ticket/{id}");
    }

    public async Task<bool> Add(Ticket item)
    {
        string data = JsonConvert.SerializeObject(item);
        StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
        var responce = await _client.PostAsync($"/api/ticket", httpContent);
        return await Task.FromResult(responce.IsSuccessStatusCode);
    }

    public async Task<Ticket> Edit(Ticket item)
    {
        string data = JsonConvert.SerializeObject(item);
        StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
        var responce = await _client.PutAsync($"/api/ticket", httpContent);
        Ticket ticket = JsonConvert.DeserializeObject<Ticket>(responce.Content.ReadAsStringAsync().Result);
        return await Task.FromResult(ticket);
    }

    public async Task<bool> Remove(int id)
    {
        var delete = await _client.DeleteAsync($"/api/ticket/${id}");

        return await Task.FromResult(delete.IsSuccessStatusCode);
    }
}