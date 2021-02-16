using System;
using System.Collections.Generic;

namespace AdditionalTask
{
    class FibonacchiCalculator
    {
        private int _count;
        private List<int> _fibonacchiSequence;
        private readonly Func<List<int>> _func;
        private Action _actionProgress; // прогресс выполнения расчета

        public FibonacchiCalculator()
        {
            _func = Calculate;
        }

        // Синхронный вызов
        public List<int> Invoke(int count)
        {
            _count = count;
            return _func.Invoke();
        }

        // Асинхронный вызов
        public IAsyncResult BeginInvoke(int count, AsyncCallback callback, object state)
        {
            _count = count;
            _actionProgress = state as Action;
            return _func.BeginInvoke(callback, state);
        }

        public List<int> EndInvoke(IAsyncResult asyncResult)
        {
            return _func.EndInvoke(asyncResult);
        }

        private List<int> Calculate()
        {
            _fibonacchiSequence = new List<int>();

            Func<int, int> fib = null;

            fib = (x) => x > 1 ? fib(x - 1) + fib(x - 2) : x;

            for (int i = 0; i < _count; i++)
            {
                _fibonacchiSequence.Add(fib.Invoke(i));
                _actionProgress?.Invoke();
            }

            return _fibonacchiSequence;
        }





    }
}
