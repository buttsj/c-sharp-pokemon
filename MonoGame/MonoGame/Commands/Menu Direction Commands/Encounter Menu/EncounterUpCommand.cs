
namespace MonoGame
{
    class EncounterUpCommand : ICommands
    {
        EncounterGUI menu;
        
        public EncounterUpCommand(EncounterGUI menu)
        {
            this.menu = menu;
        }
        public void Execute()
        {
            menu.Up();
        }
    }
}
