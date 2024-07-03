using Ascon.Pilot.Theme.Controls;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;

namespace CommonLib.Services.MenuBuilder
{
    public static class MenuBuilder
    {
        
        public static ObservableCollection<IToolbarButtonItem> CreateMenu()
        {
            return new ObservableCollection<IToolbarButtonItem>();
        }
        
        public static ObservableCollection<IToolbarButtonItem> AddItem(this ObservableCollection<IToolbarButtonItem> menu,
                                                                       ICommand command = null,
                                                                       ImageSource icon = null,
                                                                       string header = "",
                                                                       string hint = "",
                                                                       string name = "",
                                                                       MenuItemTypes itemType = MenuItemTypes.Button
                                                                       )
        {
            var menuItem = MenuItemFactory.CreateMenuItem(itemType);

            menuItem.Name = name;
            menuItem.Command = command;
            menuItem.Icon = icon;
            menuItem.Header = header;
            menuItem.Hint = hint;

            menu.Add(menuItem);

            return menu;
        }

        public static ObservableCollection<IToolbarButtonItem> AddMenuItem(this ObservableCollection<IToolbarButtonItem> menu,
                                                                           ICommand command = null,
                                                                           ImageSource icon = null,
                                                                           string header = "",
                                                                           string hint = "",
                                                                           string name = ""
                                                                           )
        {
            var menuItem = new ToolbarMenuButtonItem(name);

            menuItem.Command = command;
            menuItem.Icon = icon;
            menuItem.Header = header;
            menuItem.Hint = hint;

            menu.Add(menuItem);

            return menu;
        }

        public static ObservableCollection<IToolbarButtonItem> AddSubItem(this ObservableCollection<IToolbarButtonItem> menu,
                                                                          ICommand command = null,
                                                                          ImageSource icon = null,
                                                                          string header = "",
                                                                          string hint = "",
                                                                          string name = ""
                                                                          )
        {
            var lastItem = menu.Last() as ToolbarMenuButtonItem;

            if (lastItem != null)
            {
                var menuItem = new ToolbarButtonItem(name);

                menuItem.Command = command;
                menuItem.Icon = icon;
                menuItem.Header = header;
                menuItem.Hint = hint;

                lastItem.AddMenuItem(menuItem);
            }

            return menu;
        }
    }
}