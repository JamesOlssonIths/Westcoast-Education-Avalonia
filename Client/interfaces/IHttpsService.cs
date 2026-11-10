using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Westcoast_Education_Avalonia.interfaces;

public interface IHttpService<T> where T : class
{
    Task Delete(string resource, string id);
    Task<List<T>> Get(string resource);
    Task<T> Get(string resource, string predicate);
    Task Post(string resource, T data);
    Task Put(string resource, T data, string objectId);
}