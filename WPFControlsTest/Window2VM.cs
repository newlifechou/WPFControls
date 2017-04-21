using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.ObjectModel;

namespace WpfControlsTest
{
    public class Window2VM : ViewModelBase
    {
        List<string> data;
        public Window2VM()
        {
            recordCount = 30;
            data = new List<string>();
            loaddata();
            Ds = new ObservableCollection<string>();
            PageChanged = new RelayCommand(ActionChanged);
            Refresh = new RelayCommand(ActionRefresh);
            initial();
        }

        private void loaddata()
        {
            RecordCount += 1;
            data.Clear();
            for (int i = 0; i < RecordCount; i++)
            {
                data.Add(DateTime.Now.AddSeconds(i).ToString());
            }
        }

        private void ActionRefresh()
        {
            loaddata();
            initial();
        }

        public void initial()
        {
            PageIndex = 1;
            RecordCount = data.Count;
            ActionChanged();
        }


        private void ActionChanged()
        {
            int skip=(PageIndex-1)*10;
            int take=10;

            Ds.Clear();
            data.Skip(skip).Take(take).ToList().ForEach(i=>Ds.Add(i));
        }

        private int pageIndex;

        public int PageIndex
        {
            get { return pageIndex; }
            set { pageIndex = value; RaisePropertyChanged(nameof(PageIndex)); }
        }


        private int recordCount;

        public int RecordCount
        {
            get { return recordCount; }
            set { recordCount = value; RaisePropertyChanged(nameof(RecordCount)); }
        }
        public ObservableCollection<string> Ds { get; set; }
        public RelayCommand PageChanged { get; set; }
        public RelayCommand Refresh { get; set; }

    }
}
