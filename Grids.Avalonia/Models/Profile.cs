using System;
using Avalonia;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace Grids.Avalonia.Models;

public class Profile
{
    public IImage ProfileImage { get;  }
    public string Username { get; }
    public string Email { get; }
    
    public string Number { get; }
    public string RealName { get; }
    public string Address { get; }
    
    public string LastSeen { get; }
    public string Rank { get; }
    public string Shared { get; }
    

    public Profile (string profileImage, string username, string email, string number, string realName, string address, string lastSeen, string rank, string shared)
    {
        var assets = AvaloniaLocator.Current.GetService<IAssetLoader>();
        ProfileImage = new Bitmap(assets.Open(new Uri($"avares://Grids.Avalonia/{profileImage}")));
        Username = username;
        Email = email;
        Number = number;
        RealName = realName;
        Address = address;
        LastSeen = lastSeen;
        Rank = rank;
        Shared = shared;
    }
}