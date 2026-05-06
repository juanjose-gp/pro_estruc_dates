namespace MainProject.Entities;

using MainProject.Controllers;

public class Account
{
    private int accountNumber;
    private double saldo;
    private TransactionController transactionController;

    public Account(int accountNumber, double saldoInicial)
    {
        this.accountNumber = accountNumber;
        this.saldo = saldoInicial;
        this.transactionController = new TransactionController();
    }

    public int AccountNumber
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
}
