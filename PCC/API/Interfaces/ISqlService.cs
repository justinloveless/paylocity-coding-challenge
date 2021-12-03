using System.Data;

namespace API.Interfaces;

public interface ISqlService
{
    public DataTable ExecuteSingle(string query, Dictionary<string, object> parameters);
    public void AddQuery(string query, Dictionary<string, object> parameters);
    public void SaveChanges();
    public void CancelChanges();
}