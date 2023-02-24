using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using MovieTheater.Infrastructure.Utility.Interfaces;
using MovieTheater.Infrastructure.Utility.Models;

namespace MovieTheater.Infrastructure.Utility;

public class RawQueryService: IRawQueryService
{
    private readonly DatabaseConnection _databaseConnection;

    public RawQueryService(IOptions<DatabaseConnection> options)
    {
        _databaseConnection = options.Value;
    }
    
    public async Task<IEnumerable<dynamic>> ExecuteRawQuery(string query)
    {
        await using var connection = new SqlConnection(_databaseConnection.DefaultConnection);
        var movies = await connection.QueryAsync(query);

        return movies;
    }
}