using GalaSoft.MvvmLight;
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
            Products = new ObservableCollection<Product>(ProductFactory.GetProducts(500));
        }


    }
}
