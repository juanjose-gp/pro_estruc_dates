namespace MainProject.Controllers;

using Listas;
using MainProject.Entities;

public class ClientsController
{
    private ListaEnlazada<Client> clientList;

    public ClientsController()
    {
        clientList = new ListaEnlazada<Client>();
    }

    public ListaEnlazada<Client> ClientList
    {
        get { return clientList; }
    }

    public bool AddClient(Client client)
    {
        Nodo<Client> actual = clientList.Cabeza;

        while (actual != null)
        {
            if (actual.Valor.CC == client.CC)
            {
                Console.WriteLine("Ya existe un cliente con esa cédula.");
                return false;
            }

            if (actual.Valor.Account.AccountNumber == client.Account.AccountNumber)
            {
                Console.WriteLine("Ya existe un cliente con ese número de cuenta.");
                return false;
            }

            actual = actual.Siguiente;
        }

        clientList.Agregar(client);
        Console.WriteLine($"Cliente {client.Name} registrado correctamente.");
        return true;
    }

    public Client SearchByCC(int cc)
    {
        Nodo<Client> actual = clientList.Cabeza;

        while (actual != null)
        {
            if (actual.Valor.CC == cc)
                return actual.Valor;

            actual = actual.Siguiente;
        }

        return null;
    }

    public Client SearchByAccount(string accountNumber)
    {
        Nodo<Client> actual = clientList.Cabeza;

        while (actual != null)
        {
            if (actual.Valor.Account.AccountNumber == accountNumber)
                return actual.Valor;

            actual = actual.Siguiente;
        }

        return null;
    }

    public void ShowClients()
    {
        if (clientList.EstaVacia())
        {
            Console.WriteLine("No hay clientes registrados.");
            return;
        }

        Console.WriteLine("=== CLIENTES REGISTRADOS ===");
        Nodo<Client> actual = clientList.Cabeza;
        int i = 1;

        while (actual != null)
        {
            Console.WriteLine($"{i}. {actual.Valor}");
            actual = actual.Siguiente;
            i++;
        }
    }

    public int CountClients()
    {
        return clientList.Contar();
    }

    public double GetTotalBankMoney()
    {
        double total = 0;
        Nodo<Client> actual = clientList.Cabeza;

        while (actual != null)
        {
            total += actual.Valor.Account.Saldo;
            actual = actual.Siguiente;
        }

        return total;
    }
}
