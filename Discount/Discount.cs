using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount
{
    public abstract class Product
    {
        public string Description { get; set; }
        public float Cost;
        public int Count;
    }
    public class TypeOfProduct : Product
    {
        public TypeOfProduct(string name, float cost, int cnt)
        {
            Description = name;
            Cost = cost;
            Count = cnt;
        }
    }
    public class Porchase
    {
        public List<Product> Products { get; set; }
        public bool AvailableOfClientCard { get; set; }
        public bool TodayIsBirthday { get; set; }

        public Porchase()
        {
            Products = new List<Product>();
        }
        public float GetSumm()
        {
            float sumCost = 0;
            foreach (Product p in Products)
            {
                sumCost += p.Cost * p.Count;
            }
            if (AvailableOfClientCard == true)
            {
                sumCost = 0;
                for (int i = 0; i < Products.Count; i++)
                {
                    WithClientCard disc = new WithClientCard(Products[i]);
                    sumCost += Products[i].Cost * Products[i].Count;
                }
                return sumCost;
            }
            if (TodayIsBirthday == true && AvailableOfClientCard == false)
            {
                sumCost = 0;
                for (int i = 0; i < Products.Count; i++)
                {
                    OnBirthday disc = new OnBirthday(Products[i]);
                    sumCost += Products[i].Cost * Products[i].Count;
                }
                return sumCost;
            }
            if (sumCost > 1000)
            {
                sumCost = 0;
                for (int i = 0; i < Products.Count; i++)
                {
                    OnAllProduct disc = new OnAllProduct(Products[i]);
                    sumCost += Products[i].Cost * Products[i].Count;
                }
                return sumCost;
            }
            else
            {
                sumCost = 0;
                for (int i = 0; i < Products.Count; i++)
                {
                    if (Products[i].Count >= 3)
                    {
                        OnMoreThanThree disc = new OnMoreThanThree(Products[i]);
                    }
                    if (Products[i].Description == "Шоколад" && Products[i].Count < 3)
                    {
                        OnThisProduct disc = new OnThisProduct(Products[i]);
                    }
                    sumCost += Products[i].Cost * Products[i].Count;
                }
                return sumCost;
            }
        }
    }
    public interface Discount
    {
        float GetDiscount(Product product);
    }
    public class OnThisProduct : Discount
    {
        public OnThisProduct(Product product)
        {
            product.Cost -= GetDiscount(product);
            product.Description = product.Description + " На данный товар";
        }
        public float GetDiscount(Product product)
        {
            return (float)((float)product.Cost * 0.1);
        }
    }

    public class OnMoreThanThree : Discount
    {
        public OnMoreThanThree(Product product)
        {
            product.Cost -= GetDiscount(product);
            product.Description = product.Description + " Для 3-х и более товаров";
        }
        public float GetDiscount(Product product)
        {
            return (float)((float)product.Cost * 0.1);
        }
    }
    public class OnAllProduct : Discount
    {
        public OnAllProduct(Product product)
        {
            product.Cost -= GetDiscount(product);
            product.Description = product.Description + " На сумму покупки";
        }
        public float GetDiscount(Product product)
        {
            return (float)((float)product.Cost * 0.1);
        }
    }
    public class WithClientCard : Discount
    {
        public WithClientCard(Product product)
        {
            product.Cost -= GetDiscount(product);
            product.Description = product.Description + " По клиентской карте магазина";
        }
        public float GetDiscount(Product product)
        {
            return (float)((float)(product.Cost * 0.15));
        }
    }
    public class OnBirthday : Discount
    {
        public OnBirthday(Product product)
        {
            product.Cost -= GetDiscount(product);
            product.Description = product.Description + " По дню рождения ";
        }
        public float GetDiscount(Product product)
        {
            return (float)((float)product.Cost * 0.25);
        }

    }
}
