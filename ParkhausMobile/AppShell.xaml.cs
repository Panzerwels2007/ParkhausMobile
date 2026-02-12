using ParkhausMobile.Views;

namespace ParkhausMobile;

// Defines the main navigation container of the application
public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Registers a navigation route for the GarageDetailPage.
        // This allows navigation using Shell.Current.GoToAsync(...)
        // and enables passing the selected Garage object as a parameter.
        Routing.RegisterRoute(nameof(GarageDetailPage), typeof(GarageDetailPage));
    }
}