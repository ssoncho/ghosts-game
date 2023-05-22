using GhostsGame.Controller;
using System;

public static class EntryPoint
{
    public static GameRoot Game;
    [STAThread]
    static void Main()
    {
        using (Game = new GameRoot())
            Game.Run();
    }
}