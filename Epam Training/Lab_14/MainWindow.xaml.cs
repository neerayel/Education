
using System.Windows;
using System.Windows.Navigation;

namespace Lab_14
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            MainFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;

            LoginPage loginPage = new LoginPage(this);
            MainFrame.Content = loginPage;
        }

    }
}
