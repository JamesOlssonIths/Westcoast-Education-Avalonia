using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Westcoast_Education_Avalonia.Models;
using Westcoast_Education_Avalonia.Services;

namespace Westcoast_Education_Avalonia.ViewModels;

public partial class AddCourseViewModel : ViewModelBase
{
    private readonly ICourseService _courseServices;

    [ObservableProperty]
    public partial string CourseNumber { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string Title { get; set; } = string.Empty;    

    [ObservableProperty]
    public partial bool Remote { get; set; } 

    [ObservableProperty]
    public partial int Duration { get; set; }

    [ObservableProperty]
    public partial string StartDate { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string EndDate { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string TeacherName { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string Message { get; set; } = string.Empty;
        



    public AddCourseViewModel()
    {
        _courseServices = new CourseServices();
        PageTitle = "Add course";
    }
    
   [RelayCommand]
    private async Task Save()
    {
        if (string.IsNullOrWhiteSpace(CourseNumber) ||
            string.IsNullOrWhiteSpace(Title))
        {
            Message = "Course number and title are required";
            return;
        }

        if (!DateTime.TryParse(StartDate, out DateTime start) ||
            !DateTime.TryParse(EndDate, out DateTime end))
        {
            Message = "Enter date in this format YYYY-MM-DD.";
            return;
        }

        if (end < start)
        {
            Message = "Cant end before it starts";
            return;
        }

        Course course = new()
        {
            CourseNumber = CourseNumber,
            Title = Title,
            Duration = Duration,
            StartDate = start,
            EndDate = end,
            Remote = Remote,
            TeacherName = TeacherName
        };

        await _courseServices.Add(course);
        ClearData();
    }

    private void ClearData()
    {
        Message = string.Empty;
        CourseNumber = string.Empty;
        Title = string.Empty;
        Duration = 0;
        StartDate = string.Empty;
        EndDate = string.Empty;
        Remote = false;
        TeacherName = string.Empty;
    }
}