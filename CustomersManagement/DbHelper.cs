using System.Configuration;
using System.Data;
using System.Diagnostics;
using Microsoft.Data.SqlClient;

namespace CustomersManagement;

public class DbHelper
{
    private readonly string _connectionString;
    public DbHelper()
    {
        _connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
    }

    //Read 
    public async Task<List<Customer>> GetCustomersAsync()
    {
        try
        {
            var customers = new List<Customer>();

            await using var connection = new SqlConnection(_connectionString);

            await connection.OpenAsync();
            const string sql = "SELECT Id, FirstName, LastName, Email, Phone, CreatedAt FROM Customer";

            await using var command = new SqlCommand(sql, connection);

            await using var dataReader = await command.ExecuteReaderAsync();

            if (!dataReader.HasRows)
                return customers;

            int ordId = dataReader.GetOrdinal("Id");
            int ordFirstName = dataReader.GetOrdinal("FirstName");
            int ordLastName = dataReader.GetOrdinal("LastName");
            int ordEmail = dataReader.GetOrdinal("Email");
            int ordPhone = dataReader.GetOrdinal("Phone");
            int ordCreatedAt = dataReader.GetOrdinal("CreatedAt");

            while (await dataReader.ReadAsync())
            {
                var customer = new Customer
                {
                    Id = dataReader.GetInt32(ordId),
                    FirstName = dataReader.GetString(ordFirstName),
                    LastName = dataReader.GetString(ordLastName),
                    Email = dataReader.GetString(ordEmail),
                    Phone = dataReader.IsDBNull(ordPhone) ? null : dataReader.GetString(ordPhone),
                    CreatedAt = dataReader.GetDateTime(ordCreatedAt)
                };
                customers.Add(customer);
            }

            return customers;
        }
        catch (Exception ex)
        {
            Trace.TraceError("GetAllCustomersAsync failed with exception: {0}", ex.Message);
            throw ex;
        }
    }

    //Create 
    public async Task CreateCustomerAsync(Customer customer)
    {
        try
        {
            await using var connection = new SqlConnection(_connectionString);

            await connection.OpenAsync();
            const string sql = @"
INSERT INTO Customer(FirstName, LastName, Email, Phone) 
VALUES(@FirstName, @LastName, @Email, @Phone)";

            await using var command = new SqlCommand(sql, connection);

            var pFirstName = command.Parameters.Add("@FirstName", SqlDbType.VarChar, 50);
            pFirstName.Value = customer.FirstName;

            var pLastName = command.Parameters.Add("@LastName", SqlDbType.VarChar, 50);
            pLastName.Value = customer.LastName;

            var pEmail = command.Parameters.Add("@Email", SqlDbType.VarChar, 100);
            pEmail.Value = customer.Email;

            var pPhone = command.Parameters.Add("@Phone", SqlDbType.VarChar, 20);
            pPhone.Value = customer.Phone is null ? DBNull.Value : customer.Phone;

            await command.ExecuteNonQueryAsync();
        }
        catch (Exception ex)
        {
            Trace.TraceError("Create Customer error: ", ex.Message);
            throw ex;
        }
    }

    //Update
    public async Task UpdateCustomerAsync(Customer customer)
    {
        try
        {
            await using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            const string sql = @"
UPDATE Customer 
SET FirstName=@FirstName, 
LastName=@LastName, 
Email=@Email, 
Phone=@Phone
WHERE Id=@Id";

            await using var command = new SqlCommand(sql, connection);

            var pFirstName = command.Parameters.Add("@FirstName", SqlDbType.VarChar, 50);
            pFirstName.Value = customer.FirstName;

            var pLastName = command.Parameters.Add("@LastName", SqlDbType.VarChar, 50);
            pLastName.Value = customer.LastName;

            var pEmail = command.Parameters.Add("@Email", SqlDbType.VarChar, 100);
            pEmail.Value = customer.Email;

            var pPhone = command.Parameters.Add("@Phone", SqlDbType.VarChar, 20);
            pPhone.Value = customer.Phone is null ? DBNull.Value : customer.Phone;

            var pId = command.Parameters.Add("@Id", SqlDbType.Int);
            pId.Value = customer.Id;

            await command.ExecuteNonQueryAsync();
        }
        catch (Exception ex)
        {
            Trace.TraceError("Update Customer error: ", ex.Message);
            throw ex;
        }
    }

    //Delete 
    public async Task DeleteCustomerAsync(int id)
    {
        try
        {
            await using var connection = new SqlConnection(_connectionString);
            const string sql = "DELETE FROM Customer WHERE Id=@Id";

            await connection.OpenAsync();

            await using var command = new SqlCommand(sql, connection);

            var pId = command.Parameters.Add("@Id", SqlDbType.Int);
            pId.Value = id;

            await command.ExecuteNonQueryAsync();
        }
        catch (Exception ex)
        {
            Trace.TraceError("Delete Customer error: ", ex.Message);
            throw ex;
        }
    }
}
