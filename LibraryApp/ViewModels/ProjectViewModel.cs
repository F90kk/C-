using LibraryApp.Data;
using LibraryApp.Helpers;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryApp.ViewModels
{
    public class ProjectViewModel<T> : BaseViewModel
    {
        protected readonly IRepository<T> _repo;
        public ObservableCollection<T> Items { get; } = new();
        public ICommand LoadCommand { get; }
        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; }

        private T _selectedItem;
        public T SelectedItem
        {
            get => _selectedItem;
            set { _selectedItem = value; OnPropertyChanged(); }
        }

        public ProjectViewModel(IRepository<T> repo)
        {
            _repo = repo;
            LoadCommand = new AsyncRelayCommand(async () =>
            {
                var list = await _repo.GetAllAsync();
                Items.Clear();
                foreach (var i in list) Items.Add(i);
            });
            AddCommand = new AsyncRelayCommand(async () =>
            {
                await _repo.AddAsync(default); // Реализация в наследниках
                await _repo.SaveAsync();
                ((AsyncRelayCommand)LoadCommand).Execute(null);
            });
            DeleteCommand = new AsyncRelayCommand(async () =>
            {
                if (SelectedItem != null)
                {
                    await _repo.DeleteAsync(SelectedItem);
                    await _repo.SaveAsync();
                    ((AsyncRelayCommand)LoadCommand).Execute(null);
                }
            });
        }
    }
}