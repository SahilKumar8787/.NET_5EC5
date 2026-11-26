using Microsoft.Data.SqlClient;

namespace PlacementDashboard.Data
{
    public static class DatabaseConnection
    {
        private const string ConnectionString =
            "Server=(localdb)\\MSSQLLocalDB;Database=PlacementTrackerDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}