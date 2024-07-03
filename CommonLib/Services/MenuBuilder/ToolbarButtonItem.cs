using System.Windows.Input;
using System.Windows.Media;
using Ascon.Pilot.SDK.Controls.Commands;
using Ascon.Pilot.Theme.Controls;

namespace CommonLib.Services.MenuBuilder
{

    public class ToolbarButtonItem : ObservableObject, IToolbarButtonItem
    {
        public ToolbarButtonItem()
        { }

        public ToolbarButtonItem(string name)
        {
            Name = name;
        }

        public object Header
        {
            get { return _header; }
            set { Set(ref _header, value); }
        }
        private object _header;


        public object Hint
        {
            get { return _hint; }
            set { Set(ref _hint, value); }
        }
        private object _hint;


        public ImageSource Icon
        {
            get { return _icon; }
            set { Set(ref _icon, value); }
        }
        private ImageSource _icon;


        public ICommand Command
        {
            get { return _command; }
            set { Set(ref _command, value); }
        }
        private ICommand _command;


        public object CommandParameter
        {
            get { return _commandParameter; }
            set
            {
                Set(ref _commandParameter, value);
                
                var canExecute = Command as DelegateCommandBase;
                
                if (canExecute != null)
                {
                    canExecute.RaiseCanExecuteChanged();
                }
            }
        }
        private object _commandParameter;


        public bool? IsEnabled
        {
            get { return _isEnabled; }
            set { Set(ref _isEnabled, value); }
        }
        private bool? _isEnabled = true;


        public bool ShowCaption
        {
            get { return _showCaption; }
            set { Set(ref _showCaption, value); }
        }
        private bool _showCaption = true;


        public string Name
        {
            get { return _name; }
            set { Set(ref _name, value); }
        }
        private string _name;
    }
}