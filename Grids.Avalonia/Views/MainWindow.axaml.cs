using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.LogicalTree;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Avalonia.VisualTree;
using Grids.Avalonia.ViewModels;

namespace Grids.Avalonia.Views;

public class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
/*
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
*/
}