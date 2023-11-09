using HomeWork8_1_;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace HomeWork6_1_
{
    public enum BankAccountType { current, saving }
    class BankAccount
    {
        private static ulong base_number = 1000_0000_0000_0000;
        private ulong number;
        private double balance;
        private BankAccountType type;
        private Queue<BankTransactions> accountTransactions = new Queue<BankTransactions>();

        /*private ulong SetRandomNumber()
        {
            Random rnd = new Random();
            return ulong.Parse(rnd.Next(1000, 10000).ToString() + rnd.Next(1000, 10000).ToString() +
                rnd.Next(1000, 10000).ToString() + rnd.Next(1000, 10000).ToString());

        }*/

        /// <summary>
        /// Конструктор, заполняющий поле баланс банковского счета
        /// </summary>
        /// <param name="balance"></param>
        public BankAccount(double balance)
        {
            this.balance = balance;
            type = BankAccountType.current;
            base_number++;
            number = base_number;
        }

        /// <summary>
        /// Конструктор, заполняющий поле тип банковского счета
        /// </summary>
        /// <param name="type"></param>
        public BankAccount(BankAccountType type)
        {
            this.type = type;
            base_number++;
            number = base_number;
        }

        /// <summary>
        /// Конструктор, заполняющий поля баланс и тип банковского счета
        /// </summary>
        /// <param name="balance"></param>
        /// <param name="type"></param>
        public BankAccount(double balance, BankAccountType type)
        {
            this.balance = balance;
            this.type = type;
            base_number++;
            number = base_number;
        }

        public ulong Number
        {
            get
            {
                return number;
            }
        }

        public double Balance
        {
            get
            {
                return balance;
            }
        }

        public BankAccountType Type
        {
            get
            {
                return type;
            }
        }

        public void AccountTransactions()
        {
            foreach (BankTransactions i in accountTransactions)
            {
                Console.WriteLine($"Дата: {i.DateTransaction}\t | Сумма: {i.SumTransaction}");
            }
        }

        /// <summary>
        /// Повзволяет снять деньги со счета
        /// </summary>
        /// <param name="sum"></param>
        public void TakeSomeMoney(double sum)
        {
            if (sum >= 0)
            {
                try
                {
                    checked
                    {
                        sum = Math.Round(sum, 2);
                        double temp = balance - sum;
                        if (temp > 0)
                        {
                            balance = temp;
                            accountTransactions.Enqueue(new BankTransactions(-sum));
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно средств");
                        }
                    }
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Нельзя списать такую большую сумму");
                }
            }
            else
            {
                Console.WriteLine("Списание не может быть отрицательным");
            }
        }

        /// <summary>
        /// Вносит деньги на счет
        /// </summary>
        /// <param name="sum"></param>
        public void DepositSomeMoney(double sum)
        {
            if (sum >= 0)
            {
                try
                {
                    checked
                    {
                        sum = Math.Round(sum, 2);
                        balance += sum;
                        accountTransactions.Enqueue(new BankTransactions(sum));
                    }
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Нельзя внести такую большую сумму");
                }
            }
            else
            {
                Console.WriteLine("Пополнение не может быть отрицательным");
            } 
        }

        /// <summary>
        /// Переводит на счет указанную сумму из указанного счета
        /// </summary>
        /// <param name="transfer_account"></param>
        /// <param name="sum"></param>
        public void TransferToThisAccount(BankAccount transfer_account, double sum)
        {
            if (sum >= 0)
            {
                try
                {
                    checked
                    {
                        if (transfer_account.balance >= sum)
                        {
                            transfer_account.balance -= sum;
                            balance += sum;
                            accountTransactions.Enqueue(new BankTransactions(sum));
                            transfer_account.accountTransactions.Enqueue(new BankTransactions(-sum));
                        }
                        else
                        {
                            Console.WriteLine("На счете недостаточно средств");
                        }
                    }
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Нельзя перевести такую большую сумму");
                }
            }
            else
            {
                Console.WriteLine("Перевод не может быть отрицательным");
            }
        }

        /// <summary>
        /// Очередь транзакций записывает в текстовый файл Transactions
        /// </summary>
        public void Dispose()
        {
            while (accountTransactions.Count != 0)
            {
                var temp = accountTransactions.Dequeue();
                File.AppendAllText("Transactions.txt", $"Дата: {temp.DateTransaction}\t| Сумма: {temp.SumTransaction}\n");
            }
            GC.SuppressFinalize(this);
        }
    }
}
