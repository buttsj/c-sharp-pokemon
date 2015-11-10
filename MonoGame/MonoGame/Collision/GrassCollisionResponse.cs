using System;

namespace MonoGame
{
    class GrassCollisionResponse
    {
        Random rnd;
        Game1 game;
        double veryCommon = 5.33, common = 4.53, semiRare = 3.60, rare = 1.78, veryRare = 0.67;

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
