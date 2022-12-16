using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount
{
    public class Product
    {
        public string Description { get; set; }
        public float Cost { get; set; }
    }
    public class Item
    {
        public Product Product { get; set; }
        public int Count { get; set; }

    }
    public class ItemWithCost
    {
        public Item Item { get; set; }
        public float Cost { get; set; }
    }
    public interface IDiscount
    {
        ICollection<Item> GetDiscount(Item[] items);
    }
    public interface IDiscountCompatibleRule
    {
        bool IsCompatible(IDiscount d1, IDiscount d2);
    }

    public class OnThisProduct : IDiscount
    {
        public ICollection<Item> GetDiscount(Item[] items)
        {
            float ValueOfDisc = 0.25f;
            foreach (Item item in items)
            {
                //Расчет цены со скидкой            
            }
            return items;
        }
    }

    public class OnMoreThanThree : IDiscount
    {
        public ICollection<Item> GetDiscount(Item[] items)
        {
            float ValueOfDisc = 0.25f;
            foreach (Item item in items)
            {
                //Расчет цены со скидкой            
            }
            return items;
        }
    }
    public class OnAllProduct : IDiscount
    {
        public ICollection<Item> GetDiscount(Item[] items)
        {
            float ValueOfDisc = 0.25f;
            foreach (Item item in items)
            {
                //Расчет цены со скидкой            
            }
            return items;
        }
    }
    public class WithClientCard : IDiscount
    {
        public ICollection<Item> GetDiscount(Item[] items)
        {
            float ValueOfDisc = 0.25f;
            foreach (Item item in items)
            {
                //Расчет цены со скидкой            
            }
            return items;
        }
    }
    public class OnBirthday : IDiscount
    {
        public ICollection<Item> GetDiscount(Item[] items)
        {
            float ValueOfDisc = 0.25f;
            foreach (Item item in items)
            {
                //Расчет цены со скидкой            
            }
            return items;
        }
    }
    public interface IDiscountCalculator
    {
        ICollection<IDiscount> Discount { get; set; }
        ICollection<IDiscountCompatibleRule> DiscountCompatibleRule { get; set; }
        float GetMaxDiscount(ICollection<ItemWithCost> Items);//Находит максимальное значение
                                                              //скидки с учетом совместимостей, используя DiscountCompatibleRule.
    }

    public class Purchase
    {
        public ICollection<ItemWithCost> purchaseItems;
        public IDiscountCalculator CalculatDiscount;
        public float GetTotalCost()
        {
            float SumOfPurchase = 0;
            foreach (ItemWithCost item in purchaseItems)
            {
                SumOfPurchase += item.Cost;
            }
            SumOfPurchase -= CalculatDiscount.GetMaxDiscount(purchaseItems);
            return SumOfPurchase;
        }

    }
}