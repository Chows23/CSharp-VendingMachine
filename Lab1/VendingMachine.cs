using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    class VendingMachine
    {
        public readonly int SerialNumber;
        public static int _nextSerialNumber = 1;
        public Dictionary<int, int> MoneyFloat { get; set; }
        public Dictionary<Product, int> Inventory { get; set; }

        public VendingMachine()
        {
            this.MoneyFloat = new Dictionary<int, int>();
            this.Inventory = new Dictionary<Product, int>();
            SerialNumber = _nextSerialNumber++;
        }


        public string StockItem(Product product, int Quantity)
        {
            if (Quantity < 0)
            {
                throw new StockItemQuantityException("stockItem's quantity can not be negative");
            }
            if (Inventory.ContainsKey(product))
            {
                Inventory[product] += Quantity;
                return $"{product.Name} update the quantity, and new quantity is {Inventory[product]}";
            }
            else
            {
                Inventory.Add(product, Quantity);
                return $"{product.Name}, {product.Code}, {product.Price}$, and stock is {Inventory[product]}";
            }
        }


        public string StockFloat(int MoneyDenomination, int Quantity)
        {
            if (MoneyDenomination < 0 || Quantity == 0)
            {
                throw new PriceNegativeOrZeroException("negative or zero, please try it again");
            }

            if (!MoneyFloat.ContainsKey(MoneyDenomination))
            {
                MoneyFloat.Add(MoneyDenomination, Quantity);
            }
            else
            {
                MoneyFloat[MoneyDenomination] += Quantity;
            }
            int total = 0;
            foreach (var money in MoneyFloat)
                total += money.Key * money.Value;

            return $"StockFloat({MoneyDenomination}, {Quantity}) adds {Quantity} ${MoneyDenomination} coins to the machine’s change the total mount is {total}$";
        }


        public string VendItem(string code, List<int> Money)
        {
            Product inputProduct = FindProductByCode(code);

            var totalMoney = 0;
            foreach (var i in Money)
                totalMoney += i;

            if (!this.Inventory.ContainsKey(inputProduct))
            {
                throw new InputException($"no found item with this code \"{code}\"");
            }
            if (totalMoney - inputProduct.Price < 0)
            {
                throw new InputMoneyException("insufficient money");
            }

            foreach (var item in this.Inventory)
            {
                if (item.Key.Code == code)
                {
                    if (item.Value == 0)
                    {
                        return $"{item.Key.Name} is out of stock";
                    }
                    else
                    {
                        var moneyChange = TransferChange(totalMoney - item.Key.Price);
                        PrintResult(this.MoneyFloat, moneyChange);
                    }
                }
            }
            this.Inventory[inputProduct]--;
            return "tansaction successful.";
        }


        public Product FindProductByCode(string code)
        {
            foreach (var product in this.Inventory)
            {
                if (code.Equals(product.Key.Code))
                {
                    return product.Key;
                }
            }
            return new Product();
        }


        static Dictionary<int, int> TransferChange(int moneyChange)
        {
            int twenty = moneyChange / 20;
            int ten = (moneyChange % 20) / 10;
            int five = ((moneyChange % 20) % 10) / 5;
            int two = (((moneyChange % 20) % 10) % 5) / 2;
            int one = (((moneyChange % 20) % 10) % 5) % 2;
            var dict = new Dictionary<int, int>()
            {
                { 1, one },
                { 2, two },
                { 5, five },
                { 10, ten },
                { 20, twenty },
            };
            return dict;
        }


        static void PrintResult(Dictionary<int, int> machine, Dictionary<int, int> transferDict)
        {
            foreach (var i in transferDict)
            {
                if (machine.ContainsKey(i.Key) && machine[i.Key] < i.Value)
                {
                    Console.WriteLine($"The machine is out of a {i.Key} coin");
                }
                else if (machine.ContainsKey(i.Key) && machine[i.Key] >= i.Value)
                {
                    machine[i.Key] -= i.Value;
                    Console.WriteLine($"The machine return {i.Key}$ coin: {i.Value} {(i.Value > 1 ? "pieces" : "piece")} ");
                }
            }
        }

    }
}
