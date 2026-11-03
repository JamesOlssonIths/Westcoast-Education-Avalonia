using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Westcoast_Education_Avalonia.Services;

public sealed class JsonStorage<T> where T : class
{
    private static readonly JsonSerializerOptions Options = new()
    {
        PropertyNameCaseInsensitive = true,
        WriteIndented = true,
        Converters = { new JsonStringEnumConverter() }
    };

    private readonly string _path;
    private readonly object _lock = new();

    public JsonStorage(string fileName)
    {
        var dataDirectory = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "WestcoastEducation", "Data");
        Directory.CreateDirectory(dataDirectory);
        _path = Path.Combine(dataDirectory, fileName);
        if (!File.Exists(_path)) File.WriteAllText(_path, "[]");
    }

    public List<T> Read()
    {
        lock (_lock)
        {
            var json = File.ReadAllText(_path);
            return string.IsNullOrWhiteSpace(json) ? [] : JsonSerializer.Deserialize<List<T>>(json, Options) ?? [];
        }
    }

    public void Add(T item)
    {
        lock (_lock)
        {
            var items = Read();
            items.Add(item);
            File.WriteAllText(_path, JsonSerializer.Serialize(items, Options));
        }
    }
}
