using CommonLib.Services;

namespace AsconPilotMenuBuider.Models
{
    public class PersonModel : ObservableObject
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public bool IsChecked
        {
            get => _isChecked;
            set => Set(ref _isChecked, value);
        }
        private bool _isChecked;
    }
}