namespace MainProject.Submenus;

using MainProject.Controllers;
using MainProject.Entities;

public class BankSubmenu
{
    private ClientsController clientsController;
    private AccountSubmenu accountSubmenu;

    public BankSubmenu(ClientsController clientsController, AccountSubmenu accountSubmenu)
    {
        this.clientsController = clientsController;
        this.accountSubmenu = accountSubmenu;
    }

    public void Show()
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n=== SUBMENU BANCO ===");
            Console.WriteLine("1. Agregar cliente (AddClient)");
            Console.WriteLine("2. Acceder a cuenta de cliente (GetClientAccount)");
            Console.WriteLine("3. Mostrar clientes (ShowClients)");
            Console.WriteLine("4. Contar clientes (CountClients)");
            Console.WriteLine("5. Mostrar dinero total del banco (GetTotalBankMoney)");
            Console.WriteLine("6. Volver");
            Console.Write("Seleccione una opción: ");

            string opt = Console.ReadLine();

            switch (opt)
            {
                case "1":
                    AddClient();
                    break;
                case "2":
                    GetClientAccount();
                    break;
                case "3":
                    ShowClients();
                    break;
                case "4":
                    CountClients();
                    break;
                case "5":
                    GetTotalBankMoney();
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

    public void AddClient()
    {
        Console.Write("Cédula (CC): ");
        if (!int.TryParse(Console.ReadLine(), out int cc))
        {
            Console.WriteLine("Cédula inválida.");
            return;
        }

        if (clientsController.SearchByCC(cc) != null)
        {
            Console.WriteLine("Ya existe un cliente con esa cédula.");
            return;
        }

        Console.Write("Nombre completo: ");
        string name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Nombre inválido.");
            return;
        }

        Console.Write($"Número de cuenta (exactamente {Account.AccountNumberLength} dígitos): ");
        string accNumber = Console.ReadLine();
        if (!Account.IsValidAccountNumber(accNumber))
        {
            Console.WriteLine($"Número de cuenta inválido. Debe tener exactamente {Account.AccountNumberLength} dígitos.");
            return;
        }

        if (clientsController.SearchByAccount(accNumber) != null)
        {
            Console.WriteLine("Ya existe un cliente con ese número de cuenta.");
            return;
        }

        Console.Write("Saldo inicial: ");
        if (!double.TryParse(Console.ReadLine(), out double saldoInicial) || saldoInicial < 0)
        {
            Console.WriteLine("Saldo inicial inválido.");
            return;
        }

        Account account = new Account(accNumber, saldoInicial);
        Client client = new Client(cc, name, account);
        clientsController.AddClient(client);
    }

    public void GetClientAccount()
    {
        Console.Write("Ingrese la cédula del cliente: ");
        if (!int.TryParse(Console.ReadLine(), out int cc))
        {
            Console.WriteLine("Cédula inválida.");
            return;
        }

        Client client = clientsController.SearchByCC(cc);

        if (client == null)
        {
            Console.WriteLine("Cliente no encontrado.");
            return;
        }

        accountSubmenu.Show(client);
    }

    public void ShowClients()
    {
        clientsController.ShowClients();
    }

    public void CountClients()
    {
        Console.WriteLine($"Total de clientes registrados: {clientsController.CountClients()}");
    }

    public void GetTotalBankMoney()
    {
        Console.WriteLine($"Total de dinero en el banco: {clientsController.GetTotalBankMoney()}");
    }
}
