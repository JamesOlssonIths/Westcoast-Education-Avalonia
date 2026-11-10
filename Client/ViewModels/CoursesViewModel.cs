using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Westcoast_Education_Avalonia.Models;
using Westcoast_Education_Avalonia.Services;

namespace Westcoast_Education_Avalonia.ViewModels;

public partial class CoursesViewModel : ViewModelBase
{
    public ObservableCollection<Course> Courses { get; } =[];

    [ObservableProperty]
    public partial Course? SelectedCourse { get; set; }

    public CoursesViewModel(ICourseService courseService)
    {
        foreach (var item in courseService.GetAll())
        {
            Courses.Add(item);
       
        }
    }
}