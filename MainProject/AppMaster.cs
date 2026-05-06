namespace MainProject;

public class AppMaster
{
    private BankManager bankManager;

    public AppMaster()
    {
    }

    public void BankManagerInit()
    {
        bankManager = new BankManager();
    }

    public void Run()
    {
        BankManagerInit();

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n========================================");
            Console.WriteLine("       SIMULADOR DE BANCO - MENU");
            Console.WriteLine("========================================");
            Console.WriteLine("1. Manejar Banco (ManageBack)");
            Console.WriteLine("2. Manejar Turnos (ManageTurns)");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");

            string opt = Console.ReadLine();

            switch (opt)
            {
                case "1":
                    ManageBack();
                    break;
                case "2":
                    ManageTurns();
                    break;
                case "3":
                    exit = true;
                    Console.WriteLine("Saliendo del simulador. ¡Hasta luego!");
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }
    }

    public void ManageBack()
    {
        bankManager.BankSubmenu.Show();
    }

    public void ManageTurns()
    {
        bankManager.TurnSubmenu.Show();
    }
}
