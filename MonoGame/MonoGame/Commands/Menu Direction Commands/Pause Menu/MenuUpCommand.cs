
namespace MonoGame
{
    class MenuUpCommand : ICommands
    {
        UniversalGUI menu;

        public MenuUpCommand(UniversalGUI menu)
        {
            this.menu = menu;
        }
        public void Execute()
        {
            menu.Up();
        }
    }
}
