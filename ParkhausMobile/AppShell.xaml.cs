using ParkhausMobile.Views;

namespace ParkhausMobile;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(GarageDetailPage), typeof(GarageDetailPage));
    }
}