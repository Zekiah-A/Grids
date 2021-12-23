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

public class MainWindowViewModel : ReactiveObject
{
    //private static TextBlock? currentItem;
    public static List<TextBlock>? FooterItems;
    public static List<TextBlock>? HeaderItems;

    public string Chat => "Zekiah: Hello World!";
    
    private ObservableCollection<string> serverItems = new ObservableCollection<string>();

    public ObservableCollection<string> ServerItems
    {
        get => serverItems;
        set => this.RaiseAndSetIfChanged(ref serverItems, value);
    }

    //public static TextBlock? CurrentItem
    //{
    //    get => currentItem;
    //    set
    //    {
    //        currentItem = value;
    //        CurrentItemChanged();
    //    }
    //}

    public ServerClient test_serverclient = new ServerClient();

    //TEST: Test to add server
    public MainWindowViewModel()
    {
        AddServer("irc.lucky.net", 7777, false); //should be a class that has the server UI, button and extras
    }

    public void AddServer(string address, int port, bool enableSSL)
    {
        //could also make a template for more complex stuff
        //var newCollection = new ObservableCollection<TextBlock>();
        ServerItems.Add(address);
    }

    public void Reconnect() => test_serverclient.Reconnect();
    public void Disconnect() => test_serverclient.Disconnect();
    public void Exit() => (Application.Current.ApplicationLifetime as IControlledApplicationLifetime)?.Shutdown(1);
    //public static void CurrentItemChanged() => Console.WriteLine(CurrentItem!.Name); //TODO: Switch page when current changed?
}