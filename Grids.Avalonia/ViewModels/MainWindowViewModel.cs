using System;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using ReactiveUI;

namespace Grids.Avalonia.ViewModels;

public class MainWindowViewModel : ReactiveObject
{
    private TextBlock? currentItem;
    public List<TextBlock>? FooterItems;
    public List<TextBlock>? HeaderItems;
    public string Chat => "Zekiah: Hello World!";

    public TextBlock? CurrentItem
    {
        get => currentItem;
        set
        {
            currentItem = value;
            CurrentItemChanged();
        }
    }


    public void Exit()
    {
        (Application.Current.ApplicationLifetime as IControlledApplicationLifetime)?.Shutdown(1);
    }

    public void CurrentItemChanged()
    {
        Console.WriteLine(CurrentItem!.Name);
    }

    public void ChatRecieved(EventArgs e, string username, string message)
    {
    }
}