namespace MainProject.Entities;

using MainProject.Controllers;

public class Account
{
    public const int AccountNumberLength = 10;

    private string accountNumber;
    private double saldo;
    private TransactionController transactionController;

    public Account(string accountNumber, double saldoInicial)
    {
        this.accountNumber = accountNumber;
        this.saldo = saldoInicial;
        this.transactionController = new TransactionController();
    }

    public string AccountNumber
    {
        get { return accountNumber; }
        set { accountNumber = value; }
    }

    public double Saldo
    {
        get { return saldo; }
        set { saldo = value; }
    }

    public TransactionController TransactionController
    {
        get { return transactionController; }
    }

    public static bool IsValidAccountNumber(string value)
    {
        if (string.IsNullOrEmpty(value))
            return false;

        if (value.Length != AccountNumberLength)
            return false;

        for (int i = 0; i < value.Length; i++)
        {
            if (!char.IsDigit(value[i]))
                return false;
        }

        return true;
    }
}
