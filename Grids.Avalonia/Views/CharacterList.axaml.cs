using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Grids.Avalonia.Views;

public class CharacterList : UserControl
{
    public CharacterList()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}