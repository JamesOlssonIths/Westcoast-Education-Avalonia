using System;
using System.Collections.Generic;

namespace Westcoast_Education_Avalonia.Interfaces;

public interface IStorage<T>
{
    List<T> Read(string path);
    void Write(string path, List<T> data);
    void Add(string path, T item);

}
