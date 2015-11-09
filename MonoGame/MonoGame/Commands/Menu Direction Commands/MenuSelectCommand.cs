
namespace MonoGame
{
    class MenuSelectCommand : ICommands
    {
        GUI menu;
        
        public MenuSelectCommand(GUI menu)
        {
            this.menu = menu;
        }
        public void Execute()
        {
            menu.Select();
        }
    }
}
