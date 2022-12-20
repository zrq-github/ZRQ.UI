using System;
using System.Windows;
using System.Windows.Input;

namespace ZRQ.UI.UICommands
{
    public class CloseCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public void Execute(object parameter)
        {
            if (parameter is Window myWin) myWin.Close();
        }
    }
}
