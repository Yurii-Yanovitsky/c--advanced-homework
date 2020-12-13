using System;
using System.Windows.Media;

namespace Task4
{
    class Presenter
    {
        private readonly MainWindow _view;
        private readonly Model _model;
        public Presenter(MainWindow view)
        {
            _view = view;
            _model = new Model();
            _view.WindowLoad += View_WindowLoad;
            _view.SelectColor += View_SelectColor;
            _view.SaveColor += View_SaveColor;
        }
        private void View_WindowLoad(object sender, EventArgs e)
        {
            string color = _model.GetColorFromStorage();
            if (!string.IsNullOrEmpty(color))
            {
                _view.Label.Background = (Brush)new BrushConverter().ConvertFrom(color);
            }
        }

        private void View_SelectColor(object sender, EventArgs e)
        {

            _view.Label.Background = (Brush)new BrushConverter().ConvertFrom(_view.ColorPicker.SelectedColorText);
        }

        private void View_SaveColor(object sender, EventArgs e)
        {
            if (_view.ColorPicker.SelectedColor.HasValue)
            {
                _view.InfoTextBox.Text = _model.SaveColorToStorage(_view.ColorPicker.SelectedColorText);
            }
        }
    }
}
