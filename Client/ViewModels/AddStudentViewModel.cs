using System;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using Westcoast_Education_Avalonia.Models;

namespace Westcoast_Education_Avalonia.ViewModels;

public partial class AddStudentViewModel : ViewModelBase
{
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
        PageTitle = "Add student";
    }

}
