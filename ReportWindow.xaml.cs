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
using System.Windows.Shapes;

namespace WPFBasic
{
    /// <summary>
    /// Interaction logic for ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        public ReportWindow(List<GCCL> sl)
        {
            InitializeComponent();
            PrintDataFromDB(sl);
        }

        public void PrintDataFromDB(List<GCCL> sl)
        {
            StringBuilder PrintString = new StringBuilder();
            foreach (GCCL id in sl)
            {
                PrintString.Append(id.GCCL1 + " " + id.Description);
                PrintString.Append("\n");
            }
            
            TextBlock1.Text = PrintString.ToString();
           
        }
    }
}
