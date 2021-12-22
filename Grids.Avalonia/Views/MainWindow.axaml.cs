using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Grids.Avalonia.ViewModels;

namespace Grids.Avalonia.Views;

public class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    private ListBox headerListBox => this.FindControl<ListBox>("HeaderListBox");
    private ListBox footerListBox => this.FindControl<ListBox>("FooterListBox");
    private MenuItem serverMenu => this.FindControl<MenuItem>("ServerMenu");

    public MainWindow()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif

        MainWindowViewModel.HeaderItems = new List<TextBlock>
        {
            this.FindControl<TextBlock>("Server1"),
            this.FindControl<TextBlock>("Server2"),
            this.FindControl<TextBlock>("Server3"),
            this.FindControl<TextBlock>("Server4")
        };

        MainWindowViewModel.FooterItems = new List<TextBlock>
        {
            this.FindControl<TextBlock>("Settings")
        };       
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void HeaderListBoxSelectionChanged(object? sender, SelectionChangedEventArgs eventArgs)
    {
        if (headerListBox!.SelectedIndex == -1)
            return;
        serverMenu.IsEnabled = true;

        footerListBox!.SelectedIndex = -1;
        MainWindowViewModel.CurrentItem = MainWindowViewModel.HeaderItems![headerListBox.SelectedIndex];
    }

    private void FooterListBoxSelectionChanged(object? sender, SelectionChangedEventArgs eventArgs)
    {
        if (footerListBox!.SelectedIndex == -1)
            return;
        serverMenu.IsEnabled = false;

        headerListBox!.SelectedIndex = -1;
        MainWindowViewModel.CurrentItem = MainWindowViewModel.FooterItems![footerListBox.SelectedIndex];
    }
}