
namespace MonoGame
{
    class MenuDownCommand : ICommands
    {
        UniversalGUI menu;
        
        public MenuDownCommand(UniversalGUI menu)
        {
            this.menu = menu;
        }
        public void Execute()
        {
            menu.Down();
        }
    }
}
