using CommunityToolkit.Mvvm.ComponentModel;

namespace Westcoast_Education_Avalonia.ViewModels;

public partial class HomeViewModel : ViewModelBase
{
    [ObservableProperty]
    public partial string Welcome { get; set; } = "Welcome to Westcoast Education";
}