using static IrcClient;

namespace Grids.Avalonia.Services;

public class IrcConnectService
{
    public void Connect()
    {
        IrcClient client = new IrcClient("irc.liberia.chat"); //Fix this weirdness, ugh
    }
}