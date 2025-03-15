using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmOperationsWithDb
{
    internal class Atm
    {
        private User _user;
        private readonly Menu _menu;

        public Atm(Menu menu)
        {
            _menu = menu;
        }

        public void Run()
        {
            while (true)
            {
                _menu.StartMenu();
                string language = Console.ReadLine();

                if (language == "1")
                {
                    HandleSession("EN");
                }
                else if (language == "2")
                {
                    HandleSession("BG");
                }
                else
                {
                    Console.WriteLine("Invalid choice. Try again.");
                }
            }
        }

        private void HandleSession(string language)
        {
            Console.WriteLine(language == "EN" ? "Enter your Card Number:" : "Въведете номер на картата:");
            string cardNumber = Console.ReadLine();

            _user = User.AuthenticateByCardNumber(cardNumber);

            if (_user == null)
            {
                Console.WriteLine(language == "EN" ? "Card number not found. Exiting..." : "Номер на картата не е намерен. Изход...");
                return;
            }

            Console.WriteLine(language == "EN" ? "Enter your PIN:" : "Въведете вашия ПИН:");
            string pin = Console.ReadLine();

            _user = User.Authenticate(cardNumber, pin);

            if (_user == null)
            {
                Console.WriteLine(language == "EN" ? "Invalid Card or PIN. Exiting..." : "Грешен номер на карта или ПИН. Изход...");
                return;
            }

            bool exit = false;
            while (!exit)
            {
                _menu.ShowMainMenu(language);
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine(language == "EN" ? "Enter amount to withdraw:" : "Въведете сума за теглене:");
                        string withdrawInput = Console.ReadLine();

                        if (decimal.TryParse(withdrawInput, out decimal withdrawAmount))
                        {
                            if (withdrawAmount <= 0)
                            {
                                Console.WriteLine(language == "EN" ? "Invalid withdrawal amount." : "Невалидна сума за теглене.");
                            }
                            else if (_user.Withdraw(withdrawAmount))
                            {
                                Console.WriteLine(language == "EN" ? $"Successfully withdrew {withdrawAmount} dollars." : $"Успешно изтеглихте {withdrawAmount} лева.");
                            }
                            else
                            {
                                Console.WriteLine(language == "EN" ? "Insufficient funds or invalid withdrawal amount." : "Недостатъчно средства или невалидна сума за теглене.");
                            }
                        }
                        else
                        {
                            Console.WriteLine(language == "EN" ? "Invalid input. Please enter a valid amount." : "Невалиден вход. Моля, въведете валидна сума.");
                        }
                        break;

                    case "2":
                        Console.WriteLine(language == "EN" ? "Enter deposit amount:" : "Въведете сума за депозит:");
                        string depositInput = Console.ReadLine();

                        if (decimal.TryParse(depositInput, out decimal depositAmount))
                        {
                            if (depositAmount <= 0)
                            {
                                Console.WriteLine(language == "EN" ? "Invalid deposit amount." : "Невалидна сума за депозит.");
                            }
                            else if (_user.Deposit(depositAmount))
                            {
                                Console.WriteLine(language == "EN" ? $"Successfully deposited {depositAmount} dollars." : $"Успешно депозирахте {depositAmount} лева.");
                            }
                            else
                            {
                                Console.WriteLine(language == "EN" ? "Invalid deposit amount." : "Невалидна сума за депозит.");
                            }
                        }
                        else
                        {
                            Console.WriteLine(language == "EN" ? "Invalid input. Please enter a valid amount." : "Невалиден вход. Моля, въведете валидна сума.");
                        }
                        break;

                    case "3":
                        Console.WriteLine(language == "EN" ? $"Balance: {_user.Balance} dollars" : $"Баланс: {_user.Balance} долара");
                        break;

                    case "4":
                        Console.WriteLine(language == "EN" ? "Enter new PIN:" : "Въведете нов ПИН:");
                        _user.ChangePassword(Console.ReadLine());
                        Console.WriteLine(language == "EN"
                            ? "Password changed successfully!"
                            : "Паролата беше сменена успешно!");
                        break;

                    case "0":
                        exit = true;
                        Console.WriteLine(language == "EN" ? "Thank you for using the ATM!" : "Благодаря, че използвахте банкомата!");
                        break;

                    default:
                        Console.WriteLine(language == "EN" ? "Invalid option." : "Невалидна опция.");
                        break;
                }

                if (choice != "0" && !AskForContinue(language))
                {
                    exit = true;
                }
            }
        }

        private bool AskForContinue(string language)
        {
            if (language == "EN")
            {
                Console.WriteLine("Do you want to continue with another operation? (y/n)");
            }
            else
            {
                Console.WriteLine("Желаете ли да продължите с друга операция? (д/н)");
            }

            string choice = Console.ReadLine()?.ToLower();

            if (choice == "n" || choice == "н")
            {
                Console.WriteLine(language == "EN" ? "Thank you for using the ATM! Goodbye!" : "Благодаря, че използвахте банкомата! Довиждане!");
                return false;
            }

            return choice == "y" || choice == "д";
        }
    }
}
