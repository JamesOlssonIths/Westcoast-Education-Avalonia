using Westcoast_Education_Avalonia.Factories;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Westcoast_Education_Avalonia.Enums;
using Westcoast_Education_Avalonia.Interfaces;

namespace Westcoast_Education_Avalonia.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private readonly IPageViewFactory? _pageViewFactory;

    [ObservableProperty]
    public partial ViewModelBase? CurrentView { get; set; }

    public MainViewModel() { }

    public MainViewModel(IPageViewFactory pageViewFactory)
    {
        _pageViewFactory = pageViewFactory;
        GoToHome();
    }

    [RelayCommand]
    private void GoToHome() => CurrentView = _pageViewFactory!.LoadPageViewModel(PageViewsEnum.Home);

    [RelayCommand]
    private void GoToCourses() => CurrentView = _pageViewFactory!.LoadPageViewModel(PageViewsEnum.Courses);

    [RelayCommand]
    private void GoToStudents() => CurrentView = _pageViewFactory!.LoadPageViewModel(PageViewsEnum.Students);

    [RelayCommand]
    private void GoToAddStudent() => CurrentView = _pageViewFactory!.LoadPageViewModel(PageViewsEnum.AddStudent);

    [RelayCommand]
    private void GoToAddCourse() => CurrentView = _pageViewFactory!.LoadPageViewModel(PageViewsEnum.AddCourse);

    [RelayCommand] private void GoToEditCourse(string courseNumber) => CurrentView = _pageViewFactory!.LoadPageViewModel(PageViewsEnum.EditCourse,courseNumber);


}
