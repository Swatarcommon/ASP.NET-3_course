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
using System.Text.RegularExpressions;
using System.Net;
using System.IO;

namespace WindowsApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Sum_Click(object sender, RoutedEventArgs e)
        {
            var request = WebRequest.Create("http://localhost:1732/.lnz?ParmA=" +
                                            Convert.ToInt32(FirstNum.Text) + "&ParmB=" +
                                            Convert.ToInt32(SecondNum.Text));
            request.Method = "POST";
            request.ContentLength = 0;
            var response = request.GetResponse();

            using (var stream = new StreamReader(response.GetResponseStream() ?? throw new InvalidOperationException(), Encoding.UTF8))
            {
                Result.Content = stream.ReadToEnd();
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
