using System.Collections.Generic;
using System.Threading.Tasks;
using Westcoast_Education_Avalonia.Models;

namespace Westcoast_Education_Avalonia.Interfaces;

public interface IStudentService
{
    Task Add(Student student);
    Task<List<Student>> List();
}