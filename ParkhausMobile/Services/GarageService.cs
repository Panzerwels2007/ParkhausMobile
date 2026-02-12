using Microsoft.Data.SqlClient;
using ParkhausMobile.Models;

namespace ParkhausMobile.Services;

// Provides database access for garage data.
// Handles communication with the SQL Server database.
public class GarageService
{
    // Connection string for the local SQL Server instance running in Docker.
    // Contains server address, database name and login credentials.
    private readonly string _connectionString =
        "Server=localhost,1433;Database=ParkhausMobile;User Id=sa;Password=Igid1KRD*;TrustServerCertificate=True;";

    // Retrieves all garages from the database.
    // Returns a list of Garage objects.
    public List<Garage> GetGarages()
    {
        var garages = new List<Garage>();

        // Create and open SQL connection
        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        // SQL query to select all relevant columns from the Garages table
        var command = new SqlCommand(
            "SELECT Id, Name, Address, Capacity, FreeSpaces, OpeningHours, PricingInfo FROM Garages",
            connection);

        // Execute the query and read the result set
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            // Map each database row to a Garage object
            garages.Add(new Garage
            {
                Id = reader.GetGuid(0),
                Name = reader.GetString(1),
                Address = reader.GetString(2),
                Capacity = reader.GetInt32(3),
                FreeSpaces = reader.GetInt32(4),

                // Check for NULL values before reading optional fields
                OpeningHours = reader.IsDBNull(5) ? null : reader.GetString(5),
                PricingInfo = reader.IsDBNull(6) ? null : reader.GetString(6)
            });
        }

        return garages;
    }
}
