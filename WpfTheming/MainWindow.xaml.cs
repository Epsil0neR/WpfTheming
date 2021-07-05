using System.Windows;
using System.Windows.Controls;
using WpfTheming.Theming;

namespace WpfTheming
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnTheme_OnClick(object sender, RoutedEventArgs e)
        {
            if ((sender as FrameworkElement)?.Tag is Theme theme)
                ThemeManager.Theme = theme;
        }
    }
}
