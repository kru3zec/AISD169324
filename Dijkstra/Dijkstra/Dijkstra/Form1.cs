namespace Dijkstra
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Wezel4 w0 = new Wezel4(0);
            Wezel4 w1 = new Wezel4(1);
            Wezel4 w2 = new Wezel4(2);
            Wezel4 w3 = new Wezel4(3);
            Wezel4 w4 = new Wezel4(4);
            Wezel4 w5 = new Wezel4(5);
            w0.Link(3, w1);
            w0.Link(3, w4);
            w0.Link(6, w5);
            w1.Link(1, w2);
            w1.Link(4, w3);
            w2.Link(3, w3);
            w2.Link(1, w5);
            w3.Link(1, w5);
            w4.Link(2, w5);
            Graf g = new Graf();
            g.Add(w0);
            g.Add(w1);
            g.Add(w2);
            g.Add(w3);
            g.Add(w4);
            g.Add(w5);
            algDikjkstry ad = new algDikjkstry(g);
            ad.algorytmDijkstry();
            MessageBox.Show(ad.Show());
        }
        public class algDikjkstry
        {
            public Graf g;
            public Dictionary<Wezel4, int> drogaDlugosc = new Dictionary<Wezel4, int>();
            public Dictionary<Wezel4, Wezel4> drogaPoprzednik = new Dictionary<Wezel4, Wezel4>();
            public algDikjkstry(Graf g)
            {
                this.g = g;
            }
            public void algorytmDijkstry()
            {
                for (int i = 0; i < g.listaWezlow.Count; i++)
                {
                    drogaDlugosc.Add(g.listaWezlow[i], int.MaxValue);
                    drogaPoprzednik.Add(g.listaWezlow[i], null);
                }
                drogaDlugosc[g.listaWezlow[0]] = 0;
                drogaPoprzednik[g.listaWezlow[0]] = null;
                List<Wezel4> unvisited = new List<Wezel4>(g.listaWezlow);
                while (unvisited.Count > 0)
                {
                    Wezel4 current = NajkrotszaDroga(unvisited, drogaDlugosc);
                    unvisited.Remove(current);
                    foreach (Krawedz k in current.listaKrawedzi)
                    {
                        int newPath = drogaDlugosc[current] + k.waga;
                        if (newPath < drogaDlugosc[k.koniec])
                        {
                            drogaDlugosc[k.koniec] = newPath;
                            drogaPoprzednik[k.koniec] = current;
                        }
                    }
                }
            }
            public Wezel4 NajkrotszaDroga(List<Wezel4> listaWezlow, Dictionary<Wezel4, int> drogaDlugosc)
            {
                int minPath = int.MaxValue;
                Wezel4 minW = null;
                foreach (Wezel4 w in listaWezlow)
                {
                    if (drogaDlugosc[w] < minPath)
                    {
                        minPath = drogaDlugosc[w];
                        minW = w;
                    }
                }
                return minW;
            }
            public string Show()
            {
                string droga = "D: ";
                string poprzednik = "P: -1 ";
                for(int i = 0; i < this.drogaDlugosc.Count(); i++)
                {
                    droga += drogaDlugosc[g.listaWezlow[i]] + " ";
                }
                for(int i = 1; i< this.drogaPoprzednik.Count(); i++)
                {
                    poprzednik += drogaPoprzednik[g.listaWezlow[i]].wartosc.ToString() + " ";
                }
                return droga + "\n" + poprzednik;
            }
        }
        public class Graf
        {
            public List<Wezel4> listaWezlow = new List<Wezel4>();
            public List<Krawedz> listaKrawedzi = new List<Krawedz>();
            public Graf()
            {
            }
            public Graf(List<Wezel4> listaWezlow, List<Krawedz> listaKrawedzi)
            {
                this.listaWezlow = listaWezlow;
                this.listaKrawedzi = listaKrawedzi;
            }
            public void Add(Wezel4 w)
            {
                listaWezlow.Add(w);
                // Iteracja przez krawêdzie tego wêz³a i dodanie ich do listy krawêdzi Grafu
                foreach (Krawedz k in w.listaKrawedzi)
                {
                    bool edgeExists = false;

                    // Sprawdzenie, czy krawêdŸ istnieje ju¿ w liœcie (bez wzglêdu na kolejnoœæ pocz¹tku i koñca)
                    foreach (Krawedz existingEdge in listaKrawedzi)
                    {
                        if ((existingEdge.poczatek == k.poczatek && existingEdge.koniec == k.koniec) ||
                            (existingEdge.poczatek == k.koniec && existingEdge.koniec == k.poczatek))
                        {
                            edgeExists = true;
                            break;
                        }
                    }

                    // Dodanie krawêdzi tylko jeœli nie istnieje jeszcze w liœcie
                    if (!edgeExists)
                    {
                        listaKrawedzi.Add(k);
                    }
                }
            }
            public Graf(Krawedz k)
            {
                if (!listaWezlow.Contains(k.poczatek))
                {
                    listaWezlow.Add(k.poczatek);
                }

                if (!listaWezlow.Contains(k.koniec))
                {
                    listaWezlow.Add(k.koniec);
                }

                // Dodajemy krawêdŸ do listy krawêdzi tylko jeœli nie istnieje jeszcze
                bool edgeExists = false;
                foreach (Krawedz existingEdge in listaKrawedzi)
                {
                    if ((existingEdge.poczatek == k.poczatek && existingEdge.koniec == k.koniec) ||
                            (existingEdge.poczatek == k.koniec && existingEdge.koniec == k.poczatek))
                    {
                        edgeExists = true;
                        break;
                    }
                }
                if(!edgeExists)
                {
                    listaKrawedzi.Add(k);
                }
            }
        }
        public class Wezel4
        {
            public int wartosc;
            public List<Krawedz> listaKrawedzi = new List<Krawedz>();
            public Wezel4(int liczba)
            {
                this.wartosc = liczba;
            }
            public override string ToString()
            {
                return this.wartosc.ToString();
            }
            public void Link(int waga, Wezel4 w2)
            {
                this.listaKrawedzi.Add(new Krawedz(waga, this, w2));
                w2.listaKrawedzi.Add(new Krawedz(waga, w2, this));
            }
        }
        public class Krawedz
        {
            public int waga;
            public Wezel4 poczatek;
            public Wezel4 koniec;
            public Krawedz(int waga, Wezel4 poczatek, Wezel4 koniec)
            {
                this.waga = waga;
                this.poczatek = poczatek;
                this.koniec = koniec;
            }
        }
    }
}