using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WestCoast_Education;
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



    public AddCourseViewModel()
    {
        _courseServices = new CourseServices(new JsonStorageServices<Course>());
        PageTitle="Add course";
    }
    
    [RelayCommand]
    private void Save()
    {
        Course course = new(CourseNumber = CourseNumber,
            Title = Title,
            Remote = Remote);
      

        _courseServices.Add(course);
        ClearData();
    }

    private void ClearData()
    {
        CourseNumber = string.Empty;
        Title = string.Empty;
        Remote = true;
    }

    
}