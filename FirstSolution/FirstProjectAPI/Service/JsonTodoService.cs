using System.Text.Json;  
  
  
namespace FirstProject.Service;

public class JsonTodoService : ITodoService
{
    private Dictionary<int, Todo> todoMap = new(16);
    private const string FilePath = "todos.json";

    public JsonTodoService()
    {
        LoadFromFile();
    }

    // 모든 Todo 가져오기  
    public List<Todo> GetAll()
    {
        return todoMap.Values.ToList();
    }

    // 특정 Todo 가져오기  
    public Todo Get(int id)
    {
        return todoMap.TryGetValue(id, out var todo) ? todo : throw new Exception("Todo not found");
    }

    public void Update(int id, Todo todo)
    {
        if (!todoMap.ContainsKey(id))
            throw new Exception("Todo not found");

        todoMap[id] = todo;
        SaveToFile();
    }

    // Todo 생성  
    public void Create(Todo todo)
    {
        if (todoMap.ContainsKey(todo.ID))
            throw new Exception("Todo ID already exists");

        todoMap.Add(todo.ID, todo);
        SaveToFile();
    }

    // Todo 삭제  
    public void Delete(int id)
    {
        if (!todoMap.Remove(id))
            throw new Exception("Todo not found");

        SaveToFile();
    }

    // ✅ JSON 파일 저장  
    private void SaveToFile()
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        File.WriteAllText(FilePath, JsonSerializer.Serialize(todoMap, options));
    }

    // ✅ JSON 파일 로드  
    private void LoadFromFile()
    {
        if (File.Exists(FilePath))
        {
            string json = File.ReadAllText(FilePath);
            var data = JsonSerializer.Deserialize<Dictionary<int, Todo>>(json);
            if (data != null)
                todoMap = data;
        }
    }
}