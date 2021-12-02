using System.Data;
using Microsoft.Data.SqlClient;

namespace API.Repositories;

public class BaseRepository<T>
{
    private readonly IConfiguration _configuration;

    public BaseRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public DataTable ExecuteQuery(string query, Dictionary<string, object> parameters)
    {
        DataTable table = new DataTable();
        using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default")))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = query;
                // add parameters
                foreach (var key in parameters.Keys)
                {
                    command.Parameters.AddWithValue(key, parameters[key]);
                }

                SqlDataReader reader = command.ExecuteReader();
                table.Load(reader);
            }
        }

        return table;
    }
    
}