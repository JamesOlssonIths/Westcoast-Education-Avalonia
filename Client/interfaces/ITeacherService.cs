using System.Collections.Generic;
using System.Threading.Tasks;
using Westcoast_Education_Avalonia.Models;

namespace Westcoast_Education_Avalonia.Interfaces;

public interface ITeacherService
{
    Task Add(Teacher teacher);
    Task Delete(string id);
    Task<TeacherRestDb> Find(string socialSecurityNumber);
    Task<List<Teacher>> List();
    Task Update(Teacher teacher, string id);
}