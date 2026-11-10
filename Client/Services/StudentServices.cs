using System.Collections.Generic;
using System.Threading.Tasks;
using Westcoast_Education_Avalonia.Interfaces;
using Westcoast_Education_Avalonia.Models;

namespace Westcoast_Education_Avalonia.Services;

public class StudentServices : IStudentService
{
    public async Task Add(Student student)
    {
        var httpService = new HttpService<Student>();
        await httpService.Post("students", student);
    }

    public async Task<List<Student>> List()
    {
        var httpService = new HttpService<Student>();
        return await httpService.Get("students");
    }
}