using System.Data;
using API.Interfaces;
using Microsoft.Data.SqlClient;

namespace API.Services;

public class SqlService : ISqlService, IDisposable
{
    private readonly IConfiguration _configuration;
    // private readonly ILogger _logger;
    private readonly SqlConnection _connection;
    private readonly List<SqlCommand> _commands;
    private SqlTransaction? _transaction;

    public SqlService(IConfiguration configuration)
    {
        _configuration = configuration;
        // _logger = logger;
        _connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        _connection.Open();
        _commands = new List<SqlCommand>();
        _transaction = null;
    }
    public DataTable ExecuteSingle(string query, Dictionary<string, object> parameters)
    {
        DataTable table = new DataTable();

        using (SqlCommand command = new SqlCommand())
        {
            command.Connection = _connection;
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

        return table;
    }

    public void AddQuery(string query, Dictionary<string, object> parameters)
    {
        SqlCommand command = new SqlCommand();
        
        if (_transaction == null)
        {
            _transaction = _connection.BeginTransaction("mainTransaction");
        }

        command.Connection = _connection;
        command.Transaction = _transaction;
        command.CommandText = query;
        // add parameters
        foreach (var key in parameters.Keys)
        {
            command.Parameters.AddWithValue(key, parameters[key]);
        }
        
        // do not execute. Save to list for later
        _commands.Add(command);
    }

    public void SaveChanges()
    {
        try
        {
            foreach (var command in _commands)
            {
                command.ExecuteNonQuery();
            }

            if (_transaction != null)
            {
                _transaction.Commit();
            }
        }
        catch (Exception)
        {
            // _logger.LogError(ex, "unable to complete transaction. Rolling back");
            if (_transaction != null)
            {
                try
                {
                    _transaction.Rollback();
                }
                catch (Exception)
                {
                    // _logger.LogError(ex2, "Unable to rollback transaction. Has the connection closed?");
                }
            }
        }
    }

    public void CancelChanges()
    {
        if (_transaction == null) return;
        try
        {
            _transaction.Rollback();
        }
        catch (Exception)
        {
            // _logger.LogError(ex2, "Unable to rollback transaction. Has the connection closed?");
        }
    }

    public void Dispose()
    {
        _connection.Dispose();
    }
}