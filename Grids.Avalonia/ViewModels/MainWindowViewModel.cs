using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Mime;
using System.Reactive.Linq;
using System.Windows.Input;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Grids.Avalonia.Models;
using ReactiveUI;

namespace Grids.Avalonia.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public string Chat => "Zekiah: Hello World!";
    
    private ObservableCollection<string> serverItems = new ObservableCollection<string>();

    public ObservableCollection<string> ServerItems
    {
        get => serverItems;
        set => this.RaiseAndSetIfChanged(ref serverItems, value);
    }

    public ServerClient test_serverclient = new ServerClient();

    public MainWindowViewModel()
    {
        AddServer("irc.lucky.net", 7777, false); //should be a class that has the server UI, button and extras
        
        ShowProfileDialog = new Interaction<MainWindowViewModel, ProfileWindowViewModel?>();

        ShowProfile = ReactiveCommand.CreateFromTask(async () =>
        {
            MainWindowViewModel main = new MainWindowViewModel();

            ProfileWindowViewModel? result = await ShowProfileDialog.Handle(main);
        });
    }

    public ICommand ShowProfile { get; }

    public Interaction<MainWindowViewModel, ProfileWindowViewModel?> ShowProfileDialog { get; }

    public void AddServer(string address, int port, bool enableSSL)
    {
        ServerItems.Add(address);
    }

    public void Reconnect() => test_serverclient.Reconnect();
    public void Disconnect() => test_serverclient.Disconnect();
    public void Exit() => (Application.Current.ApplicationLifetime as IControlledApplicationLifetime)?.Shutdown(1);
}