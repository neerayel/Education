using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace Lab_12
{
    public partial class MainWindow : Window
    {
        public string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Environment.CurrentDirectory + "\\MonitorCatalog.mdf;Integrated Security=True";

        SqlConnection sqlConnection;
        List<Monitor> monitoresList;

        public MainWindow()
        {
            InitializeComponent();
            sqlConnection = new SqlConnection(connectionString);
            GridUpdate();
        }

        public void GridUpdate()
        {
            monitoresList = new List<Monitor>();

            string qry = "SELECT * FROM Monitors";
            var command = new SqlCommand(qry, sqlConnection);
            command.CommandType = CommandType.Text;

            sqlConnection.Open();
            using (SqlDataReader objReader = command.ExecuteReader())
            {
                if (objReader.HasRows)
                {
                    while (objReader.Read())
                    {
                        Monitor newMonitor = new Monitor
                        {
                            ID = objReader.GetInt32(0),
                            Manufacturer = objReader.GetString(1),
                            Model = objReader.GetString(2),
                            Code = objReader.GetString(3),
                            Price = objReader.GetDouble(4),
                            AspectRatio = objReader.GetString(5),
                            Resolution = objReader.GetString(6),
                            Diagonal = objReader.GetDouble(7),
                            FrameRate = objReader.GetInt32(8),
                            Matrix = objReader.GetString(9),
                        };
                        monitoresList.Add(newMonitor);
                    }
                }
            }
            sqlConnection.Close();

            DataGrid.ItemsSource = monitoresList;
        }

        private void BtnClk_Add(object sender, RoutedEventArgs e)
        {
            EditorWindow editorWindow = new EditorWindow(this);
            editorWindow.Show();
        }

        private void BtnClk_Edit(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DataGrid.SelectedItem != null)
                {
                    if (DataGrid.SelectedItem is Monitor)
                    {
                        var row = (Monitor)DataGrid.SelectedItem;

                        if (row != null)
                        {
                            EditorWindow editorWindow = new EditorWindow(this, row);
                            editorWindow.Show();
                        }
                    }
                }
            }
            catch { }
        }

        private void BtnClk_Delete(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DataGrid.SelectedItem != null)
                {
                    if (DataGrid.SelectedItem is Monitor)
                    {
                        var row = (Monitor)DataGrid.SelectedItem;

                        if (row != null)
                        {
                            SqlCommand command = new SqlCommand("DELETE FROM Monitors WHERE ID=@id");
                            command.Parameters.AddWithValue("@id", row.ID);
                            command.Connection = sqlConnection;
                            command.CommandType = CommandType.Text;

                            sqlConnection.Open();
                            command.ExecuteNonQuery();
                            MessageBox.Show("Данные удалены", "Внимание");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении\n" + $"({ ex.Message})", "Ошибка");
            }

            sqlConnection.Close();
            GridUpdate();
        }

        private void BtnClk_Exit(object sender, RoutedEventArgs e)
        {
            sqlConnection.Close();
            Close();
        }
    }
}
