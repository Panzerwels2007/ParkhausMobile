using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ParkhausMobile.Converters;

public class FreeSpacesToColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not int freeSpaces)
            return Colors.Black;

        if (freeSpaces > 100)
            return Colors.Green;

        if (freeSpaces > 20)
            return Colors.Orange;

        return Colors.Red;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => throw new NotImplementedException();
}