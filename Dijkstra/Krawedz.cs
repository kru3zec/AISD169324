namespace Dijkstra;

public class Krawedz
{
    public int waga;
    public Wezel poczatek, koniec;

    public Krawedz(int waga, Wezel poczatek, Wezel koniec)
    {
        this.waga = waga;
        this.poczatek = poczatek;
        this.koniec = koniec;
    }

    public Krawedz()
    {
    }
}