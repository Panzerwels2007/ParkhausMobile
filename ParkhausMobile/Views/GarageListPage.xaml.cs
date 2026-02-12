using ParkhausMobile.Models;
using ParkhausMobile.Services;

namespace ParkhausMobile.Views;

// Code-behind for the garage list page.
// Loads garages from the database and applies search, filter, and sorting.
public partial class GarageListPage : ContentPage
{
    // Service for database access
    private readonly GarageService _service = new GarageService();

    // Stores the full list from the database (base for search/filter/sort)
    private List<Garage> _allGarages = new();

    public GarageListPage()
    {
        InitializeComponent();

        // Filter options for availability status
        FilterPicker.ItemsSource = new List<string> { "Alle", "Grün", "Orange", "Rot" };
        FilterPicker.SelectedIndex = 0;

        // Sorting options for the list
        SortPicker.ItemsSource = new List<string> { "Name (A-Z)", "Freie Plätze (absteigend)" };
        SortPicker.SelectedIndex = 0;

        // Initial data load
        LoadGarages();
    }

    // Loads garage data from the database and updates the UI list
    private void LoadGarages()
    {
        _allGarages = _service.GetGarages();
        ApplySearchFilterSort();
    }

    // Applies search text, filter selection, and sort selection to the base list
    private void ApplySearchFilterSort()
    {
        // Start with the full list
        var query = _allGarages.AsEnumerable();

        // Search by name or address (case-insensitive)
        var search = SearchBar.Text?.Trim();
        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(g =>
                g.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                g.Address.Contains(search, StringComparison.OrdinalIgnoreCase));
        }

        // Filter by availability status based on FreeSpaces
        var filter = FilterPicker.SelectedItem as string ?? "Alle";
        query = filter switch
        {
            "Grün" => query.Where(g => GetStatus(g.FreeSpaces) == "Grün"),
            "Orange" => query.Where(g => GetStatus(g.FreeSpaces) == "Orange"),
            "Rot" => query.Where(g => GetStatus(g.FreeSpaces) == "Rot"),
            _ => query
        };

        // Sort the current result set
        var sort = SortPicker.SelectedItem as string ?? "Name (A-Z)";
        query = sort switch
        {
            "Freie Plätze (absteigend)" => query.OrderByDescending(g => g.FreeSpaces).ThenBy(g => g.Name),
            _ => query.OrderBy(g => g.Name)
        };

        // Update the CollectionView with the final result list
        GaragesCollection.ItemsSource = query.ToList();
    }


    // Converts free spaces into a status label (same thresholds as the color converter)
    private static string GetStatus(int freeSpaces)
    {
        if (freeSpaces > 100) return "Grün";
        if (freeSpaces > 20) return "Orange";
        return "Rot";
    }

    // Updates the list whenever the search text changes
    private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
        => ApplySearchFilterSort();

    // Updates the list whenever the filter selection changes
    private void OnFilterChanged(object sender, EventArgs e)
        => ApplySearchFilterSort();

    // Updates the list whenever the sorting selection changes
    private void OnSortChanged(object sender, EventArgs e)
        => ApplySearchFilterSort();

    // Opens the detail page when a garage is selected
    private async void OnGarageSelected(object sender, SelectionChangedEventArgs e)
    {
        // Get the selected garage from the current selection
        if (e.CurrentSelection.FirstOrDefault() is not Garage selected)
            return;

        // Clear selection to allow selecting the same item again
        ((CollectionView)sender).SelectedItem = null;

        // Navigate to the detail page and pass the selected garage object
        await Shell.Current.GoToAsync(nameof(GarageDetailPage), true,
            new Dictionary<string, object> { { "Garage", selected } });
    }
}
