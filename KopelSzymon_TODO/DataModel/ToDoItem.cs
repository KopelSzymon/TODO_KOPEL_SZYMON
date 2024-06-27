using System;
using System.ComponentModel;

namespace ToDoList.DataModel
{
    public class ToDoItem : INotifyPropertyChanged
    {
        private string _description = String.Empty;
        private bool _isChecked;

        public string Description
        {
            get => _description;
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        public bool IsChecked
        {
            get => _isChecked;
            set
            {
                if (_isChecked != value)
                {
                    _isChecked = value;
                    OnPropertyChanged(nameof(IsChecked));
                    OnCheckedChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnCheckedChanged()
        {
            // Ta metoda zostanie zaimplementowana później
        }
    }
}
