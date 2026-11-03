using System.Collections.Generic;
using Westcoast_Education_Avalonia.Models;

namespace Westcoast_Education_Avalonia.Services;

public sealed class CourseService : ICourseService
{
    private readonly JsonStorage<Course> _storage = new("Courses.json");
    public List<Course> GetAll() => _storage.Read();
    public void Add(Course course) => _storage.Add(course);
}
