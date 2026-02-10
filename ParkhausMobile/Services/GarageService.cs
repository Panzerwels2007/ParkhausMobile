using Microsoft.Data.SqlClient;
using ParkhausMobile.Models;

namespace ParkhausMobile.Services;

public class GarageService
{
    private readonly string _connectionString =
        "Server=localhost,1433;Database=ParkhausMobile;User Id=sa;Password=Igid1KRD*;TrustServerCertificate=True;";

    public List<Garage> GetGarages()
    {
        var garages = new List<Garage>();

        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        var command = new SqlCommand(
            "SELECT Id, Name, Address, Capacity, FreeSpaces, OpeningHours, PricingInfo FROM Garages",
            connection);

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            garages.Add(new Garage
            {
                Id = reader.GetGuid(0),
                Name = reader.GetString(1),
                Address = reader.GetString(2),
                Capacity = reader.GetInt32(3),
                FreeSpaces = reader.GetInt32(4),
                OpeningHours = reader.IsDBNull(5) ? null : reader.GetString(5),
                PricingInfo = reader.IsDBNull(6) ? null : reader.GetString(6)
            });
        }

        return garages;
    }
}
