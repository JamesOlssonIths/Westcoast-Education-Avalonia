using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Westcoast_Education_Avalonia.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Westcoast_Education_Avalonia.ViewModels;
using Westcoast_Education_Avalonia.Views;

namespace Westcoast_Education_Avalonia;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var collection = new ServiceCollection();
        collection.AddServices();

        var serviceProvider = collection.BuildServiceProvider();
        var vm = serviceProvider.GetRequiredService<MainViewModel>();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                // Connects our ViewModel to our View
                DataContext = vm
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}