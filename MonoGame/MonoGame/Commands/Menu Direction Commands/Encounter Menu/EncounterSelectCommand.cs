
namespace MonoGame
{
    class EncounterSelectCommand : ICommands
    {
        EncounterGUI menu;
        
        public EncounterSelectCommand(EncounterGUI menu)
        {
            this.menu = menu;
        }
        public void Execute()
        {
            menu.Select();
        }
    }
}
