using System.Diagnostics;

namespace MonoGame
{
    class UseMoveCommand : ICommands
    {
        Game1 game;
        Damage dmg;
        Monster atkMon;
        Monster enemMon;
        Move move;

        public UseMoveCommand(Damage dmg, Monster atkMon, Monster enemMon, Move move)
        {
            this.dmg = dmg;
            this.atkMon = atkMon;
            this.enemMon = enemMon;
            this.move = move;
        }
        
        public void Execute()
        {
            int dmgInt = dmg.CalculateDamage(atkMon, enemMon, move);
            Debug.WriteLine(dmgInt);
            enemMon.currHealth -= dmgInt;
            Debug.WriteLine(enemMon.currHealth);

        }
    }
}
