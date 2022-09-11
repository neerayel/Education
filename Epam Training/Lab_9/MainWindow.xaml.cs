using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;

namespace Lab_9
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
                File.WriteAllText(saveFileDialog.FileName, inputText.Text);
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


        // Context menu options
        private void ContextCopySelected(object sender, RoutedEventArgs e)
        {
            string txt = inputText.SelectedText;
            Clipboard.SetText(txt);
        }

        private void ContextPaste(object sender, RoutedEventArgs e)
        {
            string txt = Clipboard.GetText();
            inputText.SelectedText = txt;
        }

        private void ContextCutSelected(object sender, RoutedEventArgs e)
        {
            string txt = inputText.SelectedText;
            Clipboard.SetText(txt);
            inputText.SelectedText = "";
        }

        private void ContextDelSelected(object sender, RoutedEventArgs e)
        {
            inputText.SelectedText = "";
        }
    }
}
