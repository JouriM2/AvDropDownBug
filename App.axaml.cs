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
    public enum CatalogTheme {
        Fluent,
        Simple
    }
    private readonly Styles _themeStylesContainer = new();
    private FluentTheme? _fluentTheme;
    private SimpleTheme? _simpleTheme;
    public override void Initialize() {
        Styles.Add( _themeStylesContainer );

        AvaloniaXamlLoader.Load( this );

        _fluentTheme = new FluentTheme();
        _simpleTheme = new SimpleTheme();

        SetCatalogThemes( CatalogTheme.Fluent );
    }

    public override void OnFrameworkInitializationCompleted() {
        if( ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop ) {
            BindingPlugins.DataValidators.RemoveAt( 0 );
            desktop.MainWindow = new MainWindow();
        }

        base.OnFrameworkInitializationCompleted();
    }

    private CatalogTheme _prevTheme;
    public static CatalogTheme CurrentTheme => ( (App)Current! )._prevTheme;

    public static void SetCatalogThemes( CatalogTheme theme ) {
        var app = (App)Current!;
        var prevTheme = app._prevTheme;
        app._prevTheme = theme;
        var shouldReopenWindow = prevTheme != theme;

        if( app._themeStylesContainer.Count == 0 ) {
            app._themeStylesContainer.Add( new Style() );
        }

        if( theme == CatalogTheme.Fluent ) {
            app._themeStylesContainer[ 0 ] = app._fluentTheme!;
        } else if( theme == CatalogTheme.Simple ) {
            app._themeStylesContainer[ 0 ] = app._simpleTheme!;
        }

        if( shouldReopenWindow ) {
            if( app.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktopLifetime ) {
                var oldWindow = desktopLifetime.MainWindow;
                var newWindow = new MainWindow();

                if ( oldWindow is not null ) 
                    newWindow.Position = oldWindow.Position;

                desktopLifetime.MainWindow = newWindow;
                newWindow.Show();
                oldWindow?.Close();
            }
        }
    }
}