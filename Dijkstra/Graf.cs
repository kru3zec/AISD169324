namespace Dijkstra;

public class Graf
{
    public List<Wezel> listaWezlow = new List<Wezel>();

    public Graf(List<Wezel> listaWezlow)
    {
        this.listaWezlow = listaWezlow;
    }

    public Graf()
    {
    }

    public void Add(Wezel w)
    {
        listaWezlow.Add(w);
    }

    
}