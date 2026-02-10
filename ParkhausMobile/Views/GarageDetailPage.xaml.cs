using ParkhausMobile.Models;

namespace ParkhausMobile.Views;

[QueryProperty(nameof(Garage), "Garage")]
public partial class GarageDetailPage : ContentPage
{
    private Garage? _garage;

    public Garage? Garage
    {
        get => _garage;
        set
        {
            _garage = value;
            if (_garage is null) return;

            NameLabel.Text = _garage.Name;
            AddressLabel.Text = _garage.Address;
            CapacityLabel.Text = $"Kapazität: {_garage.Capacity}";
            FreeSpacesLabel.Text = $"Freie Plätze: {_garage.FreeSpaces}";

            OpeningHoursLabel.Text = $"Öffnungszeiten: {(_garage.OpeningHours ?? "Keine Angabe")}";
            PricingInfoLabel.Text = $"Tarif: {(_garage.PricingInfo ?? "Keine Angabe")}";
        }
    }

    public GarageDetailPage()
    {
        InitializeComponent();
    }
}
