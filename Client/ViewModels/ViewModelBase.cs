using CommunityToolkit.Mvvm.ComponentModel;

namespace Westcoast_Education_Avalonia.ViewModels;

public partial class ViewModelBase : ObservableObject
{
     [ObservableProperty]
    public partial string PageTitle { get; set; } = "";
}
