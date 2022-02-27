using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Tema7M2
{
    class Program
    {
        private static void Meniu()
        {
            Console.WriteLine("Selectati o optiune:");
            Console.WriteLine("1. Depunere\n" +
                "2. Retragere\n" +
                "3. Afisare Sold\n" +
                "4. Transfer\n" +
                "0. Iesire meniu");
            Console.Write("Selectati operatia dorita: ");
        }
        private static void SelectareClient()
        {
            Console.WriteLine("Ce client doriti sa utilizati: ");
        }
        static void Main(string[] args)
        {

            int dobanda;
            int tipCont;
            int optiune;
            int client;
            acountType client1 = new acountType();

            BankAccount bankAccount = new BankAccount();
            BankAccount bankAccount1 = new BankAccount();

            Console.Write("Selectati tipul de cont al primului client:\n" +
                "1. Cec\n" +
                "2. Depozit\n" +
                "Optiune: ");
            tipCont = int.Parse(Console.ReadLine());
            Console.Write("Introduceti dobanda anuala: ");
            dobanda = int.Parse(Console.ReadLine());
            if (tipCont == 1)
            {
                client1 = acountType.cec;
                bankAccount = new BankAccount(dobanda, client1);
            }
            else if (tipCont == 2)
            {
                client1 = acountType.depozit;
                bankAccount = new BankAccount(dobanda, client1);
            }

            Console.Write("Selectati tipul de cont al celui de-al doilea client:\n" +
                "1. Cec\n" +
                "2. Depozit\n" +
                "Optiune: ");
            tipCont = int.Parse(Console.ReadLine());
            Console.Write("Introduceti dobanda anuala: ");
            dobanda = int.Parse(Console.ReadLine());

            if (tipCont == 1)
            {
                client1 = acountType.cec;
                bankAccount1 = new BankAccount(dobanda, client1);
            }
            else if(tipCont == 2)
            {
                client1 = acountType.depozit;
                bankAccount1 = new BankAccount(dobanda, client1);
            }
            Console.Clear();
            Console.WriteLine("Primul Client");
            Console.WriteLine($"Numar de cont: {bankAccount.ReturnNumarCont()}\n" +
                $"Dobanda anuala: {bankAccount.ReturnDobanda()}\n" +
                $"Tip de cont: {bankAccount.ReturnAccountType()}\n");

            Console.WriteLine("Al doilea Client");
            Console.WriteLine($"Numar de cont: {bankAccount1.ReturnNumarCont()}\n" +
                $"Dobanda anuala: {bankAccount1.ReturnDobanda()}\n" +
                $"Tip de cont: {bankAccount1.ReturnAccountType()}\n");

            Console.WriteLine();

            do
            {
                SelectareClient();
                client = int.Parse(Console.ReadLine());
                switch (client)
                {
                    case 1:
                        Console.WriteLine("\n################################\nClient 1");
                        do
                        {
                            Console.WriteLine();
                            Meniu();
                            optiune = int.Parse(Console.ReadLine());
                            switch (optiune)
                            {

                                case 1:
                                    Console.WriteLine();
                                    BankAccount.testDeposit(bankAccount);
                                    break;
                                case 2:
                                    Console.WriteLine();
                                    BankAccount.TestWithdraw(bankAccount);
                                    break;
                                case 3:
                                    Console.WriteLine();
                                    Console.WriteLine(bankAccount.AfisareSold());
                                    break;
                                case 4:
                                    Console.WriteLine();
                                    bankAccount.TransferFrom(bankAccount1);
                                    break;
                            }
                            
                        } while (optiune != 0);
                        Console.Clear();
                        break;
                    case 2:
                        Console.WriteLine("################################\nClient 2");
                        do
                        {
                            Meniu();
                            optiune = int.Parse(Console.ReadLine());
                            switch (optiune)
                            {

                                case 1:
                                    BankAccount.testDeposit(bankAccount1);
                                    break;
                                case 2:
                                    BankAccount.TestWithdraw(bankAccount1);
                                    break;
                                case 3:
                                    Console.WriteLine(bankAccount1.AfisareSold());
                                    break;
                                case 4:
                                    bankAccount1.TransferFrom(bankAccount);
                                    break;
                            }
                            
                            //Console.Write("Introduceti o alta optiune: ");
                        } while (optiune != 0);
                        Console.Clear();
                        break;
                }
            } while (client != 0);
        }
    }
}
