using Godot;
using System;

public partial class Test : Node
{
    private Steam _steam;
    private bool _isSteamRunning = false;

    public override void _Ready()
    {
        _steam = GetNodeOrNull<Steam>("/root/SteamManager");

        if (_steam == null)
        {
            GD.Print("ERR");
        }
        GD.Print($"Hello {_steam.getPersonaName()} ({_steam.getSteamID()})");
    }

    public override void _Process(double delta)
    {
        if (_isSteamRunning)
        {
            _steam.run_callbacks();
        }
    }
}