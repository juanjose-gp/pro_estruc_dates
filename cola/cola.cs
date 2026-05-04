using System;

namespace Colas;

public class Cola<T>
{
    private Nodo<T> frente;
    private Nodo<T> final;
    private int tamano;

    public Cola()
    {
        frente = null;
        final = null;
        tamano = 0;
    }

    public void Encolar(T valor)
    {
        Nodo<T> nuevoNodo = new Nodo<T>(valor);

        if (EstaVacia())
        {
            frente = nuevoNodo;
            final = nuevoNodo;
        }
        else
        {
            final.Siguiente = nuevoNodo;
            final = nuevoNodo;
        }

        tamano++;
    }

    public T Desencolar()
    {
        if (EstaVacia())
        {
            throw new InvalidOperationException("En la cola no hay nada.");
        }

        Nodo<T> nodoActual = frente;
        T valor = nodoActual.Valor;
        frente = frente.Siguiente;
        tamano--;

        if (frente == null)
        {
            final = null;
        }

        return valor;
    }

    public T Frente()
    {
        if (EstaVacia())
        {
            throw new InvalidOperationException("En la cola no hay nada.");
        }

        return frente.Valor;
    }

    public T Ultimo()
    {
        if (EstaVacia())
        {
            throw new InvalidOperationException("En la cola no hay nada.");
        }

        return final.Valor;
    }

    public bool EstaVacia()
    {
        return tamano == 0;
    }

    public int ObtenerTamano()
    {
        return tamano;
    }

    public void Limpiar()
    {
        frente = null;
        final = null;
        tamano = 0;
    }

    public bool Contiene(T valor)
    {
        Nodo<T> actual = frente;

        while (actual != null)
        {
            if (Equals(actual.Valor, valor))
            {
                return true;
            }

            actual = actual.Siguiente;
        }

        return false;
    }

    public void Imprimir()
    {
        if (EstaVacia())
        {
            Console.WriteLine("En la cola no hay nada.");
            return;
        }

        Nodo<T> actual = frente;
        Console.Write("Frente -> ");

        while (actual != null)
        {
            Console.Write(actual.Valor);

            if (actual.Siguiente != null)
            {
                Console.Write(" -> ");
            }

            actual = actual.Siguiente;
        }

        Console.WriteLine(" <- Final");
    }
}