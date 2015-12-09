using System.Collections.Generic;

namespace MonoGame
{
    class FightMenuCommand : ICommands
    {
        EncounterGameState enc;
        Game1 game;

        public FightMenuCommand(EncounterGameState enc, Game1 game)
        {
            this.game = game;
            this.enc = enc;
        }

        public void Execute()
        {
            enc.menu.columnOne.Clear();
            enc.menu.columnTwo.Clear();
            enc.menu.columnOne.Add(new KeyValuePair<ICommands, string>(new UseMoveCommand(game), game.level.player.pocketMonsters[0].moves[0]));
            enc.menu.columnOne.Add(new KeyValuePair<ICommands, string>(new UseMoveCommand(game), game.level.player.pocketMonsters[0].moves[1]));
            enc.menu.columnTwo.Add(new KeyValuePair<ICommands, string>(new UseMoveCommand(game), game.level.player.pocketMonsters[0].moves[2]));
            enc.menu.columnTwo.Add(new KeyValuePair<ICommands, string>(new UseMoveCommand(game), game.level.player.pocketMonsters[0].moves[3]));
        }
    }
}
