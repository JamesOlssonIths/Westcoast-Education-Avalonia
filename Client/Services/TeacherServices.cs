using System.Collections.Generic;
using System.Threading.Tasks;
using Westcoast_Education_Avalonia.Interfaces;
using Westcoast_Education_Avalonia.Models;

namespace Westcoast_Education_Avalonia.Services;

public class TeacherServices : ITeacherService
{
    public async Task Add(Teacher teacher)
    {
        var httpService = new HttpService<Teacher>();
        await httpService.Post("teachers", teacher);
    }

    public async Task Delete(string id)
    {
        var httpService = new HttpService<Teacher>();
        await httpService.Delete("teachers", id);
    }

    public async Task<TeacherRestDb> Find(string socialSecurityNumber)
    {
        var httpService = new HttpService<TeacherRestDb>();
        var searchCriteria =
            "{\"socialSecurityNumber\":\"" + socialSecurityNumber + "\"}";

        return await httpService.Get("teachers", searchCriteria);
    }

    public async Task<List<Teacher>> List()
    {
        var httpService = new HttpService<Teacher>();
        return await httpService.Get("teachers");
    }

    public async Task Update(Teacher teacher, string id)
    {
        var httpService = new HttpService<Teacher>();
        await httpService.Put("teachers", teacher, id);
    }
}