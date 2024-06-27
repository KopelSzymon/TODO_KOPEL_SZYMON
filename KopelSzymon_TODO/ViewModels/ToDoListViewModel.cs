using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using ToDoList.DataModel;

namespace ToDoList.ViewModels
{
    public class ToDoListViewModel : ViewModelBase
    {
        public ObservableCollection<ToDoItem> ListItems { get; }

        public ToDoListViewModel(IEnumerable<ToDoItem> items) : base()
        {
            ListItems = new ObservableCollection<ToDoItem>(items);
            foreach (var item in ListItems)
            {
                item.PropertyChanged += Item_PropertyChanged;
            }
            ListItems.CollectionChanged += ListItems_CollectionChanged;
        }

        private void ListItems_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // Obsługa dodanych elementów
            if (e.NewItems != null)
            {
                foreach (ToDoItem newItem in e.NewItems)
                {
                    newItem.PropertyChanged += Item_PropertyChanged;
                }
            }

            // Obsługa usuniętych elementów
            if (e.OldItems != null)
            {
                foreach (ToDoItem oldItem in e.OldItems)
                {
                    oldItem.PropertyChanged -= Item_PropertyChanged;
                }
            }
        }

        private void Item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsChecked")
            {
                var item = sender as ToDoItem;
                if (item != null && item.IsChecked)
                {
                    ListItems.Remove(item);
                }
            }
        }
    }
}
