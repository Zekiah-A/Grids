using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using DynamicData.Binding;

namespace Grids.Avalonia.Views;

public class ProfileWindow : Window
{
    private FocusManager focusManager => new();
    
    public ProfileWindow()
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

    private void OnFocusLost(object? sender, EventArgs eventArgs)
    {
        Close(); 
    }
    
    //private void OnFocusLost(object? sender, RoutedEventArgs eventArgs)
    ///{
    //    if (!ReferenceEquals(focusManager.Current?.VisualRoot, this))
    //        Close();
    //}
}