using MySql.Data.MySqlClient;
using System;
using System.Windows;

namespace shoppingList
{
    public partial class createList : Window
    {
        public createList()
        {
            InitializeComponent();
            Loaded += CreateList_Loaded; // Subscribe to the Loaded event
        }

        private void CreateList_Loaded(object sender, RoutedEventArgs e)
        {
            // Get the MainWindow instance
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;

            // Calculate the center position
            double mainWindowLeft = mainWindow.Left;
            double mainWindowTop = mainWindow.Top;
            double mainWindowWidth = mainWindow.Width;
            double mainWindowHeight = mainWindow.Height;

            double createListWidth = Width;
            double createListHeight = Height;

            double leftOffset = mainWindowLeft + (mainWindowWidth - createListWidth) / 2;
            double topOffset = mainWindowTop + (mainWindowHeight - createListHeight) / 2;

            // Set the position of the createList window
            Left = leftOffset;
            Top = topOffset;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string listName = ListNameTextBox.Text;

            if (!string.IsNullOrEmpty(listName))
            {
                SaveListNameToDatabase(listName);
                MessageBox.Show("Lista została utworzona.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Proszę wprowadzić nazwę listy.");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveListNameToDatabase(string listName)
        {
            string connectionString = "Server=127.0.0.1;Database=shoppinglistdb;Uid=root;Pwd=;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO ShoppingLists (Name, CreationTime) VALUES (@Name, @CreationTime)";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", listName);
                    command.Parameters.AddWithValue("@CreationTime", DateTime.Now);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
