using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Converters
{
    public class TextboxBorderBrushConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var text = values[0] as string;
            var selectedContent = values[1] as string;

            var selectedBrush = new SolidColorBrush(Colors.White);
            var notsSelectedBrush = new SolidColorBrush(Colors.LightGray);

            if (selectedContent == null) return notsSelectedBrush;

            return text != selectedContent ? notsSelectedBrush : selectedBrush;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}