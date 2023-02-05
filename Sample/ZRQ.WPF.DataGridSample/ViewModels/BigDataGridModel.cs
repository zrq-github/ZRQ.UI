using Microsoft.Xaml.Behaviors.Core;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ZRQ.UI.SampleData;
using ZRQ.UI.UIModel;

namespace ZRQ.WPF.DataGridSample.ViewModels
{
    internal class BigDataGridModel : ViewModelBase
    {
        private ActionCommand? createData;
        public ICommand CreateData => createData ??= new ActionCommand(PerformCreateData);
        public string CreateNum { get; set; } = string.Empty;
        public ObservableCollection<Person>? Persons { get; set; } = new();

        private void PerformCreateData()
        {
            if (Persons == null) return;

            Persons.Clear();
            if (!int.TryParse(CreateNum, out int num)) return;

            var lazyPersion = PersonBuilder.Create(num);
            foreach (var person in lazyPersion.Value)
            {
                Persons.Add(person);
            }
        }
    }
}
