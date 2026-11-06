using System;
using System.Collections.Generic;
using Westcoast_Education_Avalonia.Interfaces;
using Westcoast_Education_Avalonia.Models;

namespace Westcoast_Education_Avalonia.Services;

public class StudentServices : IStudentService
{
    private readonly IStorage<Student> _storage;
    private readonly string _path =
        Environment.CurrentDirectory + "/Data/students.json";

    public StudentServices(IStorage<Student> storage)
    {
        _storage = storage;
    }

    public List<Student> GetAll()
    {
        return _storage.Read(_path);
    }

    public void Add(Student student)
    {
        var students = _storage.Read(_path);
        students.Add(student);
        _storage.Write(_path, students);
    }
}