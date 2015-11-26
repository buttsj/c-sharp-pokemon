
namespace MonoGame
{
    class EncounterDownCommand : ICommands
    {
        UniversalGUI menu;

        public EncounterDownCommand(UniversalGUI menu)
        {
            this.menu = menu;
        }
        public void Execute()
        {
            menu.Down();
        }
    }
}
