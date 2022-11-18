using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount
{
    class Program
    {
        static void Main(string[] args)
        {
            Porchase products = new Porchase();
            products.Products.Add(new TypeOfProduct("Молоко",63,3));
            products.Products.Add(new TypeOfProduct("Яблоко", 20, 7));
            products.Products.Add(new TypeOfProduct("Хлеб", 30, 1));
            products.Products.Add(new TypeOfProduct("Масло", 50, 1));
            products.Products.Add(new TypeOfProduct("Морковь", 15, 5));
            products.Products.Add(new TypeOfProduct("Шоколад", 80, 1));
            products.AvailableOfClientCard=false;
            products.TodayIsBirthday = false; 
            float sum = products.GetSumm();
            foreach (Product p in products.Products)
                Console.WriteLine(p.Description + " " + p.Cost + " " + p.Count);
            Console.WriteLine(sum);
            
            Console.ReadKey();
        }
    }
}
