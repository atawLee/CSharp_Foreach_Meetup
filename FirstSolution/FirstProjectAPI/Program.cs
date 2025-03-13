using FirstProject.Service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddSingleton<ITodoService,JsonTodoService>(); //프로세스가 유지되는동안 단하나의 인스턴스로 유지


WebApplication app = builder.Build();
//app.AddTodoEndPoint();
app.MapControllers();

app.MapOpenApi();  
app.UseSwaggerUI(x =>  
{  
    x.SwaggerEndpoint("/openapi/v1.json", "API");  
});  

app.Run();