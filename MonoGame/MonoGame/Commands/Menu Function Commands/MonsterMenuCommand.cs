namespace MonoGame
{
    class MonsterMenuCommand : ICommands
    {

        Game1 game;
        public MonsterMenuCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.level.player.displayMonsters = true;
        }
    }
}
