using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ascon.Pilot.SDK.Controls
{
    public abstract class PropertyChangedBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private bool? _closeResult;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? CloseResult
        {
            get { return _closeResult; }
            private set
            {
                _closeResult = value;
                NotifyOfPropertyChange(nameof(CloseResult));
            }
        }

        protected virtual void NotifyOfAllPropertiesChanged()
        {
            NotifyOfPropertyChange(null);
        }

        protected void NotifyOfPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void CloseView(bool dialogResult)
        {
            CloseResult = dialogResult;
        }
    }
}
