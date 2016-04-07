using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfControls.Model;

/*
    Developer:xs.zhou@outlook.com
    CreateTime:2016/4/7 15:27:14
*/
namespace WpfControls
{
    public class MainWindowViewModel:ViewModelBase
    {
        public ObservableCollection<Product> Products { get; set; }
        public MainWindowViewModel()
        {
            RecordCount = DataSource.Products.Count;
            Products = new ObservableCollection<Product>(DataSource.Products.OrderBy(p => p.Id).Skip(0).Take(20));
            //Messenger.Default.Register<int>(this, pageindex =>
            //{
            //    Products = new ObservableCollection<Product>(DataSource.Products.OrderBy(p=>p.ProductName).Skip(pageindex * 20).Take(20));
            //});
        }
       
        private int recordCount;
        public int RecordCount
        {
            get { return recordCount; }
            set
            {
                if (recordCount == value)
                    return;
                recordCount = value;
                RaisePropertyChanged(() => RecordCount);
            }
        }


    }
}
