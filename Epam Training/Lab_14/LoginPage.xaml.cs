
using System.Windows;
using System.Windows.Controls;

namespace Lab_14
{
    public partial class LoginPage : Page
    {
        string Login { get; } = "ShumilovAN";
        int Option { get; } = 22;

        MainWindow MainWindow { get; set; }

        public LoginPage(MainWindow mainWindow)
        {
            InitializeComponent();
            this.MainWindow = mainWindow;
        }

        private void BtnClk_LogIn(object sender, RoutedEventArgs e)
        {
            if (InputTextbox.Text.Trim() == Login)
            {
                EditorPage editorPage = new EditorPage(MainWindow);

                MainWindow.Title = Login + "_" + Option.ToString();
                MainWindow.MainFrame.Content = editorPage;
            }
            else WrongInputWarn.Opacity = 1;
        }

        private void InputTB_Changed(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(InputTextbox.Text))
            {
                InputTextbox.Opacity = 0.2;
            }
            else InputTextbox.Opacity = 1;
        }
    }
}
