using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Windows;

namespace AdditionalTask
{
    class Presenter
    {
        private MainWindow _view;
        private FibonacchiCalculator _calculator;
        private SynchronizationContext _sync;

        public Presenter(MainWindow view)
        {
            _view = view;
            _calculator = new FibonacchiCalculator();
            _view.EndClick += View_End_Click;
            _view.CallBackCLick += View_CallBack_CLick;
            _view.IsCompletdClick += View_IsCompletdClick;
        }

        private void View_IsCompletdClick(object sender, EventArgs e)
        {
            _sync = SynchronizationContext.Current;

            var valid = ArgsValidation();

            if (!valid.xIsCorrect)
            {
                return;
            }

            var asyncResult = _calculator.BeginInvoke(valid.Count, CallBack, new Action(ProgressBarChanged));

            if (!asyncResult.IsCompleted)
            {
                _view.TextResult.Text = "In processing...";
            }
        }

        private void View_CallBack_CLick(object sender, EventArgs e)
        {
            _sync = SynchronizationContext.Current;

            var valid = ArgsValidation();
            if (!valid.xIsCorrect)
            {
                return;
            }

            _calculator.BeginInvoke(valid.Count, CallBack, new Action(ProgressBarChanged));
        }

        private void View_End_Click(object sender, EventArgs e)
        {
            var valid = ArgsValidation();

            if (!valid.xIsCorrect)
            {
                return;
            }

            var asyncResult = _calculator.BeginInvoke(valid.Count, null, null);

            var result = _calculator.EndInvoke(asyncResult);

            _view.TextResult.Text = string.Join(", ", result);
        }

        private (bool xIsCorrect, int Count) ArgsValidation()
        {
            bool xIsCorrect = int.TryParse(_view.InputText.Text, out int Count);

            if (!(xIsCorrect))
            {
                MessageBox.Show("Args invalid");
                return (false, 0);
            }
            return (xIsCorrect, Count);
        }

        private void CallBack(IAsyncResult asyncResult)
        {
            var func = ((AsyncResult)asyncResult).AsyncDelegate as Func<List<int>>;

            var result = _calculator.EndInvoke(asyncResult);

            _sync.Post(delegate
            {
                _view.TextResult.Text = string.Join(", ", result);
            }, null);
        }

        private void ProgressBarChanged()
        {
            _sync.Post(delegate
            {
                _view.ProgressBar.Maximum = double.Parse(_view.InputText.Text);

                _view.ProgressBar.Value++;

                if (_view.ProgressBar.Value == _view.ProgressBar.Maximum)
                {
                    _view.ProgressBar.Value = 0;
                }

            }, null);
        }
    }

}
