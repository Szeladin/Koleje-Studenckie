using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace WPF_Koleje_Studenckie_project_Jakub_Bak.Utilities
{
    public class ScaleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double scale)
            {
                return new ScaleTransform(scale, scale);
            }
            return new ScaleTransform(1, 1);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}