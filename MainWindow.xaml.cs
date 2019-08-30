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

namespace WPFBasic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ApplyMessage_Click(object sender, RoutedEventArgs e)
        {
            if(GCCLNumber.Text.Length < 1)
            {
                MessageBox.Show("Descirption is empty");
                
            }
            else         
            MessageBox.Show(GCCLNumber.Text);
        }

        private void ResetFields_Click(object sender, RoutedEventArgs e)
        {
            GCCLNumber.Clear();
        }
    }
}
