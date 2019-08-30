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
            if (GCCLNumber.Text.Length < 1)
                MessageBox.Show("GCCL number missing");
            else
            {                
                using (GCCL_Part_DatabaseEntities context = new GCCL_Part_DatabaseEntities())
                {
                    try
                    {
                        int GCCLPartNumber = Int32.Parse(GCCLNumber.Text);
                        GCCL gccl = new GCCL
                        {
                            GCCL1 = GCCLPartNumber,
                            Part_Number = PartNumberTextField.Text,
                            Manufacturer = ManufacutrerTextField.Text,
                            Description = DesciptionTextFiled.Text
                        };
                        context.GCCLs.Add(gccl);
                        context.SaveChanges();
                        //Messagebox has no overload that formats ouput string
                        MessageBox.Show(String.Format("GCCL item {0} Added", GCCLPartNumber));
                        GCCLNumber.Clear();
                        PartNumberTextField.Clear();
                        ManufacutrerTextField.Clear();
                        DesciptionTextFiled.Clear();
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("GCCL not a number");
                        GCCLNumber.Clear();
                    }                   
                }

            }
        }

        private void ResetFields_Click(object sender, RoutedEventArgs e)
        {
            GCCLNumber.Clear();
            PartNumberTextField.Clear();
            ManufacutrerTextField.Clear();
            DesciptionTextFiled.Clear();
        }

        private void SelectClicked(object sender, RoutedEventArgs e)
        {         
             using (GCCL_Part_DatabaseEntities context = new GCCL_Part_DatabaseEntities())
             {
                    //Build dynamic query
                    IQueryable<GCCL> query = context.Set<GCCL>();
                    
                    if (GCCLNumber.Text != string.Empty)
                    {
                        int GCCLPartNumber = Int32.Parse(GCCLNumber.Text);
                        query = query.Where(s => s.GCCL1 == GCCLPartNumber);
                    }
                    if(PartNumberTextField.Text != string.Empty)
                    {
                        query = query.Where(s => s.Part_Number == PartNumberTextField.Text);
                    }
                    if(ManufacutrerTextField.Text != string.Empty)
                    {
                        query = query.Where(s => s.Manufacturer == ManufacutrerTextField.Text);
                    }
                    if(DesciptionTextFiled.Text != string.Empty)
                    {
                        query = query.Where(s => s.Description == DesciptionTextFiled.Text);
                    }
                    var queryResult = query.ToList<GCCL>();

                    foreach(GCCL sl in queryResult)
                    {
                        MessageBox.Show(sl.Description);
                    }                                      
             }           
        }
    }
}
