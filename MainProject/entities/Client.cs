namespace MainProject.Entities;

public class Client
{
    private int cc;
    private string name;
    private Account account;

    public Client(int cc, string name, Account account)
    {
        this.cc = cc;
        this.name = name;
        this.account = account;
    }

    public int CC
    {
        get { return cc; }
        set { cc = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public Account Account
    {
        get { return account; }
        set { account = value; }
    }

    public override string ToString()
    {
        return $"CC: {cc} | Nombre: {name} | Cuenta: {account.AccountNumber} | Saldo: {account.Saldo}";
    }
}
