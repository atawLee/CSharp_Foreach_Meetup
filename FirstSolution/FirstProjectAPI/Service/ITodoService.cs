public interface ITodoService
{
    List<Todo> GetAll();
    Todo Get(int id);
    void Update(int id, Todo todo);
    void Create(Todo todo);
    void Delete(int id);
}