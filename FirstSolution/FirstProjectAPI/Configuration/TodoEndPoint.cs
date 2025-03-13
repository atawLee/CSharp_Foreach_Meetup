using Microsoft.AspNetCore.Mvc;

public static class TodoEndPoint
{
    public static void AddTodoEndPoint(this WebApplication app)
    {
        app.MapGet("/todo", ([FromServices] ITodoService service) =>
        {
            return service.GetAll();
        });
        app.MapPost("/todo", ([FromServices] ITodoService service, Todo todo) =>
        {
            service.Create(todo);
        });
        app.MapPut("/todo/{id}", ([FromServices] ITodoService service, int id, Todo todo) =>
        {
            service.Update(id, todo);
        });

        app.MapDelete("/todo/{id}", ([FromServices] ITodoService service, int id) =>
        {
            service.Delete(id);
        });
    }
}