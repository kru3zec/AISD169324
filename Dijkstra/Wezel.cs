namespace Dijkstra;

public class Wezel
{
    public int wartosc;
    public List<Krawedz> listaKrawedzi = new List<Krawedz>();

    public Wezel()
    {
    }

    public Wezel(int wartosc)
    {
        this.wartosc = wartosc;
    }
    
    
    public void Link(int waga, Wezel w2)
    {
        this.listaKrawedzi.Add(new Krawedz(waga,this,w2));
        w2.listaKrawedzi.Add(new Krawedz(waga,w2,this));
    }
}