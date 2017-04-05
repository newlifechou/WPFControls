using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfControlsTest
{
    public class Window1VM:ViewModelBase
    {
        public Window1VM()
        {
            Name = "xs.zhou";
            Ds = new List<string>();
            Ds.Add("Check1");
            Ds.Add("Check2");
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value;RaisePropertyChanged(nameof(Name)); }
        }


        public List<string> Ds { get; set; }
    }
}
