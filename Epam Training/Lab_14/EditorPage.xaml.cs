
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Lab_14
{
    public partial class EditorPage : Page
    {
        private MainWindow MainWindow { get; set; }
        public bool IsSizeSet { get; set; } = false;
        public bool IsColorSet { get; set; } = false;

        public int RectangleWidth { get; set; }
        public int RectangleHeight { get; set; }

        public SolidColorBrush RectangleColor { get; set; }


        public EditorPage(MainWindow mainWindow)
        {
            InitializeComponent();
            MainWindow = mainWindow;
        }


        public void PaintBtnUpdate()
        {
            if (IsSizeSet && IsColorSet) PaintBtn.IsEnabled = true;
        }

        private void BtnClk_Size(object sender, RoutedEventArgs e)
        {
            SizeDialogWindow sizeDialogWindow = new SizeDialogWindow(this);
            sizeDialogWindow.Show();
        }

        private void BtnClk_Color(object sender, RoutedEventArgs e)
        {
            ColorDialogWindow colorDialogWindow = new ColorDialogWindow(this);
            colorDialogWindow.Show();
        }

        private void BtnClk_Paint(object sender, RoutedEventArgs e)
        {
            if ((double)RectangleWidth > Col1.ActualWidth || RectangleHeight > (double)this.ActualHeight) MessageBox.Show("Rectangle is too bug for this window", "Error");
            else
            {
                MainWindow.MinWidth = (double)RectangleWidth + 160;
                MainWindow.MinHeight = (double)RectangleHeight + 80;

                MainRectangle.Width = RectangleWidth;
                MainRectangle.Height = RectangleHeight;

                MainRectangle.Stroke = RectangleColor;
                MainRectangle.Fill = RectangleColor;
            }
        }

        private void BtnClk_Quit(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}
