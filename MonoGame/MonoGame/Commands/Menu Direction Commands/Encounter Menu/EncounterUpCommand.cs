
namespace MonoGame
{
    class EncounterUpCommand : ICommands
    {
        UniversalGUI menu;

        public EncounterUpCommand(UniversalGUI menu)
        {
            this.menu = menu;
        }
        public void Execute()
        {
            menu.Up();
        }
    }
}
