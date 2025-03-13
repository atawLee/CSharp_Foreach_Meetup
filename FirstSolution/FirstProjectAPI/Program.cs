using FirstProject.Service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddSingleton<ITodoService,JsonTodoService>(); //프로세스가 유지되는동안 단하나의 인스턴스로 유지
// builder.Services.AddTransient<ITodoService,JsonTodoService>(); //요청이 있을때마다 새로운 인스턴스 생성
// builder.Services.AddScoped<ITodoService,JsonTodoService>(); //같은 요청에 대해 같은 인스턴스를 반환

WebApplication app = builder.Build();
//app.AddTodoEndPoint();
app.MapControllers();

app.MapOpenApi();  
app.UseSwaggerUI(x =>  
{  
    x.SwaggerEndpoint("/openapi/v1.json", "API");  
});  

app.Run();