using System.Windows.Input;

namespace Ascon.Pilot.SDK.Controls.Commands
{
    public interface  IRaiseCanExecuteChangedCommand : ICommand
    {
        void RaiseCanExecuteChanged();
    }
}
