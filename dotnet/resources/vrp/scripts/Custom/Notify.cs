using GTANetworkAPI;

public enum NotifyType
{
    Alert,
    Error,
    Success,
    Info,
    Warning
}
public enum NotifyPosition
{
    Top,
    TopLeft,
    TopCenter,
    TopRight,
    Center,
    CenterLeft,
    CenterRight,
    Bottom,
    BottomLeft,
    BottomCenter,
    BottomRight
}
public static class Notify
{
    public static void Send(Player client, NotifyType type, NotifyPosition pos, string msg, int time)
    {
        NAPI.ClientEvent.TriggerClientEvent(client, "notify", type, pos, msg, time);
    }
}

