namespace grafy2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        //DFS drzewa

        public class Wezel
        {
            public List<Wezel> dzieci = new List<Wezel>();
            public int wartosc;
            public Wezel(int liczba)
            {
                this.wartosc = liczba;
            }
        }

        public void A(Wezel w)
        {
            MessageBox.Show(w.wartosc.ToString());

            for (int i = 0; i < w.dzieci.Count; i++)
            {
                A(w.dzieci[i]);
            }

        }
        private void btn1_Click(object sender, EventArgs e)
        {
            Wezel w1 = new Wezel(5);
            Wezel w2 = new Wezel(3);
            Wezel w3 = new Wezel(1);
            Wezel w4 = new Wezel(2);
            Wezel w5 = new Wezel(6);
            Wezel w6 = new Wezel(4);
            w1.dzieci.Add(w2);
            w1.dzieci.Add(w3);
            w1.dzieci.Add(w4);
            w2.dzieci.Add(w5);
            w2.dzieci.Add(w6);
            A(w1);
        }

        
        public class Wezel2
        {
            public int wartosc;
            public List<Wezel2> sasiedzi = new List<Wezel2>();
            public Wezel2(int liczba)
            {
                this.wartosc = liczba;
            }

            public void Add(Wezel2 w)
            {

                if (this == w)
                {
                    return;
                }

                if (!this.sasiedzi.Contains(w))
                {
                    this.sasiedzi.Add(w);
                }

                if (!w.sasiedzi.Contains(this))
                {
                    w.sasiedzi.Add(this);
                }




            }
        }

        //DFS grafu

        public List<Wezel2> odwiedzone = new List<Wezel2>();
        public void B(Wezel2 w)
        {
            if (!odwiedzone.Contains(w))
            {
                MessageBox.Show(w.wartosc.ToString());
                odwiedzone.Add(w);

                for (int i = 0; i < w.sasiedzi.Count; i++)
                {
                    B(w.sasiedzi[i]);
                }
            }

        }




        private void btn2_Click(object sender, EventArgs e)
        {
            Wezel2 w1 = new Wezel2(1);
            Wezel2 w2 = new Wezel2(2);
            Wezel2 w3 = new Wezel2(3);
            Wezel2 w4 = new Wezel2(4);
            Wezel2 w5 = new Wezel2(5);
            Wezel2 w6 = new Wezel2(6);
            Wezel2 w7 = new Wezel2(7);

            w1.Add(w2);
            w1.Add(w3);
            w3.Add(w4);
            w4.Add(w5);
            w5.Add(w6);
            w5.Add(w7);
            B(w1);
        }



        //BFS grafu
        public void C(Wezel2 startowy) //BFS grafu
        {
            List<Wezel2> odwiedzone = new List<Wezel2>();
            Queue<Wezel2> kolejka = new Queue<Wezel2>();

            kolejka.Enqueue(startowy);
            odwiedzone.Add(startowy);

            while (kolejka.Count > 0)
            {
                Wezel2 wezel = kolejka.Dequeue();
                MessageBox.Show(wezel.wartosc.ToString());

                foreach (var s¹siad in wezel.sasiedzi)
                {
                    if (!odwiedzone.Contains(s¹siad))
                    {
                        kolejka.Enqueue(s¹siad);
                        odwiedzone.Add(s¹siad);
                    }
                }
            }
        }


    
        private void btn3_Click(object sender, EventArgs e)
        {
            Wezel2 w1 = new Wezel2(1);
            Wezel2 w2 = new Wezel2(2);
            Wezel2 w3 = new Wezel2(3);
            Wezel2 w4 = new Wezel2(4);
            Wezel2 w5 = new Wezel2(5);
            Wezel2 w6 = new Wezel2(6);


            w1.Add(w2);
            w1.Add(w3);
            w2.Add(w4);
            w2.Add(w5);
            w3.Add(w6);
            C(w1);
        }
    }
}