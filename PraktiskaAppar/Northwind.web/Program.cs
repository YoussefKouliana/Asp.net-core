var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

#region konfiguration av http pipeline och routing
if(!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.MapGet("/", () => "Hello World!");
#endregion


app.Run();
Console.WriteLine("Detta exekveras efter att web server har stoppats!");