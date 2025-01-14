using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1_1
{
    struct User
    {
        public int money;

        public User(int money)
        {
            this.money = money;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // 0 -> ShowBalance
            // 1 -> WithdrawMoney
            // 2 -> DepositMoney
            // 3 -> TransferMoney
            // 8 -> Exit

            User user = new User(10000);
            bool keepDoing = true;
            Options options = new Options();

            while (keepDoing)
            {
                Console.WriteLine("=============================================\n" +
                                  "Please select option to execute.\n" +
                                  "0 -> Show Balance\n" +
                                  "1 -> Withdraw Money\n" +
                                  "2 -> Deposit Money\n" +
                                  "3 -> Transfer Money\n" +
                                  "8 -> Exit\n");

                try
                {
                    int option = int.Parse(Console.ReadLine());
                    switch (option)
                    {
                        case 0:
                            Console.WriteLine("Balance: {0}\n", user.money);
                            break;
                        case 1:
                            options.WithdrawMoney(ref user);
                            break;
                        case 2:
                            options.DepositMoney(ref user);
                            break;
                        case 3:
                            options.TransferMoney(ref user);
                            break;
                        case 8:
                            keepDoing = false;
                            break;
                        default:
                            Console.WriteLine("There is no option");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter an integer number");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("There is no option");
                }
            }
        }

    }

    internal class Options
    {
        public int GetInputMoney()
        {
            try
            {
                int money = int.Parse(Console.ReadLine());

                if (money < 0 || money > 100000)
                {
                    Console.WriteLine("Please enter an amount from 0 to 100000");
                    return -1;
                }
                else
                {
                    return money;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Amount should be an integer from 0 to 100000");
                return -1;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Please enter an amount from 0 to 100000");
                return -1;
            }
        }

        //public int GetInputMoney()
        //{
        //    if (int.TryParse(Console.ReadLine(), out int money))
        //    {
        //        if (money < 0 || money > 100000)
        //        {
        //            Console.WriteLine("Please enter an amount from 0 to 100000");
        //            return -1;
        //        }
        //        else
        //        {
        //            return money;
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Amount should be an integer from 0 to 100000");
        //        return -1;
        //    }
        //}

        public void WithdrawMoney(ref User user)
        {
            Console.Write("Enter the amount you want to withdraw: ");
            int money = GetInputMoney();

            if (money == -1)
            {
                return;
            }
            else if (money > user.money)
            {
                Console.WriteLine("Insufficient balance, please enter an amount from 0 to {0}", user.money);
                return;
            }
            else
            {
                user.money -= money;
                Console.WriteLine("Withdraw successfully!");
                Console.WriteLine("Balance: {0}", user.money);
                return;
            }
        }

        public void DepositMoney(ref User user)
        {
            Console.Write("Enter the amount you want to deposit: ");
            int money = GetInputMoney();

            if (money == -1)
            {
                return;
            }
            else
            {
                try
                {
                    user.money += money;
                    Console.WriteLine("Deposit successfully!");
                    Console.WriteLine("Balance: {0}", user.money);
                    return;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("The deposit amount exceeds the upper limit, and the ATM will not serve you.");
                    return;
                }
            }
        }

        public void TransferMoney(ref User user)
        {
            Console.Write("Enter transfer account: ");
            if (int.TryParse(Console.ReadLine(), out int account))
            {
                Console.Write("Enter transfer amount: ");
                int money = GetInputMoney();
                if (money == -1)
                {
                    return;
                }
                money = (int)(money * 1.1);
                Console.WriteLine("Final Cost (+10%): {0}", money);
                if (money > user.money)
                {
                    Console.WriteLine("Insufficient balance! the remaining balance is {0}, you can transfer money from 0 to {1} (+10% handling fee)", user.money, (int)(user.money / 1.1));
                    return;
                }
                else
                {
                    user.money -= money;
                    Console.WriteLine("Transfer successfully!");
                    Console.WriteLine("Balance: {0}", user.money);
                    return;
                }
            }
            else
            {
                Console.WriteLine("Account should be an integer");
                return;
            }
        }
    }
}
