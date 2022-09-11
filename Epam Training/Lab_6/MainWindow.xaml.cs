using System.Windows;
using System.Windows.Navigation;

namespace Lab_6
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
        }

        private Window Task4 = new Window4();
        private Page1 p1 = new Page1();
        private Page2 p2 = new Page2();
        private Page3 p3 = new Page3();

        private void Button_1_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = p1;
        }

        private void Button_2_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = p2;
        }

        private void Button_3_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = p3;
        }

        private void Button_4_Click(object sender, RoutedEventArgs e)
        {
            Task4 = new Window4();
            Task4.Show();
        }

        private void OnClosing(object sender, System.EventArgs e)
        {
            Task4.Close();
            Application.Current.Shutdown();
        }
    }
}
