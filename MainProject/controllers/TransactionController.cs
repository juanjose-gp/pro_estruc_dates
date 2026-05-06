namespace MainProject.Controllers;

using Pila;
using MainProject.Entities;

public class TransactionController
{
    private Pila<Transaction> transactionList;

    public TransactionController()
    {
        transactionList = new Pila<Transaction>();
    }

    public Pila<Transaction> TransactionList
    {
        get { return transactionList; }
    }

    public bool Deposit(Account account, double monto)
    {
        if (monto <= 0)
        {
            Console.WriteLine("El monto debe ser mayor a cero.");
            return false;
        }

        Transaction t = new Transaction("Deposit", monto);
        t.Deposit(account);
        transactionList.Apilar(t);
        Console.WriteLine($"Depósito de {monto} realizado. Saldo actual: {account.Saldo}");
        return true;
    }

    public bool Withdraw(Account account, double monto)
    {
        if (monto <= 0)
        {
            Console.WriteLine("El monto debe ser mayor a cero.");
            return false;
        }

        if (monto > account.Saldo)
        {
            Console.WriteLine("Saldo insuficiente para realizar el retiro.");
            return false;
        }

        Transaction t = new Transaction("Withdraw", monto);
        t.Withdraw(account);
        transactionList.Apilar(t);
        Console.WriteLine($"Retiro de {monto} realizado. Saldo actual: {account.Saldo}");
        return true;
    }

    public bool UndoLastTransaction(Account account)
    {
        if (transactionList.EstaVacia())
        {
            Console.WriteLine("No hay transacciones para deshacer.");
            return false;
        }

        Transaction last = transactionList.Desapilar();

        if (last.Tipo == "Deposit")
        {
            account.Saldo -= last.MontoTransacion;
        }
        else
        {
            account.Saldo += last.MontoTransacion;
        }

        Console.WriteLine($"Transacción deshecha: {last}. Saldo actual: {account.Saldo}");
        return true;
    }

    public void ShowLastTransaction()
    {
        if (transactionList.EstaVacia())
        {
            Console.WriteLine("No hay transacciones registradas.");
            return;
        }

        Console.WriteLine($"Última transacción: {transactionList.Cima()}");
    }

    public void ShowHistory()
    {
        if (transactionList.EstaVacia())
        {
            Console.WriteLine("No hay transacciones registradas.");
            return;
        }

        Console.WriteLine("Historial de transacciones (de más reciente a más antigua):");
        transactionList.Imprimir();
    }
}
