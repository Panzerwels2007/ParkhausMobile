using ParkhausMobile.Models;

namespace ParkhausMobile.Views;

// Receives a Garage object through Shell navigation.
// Displays detailed information about the selected garage.
[QueryProperty(nameof(Garage), "Garage")]
public partial class GarageDetailPage : ContentPage
{
    // Backing field for the selected garage
    private Garage? _garage;

    // Property used by Shell to pass the selected garage object.
    // When the property is set, the UI is updated with the garage data.
    public Garage? Garage
    {
        get => _garage;
        set
        {
            // Stop execution if no garage was provided
            _garage = value;
            if (_garage is null) return;

            // Update UI labels with garage information
            NameLabel.Text = _garage.Name;
            AddressLabel.Text = _garage.Address;
            CapacityLabel.Text = $"Kapazität: {_garage.Capacity}";
            FreeSpacesLabel.Text = $"Freie Plätze: {_garage.FreeSpaces}";

            // Display default text if optional values are null
            OpeningHoursLabel.Text = $"Öffnungszeiten: {(_garage.OpeningHours ?? "Keine Angabe")}";
            PricingInfoLabel.Text = $"Tarif: {(_garage.PricingInfo ?? "Keine Angabe")}";
        }
    }

    public GarageDetailPage()
    {
        InitializeComponent();
    }
}
