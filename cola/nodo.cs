namespace Colas;

public class Nodo<T>
{
    private T valor;
    private Nodo<T>? siguiente;

    public Nodo(T valor)
    {
        this.valor = valor;
        this.siguiente = null;
    }

    public T Valor
    {
        get { return valor; }
        set { valor = value; }
    }

    public Nodo<T>? Siguiente
    {
        get { return siguiente; }
        set { siguiente = value; }
    }
}