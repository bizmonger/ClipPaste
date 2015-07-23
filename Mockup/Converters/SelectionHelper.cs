using System.Windows.Media;

namespace Mockup.Converters
{
    public class SelectionHelper
    {
        public static void Initialize(object[] values, out string selectedContent, out bool isSelectedAndCopied, out bool isSelected)
        {
            var text = values[0] as string;
            selectedContent = values[1] as string;
            var copyMade = (bool)values[2];

            isSelectedAndCopied = text == selectedContent && copyMade;
            isSelected = text == selectedContent;
            var selectedBrush = new SolidColorBrush(Colors.LightYellow);
            var selectedCopiedBrush = new SolidColorBrush(Colors.LightGreen);
            var notSelectedBrush = new SolidColorBrush(Colors.White);
        }
    }
}
