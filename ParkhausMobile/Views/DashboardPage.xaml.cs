using ParkhausMobile.Services;
using System.Linq;

namespace ParkhausMobile.Views;

// Code-behind for the Dashboard page.
// Loads garage data and calculates aggregated statistics.
public partial class DashboardPage : ContentPage
{
    public DashboardPage()
    {
        InitializeComponent();

        // Create service instance to access database data
        var service = new GarageService();

        // Retrieve all garages from the database
        var garages = service.GetGarages();

        // Calculate total number of garages
        var totalGarages = garages.Count;

        // Calculate total number of free parking spaces
        var totalFreeSpaces = garages.Sum(g => g.FreeSpaces);

        // Calculate total parking capacity
        var totalCapacity = garages.Sum(g => g.Capacity);

        // Calculate occupancy percentage
        // Occupancy = percentage of used parking spaces
        double occupancyPercent = 0;
        if (totalCapacity > 0)
        {
            occupancyPercent = 100 - ((double)totalFreeSpaces / totalCapacity * 100);
        }

        // Update UI labels with calculated values
        GaragesCountLabel.Text = $"Parkhäuser: {totalGarages}";
        FreeSpacesLabel.Text = $"Freie Plätze gesamt: {totalFreeSpaces}";
        CapacityLabel.Text = $"Gesamtkapazität: {totalCapacity}";
        OccupancyLabel.Text = $"Auslastung: {occupancyPercent:F1} %";
    }
}
