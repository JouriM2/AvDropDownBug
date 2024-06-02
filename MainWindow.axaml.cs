using Avalonia.Controls;
using avDDBug.ViewModels;

namespace avDDBug.Views;

public partial class MainWindow : Window {
    public MainWindow() {
        DataContext = new MainWindowViewModel();
        InitializeComponent();
    }
}
