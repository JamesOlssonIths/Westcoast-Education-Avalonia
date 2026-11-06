using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WestCoast_Education;
using Westcoast_Education_Avalonia.Interfaces;
using Westcoast_Education_Avalonia.Models;
using Westcoast_Education_Avalonia.Services;

namespace Westcoast_Education_Avalonia.ViewModels;

public partial class AddStudentViewModel : ViewModelBase
{
    private readonly IStudentService _studentService;

    [ObservableProperty]
    public partial string FirstName { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string LastName { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string PhoneNumber { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string SocialSecurityNumber { get; set; } = string.Empty;

    public AddStudentViewModel()
    {
        _studentService = new StudentServices(new JsonStorageServices<Student>());
        PageTitle = "Add student";
    }

    public AddStudentViewModel(IStudentService studentService)
    {
        _studentService = studentService;
        PageTitle = "Add student";
    }

    [RelayCommand]
    private void Save()
    {
        Student student = new()
        {
            FirstName = FirstName,
            LastName = LastName,
            PhoneNumber = PhoneNumber,
            SocialSecurityNumber = SocialSecurityNumber
        };

        _studentService.Add(student);
        ClearData();
    }

    private void ClearData()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        PhoneNumber = string.Empty;
        SocialSecurityNumber = string.Empty;
    }
}