using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace CustomersManagement
{
    public class DbHelper
    {
        private readonly string _connectionString;
        public DbHelper()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        }

        //method for Read 
        public List<Customer> GetCustomers()
        {
            var customers = new List<Customer>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "select * from Customer";
                
                using SqlDataReader dataReader = command.ExecuteReader(); 

                int ordId = dataReader.GetOrdinal("Id");
                int ordFirstName = dataReader.GetOrdinal("FirstName");
                int ordLastName = dataReader.GetOrdinal("LastName");
                int ordEmail = dataReader.GetOrdinal("Email");
                int ordPhone = dataReader.GetOrdinal("Phone");
                int ordCreatedAt = dataReader.GetOrdinal("CreatedAt");

                while (dataReader.Read())
                {
                    var customer = new Customer
                    {
                        Id = dataReader.GetInt32(ordId),
                        FirstName = dataReader.GetString(ordFirstName),
                        LastName = dataReader.GetString(ordLastName),
                        Email = dataReader.GetString(ordEmail),
                        Phone =dataReader.IsDBNull(ordPhone)? "" :dataReader.GetString(ordPhone),
                        CreatedAt = dataReader.GetDateTime(ordCreatedAt)
                    };
                    customers.Add(customer);
                }
            }
            return customers;
        }

        //method for Create 
        public void AddCustomer(Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "insert into Customer(FirstName, LastName, Email, Phone)" +
                    "values(@FirstName, @LastName, @Email, @Phone)"; 
                command.Parameters.AddWithValue("@FirstName", customer.FirstName);
                command.Parameters.AddWithValue("@LastName", customer.LastName);
                command.Parameters.AddWithValue("@Email", customer.Email);
                command.Parameters.AddWithValue("@Phone", customer.Phone);

                //maybe we need to open the connection
                command.ExecuteNonQuery();

            }
        }

        //method for Update
        public void UpdateCustomer(Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open(); 
                using SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "update Customer set " +
                    "FirstName=@FirstName, LastName=@LastName, Email=@Email, Phone=@Phone" +
                    " where Id=@Id";

                command.Parameters.AddWithValue("@FirstName", customer.FirstName);
                command.Parameters.AddWithValue("@LastName", customer.LastName);
                command.Parameters.AddWithValue("@Email", customer.Email);
                command.Parameters.AddWithValue("@Phone", customer.Phone);
                command.Parameters.AddWithValue("@Id", customer.Id);

                command.ExecuteNonQuery();
            }
        }

        //method for Delete 
        public void DeleteCustomer(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open(); 
                using SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "delete from Customer where Id=@Id";
                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }
        }
    }
}
