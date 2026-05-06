namespace MainProject.Controllers;

using Colas;
using MainProject.Entities;

public class TurnsController
{
    private Cola<Turn> turnQueue;
    private int nextTurnId;

    public TurnsController()
    {
        turnQueue = new Cola<Turn>();
        nextTurnId = 1;
    }

    public Cola<Turn> TurnQueue
    {
        get { return turnQueue; }
    }

    public void AddTurn(int cc, string name)
    {
        Turn turn = new Turn(cc, name, nextTurnId);
        nextTurnId++;
        turnQueue.Encolar(turn);
        Console.WriteLine($"Turno #{turn.ID} agregado para {turn.Name}.");
    }

    public bool DeleteTurn()
    {
        if (turnQueue.EstaVacia())
        {
            Console.WriteLine("No hay turnos en la cola.");
            return false;
        }

        Turn turn = turnQueue.Desencolar();
        Console.WriteLine($"Turno #{turn.ID} ({turn.Name}) eliminado de la cola.");
        return true;
    }

    public void ShowTurns()
    {
        if (turnQueue.EstaVacia())
        {
            Console.WriteLine("No hay clientes en la cola de atención.");
            return;
        }

        Console.WriteLine("=== COLA DE ATENCIÓN ===");
        turnQueue.Imprimir();
        Console.WriteLine($"Total en cola: {turnQueue.ObtenerTamano()}");
    }

    public void ShowNextTurn()
    {
        if (turnQueue.EstaVacia())
        {
            Console.WriteLine("No hay clientes en la cola de atención.");
            return;
        }

        Turn next = turnQueue.Frente();
        Console.WriteLine($"Siguiente turno a atender: #{next.ID} - {next.Name} (CC: {next.CC})");
    }

    public bool Attend()
    {
        if (turnQueue.EstaVacia())
        {
            Console.WriteLine("No hay clientes en la cola de atención.");
            return false;
        }

        Turn turn = turnQueue.Desencolar();
        Console.WriteLine($"Atendiendo turno #{turn.ID} - {turn.Name} (CC: {turn.CC}).");
        return true;
    }
}
