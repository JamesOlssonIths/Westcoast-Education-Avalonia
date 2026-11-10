using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Westcoast_Education_Avalonia.Interfaces;
using Westcoast_Education_Avalonia.Models;

namespace Westcoast_Education_Avalonia.ViewModels;

public partial class StudentsViewModel : ViewModelBase
{
    private readonly IStudentService _studentService;

    public ObservableCollection<Student> Students { get; } = [];

    [ObservableProperty]
    public partial Student? SelectedStudent { get; set; }

    public StudentsViewModel(IStudentService studentService)
    {
        _studentService = studentService;
        Init();
    }

    private async void Init()
    {
        await LoadStudents();
    }

    private async Task LoadStudents()
    {
        try
        {
            var students = await _studentService.List();

            Students.Clear();
            foreach (var student in students)
            {
                Students.Add(student);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}   