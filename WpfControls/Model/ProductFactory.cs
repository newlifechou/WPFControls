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
namespace WpfControls.Model
{
    public static class ProductFactory
    {
        public static List<Product> GetProducts(int count)
        {
            SoftwareCreator creator = new SoftwareCreator();
            //SampleDataFactory factory = new SampleDataFactory();
            //List<string> productNames = factory.GetSampleData(creator, count);
            Random r = new Random();

            List <Product> results = new List<Product>();
            for (int i = 0; i < count; i++)
            {
                Product p = new Product()
                {
                    Id = Guid.NewGuid(),
                    ProductName = creator.Create(),
                    Price=r.Next(1000,9999)

                };
                results.Add(p);
            }
            return results;
        }
    }
}
