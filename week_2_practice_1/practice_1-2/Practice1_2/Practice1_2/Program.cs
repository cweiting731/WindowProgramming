using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;

namespace Pratice1_2
{
    public class User
    {
        public int account;
        public int money;
        public int lovePoint; // for no handling fee

        public User(int account, int money)
        {
            this.account = account;
            this.money = money;
            this.lovePoint = 0;
        }
    }

    public struct HistoryNode
    {
        public DateTime time;
        public string option;
        public int balance;
        public int lovePoint;
        public int transferAccount;
        public int money; // process money

        // this instructor for everything not for transfer money
        public HistoryNode(DateTime time, string option, int money, int balance, int lovePoint)
        {
            this.time = time;
            this.option = option;
            this.balance = balance;
            this.lovePoint = lovePoint;
            this.transferAccount = -1;
            this.money = money;
        }

        // this instructor for transfer money
        public HistoryNode(DateTime time, string option, int money, int balance, int lovePoint, int transferAccount)
        {
            this.time = time;
            this.option= option;
            this.balance = balance;
            this.lovePoint = lovePoint;
            this.transferAccount = transferAccount;
            this.money = money;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            bool keepDoing = true;
            bool signedIn = false;
            Options options = new Options();
            User user = new User(-1, -1); // tmp user for init
            
            // set initial 10 account and history list
            LinkedList<User> accounts = new LinkedList<User>();
            LinkedList<HistoryNode> history = new LinkedList<HistoryNode> ();

            for(int i=0; i<10; i++)
            {
                accounts.AddLast(new User(i * 1000 + 10000, 10000));
            }

            // sign in page
            Console.WriteLine("Welcome to NiCKU ATM!");
            do
            {
                // get account and make sure that account is a 5-digit integer
                Console.Write("Please enter your account: ");
                try
                {
                    int account = int.Parse(Console.ReadLine());
                    // check input account is a 5-digit integer
                    if (account < 10000 || account > 99999)
                    {
                        Console.WriteLine("Account should be a 5-digit integer");
                        continue;
                    } 
                    // check accounts have not the same account
                    else if (options.ContainsAccount(accounts, account))
                    {
                        Console.WriteLine("Already have this account, please try another one!");
                        continue;
                    }
                    // sign in successfully, create a user for controller now and add user to accounts
                    else
                    {
                        user = new User(account, 10000);
                        accounts.AddLast(user);
                        Console.WriteLine("Sign in successfully!");
                        signedIn = true;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a 5-digit integer");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Account should be a 5-digit integer");
                }
            } while (!signedIn);

            // options page
            while (keepDoing)
            {
                Console.WriteLine("=============================================\n" +
                                  "Please select option to execute.\n" +
                                  "0 -> Show Balance\n" +
                                  "1 -> Withdraw Money\n" +
                                  "2 -> Deposit Money\n" +
                                  "3 -> Transfer Money\n" +
                                  "4 -> Donate\n" +
                                  "5 -> History\n" +
                                  "8 -> Exit\n");

                try
                {
                    // get input option
                    int option = int.Parse(Console.ReadLine());
                    switch (option)
                    {
                        case 0: // show balance
                            Console.WriteLine("Balance: {0}\n", user.money);
                            // history.AddLast(new HistoryNode(0, user.money, true));
                            break;
                        case 1: // withdraw money
                            options.WithdrawMoney(user, history);
                            break;
                        case 2: // deposit money
                            options.DepositMoney(user, history);
                            break;
                        case 3: // transfer money
                            options.TransferMoney(user, history, accounts);
                            break;
                        case 4: // donate money
                            options.Donate(user, history);
                            break;
                        case 5: // history
                            options.PrintAllHistory(history);
                            break;
                        case 8: // exit
                            keepDoing = false;
                            break;
                        case 65304: // Hidden Function! show all account
                            options.PrintAllAccount(accounts);
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

        public bool ContainsAccount(LinkedList<User> accounts, int account)
        {
            foreach (User user in accounts)
            {
                if(user.account == account)
                {
                    return true;
                }
            }
            return false;
        }

        public User GetTargetAccount(LinkedList<User> accounts, int targetAccount)
        {
            foreach (User account in accounts)
            {
                if (account.account == targetAccount)
                {
                    return account;
                }
            }
            return null;
        }

        public void WithdrawMoney(User user, LinkedList<HistoryNode> history)
        {
            Console.Write("Enter the amount you want to withdraw: ");
            int money = GetInputMoney();

            // the input amount doesn't meet the requirment
            if (money == -1)
            {
                return;
            }
            // the input amount out of balance
            else if (money > user.money)
            {
                Console.WriteLine("Insufficient balance, please enter an amount from 0 to {0}", user.money);
                return;
            }
            // withdraw successfully
            else
            {
                user.money -= money;
                Console.WriteLine("Withdraw successfully!");
                Console.WriteLine("Balance: {0}", user.money);
                // add to history
                history.AddLast(new HistoryNode(DateTime.Now, "1 - Withdraw", money * (-1), user.money, user.lovePoint));
                return;
            }
        }

        public void DepositMoney(User user, LinkedList<HistoryNode> history)
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
                    history.AddLast(new HistoryNode(DateTime.Now, "2 - Deposit", money, user.money, user.lovePoint));
                    return;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Your account has reached the deposit limit and this ATM is no longer in service.");
                    return;
                }
            }
        }

        public void TransferMoney(User user, LinkedList<HistoryNode> history, LinkedList<User> accounts)
        {
            Console.Write("Enter transfer account: ");
            try
            {
                int transferAccount = int.Parse(Console.ReadLine());
                // check input account is a 5-digit integer
                if (transferAccount < 10000 || transferAccount > 99999)
                {
                    Console.WriteLine("Account you want to transfer money must be a 5-digit integer");
                    return;
                }
                // avoid to transfer to self
                else if (transferAccount == user.account)
                {
                    Console.WriteLine("You cannot transfer to yourself");
                    return;
                }
                // get target account in accounts
                else
                {
                    // To get the account you want to transfer
                    User transferTarget = GetTargetAccount(accounts, transferAccount);

                    if (transferTarget == null) // Don't have the target account, create one or quit
                    {
                        Console.WriteLine("This is not a exist account, press 1 if you want to open a new account and keep going");
                        string judge = Console.ReadLine();
                        if (judge == "1")
                        {
                            transferTarget = new User(transferAccount, 0);
                            accounts.AddLast(transferTarget);
                            Console.WriteLine("successfully create a new account");
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input");
                            return;
                        }
                    }

                    // To get the money you want to transfer
                    Console.Write("Please enter the amount you want to transper: ");
                    int money = GetInputMoney();
                    if(money == -1)
                    {
                        return;
                    }
                    
                    // have love point or not to choose whether you want to save handling fee
                    bool isSaving = false;
                    if (user.lovePoint > 0)
                    {
                        Console.WriteLine("You have {0} love points, do you want to use 1 love point to save handling fee\n Press 1 to use\n Press 0 to not use", user.lovePoint);
                        string judge = Console.ReadLine();
                        switch (judge)
                        {
                            case "1":
                                isSaving = true;
                                user.lovePoint--;
                                break;
                            case "0":
                                break;
                            default:
                                Console.WriteLine("Invalid Input");
                                return;
                        }
                    }

                    // count final cost
                    int originalMoney = money;
                    if(!isSaving)
                    {
                        money = (int)(money * 1.1);
                    }

                    // insufficient balance
                    if (money > user.money)
                    {
                        Console.WriteLine("Insufficient balance, you can transper 0 ~ {0} (+{1}% handling fee)", isSaving ? (user.money) : (int)(user.money / 1.1), isSaving ? 0 : 10);
                        return;
                    }

                    // success transfer money
                    transferTarget.money += originalMoney;
                    user.money -= money;
                    history.AddLast(new HistoryNode(DateTime.Now, "3 - Transfer", money * (-1), user.money, user.lovePoint, transferAccount));
                    Console.WriteLine("Final cost (+{0}%) : {1}", isSaving ? 0 : 10, money);
                    Console.WriteLine("Transfer successfully! Balance: {0}", user.money);
                    return;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Account must be a 5 digit integer");
                return;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Account you want to transfer money must be a 5-digit integer");
                return;
            }
        }

        public void PrintAllAccount(LinkedList<User> accounts)
        {
            Console.WriteLine("{0, -10} {1, -10} {2, -10}", "Account", "Balance", "LovePoint");
            foreach (User user in accounts)
            {
                Console.WriteLine("{0, -10} {1, -10} {2, -10}", user.account, user.money, user.lovePoint);
            }
        }

        public void PrintAllHistory(LinkedList<HistoryNode> history)
        {
            Console.WriteLine("{0, -23}{1, -15}{2, -11}{3, -10}| {4, -10}{5, -10}", "Time", "Options", "TransferTo", "Money", "Balance", "Love Point");

            foreach (HistoryNode historyNode in history)
            {
                Console.Write("{0, -23}", historyNode.time.ToString("yyyy-MM-dd HH:mm:ss"));
                // print option
                Console.Write("{0, -15}", historyNode.option);

                // print transferTo
                if (historyNode.transferAccount == -1)
                {
                    Console.Write("{0, -11}", "");
                }
                else
                {
                    Console.Write("{0, -11}", historyNode.transferAccount);
                }

                // print process money
                if (historyNode.money >= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green; // green for adding to balance
                    Console.Write("+{0, -9}", historyNode.money);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red; // red for reducing to balance
                    Console.Write("{0, -10}", historyNode.money);
                }
                Console.ResetColor();

                // Print balance and lovePoint
                Console.WriteLine("| {0, -10}{1, -10}", historyNode.balance, historyNode.lovePoint);
            }
        }

        public void Donate(User user, LinkedList<HistoryNode> history) 
        {
            Console.Write("Enter the amount you want to donate: ");
            int money = GetInputMoney();

            // the input amount doesn't meet the requirement
            if (money == -1)
            {
                return;
            }
            // the input amount out of balance
            else if (money > user.money)
            {
                Console.WriteLine("Insufficient balance, please enter an amount from 0 to {0}", user.money);
                return;
            }
            // donate successfully
            else
            {
                user.money -= money;
                user.lovePoint += money / 1000;
                Console.WriteLine("Donate successfully!");
                Console.WriteLine("Balance: {0}, Love Point: {1}", user.money, user.lovePoint);
                history.AddLast(new HistoryNode(DateTime.Now, "4 - Donate", money * (-1), user.money, user.lovePoint));
                return;
            }
        }
    }
}
