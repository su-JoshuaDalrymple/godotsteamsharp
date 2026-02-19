using Godot;
using System;
using Godot.Collections;

public partial class Steam : Node
{
    private GodotObject _multiplayer;

    public override void _Ready()
    {
        if (ClassDB.ClassExists("SteamMultiplayerPeer"))
        {
            _multiplayer = ClassDB.Instantiate("SteamMultiplayerPeer").As<GodotObject>();
            GD.Print("Steam Multiplayer initialized via _Ready");
        }
    }

    //** ENUMERATORS **//

    public enum DebugLevel : int
    {
        DEBUG_LEVEL_NONE = 0,
        DEBUG_LEVEL_PEER = 1,
        DEBUG_LEVEL_STEAM = 2
    }

    public enum Error : int
    {
        OK = 0,
        FAILED = 1,
        ERR_UNAVAILABLE = 2,
        ERR_UNCONFIGURED = 3,
        ERR_UNAUTHORIZED = 4,
        ERR_PARAMETER_RANGE_ERROR = 5,
        ERR_OUT_OF_MEMORY = 6,
        ERR_FILE_NOT_FOUND = 7,
        ERR_FILE_BAD_DRIVE = 8,
        ERR_FILE_BAD_PATH = 9,
        ERR_FILE_NO_PERMISSION = 10,
        ERR_FILE_ALREADY_IN_USE = 11,
        ERR_FILE_CANT_OPEN = 12,
        ERR_FILE_CANT_WRITE = 13,
        ERR_FILE_CANT_READ = 14,
        ERR_FILE_UNRECOGNIZED = 15,
        ERR_FILE_CORRUPT = 16,
        ERR_FILE_MISSING_DEPENDENCIES = 17,
        ERR_FILE_EOF = 18,
        ERR_CANT_OPEN = 19,
        ERR_CANT_CREATE = 20,
        ERR_QUERY_FAILED = 21,
        ERR_ALREADY_IN_USE = 22,
        ERR_LOCKED = 23,
        ERR_TIMEOUT = 24,
        ERR_CANT_CONNECT = 25,
        ERR_CANT_RESOLVE = 26,
        ERR_CONNECTION_ERROR = 27,
        ERR_CANT_ACQUIRE_RESOURCE = 28,
        ERR_CANT_FORK = 29,
        ERR_INVALID_DATA = 30,
        ERR_INVALID_PARAMETER = 31,
        ERR_ALREADY_EXISTS = 32,
        ERR_DOES_NOT_EXIST = 33,
        ERR_DATABASE_CANT_READ = 34,
        ERR_DATABASE_CANT_WRITE = 35,
        ERR_COMPILATION_FAILED = 36,
        ERR_METHOD_NOT_FOUND = 37,
        ERR_LINK_FAILED = 38,
        ERR_SCRIPT_FAILED = 39,
        ERR_CYCLIC_LINK = 40,
        ERR_INVALID_DECLARATION = 41,
        ERR_DUPLICATE_SYMBOL = 42,
        ERR_PARSE_ERROR = 43,
        ERR_BUSY = 44,
        ERR_SKIP = 45,
        ERR_HELP = 46,
        ERR_BUG = 47,
        ERR_PRINTER_ON_FIRE = 48
    }


    //** METHODS **//

    public Error create_host(int @virtual_port = 0)
    {
        return (Error)_multiplayer.Call("create_host", @virtual_port).AsInt32();
    }

    public Error create_client(ulong @steam_id, int @virtual_port)
    {
        return (Error)_multiplayer.Call("create_client", @steam_id, @virtual_port).AsInt32();
    }

    public Error add_peer(ulong @steam_id, int @virtual_port)
    {
        return (Error)_multiplayer.Call("add_peer", @steam_id, @virtual_port).AsInt32();
    }

    public SteamPacketPeer get_peer(int @peer_id)
    {
        return _multiplayer.Call("get_peer", @peer_id).As<SteamPacketPeer>();
    }

    public Error host_with_lobby(ulong @lobby_id)
    {
        return (Error)_multiplayer.Call("host_with_lobby", @lobby_id).AsInt32();
    }

    public Error connect_to_lobby(ulong @lobby_id)
    {
        return (Error)_multiplayer.Call("connect_to_lobby", @lobby_id).AsInt32();
    }

    public ulong get_steam_id_for_peer_id(int @peer_id)
    {
        return _multiplayer.Call("get_steam_id_for_peer_id", @peer_id).AsUInt64();
    }

    public int get_peer_id_for_steam_id(ulong @steam_id)
    {
        return _multiplayer.Call("get_peer_id_for_steam_id", @steam_id).AsInt32();
    }

    public bool get_no_delay() => _multiplayer.Call("get_no_delay").AsBool();

    public void set_no_delay(bool @_unnamed_arg0)
    {
        _multiplayer.Call("set_no_delay", @_unnamed_arg0);
    }

    public bool get_no_nagle() => _multiplayer.Call("get_no_nagle").AsBool();

    public void set_no_nagle(bool @_unnamed_arg0)
    {
        _multiplayer.Call("set_no_nagle", @_unnamed_arg0);
    }

    public bool get_server_relay() => _multiplayer.Call("get_server_relay").AsBool();

    public void set_server_relay(bool @_unnamed_arg0)
    {
        _multiplayer.Call("set_server_relay", @_unnamed_arg0);
    }

    public DebugLevel get_debug_level() => (DebugLevel)_multiplayer.Call("get_debug_level").AsInt32();

    public void set_debug_level(DebugLevel @_unnamed_arg0)
    {
        _multiplayer.Call("set_debug_level", (int)@_unnamed_arg0);
    }

    //** PROPERTIES **//

    public bool NoDelay
    {
        get => get_no_delay();
        set => set_no_delay(value);
    }
    public bool NoNangle
    {
        get => get_no_nagle();
        set => set_no_nagle(value);
    }
    public bool ServerRelay
    {
        get => get_server_relay();
        set => set_server_relay(value);
    }
    public DebugLevel LevelDebug
    {
        get => get_debug_level();
        set => set_debug_level(value);
    }

}