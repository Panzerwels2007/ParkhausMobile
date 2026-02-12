using ParkhausMobile.Models;
using ParkhausMobile.Services;

namespace ParkhausMobile.Views;

public partial class GarageListPage : ContentPage
{
    private readonly GarageService _service = new GarageService();
    private List<Garage> _allGarages = new();

    public GarageListPage()
    {
        InitializeComponent();

        // Picker-Inhalte setzen
        FilterPicker.ItemsSource = new List<string> { "Alle", "Grün", "Orange", "Rot" };
        FilterPicker.SelectedIndex = 0;

        SortPicker.ItemsSource = new List<string> { "Name (A-Z)", "Freie Plätze (absteigend)" };
        SortPicker.SelectedIndex = 0;

        LoadGarages();
    }

    private void LoadGarages()
    {
        _allGarages = _service.GetGarages();
        ApplySearchFilterSort();
    }

    private void ApplySearchFilterSort()
    {
        var query = _allGarages.AsEnumerable();

        // Suche
        var search = SearchBar.Text?.Trim();
        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(g =>
                g.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                g.Address.Contains(search, StringComparison.OrdinalIgnoreCase));
        }

        // Filter (Farbstatus anhand FreeSpaces)
        var filter = FilterPicker.SelectedItem as string ?? "Alle";
        query = filter switch
        {
            "Grün" => query.Where(g => GetStatus(g.FreeSpaces) == "Grün"),
            "Orange" => query.Where(g => GetStatus(g.FreeSpaces) == "Orange"),
            "Rot" => query.Where(g => GetStatus(g.FreeSpaces) == "Rot"),
            _ => query
        };

        // Sortierung
        var sort = SortPicker.SelectedItem as string ?? "Name (A-Z)";
        query = sort switch
        {
            "Freie Plätze (absteigend)" => query.OrderByDescending(g => g.FreeSpaces).ThenBy(g => g.Name),
            _ => query.OrderBy(g => g.Name)
        };

        GaragesCollection.ItemsSource = query.ToList();
    }

    // gleiche Schwellen wie dein Converter
    private static string GetStatus(int freeSpaces)
    {
        if (freeSpaces > 100) return "Grün";
        if (freeSpaces > 20) return "Orange";
        return "Rot";
    }

    private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
        => ApplySearchFilterSort();

    private void OnFilterChanged(object sender, EventArgs e)
        => ApplySearchFilterSort();

    private void OnSortChanged(object sender, EventArgs e)
        => ApplySearchFilterSort();

    private async void OnGarageSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is not Garage selected)
            return;

        ((CollectionView)sender).SelectedItem = null;

        await Shell.Current.GoToAsync(nameof(GarageDetailPage), true,
            new Dictionary<string, object> { { "Garage", selected } });
    }
}
