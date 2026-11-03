namespace WestCoast_Education;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using Westcoast_Educatio_Avalonia.interfaces;

public class JsonStorageServices<T> : IStorage<T>
{
    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        PropertyNameCaseInsensitive = true,
        WriteIndented = true,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    };
    public List<T> Read(string path)
    {  
        try
        {
            if (!File.Exists(path)) return [];
            var StoredTxt = File.ReadAllText(path);
            if (!string.IsNullOrEmpty(StoredTxt))
            {
            return JsonSerializer.Deserialize<List<T>>(StoredTxt, _options)!;
            }
            return [];
        }   
        catch (System.Exception)
        {    
            throw;
        }
          
    }
    public void Write(string path, List<T> data)
    {   
       try
       {
            string json = JsonSerializer.Serialize(data);
            File.WriteAllText(path, json);
       }
       catch (System.Exception)
       {
            throw;
       }
    }
    public void Add(string path, T item)
    {
        var list = Read(path);
        list.Add(item);
        Write(path, list);
    }


}

