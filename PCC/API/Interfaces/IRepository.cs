namespace API.Interfaces;

public interface IRepository<T>
{
    public int Create(T entity);
    public IEnumerable<T>? GetAll();
    public T? Get(int id);
    public void Update(int id, T entity);
    public void Delete(int id);
}