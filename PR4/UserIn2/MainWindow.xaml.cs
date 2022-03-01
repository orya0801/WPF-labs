using System;
using System.Collections.Generic;
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

namespace UserIn2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            foreach (FontFamily f in Fonts.SystemFontFamilies)
            {
                comboBox1.Items.Add(f.ToString());
            }
        }

        private void boldButton_Click(object sender, RoutedEventArgs e)
        {
            richTextBox.Selection.ApplyPropertyValue(FontWeightProperty, FontWeights.Bold);
        }

        private void italicButton_Click(object sender, RoutedEventArgs e)
        {
            richTextBox.Selection.ApplyPropertyValue(FontStyleProperty, FontStyles.Italic);
        }

        private void slider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            richTextBox.Selection.ApplyPropertyValue(FontSizeProperty, slider1.Value.ToString());
        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            richTextBox.Selection.ApplyPropertyValue(FontFamilyProperty, new FontFamily(comboBox1.Text));
        }
    }
}
