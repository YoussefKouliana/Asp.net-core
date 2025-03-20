using Northwind.DataContext.SqlServer;

#region// configure web server host and services
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages(); //here we add Razor Pages
builder.Services.AddNorthwindContext(); //here we add the database context
builder.Services.AddRequestDecompression(); //here we add the request decompression service (accepts-encoded-data)


var app = builder.Build();
#endregion

#region konfiguration av http pipeline och routing
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

//using 
app.Use(async(HttpContext context, Func<Task> next) => { 
    RouteEndpoint? rep = context.GetEndpoint() as RouteEndpoint;
    if (rep is not null)
    {
        Console.WriteLine($"Endpoint name: {rep.DisplayName}");
        Console.WriteLine($"Endpoint route pattern: {rep.RoutePattern.RawText}");
    }
    if (context.Request.Path == "/Bonjour")
    {
        //if the path is /Bonjour, we will return a message
        //delegate dont send the response, it just prepare the response
        await context.Response.WriteAsync("Bonjour l'orient!");
        return;
    }
    
    await next();
});
    

app.UseHttpsRedirection(); //here we enable https redirection
app.UseRequestDecompression(); //here we enable request decompression
app.UseDefaultFiles(); //here we enable default files
app.UseStaticFiles(); //here we enable static files
app.MapRazorPages(); //here we map Razor Pages

app.MapGet("/hello", () => $"Environment is {app.Environment.EnvironmentName}");
#endregion


app.Run(); //here the web server starts
Console.WriteLine("Detta exekveras efter att web server har stoppats!");