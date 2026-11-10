using System.Collections.Generic;
using System.Threading.Tasks;
using Westcoast_Education_Avalonia.Models;

namespace Westcoast_Education_Avalonia.Services;

public interface ICourseService
{
    Task Add(Course course);
    Task Delete(string id);
    Task<CourseRestDb> Find(string courseNumber);
    Task<List<Course>> List();
    Task Update(Course course, string id);
}
