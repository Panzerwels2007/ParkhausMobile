namespace ParkhausMobile.Models;

// Represents a parking garage in the system.
// Contains general information and current availability data.
public class Garage
{
    // Unique identifier for the garage
    public Guid Id { get; set; }

    // Name of the parking garage
    public string Name { get; set; } = string.Empty;

    // Address or location description of the garage
    public string Address { get; set; } = string.Empty;

    // Total number of parking spaces available
    public int Capacity { get; set; }

    // Current number of free parking spaces
    public int FreeSpaces { get; set; }

    // Opening hours of the garage
    public string? OpeningHours { get; set; }

    // Pricing information for the garage
    public string? PricingInfo { get; set; }
}
