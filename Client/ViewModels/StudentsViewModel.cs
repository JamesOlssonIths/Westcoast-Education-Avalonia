using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Westcoast_Education_Avalonia.Interfaces;
using Westcoast_Education_Avalonia.Models;

namespace Westcoast_Education_Avalonia.ViewModels;

public partial class StudentsViewModel : ViewModelBase
{
    public ObservableCollection<Student> Students { get; } = [];

    [ObservableProperty]
    public partial Student? SelectedStudent { get; set; }

    public StudentsViewModel(IStudentService studentService)
    {
        foreach (var item in studentService.GetAll())
        {
            Students.Add(item);
        }
    }
}