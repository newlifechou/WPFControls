using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfControls.Model;
using XSWPFControls;

/*
    Developer:xs.zhou@outlook.com
    CreateTime:2016/4/7 15:27:14
*/
namespace WpfControls
{
    public class MainWindowViewModel:ViewModelBase
    {
        
        public MainWindowViewModel(SimplePagerViewModel vm)
        {
            Messenger.Default.Register<int>(this, "PageChangedMessenge", i =>
            {
                Products = new ObservableCollection<Product>(DataSource.Products.OrderBy(p => p.Price).Skip(i).Take(20));
            });

            int recordCount = DataSource.Products.Count;
            vm.RecordCount = recordCount;
            vm.PageSize = 20;
            vm.PageIndexChangedMessage();

        }

        private ObservableCollection<Product> products;
        public ObservableCollection<Product>  Products
        {
            get { return products; }
            set
            {
                if (products == value)
                    return;
                products = value;
                RaisePropertyChanged(() => Products);
            }
        }


        private int indexCounter;
        public int IndexCounter
        {
            get { return indexCounter; }
            set
            {
                if (indexCounter == value)
                    return;
                indexCounter = value;
                RaisePropertyChanged(() => IndexCounter);
            }
        }


    }
}
