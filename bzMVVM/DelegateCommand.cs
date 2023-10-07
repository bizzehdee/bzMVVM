using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace bzMVVM
{
    public class DelegateCommand :
        ICommand
    {
        private readonly Action _action;
        private readonly Func<object, bool> _canExecute;

        public DelegateCommand(Action action)
        {
            _action = action;
            _canExecute = null;
        }

        public DelegateCommand(Action action, Func<object, bool> canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public void Execute(object parameter)
        {
            _action();
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute != null ? _canExecute(parameter) : true;
        }

#pragma warning disable 67
        public event EventHandler CanExecuteChanged;
#pragma warning restore 67
    }

    public class DelegateCommand<T> :
        ICommand
    {
        private readonly Action<T> _action;
        private readonly Func<T, bool> _canExecute;

        public DelegateCommand(Action<T> action)
        {
            _action = action;
        }

        public DelegateCommand(Action<T> action, Func<T, bool> canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public void Execute(object parameter)
        {
            _action((T)parameter);
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute((T)parameter);
        }

#pragma warning disable 67
        public event EventHandler CanExecuteChanged;
#pragma warning restore 67
    }
}
