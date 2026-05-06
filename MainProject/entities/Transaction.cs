namespace MainProject.Entities;

public class Transaction
{
    private string tipo;
    private double montoTransacion;

    public Transaction(string tipo, double montoTransacion)
    {
        this.tipo = tipo;
        this.montoTransacion = montoTransacion;
    }

    public string Tipo
    {
        get { return tipo; }
        set { tipo = value; }
    }

    public double MontoTransacion
    {
        get { return montoTransacion; }
        set { montoTransacion = value; }
    }

    public void Deposit(Account account)
    {
        account.Saldo += montoTransacion;
        tipo = "Deposit";
    }

    public void Withdraw(Account account)
    {
        account.Saldo -= montoTransacion;
        tipo = "Withdraw";
    }

    public override string ToString()
    {
        return $"{tipo} de {montoTransacion}";
    }
}
