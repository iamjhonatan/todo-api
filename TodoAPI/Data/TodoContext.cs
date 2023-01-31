using System.Data;

namespace TodoAPI.Data;

public class TodoContext
{
    public delegate Task<IDbConnection> GetConnection();
}