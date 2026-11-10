using System.Collections.Generic;
using System.Threading.Tasks;
using Westcoast_Education_Avalonia.Interfaces;
using Westcoast_Education_Avalonia.Models;

namespace Westcoast_Education_Avalonia.Services;

public class CourseServices : ICourseService
{
    public async Task Add(Course course)
    {
        var httpService = new HttpService<Course>();
        await httpService.Post("courses", course);
    }

    public async Task Delete(string id)
    {
        var httpService = new HttpService<Course>();
        await httpService.Delete("courses", id);
    }

    public async Task<CourseRestDb> Find(string courseNumber)
    {
        var httpService = new HttpService<CourseRestDb>();
        var searchCriteria =
            "{\"courseNumber\":"+ "\"" + courseNumber +"\"}";

        return await httpService.Get("courses", searchCriteria);
    }

    public async Task<List<Course>> List()
    {
        var httpService = new HttpService<Course>();
        return await httpService.Get("courses");
    }
}