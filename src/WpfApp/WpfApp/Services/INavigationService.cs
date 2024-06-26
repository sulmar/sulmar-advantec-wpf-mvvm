using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp.Services;

interface INavigationService
{
    void NavigateTo(string route);
    void RegisterRoute(string route, Type view);
}

class FrameNavigationService : INavigationService
{
    private readonly IDictionary<string, Type> views = new Dictionary<string, Type>();

    public void NavigateTo(string route)
    {
        var frame = Get("frame");

        Type type = views[route];

        var view = App.Current.Services.GetRequiredService(type);

        frame.Navigate(view);
    }

    public void RegisterRoute(string route, Type view)
    {
        views.Add(route, view);
    }

    private Frame Get(string name)
    {
        if (Application.Current.MainWindow.FindName(name) is Frame frame)
            return frame;

        throw new KeyNotFoundException();
    }
}