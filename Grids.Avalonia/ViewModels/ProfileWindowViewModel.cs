using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Mime;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Grids.Avalonia.Models;
using ReactiveUI;

namespace Grids.Avalonia.ViewModels;

public class ProfileWindowViewModel : ViewModelBase
{
    private ObservableCollection<string> serverItems = new ObservableCollection<string>();

    public ObservableCollection<string> ServerItems
    {
        get => serverItems;
        set => this.RaiseAndSetIfChanged(ref serverItems, value);
    }
}