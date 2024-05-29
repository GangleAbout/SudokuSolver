using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SudokuSolver.Models;
using SudokuSolver.ViewModels.Pages;


namespace SudokuSolver.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    /// <summary>
    ///     List of ListItemTemplates to be displayed
    /// </summary>
    private static readonly List<PaneListItem> ItemTemplates =
    [
        new PaneListItem(typeof(HomeViewModel), "HomeRegular"),
        new PaneListItem(typeof(ManualInputViewModel), "TableRegular"),
        new PaneListItem(typeof(AutomaticInputViewModel), "CameraRegular"),
        new PaneListItem(typeof(AboutViewModel), "InfoRegular")
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
    ///     Selected ListItem index in ListBox
    /// </summary>
    [ObservableProperty] private int _selectedItemIndex;

    /// <summary>
    ///     Selected ListItem in ListBox
    /// </summary>
    [ObservableProperty] private PaneListItem? _selectedListItem;

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

    /// <summary>
    ///     ObservableCollection of ListBox items
    /// </summary>
    public ObservableCollection<PaneListItem> Items { get; } = new(ItemTemplates);

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
    partial void OnSelectedListItemChanged(PaneListItem? value)
    {
        if (value is null) return;

        var instance = Activator.CreateInstance(value.ViewModelType);

        if (instance is null) return;

        CurrentPage = (ViewModelBase)instance;
    }
}