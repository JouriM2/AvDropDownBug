using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;
using Avalonia.Themes.Fluent;
using Avalonia.Themes.Simple;
using avDDBug.ViewModels;
using avDDBug.Views;

namespace avDDBug;

public partial class App : Application {
    public override void Initialize() {
        AvaloniaXamlLoader.Load( this );
    }
    public override void OnFrameworkInitializationCompleted() {
        if( ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop ) {
            BindingPlugins.DataValidators.RemoveAt( 0 );
            desktop.MainWindow = new MainWindow {
                DataContext = new MainWindowViewModel(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}