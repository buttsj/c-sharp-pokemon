
namespace MonoGame
{
    class EncounterRightCommand : ICommands
    {
        EncounterGUI menu;
        
        public EncounterRightCommand(EncounterGUI menu)
        {
            this.menu = menu;
        }
        public void Execute()
        {
            menu.Right();
        }
    }
}
