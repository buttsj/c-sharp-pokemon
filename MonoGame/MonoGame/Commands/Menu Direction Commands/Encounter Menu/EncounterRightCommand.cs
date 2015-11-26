
namespace MonoGame
{
    class EncounterRightCommand : ICommands
    {
        UniversalGUI menu;

        public EncounterRightCommand(UniversalGUI menu)
        {
            this.menu = menu;
        }
        public void Execute()
        {
            menu.LeftRight();
        }
    }
}
