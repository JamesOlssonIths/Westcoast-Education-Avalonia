using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Westcoast_Education_Avalonia.Interfaces;
using Westcoast_Education_Avalonia.Models;
using Westcoast_Education_Avalonia.Services;

namespace Westcoast_Education_Avalonia.ViewModels;

public partial class EditCourseViewModel : ViewModelBase
{
    private readonly ICourseService _courseService;
    private readonly string _courseNumber = string.Empty;
    private string _objectId = string.Empty;
    private string _courseId = string.Empty;

    [ObservableProperty]
    public partial string CourseNumber { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string Title { get; set; } = string.Empty;

    [ObservableProperty]
    public partial int Duration { get; set; }

    [ObservableProperty]
    public partial string DurationUnit { get; set; } = "veckor";

    [ObservableProperty]
    public partial string StartDate { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string EndDate { get; set; } = string.Empty;

    [ObservableProperty]
    public partial bool Remote { get; set; }

    [ObservableProperty]
    public partial string TeacherName { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string Message { get; set; } = string.Empty;

    public EditCourseViewModel()
    {
        _courseService = new CourseServices();
        PageTitle = "Edit course";
    }

    public EditCourseViewModel(ICourseService courseService, string courseNumber)
    {
        _courseService = courseService;
        _courseNumber = courseNumber;
        PageTitle = $"Edit course: {courseNumber}";
        Init();
    }

    private async void Init()
    {
        await LoadCourse();
    }

    private async Task LoadCourse()
    {
        var course = await _courseService.Find(_courseNumber);

        _objectId = course._id;
        _courseId = course.Id;

        CourseNumber = course.CourseNumber;
        Title = course.Title;
        Duration = course.Duration;
        DurationUnit = course.DurationUnit;
        StartDate = course.StartDate.ToString("yyyy-MM-dd");
        EndDate = course.EndDate.ToString("yyyy-MM-dd");
        Remote = course.Remote;
        TeacherName = course.TeacherName ?? string.Empty;
    }

    [RelayCommand]
    private async Task Save()
    {
        if (!DateTime.TryParse(StartDate, out DateTime start) ||
            !DateTime.TryParse(EndDate, out DateTime end))
        {
            Message = "Enter dates in the format YYYY-MM-DD.";
            return;
        }

        if (end < start)
        {
            Message = "End date cannot be before start date.";
            return;
        }

        Course course = new()
        {
            Id = _courseId,
            CourseNumber = CourseNumber,
            Title = Title,
            Duration = Duration,
            DurationUnit = DurationUnit,
            StartDate = start,
            EndDate = end,
            Remote = Remote,
            TeacherName = TeacherName
        };

        await _courseService.Update(course, _objectId);
    }
}