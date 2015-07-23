using Mockup.Converters;
using System;
using System.Globalization;
using System.Windows.Data;

namespace Converters
{
    public class TextConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string selectedContent;
            bool isSelectedAndCopied, isSelected;
            SelectionHelper.Initialize(values, out selectedContent, out isSelectedAndCopied, out isSelected);

            return !isSelectedAndCopied ? null : "Copied";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}