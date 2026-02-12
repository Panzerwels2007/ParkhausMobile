using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ParkhausMobile.Converters;

// Converts the number of free parking spaces into a color.
// Used in the garage list to show availability status.
public class FreeSpacesToColorConverter : IValueConverter
{
    // Converts an integer value (free spaces) to a color.
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        // Check if the value is a valid integer
        if (value is not int freeSpaces)
            return Colors.Black;

        // More than 100 free spaces -> low usage
        if (freeSpaces > 100)
            return Colors.Green;

        // More than 20 free spaces -> medium usage
        if (freeSpaces > 20)
            return Colors.Orange;

        return Colors.Red;
    }
    // Not implemented because conversion is only one-way (number to color)
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => throw new NotImplementedException();
}