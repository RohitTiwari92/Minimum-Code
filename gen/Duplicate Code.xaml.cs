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

namespace gen
{
    /// <summary>
    /// Interaction logic for Duplicate_Code.xaml
    /// </summary>
    public partial class Duplicate_Code : Window
    {
        public Duplicate_Code()
        {
            InitializeComponent();
        }
        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {

            var items = new List<sh>();
          

            // items.Add(new sh("rohit",2,3,"rakhi",3,1));
            for (int i = 0; i < store.filename.Count; i = i + 2)
                items.Add(new sh(store.filename[i], store.startlineno[i], store.endlineno[i], store.filename[i + 1], store.startlineno[i + 1], store.endlineno[i + 1]));

            var grid = sender as System.Windows.Controls.DataGrid;


            grid.ItemsSource = items;
        }
        class sh
        {
            public string File1 { get; set; }
            public int Start_line_Number { get; set; }
            public int End_Line_Number { get; set; }
            public string Duplicate_Code_Containing_File { get; set; }
            public int start_line_number { get; set; }
            public int end_line_number { get; set; }
            public sh(string name, int size, int end, string f2, int s2, int e2)
            {
                this.File1 = name;
                this.Start_line_Number = size;
                this.End_Line_Number = end;
                this.Duplicate_Code_Containing_File = f2;
                this.start_line_number = s2;
                this.end_line_number = e2;


            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
