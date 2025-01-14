using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace F74121246_Practice_2_2
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
    public class UserHistory
    {
        public int maxConsumption;
        public Queue<int> preventHistory;

        public UserHistory(int maxConsumption)
        {
            this.maxConsumption = maxConsumption;
            this.preventHistory = new Queue<int>(3);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            bool keepRuning = true;
            bool isOpening = false;
            Options options = new Options();
            List<Commodity> commodities = new List<Commodity>();
            List<int> income = new List<int>();
            Dictionary<string, UserHistory> users = new Dictionary<string, UserHistory>();

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

                // get option
                int option;

                try
                {
                    option = int.Parse(Console.ReadLine().Trim());
                    switch (option)
                    {
                        case 1:
                            if (!isOpening)
                            {
                                while (!isOpening)
                                {
                                    isOpening = options.OpenShop(commodities);
                                }
                            }
                            else
                            {
                                Console.WriteLine("已開店，請選擇其他選項");
                            }
                            break;
                        case 2:
                            if (isOpening)
                            {
                                int tmp = options.AddOrder(commodities, users);
                                if (tmp > 0)
                                {
                                    income.Add(tmp);
                                }
                            }
                            else
                            {
                                Console.WriteLine("尚未開店，請先按 1 開店");
                            }
                            break;
                        case 3:
                            if (isOpening)
                            {
                                options.GetAllInventory(commodities);
                            }
                            else
                            {
                                Console.WriteLine("尚未開店，請先按 1 開店");
                            }
                            break;
                        case 4:
                            if (isOpening)
                            {
                                options.GetAllIncome(income);
                            }
                            else
                            {
                                Console.WriteLine("尚未開店，請先按 1 開店");
                            }
                            break;
                        case 5:
                            if (isOpening)
                            {
                                options.SortedCommodities(commodities);
                            }
                            else
                            {
                                Console.WriteLine("尚未開店，請先按 1 開店");
                            }
                            break;
                        case 6:
                            keepRuning = false;
                            break;
                        default:
                            Console.WriteLine("並沒有此選項");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("請輸入數字選項 (1 ~ 6) !");
                    continue;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("輸入數字選項過大，請輸入正確的數字選項 (1 ~ 6) !");
                }
            }
        }
    }

    class Options
    {
        private int[] StringToIntArray(string[] strings)
        {
            int[] ints = new int[strings.Length];
            for (int i = 0; i < strings.Length; i++)
            {
                if (! (int.TryParse(strings[i], out ints[i])))
                {
                    return null;
                }
            }
            return ints;
        }

        public bool OpenShop(List<Commodity> commodities) // case 1;
        {
            try
            {
                // get the length of commodities
                Console.Write("請輸入今日總共有幾種商品要販售: ");
                int amount = int.Parse(Console.ReadLine().Trim());

                // get all name of commodities
                Console.Write("請依序輸入每一種商品的名稱: ");
                string input = Console.ReadLine().Trim();
                string[] commoditiesName = Regex.Split(input, @"\s+");
                if (commoditiesName.Length == amount)
                {
                    Console.Write("\n輸入成功! 你總共有 {0} 個商品, 每一個商品的名稱依序是: ", amount); // result
                    for (int i = 0; i < commoditiesName.Length; i++)
                    {
                        Console.Write($"{commoditiesName[i]} ");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("\n輸入長度不符合商品數量，開店失敗\n"); // result
                    return false;
                }

                // get all price of commodities
                Console.Write("請你依序輸入每一個商品的價格: ");
                input = Console.ReadLine().Trim();
                int[] commoditiesPrice = StringToIntArray(Regex.Split(input, @"\s+"));
                if (commoditiesPrice == null) // can't int.parse
                {
                    Console.WriteLine("\n價格應該要為數字，開店失敗\n"); // result
                    return false;
                }
                if (commoditiesPrice.Length == amount)
                {
                    Console.WriteLine("\n輸入成功! 每一種商品的價格依序為: "); // result
                    for (int i = 0; i < amount; i++)
                    {
                        Console.WriteLine("{0} : {1}", commoditiesName[i], commoditiesPrice[i]);
                    }
                }
                else
                {
                    Console.WriteLine("\n輸入長度不符合商品數量，開店失敗\n"); // result
                    return false;
                }

                Console.WriteLine();

                // get all inventory of commodities
                Console.Write("請你依序輸入每一個商品的庫存: ");
                input = Console.ReadLine().Trim();
                int[] commoditiesInventory = StringToIntArray(Regex.Split(input, @"\s+"));
                if (commoditiesInventory == null) // can't int.parse
                {
                    Console.WriteLine("\n庫存數應該要為數字，開店失敗\n"); // result
                    return false;
                }
                if (commoditiesInventory.Length == amount)
                {
                    Console.WriteLine("\n輸入成功! 每一種商品的庫存數量為: "); // result
                    for (int i = 0; i < amount; i++)
                    {
                        Console.WriteLine("{0} : {1}", commoditiesName[i], commoditiesInventory[i]);
                    }
                }
                else
                {
                    Console.WriteLine("\n輸入長度不符合商品數量，開店失敗\n"); // result
                    return false;
                }

                // all success
                Console.WriteLine();

                // stort commodities to list
                for (int i = 0; i < amount; i++)
                {
                    commodities.Add(new Commodity(commoditiesName[i], commoditiesPrice[i], commoditiesInventory[i]));
                }

                Console.WriteLine("開店程序完成，已開店"); // result
                return true;
            }
            catch (FormatException)
            {
                Console.WriteLine("\n輸入格式錯誤，開店失敗\n"); // result
                return false;
            }
            catch (OverflowException)
            {
                Console.WriteLine("\n輸入值太大，開店失敗\n"); // result
                return false;
            }

        }

        private bool JudgeNeedAmount(int[] needAmount, List<Commodity> commodities)
        {
            if (needAmount == null)
            {
                Console.WriteLine("\n欲購商品個數應為整數，請重新輸入，或輸入 -1 取消訂單 !\n");
                return false;
            }
            if (needAmount.Length != commodities.Count)
            {
                Console.WriteLine("\n輸入長度應與商品種類個數相同，請重新輸入，或輸入 -1 取消訂單 !\n");
                return false;
            }
            foreach (int i in needAmount)
            {
                if (i < 0)
                {
                    Console.WriteLine("\n欲購商品個數應為正整數，請重新輸入，或輸入 -1 取消訂單 !\n");
                    return false;
                }
            }
            return true;
        }

        private bool JudgeUserName(string userName)
        {
            foreach (char c in userName)
            {
                if (!char.IsLetter(c) && c != ' ')
                {
                    return false;
                }
            }
            return true;
        }

        private void EnqueueUserHistory(UserHistory userHistory, int cost)
        {
            if (userHistory.preventHistory.Count == 3) // full Queue
            {
                userHistory.preventHistory.Dequeue();
            }
            userHistory.preventHistory.Enqueue(cost);
        }

        private int[] GetPreventHistory(UserHistory userHistory)
        {
            int[] ans = new int[3];
            int[] queueArray = userHistory.preventHistory.ToArray();
            int count = queueArray.Length;

            for (int i = 0; i < count; i++)
            {
                ans[i] = queueArray[count - i - 1];
            }

            for (int i = count; i < 3; i++)
            {
                ans[i] = 0;
            }

            return ans;
        }

        private int JudgeMoneyValid(string money)
        {
            try
            {
                int customerMoney = int.Parse(money);

                if (customerMoney > 0)
                {
                    return customerMoney;
                }
                else
                {
                    return -2;
                }
            }
            catch (FormatException)
            {
                return -2;
            }
            catch (OverflowException)
            {
                return -2;
            }
        }

        public int AddOrder(List<Commodity> commodities, Dictionary<string, UserHistory> users) // case 2;
        {
            try
            {
                // first get customer's need amount
                Console.Write("請依序輸入此訂單每一種類的商品各需要買幾個: ");
                int[] needAmount = StringToIntArray(Regex.Split(Console.ReadLine().Trim(), @"\s+"));
                bool judgeNeedAmount = JudgeNeedAmount(needAmount, commodities);
                int cost = 0;

                while (true)
                {
                    // fail and get customer's need amount again
                    while (!judgeNeedAmount)
                    {
                        Console.Write("請依序輸入此訂單每一種類的商品各需要買幾個: ");
                        string input = Console.ReadLine().Trim();
                        if (input == "-1")
                        {
                            Console.WriteLine("訂單取消 !");
                            return 0;
                        }
                        needAmount = StringToIntArray(Regex.Split(input, @"\s+"));
                        judgeNeedAmount = JudgeNeedAmount(needAmount, commodities);
                    }


                    // check inventory > need amount
                    try
                    {
                        for (int i = 0; i < needAmount.Length; i++)
                        {
                            if (commodities[i].inventory < needAmount[i])
                            {
                                Console.WriteLine("\n庫存不足，此筆訂單取消\n");
                                return 0;
                            }
                            checked
                            {
                                cost += (needAmount[i] * commodities[i].price);
                            }
                        }
                        if (cost == 0)
                        {
                            Console.WriteLine("\n卡比懷疑你想炸機，請重新輸入，或輸入 -1 取消訂單 !\n");
                            judgeNeedAmount = false;
                            continue;
                        }
                        break;
                    } catch (OverflowException)
                    {
                        Console.WriteLine("\n訂單金額龐大，超過系統負荷，此筆訂單取消，請分批輸入，或輸入 -1 取消訂單 !\n");
                        judgeNeedAmount = false;
                        continue;
                    }
                }


                // try to get customer's money
                bool isMoneyEnough = true;
                bool isMoneyValid = true;
                Console.Write("訂單成立! 總金額為: {0} ，", cost);
                
                if (cost >= 1000)
                {
                    Random random = new Random();
                    int discount = random.Next(1, 10);
                    cost = (int)((double)cost * discount / 10);
                    Console.Write("因訂單滿 1000 元，因此總金額打 {0} 折，打折後為 {1} 元，", discount, cost);
                }
                Console.Write("請輸入付款金額: ");

                string customerMoneyStr = Console.ReadLine().Trim();
                int customerMoney = JudgeMoneyValid(customerMoneyStr);

                if (customerMoney == -2)
                {
                    isMoneyValid = false;
                }
                if (customerMoney < cost)
                {
                    isMoneyEnough = false;
                }

                while (!isMoneyEnough || !isMoneyValid)
                {
                    if (!isMoneyValid)
                    {
                        Console.Write("\n付款金額應為正整數，請再輸入一次 (或輸入 -1 直接取消此筆訂單): ");
                        isMoneyValid = true;
                    }
                    else if (!isMoneyEnough)
                    {
                        Console.Write("\n付款金額不足，請再輸入一次 (或輸入 -1 直接取消此筆訂單): ");
                    }
                    customerMoneyStr = Console.ReadLine().Trim();
                    if (customerMoneyStr == "-1")
                    {
                        Console.WriteLine("訂單取消!");
                        return 0;
                    }
                    customerMoney = JudgeMoneyValid(customerMoneyStr);
                    if (customerMoney == -2)
                    {
                        isMoneyValid = false;
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

                Console.Write("請輸入消費者的名字: ");
                string userName;
                while (true)
                {
                    userName = Console.ReadLine().Trim();
                    if (!JudgeUserName(userName))
                    {
                        Console.Write("輸入格式只包含大小寫英文字母與空格，請重新輸入: ");
                    } 
                    else
                    {
                        break;
                    }
                }

                Console.WriteLine("\n消費者 {0} 的歷史資訊: ", userName);

                if (users.ContainsKey(userName))
                {
                    users[userName].maxConsumption = Math.Max(users[userName].maxConsumption, cost);
                    EnqueueUserHistory(users[userName], cost);
                }
                else // create a new account
                {
                    UserHistory newUser = new UserHistory(cost);
                    newUser.preventHistory.Enqueue(cost);
                    users.Add(userName, newUser);
                }

                Console.WriteLine("\n此消費者的歷史訂單中，最大金額為 {0}", users[userName].maxConsumption);
                int[] preventHistory = GetPreventHistory(users[userName]);
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine("近期交易 {0} : {1}", i+1, preventHistory[i]);
                }
                Console.WriteLine();

                return cost;
            }
            catch (FormatException)
            {
                Console.WriteLine("請輸入數字");
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

        public void GetAllIncome(List<int> income) // case 4
        {
            int total = 0;
            foreach (int i in income)
            {
                if (i == 0)
                {
                    continue;
                }
                else
                {
                    Console.WriteLine($"+ {i}");
                }
                total += i;
            }
            Console.WriteLine($"Total income : {total}");
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
            for (int i = 0; i < sortedCommodities.Count; i++)
            {
                Console.WriteLine("第 {0} 名: {1}，總購買次數共 {2} 次", i + 1, sortedCommodities[i].name, sortedCommodities[i].totalPurchaseCount);
            }
        }


    }
}
