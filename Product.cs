using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XuatHoaDonAurora
{
    public class Product
    {
            public string Name { get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; }
            public TypeProduct Type { get; set; }

        public Product(string name,TypeProduct type, int quantity, decimal price)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
            Type = type;
        }
    }

    public enum TypeProduct
    {
        EyeglassFrame =0,
        Lenses = 1,
    }

    public enum TypeBank
    {
        TPBank_NguyenNgocTrien = 1,
        VPBank_DangNgocVien = 2,
    }

    public class Discount
    {
        public string Name { get; set; }
        public bool IsPercent { get; set; }
        public decimal Amount { get; set; }
        public Discount(string name, decimal amount, bool isPercent = false)
        {
            Name = name;
            Amount = amount;
            IsPercent = isPercent;
        }
    }

    internal class DataAurora
    {
        public List<Product> Products { get; set; }
        public List<Discount> Discounts { get; set; }
        public DataAurora()
        {
            Products = new List<Product>();
            Discounts = new List<Discount>();
        }
    }
    public class DataAuroraSave
    {
        public List<Product> Products { get; set; }
        public List<Discount> Discounts { get; set; }
        public TypeBank BankType { get; set; }
        public DataAuroraSave()
        {
            Products = new List<Product>();
            Discounts = new List<Discount>();
        }
    }
}
