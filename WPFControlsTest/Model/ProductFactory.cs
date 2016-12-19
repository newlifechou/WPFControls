using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleData;

/*
    Developer:xs.zhou@outlook.com
    CreateTime:2016/4/7 13:38:59
*/
namespace WpfControlsTest.Model
{
    public static class ProductFactory
    {
        public static List<Product> GetProducts(int count)
        {
            SoftwareCreator creator = new SoftwareCreator();

            List <Product> results = new List<Product>();
            for (int i = 0; i < count; i++)
            {
                Product p = new Product()
                {
                    Id = i,
                    ProductName = creator.Create(),
                    Price = Common.RandInt(1000, 9999)

                };
                results.Add(p);
            }
            return results;
        }
    }
}
