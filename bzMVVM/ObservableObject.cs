using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace bzMVVM
{
    public class ObservableObject :
        INotifyPropertyChanged
    {

        private readonly IThreadDispatcher _threadDispatcher;

        public event PropertyChangedEventHandler PropertyChanged;

        protected ObservableObject(IThreadDispatcher threadDispatcher)
        {
            _threadDispatcher = threadDispatcher;
        }

        protected void RaisePropertyChangedEvent(string propertyName)
        {
            _threadDispatcher.ExecuteOnUIThread(() =>
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            });
        }

        protected virtual void SetProperty<T>(ref T reference, T value, [CallerMemberName]string callerName = "")
        {
            if (Equals(reference, value) == false)
            {
                reference = value;
                RaisePropertyChangedEvent(callerName);
            }
        }
    }
}
