using System;
using System.Collections.Generic;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            try
            {
                var product1 = new Product("apple", 9, "A01");
                var product2 = new Product("banana", 6, "A02");

                var vending = new VendingMachine();
                //vending.StockItem(product1, 1);
                vending.StockItem(product1, 3);
                vending.StockItem(product2, 6);
                Console.WriteLine(vending.StockItem(product2, 6));

                Console.WriteLine(vending.StockFloat(20, 20));
                Console.WriteLine(vending.StockFloat(10, 20));
                Console.WriteLine(vending.StockFloat(5, 20));
                Console.WriteLine(vending.StockFloat(2, 20));
                Console.WriteLine(vending.StockFloat(1, 20));
                //vending.StockFloat(-20, 2);      //for testing exception

                var list0 = new List<int> { 5, -6 };
                var list = new List<int> { 5, 10, 20 };
                //vending.VendItem("B02", list);   //for testing exception
                //vending.VendItem("A02", list0);  //for testing exception
                Console.WriteLine(vending.VendItem("A01", list));
                Console.WriteLine(vending.VendItem("A01", list));
                //vending.RemoveItemByCode("A02");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        
    }
}
