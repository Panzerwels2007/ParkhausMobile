using ParkhausMobile.Models;
using ParkhausMobile.Services;

namespace ParkhausMobile.Views;

public partial class GarageListPage : ContentPage
{
    private readonly GarageService _service = new GarageService();

    public GarageListPage()
    {
        InitializeComponent();
        GaragesCollection.ItemsSource = _service.GetGarages();
    }

    private async void OnGarageSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is not Garage selected)
            return;

        ((CollectionView)sender).SelectedItem = null;

        await Shell.Current.GoToAsync(nameof(GarageDetailPage), true,
            new Dictionary<string, object>
            {
                { "Garage", selected }
            });
    }
}
