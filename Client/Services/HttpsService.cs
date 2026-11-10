using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Westcoast_Education_Avalonia.interfaces;

namespace Westcoast_Education_Avalonia.Services;

public class HttpService<T> : IDisposable, IHttpService<T> where T : class
{
    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        WriteIndented = true
    };

    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;

    public HttpService()
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        _baseUrl = config.GetSection("Settings:BaseUrl").Value!;
        var apiKey = config.GetSection("Settings:ApiKey").Value!;

        _httpClient = new HttpClient
        {
            BaseAddress = new Uri(_baseUrl)
        };

        _httpClient.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
        _httpClient.DefaultRequestHeaders.Add("x-apikey", apiKey);
        _httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task Delete(string resource, string id)
    {
        try
        {
            await _httpClient.DeleteAsync($"{_baseUrl}/{resource}/{id}");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<List<T>> Get(string resource)
    {
        var response = await _httpClient.GetAsync($"{_baseUrl}/{resource}");

        if (!response.IsSuccessStatusCode)
            return [];

        var result = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<List<T>>(result, _options) ?? [];
    }

    public async Task<T> Get(string resource, string predicate)
    {
        try
        {
            var response = await _httpClient.GetAsync(
                $"{_baseUrl}/{resource}?q={predicate}");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrWhiteSpace(result))
                    throw new Exception("Fanns ingenting");

                var data = JsonSerializer.Deserialize<List<T>>(result, _options)!;

                if (data.Count == 0)
                    throw new Exception("Fanns ingenting");

                return data[0];
            }

            throw new Exception("Det gick fel: " + response.StatusCode);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task Post(string resource, T data)
    {
        try
        {
            await _httpClient.PostAsJsonAsync(
                $"{_baseUrl}/{resource}", data, _options);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task Put(string resource, T data, string objectId)
    {
        try
        {
            await _httpClient.PutAsJsonAsync(
                $"{_baseUrl}/{resource}/{objectId}", data, _options);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public void Dispose()
    {
        _httpClient.Dispose();
        GC.SuppressFinalize(this);
    }
}