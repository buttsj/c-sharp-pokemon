
namespace MonoGame
{
    class EncounterLeftCommand : ICommands
    {
        UniversalGUI menu;

        public EncounterLeftCommand(UniversalGUI menu)
        {
            this.menu = menu;
        }
        public void Execute()
        {
            menu.LeftRight();
        }
    }
}
