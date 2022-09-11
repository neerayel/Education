
using System.Windows;

namespace Lab_14
{
    public partial class SizeDialogWindow : Window
    {
        private EditorPage Editor { get; set; }

        public SizeDialogWindow(EditorPage editor)
        {
            InitializeComponent();
            Editor = editor;
        }

        private void BtnClk_Ok(object sender, RoutedEventArgs e)
        {
            int width = 0;
            int height = 0;

            if (!int.TryParse(TBWidth.Text.Trim(), out width)) WidthError.Text = "Width must be an integer";
            else if (width == 0) WidthError.Text = "Width can not be 0";
            else WidthError.Text = "";

            if (!int.TryParse(TBHeight.Text.Trim(), out height)) HeightError.Text = "Height must be an integer";
            else if (height == 0) HeightError.Text = "Height can not be 0";
            else HeightError.Text = "";

            if (width != 0 && height != 0)
            {
                WidthError.Text = "";
                HeightError.Text = "";

                if (width < 0) width *= -1;
                if (height < 0) height *= -1;

                Editor.RectangleWidth = width;
                Editor.RectangleHeight = height;
                Editor.IsSizeSet = true;
                Editor.PaintBtnUpdate();
                this.Close();
            }
        }

        private void BtnClk_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
