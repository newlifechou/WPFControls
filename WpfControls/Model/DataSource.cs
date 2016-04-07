using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Developer:xs.zhou@outlook.com
    CreateTime:2016/4/7 15:40:54
*/
namespace WpfControls.Model
{
    public static class DataSource
    {
        static DataSource()
        {
            Products = ProductFactory.GetProducts(500);
        }
        public static  List<Product> Products { get; set; }
    }
}
