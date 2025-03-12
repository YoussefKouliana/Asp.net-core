using Northwind.DataContext.SqlServer;

#region// configure web server host and services
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddNorthwindDatabaseContext();


var app = builder.Build();
#endregion

#region konfiguration av http pipeline och routing
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();
app.MapRazorPages();

app.MapGet("/hello", () => $"Environment is {app.Environment.EnvironmentName}");
#endregion


app.Run();
Console.WriteLine("Detta exekveras efter att web server har stoppats!");