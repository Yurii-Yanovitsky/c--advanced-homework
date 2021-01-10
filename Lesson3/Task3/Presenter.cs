using System;

namespace Task3
{
    class Presenter
    {
        private MainWindow _view;
        private Model _model;
        public Presenter(MainWindow view)
        {
            _view = view;
            _model = new Model();
            _view.Search += _view_Search;
            _view.ShowContent += _view_ShowContent;
            _view.Compress += _view_Compress;
        }

        private void _view_Compress(object sender, EventArgs e)
        {
            if (_model.IsPath)
            {
                _view.ResultTextBox.Text = $"Файл был сжат и сохранен по пути {_model.CompressFile()}";

            }
        }

        private void _view_ShowContent(object sender, EventArgs e)
        {
            if (_model.IsPath)
            {
                _view.ResultTextBox.Text = _model.ShowFileContent();
            }
        }

        private void _view_Search(object sender, EventArgs e)
        {
            string fileName = _view.InputTextButton.Text;
            string dir = _view.drivesList.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(dir) && !string.IsNullOrEmpty(fileName))
            {
                if (_model.SearchFile(dir, fileName))
                {
                    _view.ResultTextBox.Text = $"Файл найден: {_model.FilePath}";
                }
                else
                {
                    _view.ResultTextBox.Text = "Файл не найден!";
                }
            }
        }
    }
}
