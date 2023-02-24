namespace MovieTheater.Infrastructure.Utility.Interfaces;

public interface IRawQueryService
{
    Task<IEnumerable<dynamic>> ExecuteRawQuery(string query);
}