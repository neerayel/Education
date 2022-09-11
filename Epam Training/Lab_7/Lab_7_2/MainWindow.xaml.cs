
using System.Windows;

namespace Lab_7_2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Addition(object sender, RoutedEventArgs e)
        {
            Polynomial pol1 = new Polynomial(InputField1.Text, InputVar.Text[0]);
            Polynomial pol2 = new Polynomial(InputField2.Text, InputVar.Text[0]);
            Polynomial result = pol1 + pol2;

            ResultField.Text = result.TextView_AfterSum();
        }

        private void Button_Subtraction(object sender, RoutedEventArgs e)
        {
            Polynomial pol1 = new Polynomial(InputField1.Text, InputVar.Text[0]);
            Polynomial pol2 = new Polynomial(InputField2.Text, InputVar.Text[0]);
            Polynomial result = pol1 - pol2;

            ResultField.Text = result.TextView_AfterSum();
        }

        private void Button_Multiplication(object sender, RoutedEventArgs e)
        {
            Polynomial pol1 = new Polynomial(InputField1.Text, InputVar.Text[0]);
            Polynomial pol2 = new Polynomial(InputField2.Text, InputVar.Text[0]);
            Polynomial result = pol1 * pol2;

            ResultField.Text = result.TextView_AfterSum();
        }
    }
}
