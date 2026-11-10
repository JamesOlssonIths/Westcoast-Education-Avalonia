using System;
using Westcoast_Education_Avalonia.Enums;
using Westcoast_Education_Avalonia.Interfaces;
using Westcoast_Education_Avalonia.ViewModels;

namespace Westcoast_Education_Avalonia.Factories;

public class PageViewFactory : IPageViewFactory
{
    private readonly Func<PageViewsEnum, string, ViewModelBase> _pageFactoryWithId;
    private readonly Func<PageViewsEnum, ViewModelBase> _pageFactory;

    public PageViewFactory(Func<PageViewsEnum, ViewModelBase> pageFactory)
    {
        _pageFactory = pageFactory;
    }

    public ViewModelBase LoadPageViewModel(PageViewsEnum page)
    {
        return _pageFactory.Invoke(page);
    }

    public PageViewFactory(Func<PageViewsEnum, ViewModelBase> pageFactory,Func<PageViewsEnum, string, ViewModelBase> pageFactoryWithId)
    {
        _pageFactory = pageFactory;
        _pageFactoryWithId = pageFactoryWithId;
    }
    public ViewModelBase LoadPageViewModel(PageViewsEnum page, string id)
    {
        return _pageFactoryWithId.Invoke(page, id);
    }
}