using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;

namespace ShopSample
{
    public class DataBaseHelper
    {
        public DbConnection Connection
        {
            get
            {
                DbProviderFactory factory = DbProviderFactories.GetFactory(
                    ConfigurationManager.ConnectionStrings["shopDb"].ProviderName);

                DbConnection connection = factory.CreateConnection();
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["shopDb"].ConnectionString;

                return connection;
            }
        }

        // Выбрать все заказы
        public List<Order> GetOrders()
        {
            List<Order> orders = new List<Order>();

            using(var connection = Connection)
            {
                connection.Open();

                DbCommand command = connection.CreateCommand();
                command.CommandText = "select * from orders";

                DbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    orders.Add(new Order
                    {
                        Id = (int)reader["id"],
                        CustomerId = (int)reader["idCustomer"],
                        SellerId = (int)reader["idSeller"],
                        Price = (decimal)reader["price"],
                        OrderDate = DateTime.Parse(reader["orderDate"].ToString())
                    });
                }
            }

            return orders;
        }

        // Выбрать всех покупателей
        public List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();

            using (var connection = Connection)
            {
                connection.Open();

                DbCommand command = connection.CreateCommand();
                command.CommandText = "select * from customers";

                DbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    customers.Add(new Customer
                    {
                        Id = (int)reader["id"],
                        FirstName = reader["firstName"].ToString(),
                        SurName = reader["surName"].ToString(),
                    });
                }
            }

            return customers;
        }

        // Выбрать всех продавцов
        public List<Seller> GetSellers()
        {
            List<Seller> sellers = new List<Seller>();

            using (var connection = Connection)
            {
                connection.Open();

                DbCommand command = connection.CreateCommand();
                command.CommandText = "select * from sellers";

                DbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    sellers.Add(new Seller
                    {
                        Id = (int)reader["id"],
                        FirstName = reader["firstName"].ToString(),
                        SurName = reader["surName"].ToString(),
                    });
                }
            }

            return sellers;
        }
    }
}
