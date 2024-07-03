using System.Collections;
using System.Collections.Generic;
using Ascon.Pilot.Theme.Controls;

namespace CommonLib.Services.MenuBuilder
{

    public class ToolbarMenuButtonItem : ToolbarButtonItem, IToolbarMenuButtonItem
    {
        public IEnumerable Menu => _menu;

        private List<IToolbarItem> _menu = new List<IToolbarItem>();

        public ToolbarMenuButtonItem(string name) : base(name)
        {
        }

        public void AddMenuItem(IToolbarItem item)
        {
            _menu.Add(item);
        }

        public void RemoveMenuItem(IToolbarItem item)
        {
            _menu.Remove(item);
        }
    }
}