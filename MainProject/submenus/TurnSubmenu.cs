namespace MainProject.Submenus;

using MainProject.Controllers;

public class TurnSubmenu
{
    private TurnsController turnsController;

    public TurnSubmenu(TurnsController turnsController)
    {
        this.turnsController = turnsController;
    }

    public void Show()
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n=== SUBMENU TURNOS ===");
            Console.WriteLine("1. Agregar turno (AddTurn)");
            Console.WriteLine("2. Eliminar turno (DeleteTurn)");
            Console.WriteLine("3. Mostrar turnos (ShowTurns)");
            Console.WriteLine("4. Mostrar siguiente turno (ShowNextTurn)");
            Console.WriteLine("5. Atender (Attend)");
            Console.WriteLine("6. Volver");
            Console.Write("Seleccione una opción: ");

            string opt = Console.ReadLine();

            switch (opt)
            {
                case "1":
                    AddTurn();
                    break;
                case "2":
                    DeleteTurn();
                    break;
                case "3":
                    ShowTurns();
                    break;
                case "4":
                    ShowNextTurn();
                    break;
                case "5":
                    Attend();
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

    public void AddTurn()
    {
        Console.Write("Cédula (CC) del cliente: ");
        if (!int.TryParse(Console.ReadLine(), out int cc))
        {
            Console.WriteLine("Cédula inválida.");
            return;
        }

        Console.Write("Nombre del cliente: ");
        string name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Nombre inválido.");
            return;
        }

        turnsController.AddTurn(cc, name);
    }

    public void DeleteTurn()
    {
        turnsController.DeleteTurn();
    }

    public void ShowTurns()
    {
        turnsController.ShowTurns();
    }

    public void ShowNextTurn()
    {
        turnsController.ShowNextTurn();
    }

    public void Attend()
    {
        turnsController.Attend();
    }
}
