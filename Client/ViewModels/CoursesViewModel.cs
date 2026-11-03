using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Westcoast_Education_Avalonia.Models;

namespace Westcoast_Education_Avalonia.ViewModels;

public partial class CoursesViewModel : ViewModelBase
{
    public ObservableCollection<Course> Courses { get; } =
    [
        new("C# Fundamentals", "Anna Berg", false),
        new("Web Development", "Karl Svensson", true),
        new("Databases", "Maria Lind", false),
    ];

    [ObservableProperty]
    public partial Course? SelectedCourse { get; set; }
}