using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace DebtBook.Utilities
{
    class DebtorValueColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                double input = (double)value;

                if (input < 0)
                    return new SolidColorBrush(Colors.Red);
                else
                    return new SolidColorBrush(Colors.LimeGreen);
            }
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
    }
}
