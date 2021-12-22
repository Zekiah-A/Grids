using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.ReactiveUI;
using ReactiveUI;
using static Grids.Avalonia.App;

namespace Grids.Avalonia.ViewModels
{
    public class MainWindowViewModel : ReactiveObject
    {
        public string Chat => "Zekiah: Hello World!";

        private TextBlock? currentItem;
        public TextBlock? CurrentItem
        {
            get => currentItem;
            set
            {
                currentItem = value;
                CurrentItemChanged();
            }
        }
        public List<TextBlock>? HeaderItems;
        public List<TextBlock>? FooterItems; 

        
        public void Exit() =>
            (Application.Current.ApplicationLifetime as IControlledApplicationLifetime)?.Shutdown(1);

        public void CurrentItemChanged()
        {
            Console.WriteLine(CurrentItem!.Name);
        }
        
        public void ChatRecieved(EventArgs e, string username, string message)
        {
            
        }
    }
}