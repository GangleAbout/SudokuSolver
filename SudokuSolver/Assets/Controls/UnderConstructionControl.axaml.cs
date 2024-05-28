using Avalonia;
using Avalonia.Controls.Primitives;

namespace SudokuSolver.Assets.Controls;

public class UnderConstructionControl : TemplatedControl
{
    public static readonly StyledProperty<string> PageNameProperty =
        AvaloniaProperty.Register<UnderConstructionControl, string>(
            nameof(PageName));

    public string PageName
    {
        get => GetValue(PageNameProperty);
        set => SetValue(PageNameProperty, value);
    }
}