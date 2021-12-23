using System;
using System.Linq;
using static IrcClient;
using Grids.Avalonia.ViewModels;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Channels;


namespace Grids.Avalonia.Models;

public class ServerClient
{
    public IrcClient Client;
    
    public Dictionary<string, string[]> UserList = new Dictionary<string, string[]>(); //Channel, Userlist
    public Dictionary<string, List<Message>> ChannelMessages = new Dictionary<string, List<Message>>(); //Channel, Message
    public List<Message> ServerMessages = new List<Message>(); //Server Message
    public List<Message> NoticeMessages = new List<Message>(); //Notice Message

    public void Connect()
    {
        try
        {
            Client = new IrcClient("irc.lucky.net", 7777, false);
            Client.Connect();
            Client.OnConnect += OnConnect;
            Client.UpdateUsers += UpdateUsers;
            Client.ServerMessage += ServerMessage;
            Client.ChannelMessage += ChannelMessage;
            Client.NoticeMessage += NoticeMessage;
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
        Connect();
        Console.WriteLine($"Reconnecting to server {Client.Server}.");
    }
    
    
    private void OnConnect(object? sender, EventArgs args) =>
        Console.WriteLine($"Successfully Connected to server {Client.Server}.");

    private void OnDisconnect(object? sender, EventArgs args) =>
        Console.WriteLine($"Successfully Disconnected from server {Client.Server}.");

    //UpdateUsers will automatically update when someone leaves or joins.
    private void UpdateUsers(object? sender, UpdateUsersEventArgs args)
    {
        UserList.Add(args.Channel, args.UserList);
    }

    private void ServerMessage(object? sender, StringEventArgs args)
    {
        ServerMessages.Add(new Message("Server", args.ToString()));
    }

    private void NoticeMessage(object? sender, NoticeMessageEventArgs args)
    {
        NoticeMessages.Add(new Message(args.From, args.Message));
    }
    
    private void ChannelMessage(object? sender, ChannelMessageEventArgs args)
    { 
        if (!ChannelMessages.ContainsKey(args.Channel))
        {
           //First message in a channel, add that channel to the list if it doesn't exist.
           ChannelMessages.Add(args.Channel, new List<Message>() {new Message(args.From, args.Message)});
        }
        else
        {
           //Add another message to the list of messages for that channel
           ChannelMessages[args.Channel].Add(new Message(args.From, args.Message));
        }
    }
}
