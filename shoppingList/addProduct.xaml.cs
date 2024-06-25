using MySql.Data.MySqlClient;
using System.Windows;

namespace shoppingList
{
    public partial class addProduct : Window
    {
        private int _shoppingListId;

        public addProduct(int shoppingListId)
        {
            InitializeComponent();
            _shoppingListId = shoppingListId;

            Loaded += AddProduct_Loaded; 
        }

        private void AddProduct_Loaded(object sender, RoutedEventArgs e)
        {
            
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;

            
            double mainWindowLeft = mainWindow.Left;
            double mainWindowTop = mainWindow.Top;
            double mainWindowWidth = mainWindow.Width;
            double mainWindowHeight = mainWindow.Height;

            double addProductWidth = Width;
            double addProductHeight = Height;

            double leftOffset = mainWindowLeft + (mainWindowWidth - addProductWidth) / 2;
            double topOffset = mainWindowTop + (mainWindowHeight - addProductHeight) / 2;

            
            Left = leftOffset;
            Top = topOffset;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string productName = productNameTextBox.Text;

            if (!string.IsNullOrEmpty(productName))
            {
                SaveProductNameToDatabase(productName);
                MessageBox.Show("Produkt został dodany.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Proszę wprowadzić nazwę produktu.");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveProductNameToDatabase(string productName)
        {
            string connectionString = "Server=127.0.0.1;Database=shoppinglistdb;Uid=root;Pwd=;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Products (ProductName, Status, ShoppingListId) VALUES (@ProductName, 0, @ShoppingListId)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductName", productName);
                    command.Parameters.AddWithValue("@ShoppingListId", _shoppingListId);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void productNameTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
