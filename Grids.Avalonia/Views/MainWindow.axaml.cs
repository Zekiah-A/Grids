using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.LogicalTree;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.ReactiveUI;
using Avalonia.VisualTree;
using Grids.Avalonia.Models;
using Grids.Avalonia.ViewModels;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ReactiveUI;

namespace Grids.Avalonia.Views;

public class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    private ListBox headerListBox => this.FindControl<ListBox>("HeaderListBox");
    private ListBox footerListBox => this.FindControl<ListBox>("FooterListBox");
    private MenuItem serverMenu => this.FindControl<MenuItem>("ServerMenu");
    //private ProfileWindow profileDialog;
    
    public MainWindow()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
        this.WhenActivated(d => d(ViewModel!.ShowProfileDialog.RegisterHandler(ShowProfileDialogAsync)));
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
    }

    private void FooterListBoxSelectionChanged(object? sender, SelectionChangedEventArgs eventArgs)
    {
        if (footerListBox!.SelectedIndex == -1)
            return;
        serverMenu.IsEnabled = false;

        headerListBox!.SelectedIndex = -1;
    }
    
    private async Task ShowProfileDialogAsync(InteractionContext<MainWindowViewModel, ProfileWindowViewModel?> interaction)
    {
        var profileDialog = new ProfileWindow();
        profileDialog.DataContext = interaction.Input;
        
        var profileContent = new Profile("../Assets/ProfileImages/z.png", "zekiahepic", "zekiahepic@irc.net", "I am but a sad soul, just looking for deez nuts.", "00000000", "zekiahAmo", "73.02.134.5", "01/07/20201", "Operator", "#channel on server1");
        profileDialog.Content = profileContent;

        var result = await profileDialog.ShowDialog<ProfileWindowViewModel?>(this);
        interaction.SetOutput(result);
    }
}