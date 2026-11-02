using Westcoast_Education_Avalonia.Enums;
using Westcoast_Education_Avalonia.ViewModels;

namespace Westcoast_Education_Avalonia.Interfaces;

public interface IPageViewFactory
{
    ViewModelBase LoadPageViewModel(PageViewsEnum page);
}