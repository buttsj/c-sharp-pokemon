
namespace MonoGame
{
    class MenuDownCommand : ICommands
    {
        GUI menu;
        
        public MenuDownCommand(GUI menu)
        {
            this.menu = menu;
        }
        public void Execute()
        {
            menu.Down();
        }
    }
}
