using System;

namespace MonoGame
{
    class GrassCollisionResponse
    {
        Random rnd;
        Game1 game;
        double veryCommon = 5.33;

        public GrassCollisionResponse(Game1 game)
        {
            rnd = new Random();
            this.game = game;
        }

        public void PlayerTileCollide(Grass grass)
        {
                double value = RandomExtension.NextDouble(rnd, 0.01, 99.99);
                if (value <= veryCommon)
                {
                    game.gameState = new EncounterGameState(game);
                }
        }
    }
}
