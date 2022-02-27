using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema7M2
{
    public enum acountType { cec, depozit };

    class BankAccount
    {
        private long numarCont;
        private int dobanda;
        private acountType tipCont;
        private decimal amount = 300m;

        public BankAccount()
        {
            this.dobanda = 0;
            this.tipCont = acountType.cec;
            this.numarCont = NextNumber();
        }

        public BankAccount(int dobanda, acountType tipCont)
        {
            this.dobanda = dobanda;
            this.tipCont = tipCont;
            this.numarCont = NextNumber();
        }

        private static long numarContIncrementat = 123;
        public static long NextNumber()
        {
            numarContIncrementat++;
            return numarContIncrementat;
        }
       

        public void SetBankAccount(acountType tipCont)
        {
            this.tipCont = tipCont;
        }

        public long ReturnNumarCont()
        {
            return numarCont;
        }

        public int ReturnDobanda()
        {
            return dobanda;
        }

        public acountType ReturnAccountType()
        {
            return tipCont;
        }


        private decimal Deposit(decimal amount)
        {

            this.amount += amount;
            return this.amount;

        }

        public static void testDeposit(BankAccount ba)
        {
            Console.Write("Introduceti suma pe care vreti sa o depozitati: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            ba.Deposit(amount);
        }

        private bool Withdraw(decimal amount)
        {
            if (this.amount - amount > 0)
            {
                this.amount -= amount;
                return true;
            }
            return false;
        }

        public static void TestWithdraw(BankAccount ba)
        {

            Console.Write("Introduceti suma pe care vreti sa o scoateti: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            if (ba.Withdraw(amount))
            {
                Console.WriteLine("Ati scos cu succes bani");
            }
            else
            {
                Console.WriteLine("Sold insuficient");
            }

        }

        public decimal AfisareSold()
        {
            return amount;
        }

        public void TransferFrom(BankAccount sourceAccount)
        {
            Console.Write("Ce suma doriti sa trasferati: ");
            decimal amount = int.Parse(Console.ReadLine());
            if (sourceAccount.Withdraw(amount))
            {
                Console.WriteLine("Transferul a fost realizat cu succes");
                Deposit(amount);
            }
            else
            {
                Console.WriteLine("Sold insuficient. \nTransferul nu a fost realizat");
            }            
        }



    }
}
