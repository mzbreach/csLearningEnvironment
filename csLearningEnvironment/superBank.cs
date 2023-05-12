using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace csLearningEnvironment
{
    internal class superBank
    {
        private uint number { get; }
        private string name { get; set; }
        private double balance { get; set; }

        public superBank()
        {
            balance = 0;
            name = string.Empty;
        }

        public superBank(string name, double initDeposit)
        {
            this.name = name;
            this.balance = initDeposit;
        }

        public void withdrawl(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount to withdrawl must be a non-negative value");
            }
            else if(this.balance - amount >= 0)
            {
                this.balance -= amount;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount to withdrawl must be at most equal to the current balance of the account");
            }
        }

        public void deposit(double amount)
        {
            this.balance += amount;
        }

        public string getName()
        {
            return this.name;
        }

        public double getBalance()
        {
            return this.balance;
        }
    }
}
