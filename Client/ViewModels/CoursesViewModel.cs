using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Westcoast_Education_Avalonia.Models;

namespace Westcoast_Education_Avalonia.ViewModels;

public partial class CoursesViewModel : ViewModelBase
{
    public ObservableCollection<Course> Courses { get; } =
    [
        new("C# Fundamentals", "Anna Berg", 8),
        new("Web Development", "Karl Svensson", 12),
        new("Databases", "Maria Lind", 6),
    ];

    [ObservableProperty]
    public partial Course? SelectedCourse { get; set; }
}