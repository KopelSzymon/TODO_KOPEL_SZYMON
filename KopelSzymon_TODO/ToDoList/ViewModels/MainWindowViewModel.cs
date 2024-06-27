
using ReactiveUI;
using System;
using System.Reactive;
using System.Reactive.Linq;
using ToDoList.DataModel;
using ToDoList.Services;

namespace ToDoList.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase _contentViewModel;
        public ToDoListViewModel ToDoListViewModel { get; }

        //this has a dependency on the ToDoListService
        public ReactiveCommand<ToDoItem, Unit> DeleteItemCommand { get; }
        public MainWindowViewModel()
        {
            var service = new ToDoListService();
            ToDoListViewModel = new ToDoListViewModel(service.GetItems());
            _contentViewModel = ToDoListViewModel;
            DeleteItemCommand = ReactiveCommand.Create<ToDoItem>(DeleteItem);
        }
        private void DeleteItem(ToDoItem item)
        {
            ToDoListViewModel.ListItems.Remove(item);
        }
        public ViewModelBase ContentViewModel
        {
            get => _contentViewModel;
            private set => this.RaiseAndSetIfChanged(ref _contentViewModel, value);
        }

        public void AddItem()
        {
            AddItemViewModel addItemViewModel = new();

            Observable.Merge(
                addItemViewModel.OkCommand,
                addItemViewModel.CancelCommand.Select(_ => (ToDoItem?)null))
                .Take(1)
                .Subscribe(newItem =>
                {
                    if (newItem != null)
                    {
                        ToDoListViewModel.ListItems.Add(newItem);
                    }
                    ContentViewModel = ToDoListViewModel;
                });

            ContentViewModel = addItemViewModel;
        }
    }
}
