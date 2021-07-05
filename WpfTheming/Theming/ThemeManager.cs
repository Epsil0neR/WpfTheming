using System;

namespace WpfTheming.Theming
{
    public static class ThemeManager
    {
        private static Theme _theme = Theme.Red;
        public static event EventHandler ThemeChanged;

        public static Theme Theme
        {
            get => _theme;
            set
            {
                _theme = value;
                ThemeChanged?.Invoke(null, EventArgs.Empty);
            }
        }
    }
}