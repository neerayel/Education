using Microsoft.Win32;
using System.Text.RegularExpressions;
using System.IO;
using System.Windows;

namespace Lab_11
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        // Window menu options
        private void OpenFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                inputText.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void SaveToFile(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, outputText.Text);
            }
        }

        private void CloseProgram(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ClearAllText(object sender, RoutedEventArgs e)
        {
            inputText.Text = "";
        }

        private void ConvertText(object sender, RoutedEventArgs e)
        {
            string inputStr = inputText.Text;

            Regex regex = new Regex(@"\w+", RegexOptions.IgnoreCase);
            MatchCollection matches = regex.Matches(inputStr);
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    string temp = "";
                    for (int i = match.Value.Length - 1; i >= 0; i--)
                    {
                        temp += match.Value[i];
                    }
                    inputStr = inputStr.Replace(match.Value, temp);
                }
            }

            outputText.Text = inputStr.Trim();
        }


        // Context menu options
        private void InputContextCopySelected(object sender, RoutedEventArgs e)
        {
            string txt = inputText.SelectedText;
            Clipboard.SetText(txt);
        }

        private void OutputContextCopySelected(object sender, RoutedEventArgs e)
        {
            string txt = outputText.SelectedText;
            Clipboard.SetText(txt);
        }

        private void InputContextPaste(object sender, RoutedEventArgs e)
        {
            string txt = Clipboard.GetText();
            inputText.SelectedText = txt;
        }

        private void InputContextCutSelected(object sender, RoutedEventArgs e)
        {
            string txt = inputText.SelectedText;
            Clipboard.SetText(txt);
            inputText.SelectedText = "";
        }

        private void InputContextDelSelected(object sender, RoutedEventArgs e)
        {
            inputText.SelectedText = "";
        }
    }
}
