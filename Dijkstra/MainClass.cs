namespace Dijkstra;

public class MainClass
{
    public static void Main()
    {
        Graf g = new Graf();
        Wezel w0 = new Wezel(0);
        Wezel w1 = new Wezel(1);
        Wezel w2 = new Wezel(2);
        Wezel w3 = new Wezel(3);
        Wezel w4 = new Wezel(4);
        Wezel w5 = new Wezel(5);
        
        w0.Link(3,w1);
        w0.Link(3,w4);
        w0.Link(6,w5);
        w1.Link(1,w2);
        w1.Link(4,w3);
        w2.Link(3,w3);
        w2.Link(1,w5);
        w5.Link(2,w4);
        w5.Link(1,w3);
        
        g.listaWezlow.Add(w0);
        g.listaWezlow.Add(w1);
        g.listaWezlow.Add(w2);
        g.listaWezlow.Add(w3);
        g.listaWezlow.Add(w4);
        g.listaWezlow.Add(w5);

        DijkstraClass dc = new DijkstraClass();
        dc.g = g;
        dc.algorithm();
    }
}