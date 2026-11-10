using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Westcoast_Education_Avalonia.Interfaces;
using Westcoast_Education_Avalonia.Models;

namespace Westcoast_Education_Avalonia.ViewModels;

public partial class TeachersViewModel : ViewModelBase
{
    private readonly ITeacherService _teacherService;

    public ObservableCollection<Teacher> Teachers { get; } = [];

    [ObservableProperty]
    public partial Teacher? SelectedTeacher { get; set; }

    public TeachersViewModel(ITeacherService teacherService)
    {
        _teacherService = teacherService;
        Init();
    }

    private async void Init()
    {
        await LoadTeachers();
    }

    private async Task LoadTeachers()
    {
        try
        {
            var teachers = await _teacherService.List();

            Teachers.Clear();
            foreach (var teacher in teachers)
            {
                Teachers.Add(teacher);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    [RelayCommand]
    private async Task DeleteTeacher(string socialSecurityNumber)
    {
        var teacher = await _teacherService.Find(socialSecurityNumber);

        await _teacherService.Delete(teacher._id);

        await LoadTeachers();
    }
    
}