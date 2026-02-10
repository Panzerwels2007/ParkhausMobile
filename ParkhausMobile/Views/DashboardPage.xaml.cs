using ParkhausMobile.Services;
using System.Linq;

namespace ParkhausMobile.Views;

public partial class DashboardPage : ContentPage
{
    public DashboardPage()
    {
        InitializeComponent();

        var service = new GarageService();
        var garages = service.GetGarages();

        var totalGarages = garages.Count;
        var totalFreeSpaces = garages.Sum(g => g.FreeSpaces);
        var totalCapacity = garages.Sum(g => g.Capacity);

        double occupancyPercent = 0;
        if (totalCapacity > 0)
        {
            occupancyPercent = 100 - ((double)totalFreeSpaces / totalCapacity * 100);
        }

        GaragesCountLabel.Text = $"Parkhäuser: {totalGarages}";
        FreeSpacesLabel.Text = $"Freie Plätze gesamt: {totalFreeSpaces}";
        CapacityLabel.Text = $"Gesamtkapazität: {totalCapacity}";
        OccupancyLabel.Text = $"Auslastung: {occupancyPercent:F1} %";
    }
}
