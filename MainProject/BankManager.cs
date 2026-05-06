namespace MainProject;

using MainProject.Controllers;
using MainProject.Submenus;

public class BankManager
{
    private BankSubmenu bankSubmenu;
    private TurnSubmenu turnSubmenu;
    private AccountSubmenu accountSubmenu;
    private ClientsController clientsController;
    private TurnsController turnsController;

    public BankManager()
    {
        clientsController = new ClientsController();
        turnsController = new TurnsController();
        accountSubmenu = new AccountSubmenu();
        bankSubmenu = new BankSubmenu(clientsController, accountSubmenu);
        turnSubmenu = new TurnSubmenu(turnsController);
    }

    public BankSubmenu BankSubmenu
    {
        get { return bankSubmenu; }
    }

    public TurnSubmenu TurnSubmenu
    {
        get { return turnSubmenu; }
    }

    public AccountSubmenu AccountSubmenu
    {
        get { return accountSubmenu; }
    }

    public ClientsController ClientsController
    {
        get { return clientsController; }
    }

    public TurnsController TurnsController
    {
        get { return turnsController; }
    }
}
