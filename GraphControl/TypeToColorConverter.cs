using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace GraphControl
{
    public class TypeToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Type type)
            {
                // TODO
                return Brushes.Green;
            }

            return Brushes.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
