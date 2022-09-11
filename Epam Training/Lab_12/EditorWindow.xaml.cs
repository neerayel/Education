using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace Lab_12
{
    public partial class EditorWindow : Window
    {
        SqlConnection sqlConnection;
        MainWindow mainWindow;
        Monitor? selectedRow = null;

        public EditorWindow(MainWindow mainWind)
        {
            InitializeComponent();
            this.mainWindow = mainWind;

            Manufacturer.IsReadOnly = false;
            Model.IsReadOnly = false;
        }

        public EditorWindow(MainWindow mainWind, Monitor row)
        {
            InitializeComponent();
            this.mainWindow = mainWind;
            this.selectedRow = row;

            Manufacturer.Text = selectedRow.Manufacturer;
            Model.Text = selectedRow.Model;
            Code.Text = selectedRow.Code;
            Price.Text = selectedRow.Price.ToString();
            AspectRatio.Text = selectedRow.AspectRatio;
            Resolution.Text = selectedRow.Resolution;
            Diagonal.Text = selectedRow.Diagonal.ToString();
            FrameRate.Text = selectedRow.FrameRate.ToString();
            Matrix.Text = selectedRow.Matrix;

            Manufacturer.IsReadOnly = true;
            Model.IsReadOnly = true;
        }

        private void BtnClk_OK(object sender, RoutedEventArgs e)
        {
            sqlConnection = new SqlConnection(mainWindow.connectionString);
            SqlCommand command;
            if (selectedRow != null)
            {
                string parameterized = "AssemblyCode = (@code), Price = (@price), AspectRatio = (@aspectratio), Resolution = (@resolution), Diagonal = (@diagonal), Framerate = (@framerate), Matrix = (@matrix)";
                command = new SqlCommand("Update Monitors SET " + parameterized + " WHERE ID=@id");
                command.Parameters.AddWithValue("@id", selectedRow.ID);
            }
            else
            {
                command = new SqlCommand("INSERT INTO Monitors " +
                                                    "VALUES (@manufact, @model, @code, @price, @aspectratio, @resolution, @diagonal, @framerate, @matrix)");
            }
            command.Connection = sqlConnection;
            command.CommandType = CommandType.Text;


            if (string.IsNullOrWhiteSpace(Manufacturer.Text)) { MessageBox.Show("Поле Производитель не должно быть пустым", "Внимание"); return; }
            if (string.IsNullOrWhiteSpace(Model.Text)) { MessageBox.Show("Поле Модель не должно быть пустым", "Внимание"); return; }
            if (string.IsNullOrWhiteSpace(Code.Text)) Code.Text = "N/A";
            if (string.IsNullOrWhiteSpace(Price.Text)) Price.Text = "0.0";
            if (string.IsNullOrWhiteSpace(AspectRatio.Text)) AspectRatio.Text = "N/A";
            if (string.IsNullOrWhiteSpace(Resolution.Text)) Resolution.Text = "N/A";
            if (string.IsNullOrWhiteSpace(Diagonal.Text)) Diagonal.Text = "0.0";
            if (string.IsNullOrWhiteSpace(FrameRate.Text)) FrameRate.Text = "0";
            if (string.IsNullOrWhiteSpace(Matrix.Text)) Matrix.Text = "N/A";

            try
            {
                command.Parameters.AddWithValue("@manufact", Manufacturer.Text);
                command.Parameters.AddWithValue("@model", Model.Text);
                command.Parameters.AddWithValue("@code", Code.Text);
                command.Parameters.AddWithValue("@price", float.Parse(Price.Text.Replace('.', ',')));
                command.Parameters.AddWithValue("@aspectratio", AspectRatio.Text);
                command.Parameters.AddWithValue("@resolution", Resolution.Text);
                command.Parameters.AddWithValue("@diagonal", float.Parse(Diagonal.Text.Replace('.', ',')));
                command.Parameters.AddWithValue("@framerate", int.Parse(FrameRate.Text));
                command.Parameters.AddWithValue("@matrix", Matrix.Text);

                sqlConnection.Open();

                command.ExecuteNonQuery();

                if (selectedRow != null) MessageBox.Show("Данные Изменены", "Внимание");
                else MessageBox.Show("Данные добавлены", "Внимание");

                mainWindow.GridUpdate();

                sqlConnection.Close();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Неверное значение\n" + $"({ ex.Message})", "Ошибка");
            }
        }

        private void BtnClk_Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
