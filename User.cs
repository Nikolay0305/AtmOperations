using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AtmOperationsWithDb
{
    internal class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CardNumber { get; set; }

        [Required]
        public string Pin { get; set; }

        public decimal Balance { get; set; }

        public static User Authenticate(string cardNumber, string pin)
        {
            using (var context = new AtmDbContext())
            {
                return context.Users.FirstOrDefault(u => u.CardNumber == cardNumber && u.Pin == pin);
            }
        }

        public static User AuthenticateByCardNumber(string cardNumber)
        {
            using (var context = new AtmDbContext())
            {
                return context.Users.FirstOrDefault(u => u.CardNumber == cardNumber);
            }
        }

        private void UpdateBalance()
        {
            using (var context = new AtmDbContext())
            {
                var user = context.Users.Find(Id);
                if (user != null)
                {
                    user.Balance = Balance;
                    context.SaveChanges();
                }
            }
        }

        public bool Withdraw(decimal amount)
        {
            if (amount <= 0 || amount > Balance)
            {
                return false;
            }

            Balance -= amount;
            UpdateBalance(); 
            return true;
        }
        public bool Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                return false;
            }

            Balance += amount;
            UpdateBalance(); 
            return true;
        }

        
        public void ChangePassword(string newPin)
        {
            Pin = newPin;
            using (var context = new AtmDbContext())
            {
                var user = context.Users.Find(Id);
                if (user != null)
                {
                    user.Pin = newPin;
                    context.SaveChanges();
                }
            }
        }
    }
}
