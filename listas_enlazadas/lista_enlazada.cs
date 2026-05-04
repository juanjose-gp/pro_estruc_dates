namespace Listas;

using System;
using System.Collections.Generic;

public class ListaEnlazada<T>
{
    private Nodo<T> cabeza;
    private Nodo<T> ultimo;
    private int cantidad = 0;

    public Nodo<T> Cabeza => cabeza;
    public Nodo<T> Ultimo => ultimo;
    public int Cantidad => cantidad;

    public bool EstaVacia()
    {
        return cabeza == null;
    }

    public void Limpiar()
    {
        cabeza = null;
        ultimo = null;
        cantidad = 0;
    }

    public void AgregarIneficiente(T valor) 
    { 
        cantidad++; 
        if (cabeza == null) 
        { 
            cabeza = new Nodo<T>(valor); 
            ultimo = cabeza; 
            return; 
        }
        Nodo<T> actual = cabeza; 
        while (actual.Siguiente != null) 
        { 
            actual = actual.Siguiente; 
        } 
        actual.Siguiente = new Nodo<T>(valor); 
        ultimo = actual.Siguiente; 
    }

    public void Agregar(T valor)
    {
        Nodo<T> nuevo = new Nodo<T>(valor);

        if (cabeza == null)
        {
            cabeza = nuevo;
            ultimo = nuevo;
        }
        else
        {
            ultimo.Siguiente = nuevo;
            ultimo = nuevo;
        }

        cantidad++;
    }

    public void AgregarAlInicio(T valor)
    {
        Nodo<T> nuevo = new Nodo<T>(valor);
        nuevo.Siguiente = cabeza;
        cabeza = nuevo;

        if (ultimo == null)
        {
            ultimo = nuevo;
        }

        cantidad++;
    }

    public T ObtenerPrimero()
    {
        if (cabeza == null)
            throw new InvalidOperationException("La lista no tiene nada.");

        return cabeza.Valor;
    }

    public T ObtenerUltimo()
    {
        if (ultimo == null)
            throw new InvalidOperationException("La lista no tiene nada.");

        return ultimo.Valor;
    }

    public T ObtenerPorPosicion(int posicion)
    {
        if (posicion < 0 || posicion >= cantidad)
            throw new ArgumentOutOfRangeException(nameof(posicion), "Esta posicion es invalida.");

        Nodo<T> actual = cabeza;
        int i = 0;

        while (i < posicion)
        {
            actual = actual.Siguiente;
            i++;
        }

        return actual.Valor;
    }

    public void ModificarPorPosicion(int posicion, T nuevoValor)
    {
        if (posicion < 0 || posicion >= cantidad)
            throw new ArgumentOutOfRangeException(nameof(posicion), "Esta posicion es invalida.");

        Nodo<T> actual = cabeza;
        int i = 0;

        while (i < posicion)
        {
            actual = actual.Siguiente;
            i++;
        }

        actual.Valor = nuevoValor;
    }

    public bool Contiene(T valor)
    {
        Nodo<T> actual = cabeza;

        while (actual != null)
        {
            if (EqualityComparer<T>.Default.Equals(actual.Valor, valor))
                return true;

            actual = actual.Siguiente;
        }

        return false;
    }

    public int ObtenerPosicion(T valor)
    {
        Nodo<T> actual = cabeza;
        int posicion = 0;

        while (actual != null)
        {
            if (EqualityComparer<T>.Default.Equals(actual.Valor, valor))
                return posicion;

            actual = actual.Siguiente;
            posicion++;
        }

        return -1;
    }

    public void InsertarEnPosicion(T valor, int posicion)
    {
        if (posicion < 0 || posicion > cantidad)
            throw new ArgumentOutOfRangeException(nameof(posicion), "Esta posicion es invalida.");

        if (posicion == 0)
        {
            AgregarAlInicio(valor);
            return;
        }

        if (posicion == cantidad)
        {
            Agregar(valor);
            return;
        }

        Nodo<T> nuevo = new Nodo<T>(valor);
        Nodo<T> actual = cabeza;
        int i = 0;

        while (i < posicion - 1)
        {
            actual = actual.Siguiente;
            i++;
        }

        nuevo.Siguiente = actual.Siguiente;
        actual.Siguiente = nuevo;
        cantidad++;
    }

    public bool Eliminar(T valor)
    {
        if (cabeza == null)
            return false;

        if (EqualityComparer<T>.Default.Equals(cabeza.Valor, valor))
        {
            cabeza = cabeza.Siguiente;
            cantidad--;

            if (cabeza == null)
                ultimo = null;

            return true;
        }

        Nodo<T> actual = cabeza;

        while (actual.Siguiente != null)
        {
            if (EqualityComparer<T>.Default.Equals(actual.Siguiente.Valor, valor))
            {
                if (actual.Siguiente == ultimo)
                    ultimo = actual;

                actual.Siguiente = actual.Siguiente.Siguiente;
                cantidad--;
                return true;
            }

            actual = actual.Siguiente;
        }

        return false;
    }

    public bool EliminarPrimero()
    {
        if (cabeza == null)
            return false;

        cabeza = cabeza.Siguiente;
        cantidad--;

        if (cabeza == null)
            ultimo = null;

        return true;
    }

    public bool EliminarUltimo()
    {
        if (cabeza == null)
            return false;

        if (cabeza == ultimo)
        {
            cabeza = null;
            ultimo = null;
            cantidad--;
            return true;
        }

        Nodo<T> actual = cabeza;

        while (actual.Siguiente != ultimo)
        {
            actual = actual.Siguiente;
        }

        actual.Siguiente = null;
        ultimo = actual;
        cantidad--;
        return true;
    }

    public bool EliminarPosicion(int posicion)
    {
        if (posicion < 0 || posicion >= cantidad || cabeza == null)
            return false;

        if (posicion == 0)
            return EliminarPrimero();

        Nodo<T> actual = cabeza;
        int i = 0;

        while (i < posicion - 1)
        {
            actual = actual.Siguiente;
            i++;
        }

        if (actual.Siguiente == ultimo)
            ultimo = actual;

        actual.Siguiente = actual.Siguiente.Siguiente;
        cantidad--;
        return true;
    }

    public void Revertir()
    {
        if (cabeza == null || cabeza.Siguiente == null)
            return;

        Nodo<T> antiguoPrimero = cabeza;
        Nodo<T> previo = null;
        Nodo<T> actual = cabeza;

        while (actual != null)
        {
            Nodo<T> siguiente = actual.Siguiente;
            actual.Siguiente = previo;
            previo = actual;
            actual = siguiente;
        }

        cabeza = previo;
        ultimo = antiguoPrimero;
    }

    public void Imprimir()
    {
        Nodo<T> actual = cabeza;

        while (actual != null)
        {
            Console.Write(actual.Valor);

            if (actual.Siguiente != null)
                Console.Write(" -> ");

            actual = actual.Siguiente;
        }

        Console.WriteLine();
    }

    public int Contar()
    {
        return cantidad;
    }
}