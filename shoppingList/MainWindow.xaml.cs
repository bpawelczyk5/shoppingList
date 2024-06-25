using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace shoppingList
{
    public partial class MainWindow : Window
    {
        private int currentShoppingListId;

        public MainWindow()
        {
            InitializeComponent();
            LoadShoppingLists();
        }
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            createList createListWindow = new createList();
            createListWindow.ShowDialog();
            LoadShoppingLists(); // Refresh the list after creating a new one
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentShoppingListId != 0)
            {
                addProduct addProductWindow = new addProduct(currentShoppingListId);
                addProductWindow.ShowDialog();
                LoadProductList(currentShoppingListId); // Refresh the product list after adding a new product
            }
            else
            {
                MessageBox.Show("Proszę wybrać listę zakupów.");
            }
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentShoppingListId != 0)
            {
                var result = MessageBox.Show("Czy na pewno chcesz usunąć tę listę zakupów?", "Usuń listę", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    DeleteShoppingList(currentShoppingListId);

                    // Reset current shopping list id
                    currentShoppingListId = 0;

                    // Hide product list and related buttons, show shopping lists
                    ProductListBox.Visibility = Visibility.Hidden;
                    BackButton.Visibility = Visibility.Hidden;
                    ShoppingListBox.Visibility = Visibility.Visible;

                    createButton.Visibility = Visibility.Visible;
                    AddButton.Visibility = Visibility.Hidden;
                    DeleteButton.Visibility = Visibility.Hidden;

                    // Refresh the list of shopping lists
                    LoadShoppingLists();
                }
            }
        }
        private void LoadShoppingLists()
        {
            ShoppingListBox.Items.Clear();
            string connectionString = "Server=127.0.0.1;Database=shoppinglistdb;Uid=root;Pwd=;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Id, Name, CreationTime FROM ShoppingLists";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ShoppingListBox.Items.Add(new
                            {
                                Id = reader.GetInt32("Id"),
                                Name = reader.GetString("Name"),
                                CreationTime = reader.GetDateTime("CreationTime").ToString("g")
                            });
                        }
                    }
                }
            }
        }

        private void ShoppingListBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (ShoppingListBox.SelectedItem != null)
            {
                dynamic selectedItem = ShoppingListBox.SelectedItem;
                currentShoppingListId = selectedItem.Id;
                LoadProductList(currentShoppingListId);
                ShoppingListBox.Visibility = Visibility.Hidden;
                ProductListBox.Visibility = Visibility.Visible;
                BackButton.Visibility = Visibility.Visible;

                createButton.Visibility = Visibility.Hidden;
                AddButton.Visibility = Visibility.Visible;
                DeleteButton.Visibility = Visibility.Visible;
            }
        }

        private void LoadProductList(int shoppingListId)
        {
            ProductListBox.Items.Clear();
            string connectionString = "Server=127.0.0.1;Database=shoppinglistdb;Uid=root;Pwd=;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Id, ProductName, Status FROM Products WHERE ShoppingListId = @ShoppingListId";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ShoppingListId", shoppingListId);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProductListBox.Items.Add(new ProductItem
                            {
                                Id = reader.GetInt32("Id"),
                                ProductName = reader.GetString("ProductName"),
                                Status = reader.GetBoolean("Status")
                            });
                        }
                    }
                }
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            ProductListBox.Visibility = Visibility.Hidden;
            BackButton.Visibility = Visibility.Hidden;
            ShoppingListBox.Visibility = Visibility.Visible;

            createButton.Visibility = Visibility.Visible;
            AddButton.Visibility = Visibility.Hidden;
            DeleteButton.Visibility = Visibility.Hidden;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox != null)
            {
                ProductItem product = checkBox.DataContext as ProductItem;
                if (product != null)
                {
                    UpdateProductStatus(product.Id, true);
                    checkBox.IsEnabled = false; 
                }
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox != null)
            {
                // Prevent unchecking the checkbox
                checkBox.IsChecked = true;
            }
        }

        private void UpdateProductStatus(int productId, bool status)
        {
            string connectionString = "Server=127.0.0.1;Database=shoppinglistdb;Uid=root;Pwd=;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Products SET Status = @Status WHERE Id = @ProductId";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Status", status);
                    command.Parameters.AddWithValue("@ProductId", productId);
                    command.ExecuteNonQuery();
                }
            }
        }
        private void DeleteShoppingList(int shoppingListId)
        {
            string connectionString = "Server=127.0.0.1;Database=shoppinglistdb;Uid=root;Pwd=;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM ShoppingLists WHERE Id = @ShoppingListId";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ShoppingListId", shoppingListId);
                    command.ExecuteNonQuery();
                }
            }

            DeleteProductsByShoppingListId(shoppingListId);
        }

        private void DeleteProductsByShoppingListId(int shoppingListId)
        {
            string connectionString = "Server=127.0.0.1;Database=shoppinglistdb;Uid=root;Pwd=;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Products WHERE ShoppingListId = @ShoppingListId";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ShoppingListId", shoppingListId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public class ProductItem
        {
            public int Id { get; set; }
            public string ProductName { get; set; }
            public bool Status { get; set; }
        }

    }
}