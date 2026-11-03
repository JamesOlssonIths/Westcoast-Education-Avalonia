using System.Collections.Generic;
using Westcoast_Education_Avalonia.Models;

namespace Westcoast_Education_Avalonia.Services;

public interface ICourseService
{
    List<Course> GetAll();
    void Add(Course course);
}
