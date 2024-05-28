using System;
using System.Text.RegularExpressions;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace SudokuSolver.Templates;

public partial class ListItemTemplate
{
    private const string WarningRegularStreamGeometryString =
        "M10.9093922,2.78216375 C11.9491636,2.20625071 13.2471955,2.54089334 13.8850247,3.52240345 L13.9678229,3.66023048 L21.7267791,17.6684928 C21.9115773,18.0021332 22.0085303,18.3772743 22.0085303,18.7586748 C22.0085303,19.9495388 21.0833687,20.9243197 19.9125791,21.003484 L19.7585303,21.0086748 L4.24277801,21.0086748 C3.86146742,21.0086748 3.48641186,20.9117674 3.15282824,20.7270522 C2.11298886,20.1512618 1.7079483,18.8734454 2.20150311,17.8120352 L2.27440063,17.668725 L10.0311968,3.66046274 C10.2357246,3.291099 10.5400526,2.98673515 10.9093922,2.78216375 Z M20.4146132,18.3952808 L12.6556571,4.3870185 C12.4549601,4.02467391 11.9985248,3.89363262 11.6361802,4.09432959 C11.5438453,4.14547244 11.4637001,4.21532637 11.4006367,4.29899869 L11.3434484,4.38709592 L3.58665221,18.3953582 C3.385998,18.7577265 3.51709315,19.2141464 3.87946142,19.4148006 C3.96285732,19.4609794 4.05402922,19.4906942 4.14802472,19.5026655 L4.24277801,19.5086748 L19.7585303,19.5086748 C20.1727439,19.5086748 20.5085303,19.1728883 20.5085303,18.7586748 C20.5085303,18.6633247 20.4903516,18.5691482 20.455275,18.4811011 L20.4146132,18.3952808 L12.6556571,4.3870185 L20.4146132,18.3952808 Z M12.0004478,16.0017852 C12.5519939,16.0017852 12.9991104,16.4489016 12.9991104,17.0004478 C12.9991104,17.5519939 12.5519939,17.9991104 12.0004478,17.9991104 C11.4489016,17.9991104 11.0017852,17.5519939 11.0017852,17.0004478 C11.0017852,16.4489016 11.4489016,16.0017852 12.0004478,16.0017852 Z M11.9962476,8.49954934 C12.3759432,8.49924613 12.689964,8.78114897 12.7399193,9.14718469 L12.7468472,9.24894974 L12.750448,13.7505438 C12.7507788,14.1647572 12.4152611,14.5008121 12.0010476,14.5011439 C11.621352,14.5014471 11.3073312,14.2195442 11.257376,13.8535085 L11.250448,13.7517435 L11.2468472,9.25014944 C11.2465164,8.83593601 11.5820341,8.49988112 11.9962476,8.49954934 Z";

    /// <summary>
    ///     Initialises new instance of ListItemTemplate class
    /// </summary>
    /// <param name="viewModelType">Type of *ViewModel</param>
    /// <param name="label">Label to show in ListItem</param>
    /// <param name="iconKey">Icon to show in ListItem</param>
    public ListItemTemplate(Type viewModelType, string label, string iconKey)
    {
        ViewModelType = viewModelType;
        Label = label;

        Application.Current!.TryFindResource(iconKey, out var result);

        var streamGeometry =
            result as StreamGeometry ?? StreamGeometry.Parse(WarningRegularStreamGeometryString);

        Icon = streamGeometry;
    }

    /// <summary>
    ///     Initialises new instance of ListItemTemplate class
    /// </summary>
    /// <param name="viewModelType">Type of *ViewModel</param>
    /// <param name="iconKey">Icon to show in ListItem</param>
    public ListItemTemplate(Type viewModelType, string iconKey)
    {
        ViewModelType = viewModelType;

        var viewModelName = viewModelType.Name.Replace("ViewModel", "");

        Label = CamelCaseSplitRegex().Replace(viewModelName, " $1").Trim();

        Application.Current!.TryFindResource(iconKey, out var result);
        var streamGeometry =
            result as StreamGeometry ?? StreamGeometry.Parse(WarningRegularStreamGeometryString);

        Icon = streamGeometry;
    }

    /// <summary>
    ///     Type of *ViewModel
    /// </summary>
    public Type ViewModelType { get; private set; }

    /// <summary>
    ///     ListItem label
    /// </summary>
    public string Label { get; private set; }

    /// <summary>
    ///     ListItem icon
    /// </summary>
    public StreamGeometry Icon { get; private set; }

    /// <summary>
    ///     Regex to split a CamelCase string into separate words
    /// </summary>
    /// <returns></returns>
    [GeneratedRegex("([A-Z])", RegexOptions.Compiled)]
    private static partial Regex CamelCaseSplitRegex();
}