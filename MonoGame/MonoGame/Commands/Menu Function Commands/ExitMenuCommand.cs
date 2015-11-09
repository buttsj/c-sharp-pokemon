
namespace MonoGame
{
    class ExitMenuCommand : ICommands
    {
        Game1 game;
        public ExitMenuCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.isPaused = false;
            game.gameState = new PlayingGameState(game);
        }
    }
}
