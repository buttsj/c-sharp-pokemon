using Microsoft.Xna.Framework;

namespace MonoGame
{
    class ExitCollisionResponse
    {
        Game1 game;

        public ExitCollisionResponse(Game1 game)
        {
            this.game = game;
        }

        public void PlayerTileCollide(Player player, Exit exit)
        {
            game.transition = true;
            game.level = new Level(exit.destination, game);
            game.keyboard = new KeyboardController(game.level.player, game);
            game.level.player.position = new Vector2(game.prevPlayerPosition.X, game.prevPlayerPosition.Y + 10);
        }
    }
}
