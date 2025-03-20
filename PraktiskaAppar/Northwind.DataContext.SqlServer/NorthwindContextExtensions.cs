using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore; 
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.EntityModels;

namespace Northwind.DataContext.SqlServer
{
    public static class NorthwindContextExtensions
    {
        //<summary>
        
        public static IServiceCollection AddNorthwindContext(this IServiceCollection services, string? connectionString= null) //typen av services som extends
        {
            {
                if (connectionString is null)
                {

                    SqlConnectionStringBuilder builder = new();

                    builder.DataSource = "(localdb)\\MSSQLLocalDB"; //servername / instancename sqllocaldb info
                    builder.InitialCatalog = "NorthwindDatabase";
                    builder.TrustServerCertificate = true;
                    builder.MultipleActiveResultSets = true;

                    //visar timeout i 3 sekunder, default är 15 sekunder
                    builder.ConnectTimeout = 3;

                    // om ni vill använda Windows Authentication
                    builder.IntegratedSecurity = true;

                    // om ni vill använda SQL Server Authentication
                    //builder.UserID = Environment.GetEnvironmentVariable("My_SQL_USR");
                    //builder.Password = Environment.GetEnvironmentVariable("My_SQL_PWD");

                    connectionString = builder.ConnectionString;
                }
                services.AddDbContext<NorthwindDatabaseContext>(options =>
                {
                    options.UseSqlServer(connectionString);
                    options.LogTo(NorthwindContextLogger.WriteLine,
                    new[] { Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.CommandExecuting });
                },
            //Registrera NorthwindDatabaseContext med service Lifetime transient för att undvika problem med DbContext concurrency i Blazor server projects
            contextLifetime: ServiceLifetime.Transient,
            optionsLifetime: ServiceLifetime.Transient);
            }
                return services;
            }
        }
    }

