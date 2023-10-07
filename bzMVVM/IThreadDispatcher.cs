using System;
using System.Collections.Generic;
using System.Text;

namespace bzMVVM
{
    public interface IThreadDispatcher
    {
        void ExecuteOnUIThread(Action action);
    }
}
