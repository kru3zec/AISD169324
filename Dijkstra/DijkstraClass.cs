using System.Text;

namespace Dijkstra;

public class DijkstraClass
{
    public Graf g;
    public Dictionary<Wezel, int> drogaDict = new Dictionary<Wezel, int>();
    public Dictionary<Wezel, Wezel> poprzedniDict = new Dictionary<Wezel, Wezel>();

    public void algorithm()
    {
        for(int i = 0; i < g.listaWezlow.Count; i++)
        {
            drogaDict.Add(g.listaWezlow[i],int.MaxValue);
            poprzedniDict.Add(g.listaWezlow[i], null);
        }

        drogaDict[g.listaWezlow[0]] = 0; //punkt startowy algorytmu
        poprzedniDict[g.listaWezlow[0]] = null;
        
        foreach (Wezel p in g.listaWezlow)
        {
            foreach (Krawedz q in p.listaKrawedzi)
            {
                if (drogaDict[p] < drogaDict[q.koniec])
                {
                    drogaDict[q.koniec] = drogaDict[p] + q.waga;
                    poprzedniDict[q.koniec] = p;
                }
            }
        }
    }

    
}