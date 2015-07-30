using Mockup.Converters;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Converters
{
    public class TextboxBackgroundBrushConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string selectedContent;
            bool isSelectedAndCopied, isSelected;
            SelectionHelper.Initialize(values, out selectedContent, out isSelectedAndCopied, out isSelected);

            var selectedBrush = new SolidColorBrush(Colors.LightYellow);
            var selectedCopiedBrush = new SolidColorBrush(Colors.LightGreen);
            var notSelectedBrush = new SolidColorBrush(Colors.White);

            if (selectedContent == null) return notSelectedBrush;

            if (isSelectedAndCopied) return selectedCopiedBrush;

            if (isSelected) return selectedBrush;
            
            return notSelectedBrush;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}