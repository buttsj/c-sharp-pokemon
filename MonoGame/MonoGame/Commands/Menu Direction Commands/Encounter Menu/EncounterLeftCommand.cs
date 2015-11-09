
namespace MonoGame
{
    class EncounterLeftCommand : ICommands
    {
        EncounterGUI menu;
        
        public EncounterLeftCommand(EncounterGUI menu)
        {
            this.menu = menu;
        }
        public void Execute()
        {
            menu.Left();
        }
    }
}
