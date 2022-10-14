using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ZRQ.UI.UIUtils
{
    class RelayCommand : ICommand
    {
        Func<object, bool> _canExecute;
        Action<object> _execute;
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
        public RelayCommand(Action<object> execute)
    : this(execute, null)
        {
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (_canExecute != null)
                {
                    CommandManager.RequerySuggested += value;
                }
            }
            remove
            {
                if (_canExecute != null)
                {
                    CommandManager.RequerySuggested -= value;
                }
            }
        }
        public bool CanExecute(object parameter)
        {
            if (_canExecute == null) return true;
            return _canExecute(parameter);
        }
        public void Execute(object parameter)
        {
            if (_execute != null && CanExecute(parameter))
            {
                _execute(parameter);
            }
        }
    }
}
