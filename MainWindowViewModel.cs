using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;

namespace avDDBug.ViewModels;

public partial class MainWindowViewModel : ObservableValidator, INotifyPropertyChanged {
    public MainWindowViewModel() {
    }
}
