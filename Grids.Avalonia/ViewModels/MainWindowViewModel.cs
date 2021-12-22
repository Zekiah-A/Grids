using System;
using System.Collections.Generic;
using System.Net.Http;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Grids.Avalonia.Models;
using ReactiveUI;

namespace Grids.Avalonia.ViewModels;

public class MainWindowViewModel : ReactiveObject
{
    private static TextBlock? currentItem;
    public static List<TextBlock>? FooterItems;
    public static List<TextBlock>? HeaderItems;

    public string Chat => "Zekiah: Hello World!";

    public static TextBlock? CurrentItem
    {
        get => currentItem;
        set
        {
            currentItem = value;
            CurrentItemChanged();
        }
    }

    public ServerClient test_serverclient = new ServerClient();

    public void Reconnect() =>
        test_serverclient.Reconnect();

    public void Disconnect() =>
        test_serverclient.Disconnect();

    public void Exit() => (Application.Current.ApplicationLifetime as IControlledApplicationLifetime)?.Shutdown(1);
    public static void CurrentItemChanged() => Console.WriteLine(CurrentItem!.Name); //TODO: Switch page when current changed?
}