using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;

namespace avDDBug.ViewModels;

public partial class MainWindowViewModel : ObservableValidator, INotifyPropertyChanged {
    [ObservableProperty]int itemIndex;
    
    string SimpleStringData = "SimpleStringData";
    string SimpleStringProp {
        get => $"Theme is \"{SimpleStringData}\"";
    }

    public MainWindowViewModel() {
    }

    [RelayCommand]
    private void Change() {
    }
}
