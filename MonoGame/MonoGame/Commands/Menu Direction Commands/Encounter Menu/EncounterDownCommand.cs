
namespace MonoGame
{
    class EncounterDownCommand : ICommands
    {
        EncounterGUI menu;
        
        public EncounterDownCommand(EncounterGUI menu)
        {
            this.menu = menu;
        }
        public void Execute()
        {
            menu.Down();
        }
    }
}
