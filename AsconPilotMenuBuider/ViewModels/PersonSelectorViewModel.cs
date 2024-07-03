using Ascon.Pilot.Theme;
using Ascon.Pilot.Theme.Controls;
using AsconPilotMenuBuider.Models;
using CommonLib.Services;
using CommonLib.Services.MenuBuilder;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace AsconPilotMenuBuider.ViewModels
{
    public class PersonSelectorViewModel : ObservableObject
    {
        private Action _closeView;

        public ObservableCollection<IToolbarButtonItem> ToolbarItems { get; private set; }
        public ObservableCollection<PersonModel> Persons { get; private set; }

        public ICommand OkCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }
        public ICommand CheckAllCommand { get; private set; }
        public ICommand UncheckAllCommand { get; private set; }


        public string TestText { get; private set; }

        public bool DialogResult { get; set; } = false;

        public PersonSelectorViewModel(Action close, ObservableCollection<PersonModel> persons)
        {
            _closeView = close;

            Persons = persons;

            OkCommand = new RelayCommand(ApplyAndCloseWindow, ApplyAndCloseWindowCan);
            CancelCommand = new RelayCommand(CloseWindow);
            CheckAllCommand = new RelayCommand(CheckAllPersons, CheckAllPersonsCan);
            UncheckAllCommand = new RelayCommand(UncheckAllPersons, UncheckAllPersonsCan);

            ToolbarItems = GetToolbarItems();

            CheckAllPersons();
        }


        private bool CheckAllPersonsCan()
        {
            return Persons.Any(p => !p.IsChecked);
        }

        private void CheckAllPersons()
        {
            Persons.ToList().ForEach(p => p.IsChecked = true);
        }
        private bool UncheckAllPersonsCan()
        {
            return Persons.Any(p => p.IsChecked);
        }

        private void UncheckAllPersons()
        {
            Persons.ToList().ForEach(p => p.IsChecked = false);
        }

        private ObservableCollection<IToolbarButtonItem> GetToolbarItems()
        {
            return MenuBuilder.CreateMenu()
                              .AddItem(CheckAllCommand, Icons.Instance.CheckAllIcon, "Выделить всё", "Выделить всё")
                              .AddItem(UncheckAllCommand, Icons.Instance.UncheckAllIcon, "Снять всё", "Снять всё")
                              ;
        }

        private bool ApplyAndCloseWindowCan()
        {
            return Persons.Where(p => p.IsChecked).Any();
        }

        private void ApplyAndCloseWindow()
        {
            DialogResult = true;
            CloseWindow();
        }

        private void CloseWindow()
        {
            _closeView?.Invoke();
        }
    }
}
