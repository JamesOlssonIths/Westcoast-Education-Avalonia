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



  public AddCourseViewModel()
{
    _courseServices = new CourseServices();
    PageTitle = "Add course";
}
    
    [RelayCommand]
    private async Task Save()
    {
        Course course = new()
        {
            CourseNumber = CourseNumber,
            Title = Title,
            Remote = Remote
        };

        await _courseServices.Add(course);
        ClearData();
    }
    private void ClearData()
    {
        CourseNumber = string.Empty;
        Title = string.Empty;
        Remote = true;
    }

    
}