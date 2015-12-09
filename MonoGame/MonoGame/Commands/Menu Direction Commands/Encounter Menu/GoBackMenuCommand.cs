
namespace MonoGame
{
    class GoBackMenuCommand : ICommands
    {
        UniversalGUI menu;

        public GoBackMenuCommand(UniversalGUI menu)
        {
            this.menu = menu;
        }
        public void Execute()
        {
            menu.GoBack();
        }
    }
}
