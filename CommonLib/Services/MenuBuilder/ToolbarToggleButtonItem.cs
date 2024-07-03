using System;
using Ascon.Pilot.Theme.Controls;

namespace CommonLib.Services.MenuBuilder
{
    public class ToolbarToggleButtonItem : ToolbarButtonItem, IToolbarToggleButtonItem
    {
        public ToolbarToggleButtonItem() : base()
        {}
        public ToolbarToggleButtonItem(string name) : base(name)
        {}

        public bool IsChecked
        {
            get => _isChecked;
            set => Set(ref _isChecked, value);
        }
        private bool _isChecked;

        public event EventHandler OnChecked;
    }
}