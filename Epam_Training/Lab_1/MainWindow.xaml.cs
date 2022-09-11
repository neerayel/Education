using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;

namespace Lab_1
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

        private string LineSplitter(string line)
        {
            string result = "";

            if (!String.IsNullOrWhiteSpace(line))
            {
                int position = line.IndexOf(",");

                line = line.Replace(".", ",");

                if (position < 0)
                {
                    result = $"X: {line}";
                }
                else
                {
                    result = $"X: {line.Substring(0, position)} Y: {line.Substring(position + 1)}";
                }
            }

            return result;
        }

        private void ConvertToXY(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            string inputLine = "";
            string outputLine = "";

            if (String.IsNullOrWhiteSpace(inputText.Text))
            {
                outputText.Clear();
                return;
            }

            for (int i = 0; i < inputText.LineCount; i++)
            {
                inputLine = inputText.GetLineText(i);
                outputLine += LineSplitter(inputLine);
                outputText.Clear();
                outputText.Text += outputLine;
            }
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

        private void SpawnExample(object sender, RoutedEventArgs e)
        {
            inputText.Text = "23.8976,12.3218\n25.7639,11.9463\n24.8293,12.2134\n";
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
