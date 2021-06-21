using System;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
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

namespace Calc
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

        }

        private void TimesNewRomanFont_Click(object sender, RoutedEventArgs e)
        {
            textBox.FontFamily = new FontFamily("Times New Roman");
            verdanaFont.IsChecked = false;
        }

        private void VerdanaFont_Click(object sender, RoutedEventArgs e)
        {
            textBox.FontFamily = new FontFamily("Verdana");
            timesNewRomanFont.IsChecked = false;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveNewFile_Click(object sender, RoutedEventArgs e)
        {
            saveToFile();
        }

        private void OpenNewFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            bool? res = of.ShowDialog();
            if (res != false)
            {
                Stream mystream;
                if ((mystream = of.OpenFile()) != null)
                {
                    string file_name = of.FileName;
                    string file_text = File.ReadAllText(file_name);
                    textBox.Text = file_text;
                }
            }
        }

        private void CreateNewFile_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.Text != "")
            {
                saveToFile();
            }
            textBox.Text = "";
        }

        private void saveToFile()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            bool? res = sfd.ShowDialog();

            if (res != false)
            {
                using (StreamWriter sw = new StreamWriter(File.Open(sfd.FileName, FileMode.OpenOrCreate)))
                {
                    sw.Write(textBox.Text);
                }
            }
        }

        private void BackgroundRed_Click(object sender, RoutedEventArgs e)
        {
            textBox.Background = Brushes.Red;
            backgroundWhite.IsChecked = false;
            backgroundBlue.IsChecked = false;
        }
        private void BackgroundBlue_Click(object sender, RoutedEventArgs e)
        {
            textBox.Background = Brushes.Blue;
            backgroundWhite.IsChecked = false;
            backgroundRed.IsChecked = false;
        }
        private void BackgroundWhite_Click(object sender, RoutedEventArgs e)
        {
            textBox.Background = Brushes.White;
            backgroundBlue.IsChecked = false;
            backgroundRed.IsChecked = false;
        }

        private void FontWhite_Click(object sender, RoutedEventArgs e)
        {
            textBox.Foreground = Brushes.White;
            fontBlue.IsChecked = false;
            fontRed.IsChecked = false;
        }

        private void FontBlue_Click(object sender, RoutedEventArgs e)
        {
            textBox.Foreground = Brushes.Blue;
            fontWhite.IsChecked = false;
            fontRed.IsChecked = false;
        }
        private void FontRed_Click(object sender, RoutedEventArgs e)
        {
            textBox.Foreground = Brushes.Red;
            fontBlue.IsChecked = false;
            fontWhite.IsChecked = false;
        }
        private void SelectFontSize_SelectionChanged(object sender, RoutedEventArgs e)
        {
            string fontSize = selectFontSize.SelectedItem.ToString();
            fontSize = fontSize.Substring(fontSize.Length - 2);

            switch(fontSize)
            {
                case "10":
                    textBox.FontSize = 10;
                    break;

                case "14":
                    textBox.FontSize = 14;
                    break;

                case "16":
                    textBox.FontSize = 16;
                    break;

                case "20":
                    textBox.FontSize = 20;
                    break;

                case "24":
                    textBox.FontSize = 24;
                    break;

                case "32":
                    textBox.FontSize = 32;
                    break;

                case "48":
                    textBox.FontSize = 48;
                    break;
            }
        }
        
    }
}
