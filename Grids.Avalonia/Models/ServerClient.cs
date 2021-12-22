using System;
using System.Linq;
using static IrcClient;
using Grids.Avalonia.ViewModels;
using System.Collections.Generic;
using System.Net.Http;


namespace Grids.Avalonia.Models;

public class ServerClient
{
    public IrcClient Client;
    public Dictionary<string, string> ChannelMessages; //Channel, Message
    public List<string> ServerList = new List<string>();

    public void Connect()
    {
        try
        {
            Client = new IrcClient("irc.lucky.net", 7777, false);
            Client.Connect();
            Client.OnConnect += OnConnect;
            Client.ServerMessage += ServerMessage;
            Client.ChannelMessage += ChannelMessage;
            Console.WriteLine($"Connecting to server {Client.Server}.");
        }
        catch (Exception error)
        {
            Console.WriteLine($"Could not disconnect from server {error}");
        }
    }
    
    public void Disconnect() //Make a settings service, with settings such as whether to enable SSL by default, default server config, etc
    {
        try
        {
            Client.Disconnect();
            Client.OnDisconnect += OnDisconnect;
            Console.WriteLine($"Disconnecting from server {Client.Server}.");
        }
        catch (Exception error)
        {
            Console.WriteLine($"Could not disconnect from server {error}");
        }
    }
    
    public void Reconnect() //Make a settings service, with settings such as whether to enable SSL by default, default server config, etc
    {
        Disconnect();
        Console.WriteLine($"Reconnecting to server {Client.Server}.");
        Connect();
    }

    //Figure out how to get server list.
    public void UpdateServerList()
    {
        
    }

    private void OnConnect(object? sender, EventArgs args)
    {
        Console.WriteLine($"Successfully Connected to server {Client.Server}.");
        UpdateServerList();
    }

    private void OnDisconnect(object? sender, EventArgs args) =>
        Console.WriteLine($"Successfully Disconnected from server {Client.Server}.");

    private void ServerMessage(object? sender, StringEventArgs args) =>
        Console.WriteLine("Server: " + args);
    
    private void ChannelMessage(object? sender, ChannelMessageEventArgs args) =>
        Console.WriteLine($"(//{args.Channel}//) {args.From}: {args.Message}");
    
    private void NoticeMessage(object? sender, NoticeMessageEventArgs args) =>
        Console.WriteLine($"{args.From}: {args.Message}");
}
