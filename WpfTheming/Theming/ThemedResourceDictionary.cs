using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;

namespace WpfTheming.Theming
{
    public class ThemedResourceDictionary : ResourceDictionary
    {
        private Uri _fallbackSource;

        public ObservableCollection<ThemeUri> Themes { get; } = new ObservableCollection<ThemeUri>();

        public ThemedResourceDictionary()
        {
            ThemeManager.ThemeChanged += ThemeChangedHandler;
            Themes.CollectionChanged += ThemesOnCollectionChanged;
        }

        ~ThemedResourceDictionary()
        {
            ThemeManager.ThemeChanged -= ThemeChangedHandler;
            Themes.CollectionChanged -= ThemesOnCollectionChanged;
        }

        protected override void OnGettingValue(object key, ref object value, out bool canCache)
        {
            base.OnGettingValue(key, ref value, out canCache);
        }

        private void ThemesOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            UpdateSource();
        }

        private void ThemeChangedHandler(object sender, EventArgs e)
        {
            UpdateSource();
        }

        public void UpdateSource()
        {
            Uri theme = Themes?.FirstOrDefault(x => x.Theme == ThemeManager.Theme)?.Source;

            if (_fallbackSource == null)
                _fallbackSource = Source;

            if (theme == null)
                theme = _fallbackSource;

            if (Source == theme)
                return;

            Source = theme;
        }
    }
}
