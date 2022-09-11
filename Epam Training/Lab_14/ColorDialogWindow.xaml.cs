
using System.Windows;
using System.Windows.Media;

namespace Lab_14
{
    public partial class ColorDialogWindow : Window
    {
        private int Red { get; set; } = 0;
        private int Green { get; set; } = 0;
        private int Blue { get; set; } = 0;
        private int Alpha { get; set; } = 0;

        private SolidColorBrush PreviewleColor = new SolidColorBrush();

        private EditorPage Editor { get; set; }


        public ColorDialogWindow(EditorPage editor)
        {
            InitializeComponent();
            Editor = editor;
        }


        private void PreviewUpdate()
        {
            PreviewleColor.Color = Color.FromArgb(System.Convert.ToByte(Alpha), System.Convert.ToByte(Red), System.Convert.ToByte(Green), System.Convert.ToByte(Blue));
            ColorPreviewRect.Fill = PreviewleColor;
        }


        private void RValChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Red = (int)(SliderRed.Value * 255 * 0.1);
            PreviewUpdate();
        }

        private void GValChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Green = (int)(SliderGreen.Value * 255 * 0.1);
            PreviewUpdate();
        }

        private void BValChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Blue = (int)(SliderBlue.Value * 255 * 0.1);
            PreviewUpdate();
        }

        private void AValChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Alpha = (int)(SliderAlpha.Value * 255 * 0.1);
            PreviewUpdate();
        }


        private void BtnClk_Ok(object sender, RoutedEventArgs e)
        {
            Editor.RectangleColor = PreviewleColor;
            Editor.IsColorSet = true;
            Editor.PaintBtnUpdate();
            this.Close();
        }

        private void BtnClk_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
