namespace Domain.Interfaces.Generics;

public interface IGeneric<T> where T : class    
{
    Task Add(T obj);
    Task update(T obj);
    Task Delete(T obj);
    Task<T> GetById(int id);
    Task<List<T>> List();
}
