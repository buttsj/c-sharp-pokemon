
namespace MonoGame
{
    class MenuSelectCommand : ICommands
    {
        UniversalGUI menu;

        public MenuSelectCommand(UniversalGUI menu)
        {
            this.menu = menu;
        }
        public void Execute()
        {
            menu.Select();
        }
    }
}
