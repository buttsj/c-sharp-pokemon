using System;

namespace MonoGame
{
    class RunAwayCommand : ICommands
    {
        Game1 game;
        int escapeCount = 1;
        public RunAwayCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            int A = 25; //your pokemons speed
            int B = 50; //other pokemons speed
            int F = (((A * 128) / B) + 30 * escapeCount) % 256;
            Random rndNum = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));
            int rnd = rndNum.Next(0, 255);
            if (rnd < F)
            {
                game.gameState = new PlayingGameState(game);
            }
            escapeCount++;
        }
    }
}
