using Godot;

public partial class SteamPacketPeer : RefCounted
{
    private GodotObject _ptr;

    public SteamPacketPeer(GodotObject rawPointer)
    {
        _ptr = rawPointer;
    }

    public enum PeerState : int
    {
        STATE_NONE = 0,
        STATE_CONNECTING = 1,
        STATE_FINDING_ROUTE = 2,
        STATE_CONNECTED = 3,
        STATE_CLOSED_BY_PEER = 4,
        STATE_PROBLEM_DETECTED_LOCALLY = 5,
        STATE_FIN_WAIT = -1,
        STATE_LINGER = -2,
        STATE_DEAD = -3
    }

    public ulong GetSteamID() => _ptr.Call("get_steam_id").AsUInt64();

    public uint GetPeerID() => (uint)_ptr.Call("get_peer_id").AsInt32();

    public void DisconnectPeer(bool @force = false)
    {
        _ptr.Call("disconnect_peer", @force);
    }
}