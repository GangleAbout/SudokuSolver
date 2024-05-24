using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace SudokuSolver.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    // Main Window Fields
    [ObservableProperty] private string _windowTitle = "Sudoku Solver";
    [ObservableProperty] private int _widowWidth = 800;
    [ObservableProperty] private int _widowHeight = 700;
    
    
    [ObservableProperty] private bool _isPaneOpen;

    [RelayCommand]
    private void TogglePane()
    {
        IsPaneOpen = !IsPaneOpen;
    }
}