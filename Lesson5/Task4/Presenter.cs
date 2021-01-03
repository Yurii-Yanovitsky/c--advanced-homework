using System;
using System.Windows.Media;

namespace Task4
{
    class Presenter
    {
        private readonly MainWindow _view;
        private readonly Model _model;
        private readonly BrushConverter _converter = new BrushConverter();

        public Presenter(MainWindow view)
        {
            _view = view;
            _model = new Model();
            _view.BackColorChanged += View_BackColorChanged;
            _view.TextColorChanged += View_TextColorChanged;
            _view.TextSizeChanged += View_TextSizeChanged;
            _view.TextFontChanged += View_TextFontChanged;
            _view.SaveSettings += View_SaveSettings;
            _view.WindowLoaded += View_WindowLoaded;
        }

        private void View_WindowLoaded(object sender, EventArgs e)
        {
            _view.TextBox.Background = _model.Settings.BackColor;
            _view.TextBox.Foreground = _model.Settings.TextColor;
            _view.TextBox.FontSize = _model.Settings.FontSize;
            _view.TextBox.FontFamily = _model.Settings.FontStyle;
        }

        private void View_SaveSettings(object sender, EventArgs e)
        {
            _model.Settings.BackColor = _view.TextBox.Background;
            _model.Settings.TextColor = _view.TextBox.Foreground;
            _model.Settings.FontSize = _view.TextBox.FontSize;
            _model.Settings.FontStyle = _view.TextBox.FontFamily;
            _model.Settings.Save();
        }

        private void View_BackColorChanged(object sender, EventArgs e)
        {
            _view.TextBox.Background = (Brush)_converter.ConvertFromString(_view.ColorPickerBack.SelectedColor.Value.ToString());
        }

        private void View_TextColorChanged(object sender, EventArgs e)
        {
            _view.TextBox.Foreground = (Brush)_converter.ConvertFromString(_view.ColorPickerText.SelectedColor.Value.ToString());
        }

        private void View_TextSizeChanged(object sender, EventArgs e)
        {
            _view.TextBox.FontSize = Convert.ToDouble(_view.TextSizes.SelectedValue);
        }

        private void View_TextFontChanged(object sender, EventArgs e)
        {
            _view.TextBox.FontFamily = (FontFamily)_view.TextFonts.SelectedValue;
        }

    }
}
