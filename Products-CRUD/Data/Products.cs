using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Products_CRUD.Entities;
using static System.Net.Mime.MediaTypeNames;

namespace Products_CRUD.Data
{
    internal class Products
    {
        public DataTable list_categories()
        {
            DataTable dataTable = new DataTable();
            ConnectionDB connectionDB = new ConnectionDB();

            using (MySqlConnection connect = connectionDB.getConnect())
            {
                try
                {
                    string query = "SELECT * FROM categories";

                    using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connect))
                    {
                        dataAdapter.Fill(dataTable);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error fetching categories: " + ex.Message);
                    throw;
                }
            }
            return dataTable;
        }

        public DataTable list_products(string text)
        {
            text = "%" + text + "%";
            DataTable dataTable = new DataTable();
            ConnectionDB connectionDB = new ConnectionDB();

            using (MySqlConnection connect = connectionDB.getConnect())
            {
                try
                {
                    string query = @"
                        SELECT p.*, c.name AS nameCategory 
                        FROM products p 
                        INNER JOIN categories c ON p.category_id = c.id 
                        WHERE p.name LIKE @productName AND p.status = 1";

                    using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connect))
                    {
                        dataAdapter.SelectCommand.Parameters.AddWithValue("@productName", text);
                        dataAdapter.Fill(dataTable);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error fetching products: " + ex.Message);
                    throw;
                }
            }
            return dataTable;
        }

        public string save(int option, Product product)
        {
            string reply = "";
            ConnectionDB connectionDB = new ConnectionDB();

            using (MySqlConnection connect = connectionDB.getConnect())
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand("USP_SAVE", connect))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("p_option", option);
                        cmd.Parameters.AddWithValue("p_id", product.id);
                        cmd.Parameters.AddWithValue("p_category_id", product.categoryId);
                        cmd.Parameters.AddWithValue("p_name", product.name);
                        cmd.Parameters.AddWithValue("p_price", product.price);
                        cmd.Parameters.AddWithValue("p_stock", product.stock);
                        cmd.Parameters.AddWithValue("p_status", 1);
                        reply = cmd.ExecuteNonQuery() >= 1 ? "OK" : "could not be saved";
                    }
                }
                catch (Exception ex)
                {
                    reply = "Error saving product: " + ex.Message;
                }
            }
            return reply;
        }

        public string delete(int id)
        {
            string reply = "";
            ConnectionDB connectionDB = new ConnectionDB();

            using (MySqlConnection connect = connectionDB.getConnect())
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand("USP_DELETE", connect))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("p_id", id);
                        reply = cmd.ExecuteNonQuery() >= 1 ? "OK" : "could not be registered";
                    }
                }
                catch (Exception ex)
                {
                    reply = "Error saving product: " + ex.Message;
                }
            }
            return reply;
        }

    }
}
