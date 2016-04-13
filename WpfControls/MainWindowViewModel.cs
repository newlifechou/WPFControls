using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
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
    public class MainWindowViewModel : ViewModelBase
    {

        public MainWindowViewModel()
        {
            searchResults = ProductFactory.GetProducts(126);
            PageIndex = 1;
            PageSize = 10;
            RecordCount = searchResults.Count;
            PageIt();
            PageCommand = new RelayCommand(PageAction);
        }

        private void PageAction()
        {
            PageIt();
        }

        private void PageIt()
        {
            Products = new ObservableCollection<Product>(
                            searchResults.OrderByDescending(p => p.Id).Skip((PageIndex - 1) * PageSize - 1).Take(PageSize).ToList());
        }

        private int pageIndex;
        public int PageIndex
        {
            get { return pageIndex; }
            set
            {
                if (pageIndex == value)
                    return;
                pageIndex = value;
                RaisePropertyChanged(() => PageIndex);
            }
        }
        private int pageSize;
        public int PageSize
        {
            get { return pageSize; }
            set
            {
                if (pageSize == value)
                    return;
                pageSize = value;
                RaisePropertyChanged(() => PageSize);
            }
        }

        private int pageCount;
        public int PageCount
        {
            get { return pageCount; }
            set
            {
                if (pageCount == value)
                    return;
                pageCount = value;
                RaisePropertyChanged(() => PageCount);
            }
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

        //显示数据集
        private ObservableCollection<Product> products;
        public ObservableCollection<Product> Products
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
        //查询结果
        private List<Product> searchResults;

        public RelayCommand PageCommand { get; set; }




    }
}
