using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF9
{
    class MyCommands
    {
        public static RoutedUICommand Exit { get; set; }
        public static RoutedCommand Bold { get; set; }
        public static RoutedCommand Italic { get; set; }
        public static RoutedCommand Underline { get; set; }
        public static RoutedCommand TextBlack { get; set; }
        public static RoutedCommand TextRed { get; set; }
        public static RoutedCommand Light { get; set; }
        public static RoutedCommand Dark { get; set; }

        static MyCommands()
        {

            InputGestureCollection inputs = new InputGestureCollection();
            inputs.Add(new KeyGesture(Key.T, ModifierKeys.Control, "Ctrl+T"));
            Exit = new RoutedUICommand("Выход", "Exit", typeof(MyCommands), inputs);
            Bold = new RoutedCommand();
            Italic = new RoutedCommand();
            Underline = new RoutedCommand();
            TextBlack = new RoutedCommand();
            TextRed = new RoutedCommand();
            Light = new RoutedCommand();
            Dark = new RoutedCommand();
        }
    }
}
