using System;
using Avalonia;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace Grids.Avalonia.Models;

public class Profile
{
    public IImage ProfileImage { get; }
    public string Username { get; }
    public string Email { get; }
    public string Description { get; }

    private string number;
    public string Number
    {
        get => number;
        set => number = "Number: " + value;
    }
    private string realName;
    public string RealName
    {
        get => realName;
        set => realName = "Real Name: " + value;
    }
    private string address;
    public string Address
    {
        get => address;
        set => address = "IP Address: " + value;
    }
    
    private string lastSeen;
    public string LastSeen
    {
        get => lastSeen;
        set => lastSeen = "Last Message: " + value;
    }
    private string rank;
    public string Rank
    {
        get => rank;
        set => rank = "Server Rank: " + value;
    }
    private string mutual;
    public string Mutual
    {
        get => mutual;
        set => mutual = "Mutual Servers: " + value;
    }
    
    public Profile (string profileImage, string username, string email, string description, string number, string realName, string address, string lastSeen, string rank, string mutual)
    {
        var assets = AvaloniaLocator.Current.GetService<IAssetLoader>();
        ProfileImage = new Bitmap(assets.Open(new Uri($"avares://Grids.Avalonia/{profileImage}")));
        Username = username;
        Email = email;
        Description = description;
        Number = number;
        RealName = realName;
        Address = address;
        LastSeen = lastSeen;
        Rank = rank;
        Mutual = mutual;
    }
}