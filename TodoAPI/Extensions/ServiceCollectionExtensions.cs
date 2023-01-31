using System.Data.SqlClient;
using TodoAPI.Data;

namespace TodoAPI.Extensions;

public static class ServiceCollectionExtensions
{
    public static WebApplicationBuilder AddPersistence(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        // AddScoped: each request will create a service instance, and this service will be used for the duration of the request.
        builder.Services.AddScoped<TodoContext.GetConnection>(sp =>
            async () =>
            {
                var connection = new SqlConnection(connectionString);
                await connection.OpenAsync();
                
                return connection;
            });

        return builder;
    }
}