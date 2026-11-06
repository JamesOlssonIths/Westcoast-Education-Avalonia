using System;
using System.Collections.Generic;
using Westcoast_Education_Avalonia.Interfaces;
using Westcoast_Education_Avalonia.Models;

namespace Westcoast_Education_Avalonia.Services;

public class CourseServices : ICourseService
{
    private readonly IStorage<Course> _storage;

    private readonly string _path = Environment.CurrentDirectory + "/Data/course.json";

    public CourseServices(IStorage<Course> storage)
    {
        _storage = storage;
    }

    public List<Course> GetAll()
    {
        return _storage.Read(_path);
    }

    public void Add(Course course)
    {
        var students = _storage.Read(_path);
        students.Add(course);
        _storage.Write(_path, students);
    }
}
