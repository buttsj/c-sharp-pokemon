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
            enc.menu.columnOne.Add(new KeyValuePair<ICommands, string>(new UseMoveCommand(enc.dmg, game.level.player.pocketMonsters[0], enc.enemyMon, game.level.player.pocketMonsters[0].moves[0]), game.level.player.pocketMonsters[0].moves[0].name));
            enc.menu.columnOne.Add(new KeyValuePair<ICommands, string>(new UseMoveCommand(enc.dmg, game.level.player.pocketMonsters[0], enc.enemyMon, game.level.player.pocketMonsters[0].moves[1]), game.level.player.pocketMonsters[0].moves[1].name));
            enc.menu.columnTwo.Add(new KeyValuePair<ICommands, string>(new UseMoveCommand(enc.dmg, game.level.player.pocketMonsters[0], enc.enemyMon, game.level.player.pocketMonsters[0].moves[2]), game.level.player.pocketMonsters[0].moves[2].name));
            enc.menu.columnTwo.Add(new KeyValuePair<ICommands, string>(new UseMoveCommand(enc.dmg, game.level.player.pocketMonsters[0], enc.enemyMon, game.level.player.pocketMonsters[0].moves[3]), game.level.player.pocketMonsters[0].moves[3].name));

        }
    }
}
