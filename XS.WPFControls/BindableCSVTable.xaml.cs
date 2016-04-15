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

namespace XS.WPFControls
{
    /// <summary>
    /// BindableCSVTable.xaml 的交互逻辑
    /// </summary>
    public partial class BindableCSVTable : UserControl
    {
        public BindableCSVTable()
        {
            InitializeComponent();
        }


        public string CSVContent
        {
            get
            {
                return (string)GetValue(CSVContentProperty);
            }
            set
            {
                SetValue(CSVContentProperty, value);
            }
        }

        public static readonly DependencyProperty CSVContentProperty =
              DependencyProperty.Register("CSVContent", typeof(string), typeof(BindableCSVTable),
                  new PropertyMetadata(string.Empty, new PropertyChangedCallback(CSVChanged)));

        private static void CSVChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            BindableCSVTable table = d as BindableCSVTable;
            if (table!=null && e.NewValue!=null)
            {
                table.CSVToTable(e.NewValue.ToString());
            }
            else
            {
                table.ClearTable();
            }
        }
        private void ClearTable()
        {
            this.tableRowGroup.Rows.Clear();
        }

        private void CSVToTable(string csvString)
        {
            ClearTable();
            if (string.IsNullOrEmpty(csvString))
            {
                return;
            }
            string[] lines = CSVContent.Split(new char[] { '\n', '\r' });
            foreach (var line in lines)
            {
                TableRow row = new TableRow();
                foreach (var item in line.Split(new char[] { ','}))
                {
                    if (!string.IsNullOrEmpty(item))
                    {
                        TableCell cell = new TableCell();
                        cell.BorderBrush = Brushes.Blue;
                        cell.BorderThickness = new Thickness(1);
                        Paragraph p = new Paragraph();
                        p.Inlines.Add(item);
                        cell.Blocks.Add(p);
                        row.Cells.Add(cell);
                    }
                }
                this.tableRowGroup.Rows.Add(row);
            }
        }


    }
}
