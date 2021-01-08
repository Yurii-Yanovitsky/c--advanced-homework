using System;
using System.Threading;

namespace AdditionalTask1
{
    class Program
    {
        static void Main(string[] args)
        {
            var thread = new ThreadWithResult<int>(() => 10);

            Console.WriteLine($"Result: {thread.Result}");

            thread.Start();

            Console.WriteLine($"Result: {thread.Result}");

            Console.ReadLine();
        }
    }

    class ThreadWithResult<TResult>
    {
        private Thread _thread;
        private TResult _result;

        public ThreadWithResult(Func<TResult> action)
        {
            _thread = new Thread(() =>
            {
                try
                {
                    _result = action();
                    IsSuccess = true;
                }
                catch (Exception ex)
                {
                    Exception = ex;
                    IsSuccess = false;
                }
                finally
                {
                    IsCompleted = true;
                }

            });
        }

        public bool IsCompleted { get; private set; }
        public bool IsStarted { get; private set; }
        public bool IsSuccess { get; private set; }
        public Exception Exception { get; private set; }
        public TResult Result
        {
            get
            {
                if (IsCompleted)
                {
                    return IsSuccess ? _result : throw Exception;
                }
                else
                {
                    if (IsStarted)
                    {
                        Wait();
                        return Result;
                    }
                    else
                    {
                        return default;
                    }
                }
            }
        }

        public void Start()
        {
            IsStarted = true;
            _thread.Start();
        }

        private void Wait()
        {
            while (!IsCompleted)
            {
                Console.Write("*");
            }

            Console.WriteLine();
        }
    }
}