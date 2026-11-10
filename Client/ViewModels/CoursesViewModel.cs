using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Westcoast_Education_Avalonia.interfaces;
using Westcoast_Education_Avalonia.Models;
using Westcoast_Education_Avalonia.Services;

namespace Westcoast_Education_Avalonia.ViewModels;

public partial class CoursesViewModel : ViewModelBase
{
    private readonly ICourseService _courseService;

    public ObservableCollection<Course> Courses { get; } = [];

    [ObservableProperty]
    public partial Course? SelectedCourse { get; set; }

    [ObservableProperty]
    public partial bool ShowDialog { get; set; }

    private string _courseNumber = string.Empty;

    [RelayCommand]
    private void Delete(string courseNumber)
    {
        _courseNumber = courseNumber;
        ShowDialog = true;
    }

    [RelayCommand]
    private async Task Confirm()
    {
        ShowDialog = false;

        try
        {
            CourseRestDb course = await _courseService.Find(_courseNumber);

            if (course is not null)
            {
                await _courseService.Delete(course._id);
                await LoadCourses();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    [RelayCommand]
    private void Cancel()
    {
        ShowDialog = false;
    }

    public CoursesViewModel()
    {
        _courseService = new CourseServices();
        Init();
    }

    private async void Init()
    {
        await LoadCourses();
    }

    private async Task LoadCourses()
    {
        try
        {
            var courses = await _courseService.List();

            Courses.Clear();
            foreach (var course in courses)
            {
                Courses.Add(course);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}