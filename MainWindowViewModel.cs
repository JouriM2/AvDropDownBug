using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;

namespace avDDBug.ViewModels;

public record TableDisplayInfo {
    public string Description { get; set; }
    public string TypeName { get; set; }
    public string Count { get; set; }
    public TableDisplayInfo() {
        Count = string.Empty;
        TypeName = "<none>";
        Description = string.Empty;
    }
    public TableDisplayInfo( string tp, string file, int cn ) {
        TypeName = tp;
        Description = file;
        Count = cn.ToString();
    }
}

public partial class MainWindowViewModel : ObservableValidator, INotifyPropertyChanged {
    [ObservableProperty]IList<TableDisplayInfo> list = [];
    [ObservableProperty]int itemIndex;
    [ObservableProperty]TableDisplayInfo? curItem;
    string ThemeName {
        get => $"Theme is \"{App.CurrentTheme}\"";
    }
    bool IsFluentTheme {
        get => App.CurrentTheme == App.CatalogTheme.Fluent;
        set => App.SetCatalogThemes( value ? App.CatalogTheme.Fluent : App.CatalogTheme.Simple );
    }

    public MainWindowViewModel() {
        List = [
            new TableDisplayInfo(),
            new TableDisplayInfo( "tp1", "decs1", 10 ),
            new TableDisplayInfo( "typep2", "decs2", 100 ),
            new TableDisplayInfo( "type point3", "decs3", 1000 ),
            new TableDisplayInfo( "some other long type tp4", "decs4", 10000 ),
            ];
    }

    [RelayCommand]
    private void Change() {
        App.SetCatalogThemes( App.CurrentTheme == App.CatalogTheme.Simple ? App.CatalogTheme.Fluent : App.CatalogTheme.Simple );
    }
}
