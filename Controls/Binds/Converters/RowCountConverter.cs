using System;
using System.Globalization;
using System.Windows.Data;
using static System.Convert;

namespace Wreath.Controls.Binds.Converters
{
    public class RowCountConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int count = ToInt32(value);
            return count - 1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int count = ToInt32(value);
            return count + 1;
        }
    }
}