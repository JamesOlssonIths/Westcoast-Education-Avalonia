using System;
using System.Collections.Generic;

namespace Westcoast_Educatio_Avalonia.interfaces;

public interface IStorage<T>
{
    List<T> Read(string path);
    void Write(string path, List<T> data);
    void Add(string path, T item);

}
