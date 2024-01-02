
using System.Data;
using System.Globalization;

Console.WriteLine("Przed sortowaniem");

//Select sort
int [] tab = new int[] { 5, 7, 3, 9, 2 };
for (int i =0;i< tab.Length; i++)
{
    Console.WriteLine(tab[i]);
}

Console.WriteLine("Po sortowaniu");
bubbleSort(tab);
//selectSort(tab);
//insertSort(tab);
for (int i = 0; i < tab.Length; i++)
{
    Console.WriteLine(tab[i]);
}


void bubbleSort(int[] tab)
{
    bool czy;
    do
    {
        czy = false;
        for (int i = 0; i < tab.Length - 1; i++)
        {
            if (tab[i + 1] < tab[i])

            {
                int temp = tab[i];
                tab[i] = tab[i + 1];
                tab[i + 1] = temp;
                czy = true;
            }

        }

    } while (czy);
}

void selectSort(int[] tab)
{
    for (int i = 0; i < tab.Length; i++)
    {
        int min = i;
        for (int j = i + 1; j < tab.Length; j++)
        {
            if (tab[j] < tab[min])
            {
                min = j;
            }
            if (min != i)
            {
                int temp = tab[i];
                tab[i] = tab[min];
                tab[min] = temp;
            }

        }

    }
}

void insertSort(int[] tab)
{
    for (int i = 1; i < tab.Length; i++)
    {
        int temp = tab[i];
        int j = i - 1;
        while (j >= 0 && tab[j] > temp)
        {
            tab[j + 1] = tab[j];
            j--;
        }
        tab[j + 1] = temp;

    }
}
