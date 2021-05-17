using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Code { get; set; }
        public List<int> Money { get; set; }
        public Product()
        {

        }
        public Product(string name, int price, string code)
        {
            this.Name = name;
            this.Price = price;
            this.Code = code;
            this.Money = new List<int>();
        }
    }
}
