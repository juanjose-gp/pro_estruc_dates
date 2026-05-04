using System;

namespace Pila;

public class Pila<T>
{
    private Nodo<T> cima;
    private int tamano;

    public Pila()
    {
        cima = null;
        tamano = 0;
    }

    public void Apilar(T valor)
    {
        Nodo<T> nuevoNodo = new Nodo<T>(valor);
        nuevoNodo.Siguiente = cima;
        cima = nuevoNodo;
        tamano++;
    }

    public T Desapilar()
    {
        if (EstaVacia())
        {
            throw new InvalidOperationException("En la pila no hay nada.");
        }

        Nodo<T> nodoEliminado = cima;
        T valor = nodoEliminado.Valor;
        cima = nodoEliminado.Siguiente;
        tamano--;

        return valor;
    }

    public T Cima()
    {
        if (EstaVacia())
        {
            throw new InvalidOperationException("En la pila no hay nada.");
        }

        return cima.Valor;
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
        cima = null;
        tamano = 0;
    }

    public bool Contiene(T valor)
    {
        Nodo<T> actual = cima;

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
            Console.WriteLine("En la pila no hay nada.");
            return;
        }

        Nodo<T> actual = cima;

        Console.WriteLine("Cima");
        Console.WriteLine("|");

        while (actual != null)
        {
            Console.WriteLine(actual.Valor);
            Console.WriteLine("|");
            actual = actual.Siguiente;
        }

        Console.WriteLine("Base");
    }
}