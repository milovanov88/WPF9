using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF9
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string style = "Light";



        public MainWindow()
        {
            InitializeComponent();
            var uri = new Uri(style + ".xaml", UriKind.Relative);
            ResourceDictionary resourceDictionary = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
        }
        private void LightExucuted(object sender, ExecutedRoutedEventArgs e)
        {
            style = MenuLightTheme.Tag as string;
            var uri = new Uri(style + ".xaml", UriKind.Relative);
            RadioBlack.Content = "Черный";
            if (textBox.Foreground != Brushes.Red) TextBlackExucuted(sender, e);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }
        private void DarkExucuted(object sender, ExecutedRoutedEventArgs e)
        {
            style = MenuDarkTheme.Tag as string;
            var uri = new Uri(style + ".xaml", UriKind.Relative);
            RadioBlack.Content = "Белый";
            if (textBox.Foreground != Brushes.Red) TextBlackExucuted(sender, e);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string fontName = (string)(sender as ComboBox).SelectedItem;

            if (textBox != null)
            {
                textBox.FontFamily = new FontFamily(fontName);
            }
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            int fontSize = Convert.ToInt32((sender as ComboBox).SelectedItem);

            if (textBox != null)
            {
                textBox.FontSize = fontSize;
            }
        }
        private void ExitExucuted(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void OpenExucuted(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*txt)|*.txt|Все файлы (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                textBox.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }
        private void SaveExucuted(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*txt)|*.txt|Все файлы (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, textBox.Text);
            }
        }
        private void BoldExucuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (textBox != null)
            {
                if (textBox.FontWeight == FontWeights.Normal) textBox.FontWeight = FontWeights.Bold;
                else textBox.FontWeight = FontWeights.Normal;
            }
        }

        private void ItalicExucuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (textBox != null)
            {
                if (textBox.FontStyle == FontStyles.Normal) textBox.FontStyle = FontStyles.Italic;
                else textBox.FontStyle = FontStyles.Normal;
            }
        }

        private void UnderlineExucuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (textBox != null)
            {
                if (textBox.TextDecorations == null) textBox.TextDecorations = TextDecorations.Underline;
                else textBox.TextDecorations = null;
            }
        }

        private void TextBlackExucuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (textBox != null)
            {
                if (style.Equals("Light"))
                {
                    textBox.Foreground = Brushes.Black;
                }
                else
                {
                    textBox.Foreground = Brushes.White;
                }
            }
        }

        private void TextRedExucuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (textBox != null)
            {
                textBox.Foreground = Brushes.Red;
            }
        }
    }
}