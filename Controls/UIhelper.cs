using System.Windows;

namespace Wreath.Controls
{
    public static class UIhelper
    {
        public static void SetActive(this UIElement control, in bool activation)
        {
            control.IsEnabled = activation;
            control.Visibility = activation ?
                Visibility.Visible : Visibility.Hidden;
        }

        public static void SetActive(this UIElement control, in byte collapse)
        {
            Visibility[] visibility = new Visibility[] {
                Visibility.Visible, Visibility.Hidden, Visibility.Collapsed
            };
            control.IsEnabled = collapse != 0;
            control.Visibility = visibility[collapse];
        }
    }
}