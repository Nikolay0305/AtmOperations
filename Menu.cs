using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmOperationsWithDb
{
    internal class Menu
    {
        public void StartMenu()
        {
            Console.WriteLine("=== Press ENTER to start ===");
            string start = Console.ReadLine();

            Console.WriteLine("=== Welcome to the ATM ===");
            Console.WriteLine("1. English\n2. Български");
            Console.WriteLine("Type '1' or '2':");
        }

        public void ShowMainMenu(string language)
        {
            if (language == "EN")
            {
                Console.WriteLine("1. Withdraw\n2. Deposit\n3. Balance\n4. Change PIN\n0. Exit");
            }
            else
            {
                Console.WriteLine("1. Теглене\n2. Депозит\n3. Баланс\n4. Смяна на ПИН\n0. Изход");
            }
        }
    }
}
