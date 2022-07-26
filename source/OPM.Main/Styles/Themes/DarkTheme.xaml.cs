using Avalonia.Markup.Xaml;
using AvaloniaStyles = Avalonia.Styling.Styles;

namespace OPM.Styles.Themes
{
    public class DarkTheme : AvaloniaStyles
    {
        public DarkTheme() => AvaloniaXamlLoader.Load(this);
    }
}
