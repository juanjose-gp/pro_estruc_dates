namespace MainProject.Controllers;

using Listas;
using Pila;
using MainProject.Entities;

public class TransactionController
{
    public const string TipoDeposito = "Depósito";
    public const string TipoRetiro = "Retiro";
    public const string TipoCancelacionDeposito = "Cancelación de depósito";
    public const string TipoCancelacionRetiro = "Cancelación de retiro";

    private Pila<Transaction> undoStack;
    private ListaEnlazada<Transaction> history;

    public TransactionController()
    {
        undoStack = new Pila<Transaction>();
        history = new ListaEnlazada<Transaction>();
    }

    public Pila<Transaction> UndoStack
    {
        get { return undoStack; }
    }

    public ListaEnlazada<Transaction> History
    {
        get { return history; }
    }

    public bool Deposit(Account account, double monto)
    {
        if (monto <= 0)
        {
            Console.WriteLine("El monto debe ser mayor a cero.");
            return false;
        }

        Transaction t = new Transaction(TipoDeposito, monto);
        t.Deposit(account);
        undoStack.Apilar(t);
        history.Agregar(t);
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

        Transaction t = new Transaction(TipoRetiro, monto);
        t.Withdraw(account);
        undoStack.Apilar(t);
        history.Agregar(t);
        Console.WriteLine($"Retiro de {monto} realizado. Saldo actual: {account.Saldo}");
        return true;
    }

    public bool UndoLastTransaction(Account account)
    {
        if (undoStack.EstaVacia())
        {
            Console.WriteLine("No hay transacciones para deshacer.");
            return false;
        }

        Transaction last = undoStack.Desapilar();
        string cancelTipo;

        if (last.Tipo == TipoDeposito)
        {
            account.Saldo -= last.MontoTransacion;
            cancelTipo = TipoCancelacionDeposito;
        }
        else
        {
            account.Saldo += last.MontoTransacion;
            cancelTipo = TipoCancelacionRetiro;
        }

        Transaction cancellation = new Transaction(cancelTipo, last.MontoTransacion);
        history.Agregar(cancellation);

        Console.WriteLine($"Transacción deshecha: {last}. Saldo actual: {account.Saldo}");
        return true;
    }

    public void ShowLastTransaction()
    {
        if (history.EstaVacia())
        {
            Console.WriteLine("No hay transacciones registradas.");
            return;
        }

        Console.WriteLine($"Última transacción: {history.ObtenerUltimo()}");
    }

    public void ShowHistory()
    {
        if (history.EstaVacia())
        {
            Console.WriteLine("No hay transacciones registradas.");
            return;
        }

        Console.WriteLine("Historial de transacciones (cronológico):");
        Listas.Nodo<Transaction> actual = history.Cabeza;
        int i = 1;

        while (actual != null)
        {
            Console.WriteLine($"  {i}. {actual.Valor}");
            actual = actual.Siguiente;
            i++;
        }
    }
}
