using GhostsGame.Controller;

public static class EntryPoint
{
    public static GameRoot game;
    static void Main()
    {
        using (game = new GameRoot())
            game.Run();
    }
}