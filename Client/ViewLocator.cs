using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Westcoast_Education_Avalonia.ViewModels;

namespace Westcoast_Education_Avalonia;

public class ViewLocator : IDataTemplate
{
    public Control? Build(object? data)
    {
        if (data is null) return null;

        var viewName = data.GetType().FullName!
            .Replace("ViewModel", "View", StringComparison.InvariantCulture);
        var view = Type.GetType(viewName);

        if (view is null) return null;

        var control = (Control)Activator.CreateInstance(view)!;
        control.DataContext = data;

        return control;
    }

    public bool Match(object? data) => data is ViewModelBase;
}