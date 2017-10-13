using SQLite.Net;

namespace StudentManagement.Interfaces
{
    public interface IDatabaseConnection
    {
        SQLiteConnection DbConnection(string databaseName);
        long GetSize(string databaseName);
    }
}
