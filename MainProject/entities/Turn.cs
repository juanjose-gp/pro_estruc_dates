namespace MainProject.Entities;

public class Turn
{
    private int cc;
    private string name;
    private int id;

    public Turn(int cc, string name, int id)
    {
        this.cc = cc;
        this.name = name;
        this.id = id;
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

    public int ID
    {
        get { return id; }
        set { id = value; }
    }

    public override string ToString()
    {
        return $"[Turno #{id} - CC: {cc} - {name}]";
    }
}
