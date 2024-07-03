using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows;
using Ascon.Pilot.SDK.Menu;
using AsconPilotMenuBuider.Models;
using AsconPilotMenuBuider.ViewModels;
using AsconPilotMenuBuider.Views;

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
                var persons = new ObservableCollection<PersonModel>()
                {
                    new PersonModel(){ Name = "Xxxxxxxx", Age = 20},
                    new PersonModel(){ Name = "Yyyyy", Age = 24},
                    new PersonModel(){ Name = "Zzzz", Age = 24}
                };

                var view = new PersonSelectorView();
                var viewModel = new PersonSelectorViewModel(view.Close, persons);

                view.DataContext = viewModel;
                
                view.ShowDialog();

                if (viewModel.DialogResult == false)
                {
                    return;
                }

                MessageBox.Show(string.Join("\n", viewModel.Persons.Select(p => p.Name)));
            }
        }
    }
}