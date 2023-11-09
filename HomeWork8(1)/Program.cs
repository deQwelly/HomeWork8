using HomeWork6_1_;
using HomeWork7_1_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork8_1_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ///Упражнение 9.1
            Console.WriteLine("Упражнение 9.1: создать конструктор для заполнения поля баланс, конструктор" +
                "\r\nдля заполнения поля тип банковского счета, конструктор для заполнения баланса и типа\r\nбанковского счета.");
            BankAccount account1 = new BankAccount(16500);
            Console.WriteLine($"Номер счета: {account1.Number}\t | Баланс счета: {account1.Balance}\t | Тип счета: {account1.Type}");
            BankAccount account2 = new BankAccount(BankAccountType.current);
            Console.WriteLine($"Номер счета: {account2.Number}\t | Баланс счета: {account2.Balance}\t | Тип счета: {account2.Type}");
            BankAccount account3 = new BankAccount(178900, BankAccountType.saving);
            Console.WriteLine($"Номер счета: {account3.Number}\t | Баланс счета: {account3.Balance}\t | Тип счета: {account3.Type}");

            ///Упражнение 9.2
            Console.WriteLine("\nУпражнение 9.2: Создать новый класс BankTransaction, который будет хранить информацию" +
                "\r\nо всех банковских операциях. В классе банковский счет добавить закрытое поле типа\r\n" +
                "System.Collections.Queue, которое будет хранить объекты класса BankTransaction для\r\nданного банковского счета");
            account1.DepositSomeMoney(1000);
            account1.TakeSomeMoney(250);
            account1.TransferToThisAccount(account3, 10000);
            account2.TransferToThisAccount(account1, 8000);

            Console.WriteLine();
            Console.WriteLine("Счет 1: ");
            account1.AccountTransactions();
            Console.WriteLine("\nСчет 2: ");
            account3.AccountTransactions();

            Console.WriteLine();
            Console.WriteLine($"Номер счета: {account1.Number}\t | Баланс счета: {account1.Balance}\t | Тип счета: {account1.Type}");
            Console.WriteLine($"Номер счета: {account2.Number}\t | Баланс счета: {account2.Balance}\t | Тип счета: {account2.Type}");
            Console.WriteLine($"Номер счета: {account3.Number}\t | Баланс счета: {account3.Balance}\t | Тип счета: {account3.Type}");

            ///Упражнение 9.3
            Console.WriteLine("\nУпражнение 9.3: В классе банковский счет создать метод Dispose, который данные о" +
                "\r\nпроводках из очереди запишет в файл.");
            account1.Dispose();

            ///Домашнее задание 9.1
            Console.WriteLine("\nДомашнее задание 9.1");
            Song song1 = new Song("Смуглянка", "Академический Ансамбль песни и пляски Российской Армии имени А.В Александрова");
            Song song2 = new Song("Billie Jean", "Michael Jackson", song1);
            Song mySong = new Song();

            Console.WriteLine($"{song1.Name}, {song1.Author}");
            Console.WriteLine($"{song2.Name}, {song2.Author}, {song2.Prev.Name}");
        }
    }
}
