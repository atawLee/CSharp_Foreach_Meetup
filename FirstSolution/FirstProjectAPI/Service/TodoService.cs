public class TodoService : ITodoService
{
    Dictionary<int, Todo> todos = new(16);
    // Todo All
    public List<Todo> GetAll()
    {
        return todos.Values.ToList();
    }
    
    // Todo Get Id
    public Todo Get(int id)
    {
        if (false == todos.ContainsKey(id))
        {
            throw new Exception("Not Found");
        }
        
        return todos[id];
    }
    
    // Update 
    public void Update(int id, Todo todo)
    {
        if (false == todos.ContainsKey(id))
        {
            throw new Exception("Not Found");
        }
        
        todos[id] = todo;
    }
    
    //Create
    public void Create(Todo todo)
    {
        todo.ID = todos.Count + 1;
        todos.Add(todo.ID, todo);
    }
    
    //Delete
    public void Delete(int id)
    {
        if (false == todos.ContainsKey(id))
        {
            throw new Exception("Not Found");
        }
        
        todos.Remove(id);
    }
}