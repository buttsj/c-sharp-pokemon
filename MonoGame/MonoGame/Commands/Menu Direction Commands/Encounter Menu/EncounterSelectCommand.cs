
namespace MonoGame
{
    class EncounterSelectCommand : ICommands
    {
        UniversalGUI menu;

        public EncounterSelectCommand(UniversalGUI menu)
        {
            this.menu = menu;
        }
        public void Execute()
        {
            menu.Select();
        }
    }
}
