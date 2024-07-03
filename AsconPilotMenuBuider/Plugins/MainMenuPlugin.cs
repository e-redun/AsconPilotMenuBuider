using System.ComponentModel.Composition;
using System.Linq;
using System.Windows;
using Ascon.Pilot.SDK.Menu;

namespace Ascon.Pilot.SDK.MainMenuSample
{
    [Export(typeof(IMenu<MainViewContext>))]
    public class MainMenuPlugin : IMenu<MainViewContext>
    {
        private const string DIALOG_MENU = "DialogMenu";
        private const string DIALOG_MENU_HEADER = "Вызвать диалоговое окно";

        public void Build(IMenuBuilder builder, MainViewContext context)
        {
            var item = builder.AddItem(DIALOG_MENU, 1).WithHeader(DIALOG_MENU_HEADER);
        }

        public void OnMenuItemClick(string name, MainViewContext context)
        {
            if (name == DIALOG_MENU)
            {
                MessageBox.Show(DIALOG_MENU_HEADER);
            }
        }
    }
}