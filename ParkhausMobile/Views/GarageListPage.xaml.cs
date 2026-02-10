using ParkhausMobile.Services;

namespace ParkhausMobile.Views;

public partial class GarageListPage : ContentPage
{
    public GarageListPage()
    {
        InitializeComponent();

        var service = new GarageService();
        GaragesCollection.ItemsSource = service.GetGarages();
    }
}
