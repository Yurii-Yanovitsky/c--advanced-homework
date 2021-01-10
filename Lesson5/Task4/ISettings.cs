using System.Windows.Media;

namespace Task4
{
    public interface ISettings
    {
        Brush BackColor { get; set; }
        Brush TextColor { get; set; }
        double FontSize { get; set; }
        FontFamily FontStyle { get; set; }
        void Save();
    }
}
