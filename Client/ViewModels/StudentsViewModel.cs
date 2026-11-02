using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Westcoast_Education_Avalonia.Models;

namespace Westcoast_Education_Avalonia.ViewModels;

public partial class StudentsViewModel : ViewModelBase
{
    public ObservableCollection<Student> Students { get; } =
    [
        new("Erik Johansson", "erik@example.com", "C# Fundamentals"),
        new("Sara Nilsson", "sara@example.com", "Web Development"),
        new("Omar Hassan", "omar@example.com", "Databases"),
    ];

    [ObservableProperty]
    public partial Student? SelectedStudent { get; set; }
}