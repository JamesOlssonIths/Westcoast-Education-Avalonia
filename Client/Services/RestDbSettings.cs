using System;
using System.IO;
using System.Text.Json;

namespace Westcoast_Education_Avalonia.Services;

public class RestDbSettings
{
    public string BaseUrl { get; set; } = "";
    public string ApiKey { get; set; } = "";

    private class SettingsFile
    {
        public RestDbSettings? RestDb { get; set; }
    }

    public static RestDbSettings Load(string fileName = "appsettings.json")
    {
        var path = Path.Combine(AppContext.BaseDirectory, fileName);

        if (!File.Exists(path))
        {
            throw new FileNotFoundException("Did not find appsetting.json", path);
        }

        var file = JsonSerializer.Deserialize<SettingsFile>(File.ReadAllText(path), new JsonSerializerOptions{PropertyNameCaseInsensitive = true});

        var settings = file?.RestDb;

        if (settings == null || string.IsNullOrWhiteSpace(settings.BaseUrl) || string.IsNullOrWhiteSpace(settings.ApiKey))
        {
            throw new InvalidOperationException("Missing baseURl and APikey");
        }

        return settings;
    }
}