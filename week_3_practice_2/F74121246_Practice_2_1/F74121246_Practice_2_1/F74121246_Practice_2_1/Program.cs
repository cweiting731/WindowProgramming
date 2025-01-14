using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F74121246_Practice_2_1
{
    class Commodity
    {
        public string name;
        public int price;
        public int inventory;
        public int totalPurchaseCount;

        public Commodity(string name, int price, int inventory)
        {
            this.name = name;
            this.price = price;
            this.inventory = inventory;
            this.totalPurchaseCount = 0;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            bool keepRuning = true;
            Options options = new Options();
            List<Commodity> commodities = new List<Commodity>();
            int income = 0;

            while (keepRuning)
            {
                Console.WriteLine("歡迎來到 NCKU 卡比商店交易系統");
                Console.WriteLine("======================================");
                Console.WriteLine("(1) 開店");
                Console.WriteLine("(2) 新增訂單");
                Console.WriteLine("(3) 查詢庫存");
                Console.WriteLine("(4) 查詢總收入");
                Console.WriteLine("(5) 計算人氣商品排名");
                Console.WriteLine("(6) 關店");
                Console.WriteLine("======================================");
                Console.Write("請輸入您現在想要進行的操作: ");

                int option;
                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    continue;
                }

                switch (option)
                {
                    case 1:
                        options.OpenShop(commodities);
                        break;
                    case 2:
                        income += options.AddOrder(commodities);
                        break;
                    case 3:
                        options.GetAllInventory(commodities);
                        break;
                    case 4:
                        Console.WriteLine("總收入為: {0}", income);
                        break;
                    case 5:
                        options.SortedCommodities(commodities);
                        break;
                    case 6:
                        keepRuning = false;
                        break;
                    default:
                        Console.WriteLine("並沒有此選項");
                        break;
                }

            }
        }
    }

    class Options
    {
        public void OpenShop(List<Commodity> commodities) // case 1;
        {
            try
            {
                // get the length of commodities
                Console.Write("請輸入今日總共有幾種商品要販售: ");
                int amount = int.Parse(Console.ReadLine());

                // get all name of commodities
                Console.Write("請依序輸入每一種商品的名稱: ");
                string input = Console.ReadLine();
                string[] commoditiesName = input.Split(' ');
                if(commoditiesName.Length == amount)
                {
                    Console.WriteLine("\n輸入成功! 你總共有 {0} 個商品, 每一個商品的名稱依序是: {1}", amount, input);
                }
                else
                {
                    Console.WriteLine("輸入長度不符合商品數量");
                    return;
                }

                // get all price of commodities
                Console.Write("請你依序輸入每一個商品的價格: ");
                input = Console.ReadLine();
                string[] commoditiesPrice = input.Split(' ');
                if (commoditiesPrice.Length == amount)
                {
                    Console.WriteLine("\n輸入成功! 每一種商品的價格依序為: ");
                    for (int i=0; i<amount; i++)
                    {
                        Console.WriteLine("{0} : {1}", commoditiesName[i], commoditiesPrice[i]);
                    }
                }
                else
                {
                    Console.WriteLine("輸入長度不符合商品數量");
                    return;
                }

                Console.WriteLine();

                // get all inventory of commodities
                Console.Write("請你依序輸入每一個商品的庫存: ");
                input= Console.ReadLine();
                string[] commoditiesInventory = input.Split(' ');
                if (commoditiesInventory.Length == amount)
                {
                    Console.WriteLine("\n輸入成功! 每一種商品的庫存數量為: ");
                    for (int i = 0; i < amount; i++)
                    {
                        Console.WriteLine("{0} : {1}", commoditiesName[i], commoditiesInventory[i]);
                    }
                }
                else
                {
                    Console.WriteLine("輸入長度不符合商品數量");
                    return;
                }


                Console.WriteLine();

                // stort commodities to list
                for (int i=0; i<amount; i++)
                {
                    commodities.Add(new Commodity(commoditiesName[i], int.Parse(commoditiesPrice[i]), int.Parse(commoditiesInventory[i])));
                }

                Console.WriteLine("開店程序完成，已開店");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return;
            }

        }

        public int AddOrder(List<Commodity> commodities) // case 2;
        {
            try
            {
                // get customer's need amount
                Console.Write("請依序輸入此訂單每一種類的商品各需要買幾個: ");
                string[] input = Console.ReadLine().Split(' ');
                int[] needAmount = new int[input.Length];
                for (int i = 0; i < input.Length; i++)
                {
                    needAmount[i] = int.Parse(input[i]);
                }

                int cost = 0;

                // check inventory > need amount
                for (int i = 0; i < needAmount.Length; i++)
                {
                    if (commodities[i].inventory < needAmount[i])
                    {
                        Console.WriteLine("\n庫存不足，此筆訂單不成立\n");
                        return 0;
                    }
                    cost += (needAmount[i] * commodities[i].price);
                }

                // try to get customer's money
                bool isMoneyEnough = true;
                Console.Write("訂單成立! 總金額為: {0} ，請輸入付款金額: ", cost);
                int customerMoney = int.Parse(Console.ReadLine());
                if (customerMoney < cost)
                {
                    isMoneyEnough = false;
                }
                while (!isMoneyEnough)
                {
                    Console.Write("\n付款金額不足，請再輸入一次 (或輸入 -1 直接取消此筆訂單): ");
                    customerMoney = int.Parse(Console.ReadLine());
                    if (customerMoney == -1)
                    {
                        Console.WriteLine("訂單取消!");
                        return 0;
                    }

                    if (customerMoney >= cost)
                    {
                        isMoneyEnough = true;
                    }
                }

                customerMoney -= cost;

                for (int i = 0; i < needAmount.Length; i++)
                {
                    commodities[i].inventory -= needAmount[i];
                    commodities[i].totalPurchaseCount += needAmount[i];
                }
                Console.WriteLine("\n付款完成! 請找零 {0} 元", customerMoney);
                return cost;
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return 0;
            }

        }

        public void GetAllInventory(List<Commodity> commodities) // case 3;
        {
            bool isInventoryEnough = true;
            foreach (Commodity commodity in commodities)
            {
                if (commodity.inventory <= 5)
                {
                    isInventoryEnough = false;
                }
                Console.WriteLine("{0} : {1}", commodity.name, commodity.inventory);
            }
            if (!isInventoryEnough)
            {
                Console.WriteLine("有商品的庫存數量不足!");
            }
        }

        public void SortedCommodities(List<Commodity> commodities) // case 5;
        {
            List<Commodity> sortedCommodities = new List<Commodity>(commodities);

            sortedCommodities.Sort((x, y) =>
            {
                int purchaseCountComparison = y.totalPurchaseCount.CompareTo(x.totalPurchaseCount);

                if (purchaseCountComparison == 0)
                {
                    return commodities.IndexOf(x).CompareTo(commodities.IndexOf(y));
                }

                return purchaseCountComparison;
            });

            Console.WriteLine("人氣商品排行表:");
            for (int i=0; i < sortedCommodities.Count; i++)
            {
                Console.WriteLine("第 {0} 名: {1}，總購買次數共 {2} 次", i+1, sortedCommodities[i].name, sortedCommodities[i].totalPurchaseCount);
            }
        }

    }
}
