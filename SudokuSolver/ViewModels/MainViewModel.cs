using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SudokuSolver.Templates;
using SudokuSolver.ViewModels.Pages;

namespace SudokuSolver.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    /// <summary>
    ///     List of ListItemTemplates to be displayed
    /// </summary>
    private static readonly List<ListItemTemplate> ItemTemplates =
    [
        new ListItemTemplate(typeof(HomeViewModel), "HomeRegular"),
        new ListItemTemplate(typeof(ManualInputViewModel), "TableRegular"),
        new ListItemTemplate(typeof(AutomaticInputViewModel), "CameraRegular"),
        new ListItemTemplate(typeof(AboutViewModel), "InfoRegular")
    ];

    /// <summary>
    ///     Currently displayed page
    /// </summary>
    [ObservableProperty] private ViewModelBase _currentPage = new HomeViewModel();

    /// <summary>
    ///     SplitView pane open/closed flag
    /// </summary>
    [ObservableProperty] private bool _isPaneOpen;

    /// <summary>
    ///     Selected ListItem in ListBox
    /// </summary>
    [ObservableProperty] private ListItemTemplate? _selectedListItem;

    /// <summary>
    ///     MainWindow height
    /// </summary>
    [ObservableProperty] private int _widowHeight = 700;

    /// <summary>
    ///     MainWidow width
    /// </summary>
    [ObservableProperty] private int _widowWidth = 800;

    /// <summary>
    ///     MainWindow title
    /// </summary>
    [ObservableProperty] private string _windowTitle = "Sudoku Solver";

    public ObservableCollection<ListItemTemplate> Items { get; } = new(ItemTemplates);

    /// <summary>
    ///     Toggle SplitView pane open or closed
    /// </summary>
    [RelayCommand]
    private void TogglePane()
    {
        IsPaneOpen = !IsPaneOpen;
    }

    /// <summary>
    ///     On ObservableCollection change event
    /// </summary>
    /// <param name="value"></param>
    partial void OnSelectedListItemChanged(ListItemTemplate? value)
    {
        if (value is null) return;

        var instance = Activator.CreateInstance(value.ViewModelType);

        if (instance is null) return;

        CurrentPage = (ViewModelBase)instance;
    }
}