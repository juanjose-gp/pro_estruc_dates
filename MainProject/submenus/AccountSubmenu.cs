namespace MainProject.Submenus;

using MainProject.Entities;

public class AccountSubmenu
{
    public void Show(Client client)
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine($"\n=== CUENTA DE {client.Name} (#{client.Account.AccountNumber}) ===");
            Console.WriteLine("1. Mostrar saldo (ShowBalance)");
            Console.WriteLine("2. Retirar (Withdraw)");
            Console.WriteLine("3. Depositar (Deposit)");
            Console.WriteLine("4. Deshacer última transacción");
            Console.WriteLine("5. Ver historial de transacciones");
            Console.WriteLine("6. Volver");
            Console.Write("Seleccione una opción: ");

            string opt = Console.ReadLine();

            switch (opt)
            {
                case "1":
                    ShowBalance(client);
                    break;
                case "2":
                    Withdraw(client);
                    break;
                case "3":
                    Deposit(client);
                    break;
                case "4":
                    client.Account.TransactionController.UndoLastTransaction(client.Account);
                    break;
                case "5":
                    client.Account.TransactionController.ShowHistory();
                    break;
                case "6":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }
    }

    public void ShowBalance(Client client)
    {
        Console.WriteLine($"Saldo actual de la cuenta #{client.Account.AccountNumber}: {client.Account.Saldo}");
    }

    public void Withdraw(Client client)
    {
        Console.Write("Monto a retirar: ");
        if (double.TryParse(Console.ReadLine(), out double monto))
        {
            client.Account.TransactionController.Withdraw(client.Account, monto);
        }
        else
        {
            Console.WriteLine("Monto inválido.");
        }
    }

    public void Deposit(Client client)
    {
        Console.Write("Monto a depositar: ");
        if (double.TryParse(Console.ReadLine(), out double monto))
        {
            client.Account.TransactionController.Deposit(client.Account, monto);
        }
        else
        {
            Console.WriteLine("Monto inválido.");
        }
    }
}
