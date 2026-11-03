using System.Collections.Generic;
using Westcoast_Education_Avalonia.Models;

namespace Westcoast_Education_Avalonia.Interfaces;

public interface IStudentService
{
    List<Student> GetAll();
    void Add(Student student);
}