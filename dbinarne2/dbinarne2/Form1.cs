
namespace dbinarne2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public class Wezel3
        {
            public int wartosc;
            public Wezel3 rodzic;
            public Wezel3 leweDziecko;
            public Wezel3 praweDziecko;

            public Wezel3(int liczba)
            {
                this.wartosc = liczba;
            }

            public void Add(int liczba)
            {
                Wezel3 dziecko = new Wezel3(liczba);
                dziecko.rodzic = this;

                if (liczba < this.wartosc)
                {
                    leweDziecko = dziecko;
                }
                else
                {
                    praweDziecko = dziecko;
                }
            }

            public int GetLiczbaDzieci()
            {
                int wynik = 0;
                if (this.leweDziecko != null)
                {
                    wynik++;
                }
                if (this.praweDziecko != null)
                {
                    wynik++;
                }
                return wynik;
            }
        }


        public class DrzewoBinarne
        {
            public Wezel3 korzen;
            public int liczbawezlow;

            public DrzewoBinarne(int liczba)
            {
                this.korzen = new Wezel3(liczba);
                liczbawezlow = 1;
            }


            public Wezel3 ZnajdzRodzica(int liczba)
            {
                var w = korzen;
                while (true)
                {
                    if (liczba < w.wartosc)
                    {
                        if (w.leweDziecko == null)
                        {
                            return w;
                        }
                        else
                        {
                            w = w.leweDziecko;
                        }
                    }
                    else
                    {
                        if (w.praweDziecko == null)
                        {
                            return w;
                        }
                        else
                        {
                            w = w.praweDziecko;
                        }
                    }
                }
            }

            public void Add(int liczba)
            {
                var rodzic = ZnajdzRodzica(liczba);
                rodzic.Add(liczba);
            }

            public void wyswietldrzewo()
            {
                wyswietrekurencyjnie(korzen);
            }

            public void wyswietrekurencyjnie(Wezel3 w)
            {
                if (w != null)
                {
                    MessageBox.Show(w.wartosc.ToString());
                    wyswietrekurencyjnie(w.leweDziecko);
                    wyswietrekurencyjnie(w.praweDziecko);
                }
            }

            public Wezel3 Znajdz(int liczba)
            {
                var w = korzen;
                while (w != null)
                {
                    if (w.wartosc == liczba)
                    {
                        return w;
                    }
                    else if (liczba < w.wartosc)
                    {
                        w = w.leweDziecko;
                    }
                    else
                    {
                        w = w.praweDziecko;
                    }
                }
                return null;
            }

            public Wezel3 Znajdzmin(Wezel3 w)
            {
                while (w.leweDziecko != null)
                {
                    w = w.leweDziecko;
                }
                return w;
            }

            public Wezel3 Znajdzmax(Wezel3 w)
            {
                while (w.praweDziecko != null)
                {
                    w = w.praweDziecko;
                }
                return w;
            }

            public Wezel3 Nastepnik(Wezel3 w)
            {
                if (w.praweDziecko != null)
                {
                    return this.Znajdzmin(w.praweDziecko);
                }
                else
                {
                    while (w.rodzic != null)
                    {
                        if (w.rodzic.leweDziecko == w)
                        {
                            return w.rodzic;
                        }
                        w = w.rodzic;
                    }

                }
                return null;
            }

            public Wezel3 Poprzednik(Wezel3 w)
            {
                if (w.leweDziecko != null)
                {
                    return this.Znajdzmax(w.leweDziecko);
                }
                else
                {
                    while (w.rodzic != null)
                    {
                        if (w.rodzic.praweDziecko == w)
                        {
                            return w.rodzic;
                        }
                        w = w.rodzic;
                    }

                }
                return null;
            }

            public Wezel3 Usun(Wezel3 w)
            {
                switch (w.GetLiczbaDzieci())
                {
                    case 0:
                        w = this.UsunGdy0dzieci(w);
                        break;
                    case 1:
                        w = this.UsunGdy1Dziecko(w);
                        break;
                    case 2:
                        w = this.UsunGdy2Dzieci(w);
                        break;
                }
                return w;
            }

            public Wezel3 UsunGdy0dzieci(Wezel3 w)
            {
                if (w.rodzic == null)
                {
                    this.korzen = null;
                    return w;

                }
                if (w.rodzic.leweDziecko == w)
                {
                    w.rodzic.leweDziecko = null;
                }
                else
                {
                    w.rodzic.praweDziecko = null;
                }
                w.rodzic = null;
                return w;
            }

            public Wezel3 UsunGdy1Dziecko(Wezel3 w)
            {

                Wezel3 dziecko = null;
                if (w.leweDziecko != null)
                {
                    dziecko = w.leweDziecko;
                    w.leweDziecko = null;
                }
                else
                {
                    dziecko = w.praweDziecko;
                    w.praweDziecko = null;
                }
                if (w.rodzic != null)
                {
                    if (w.rodzic.leweDziecko == w)
                    {
                        w.rodzic.leweDziecko = dziecko;
                    }
                    else
                    {
                        w.rodzic.praweDziecko = dziecko;
                    }
                }
                else
                {
                    this.korzen = dziecko;
                }
                dziecko.rodzic = w.rodzic;
                w.rodzic = null;
                return w;
            }

            private Wezel3 UsunGdy2Dzieci(Wezel3 w)
            {
                var zamiennik = this.Nastepnik(w);
                zamiennik = this.Usun(zamiennik);
                if (w.rodzic != null)
                {
                    if (w.rodzic.leweDziecko == w)
                    {
                        w.rodzic.leweDziecko = zamiennik;
                    }
                    else
                    {
                        w.rodzic.praweDziecko = zamiennik;
                    }
                    zamiennik.rodzic = w.rodzic;
                }
                else
                {
                    this.korzen = zamiennik;
                    zamiennik.rodzic = null;
                }
                zamiennik.praweDziecko = w.praweDziecko;
                if (zamiennik.praweDziecko != null)
                {
                    zamiennik.praweDziecko.rodzic = zamiennik;
                }
                zamiennik.leweDziecko = w.leweDziecko;
                if (zamiennik.leweDziecko != null)
                {
                    zamiennik.leweDziecko.rodzic = zamiennik;
                }
                w.rodzic = null;
                w.leweDziecko = null;
                w.praweDziecko = null;

                return w;
            }



        }


        private void btn1_Click(object sender, EventArgs e)
        {
            var drzewo = new DrzewoBinarne(6);
            drzewo.Add(5);
            drzewo.Add(4);
            drzewo.Add(5);
            drzewo.Add(7);
            drzewo.Add(6);
            drzewo.Add(8);
            drzewo.Add(7);
            drzewo.Add(10);
            drzewo.wyswietldrzewo();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            var drzewo = new DrzewoBinarne(6);
            drzewo.Add(5);
            drzewo.Add(4);
            drzewo.Add(5);
            drzewo.Add(7);
            drzewo.Add(6);
            drzewo.Add(8);
            drzewo.Add(7);
            drzewo.Add(10);

            MessageBox.Show("Znajdz 8: " + drzewo.Znajdz(8).wartosc.ToString());
            MessageBox.Show("Znajdz min:" + drzewo.Znajdzmin(drzewo.korzen).wartosc.ToString());
            MessageBox.Show("Znajdz max:" + drzewo.Znajdzmax(drzewo.korzen).wartosc.ToString());
            MessageBox.Show("Nastepnik:" + drzewo.Nastepnik(drzewo.korzen.praweDziecko.praweDziecko).wartosc.ToString());
            MessageBox.Show("Poprzednik:" + drzewo.Poprzednik(drzewo.korzen.praweDziecko.praweDziecko).wartosc.ToString());

        }

        private void btn3_Click(object sender, EventArgs e)
        {
            var drzewo = new DrzewoBinarne(6);
            drzewo.Add(5);
            drzewo.Add(4);
            drzewo.Add(5);
            drzewo.Add(7);
            drzewo.Add(6);
            drzewo.Add(8);
            drzewo.Add(7);
            drzewo.Add(10);
            drzewo.Usun(drzewo.korzen.praweDziecko.praweDziecko);
            drzewo.wyswietldrzewo();
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            var drzewo = new DrzewoBinarne(6);
            drzewo.Add(5);
            drzewo.Add(4);
            drzewo.Add(5);
            drzewo.Add(7);
            drzewo.Add(6);
            drzewo.Add(8);
            drzewo.Add(7);
            drzewo.Add(10);

            var w = drzewo.Znajdzmin(drzewo.korzen);
            while (w != null)
            {
                MessageBox.Show(w.wartosc.ToString());
                w = drzewo.Nastepnik(w);

            }
        }
    }
}