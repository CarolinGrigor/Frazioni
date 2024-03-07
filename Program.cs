namespace Es.Frazioni;

internal class Program
{
    class Frazione
    {
        public int Numeratore { get; set; }
        public int Denominatore { get; set; }

        public Frazione(int numeratore, int denominatore)
        {
            if (denominatore != 0)
            {
                Numeratore = numeratore;
                Denominatore = denominatore;
                SemplificaFrazione();
            }
            else
            {
                throw new ArgumentException("Il denominatore non può essere zero.");
            }
        }

        private void SemplificaFrazione()
        {
            int mcd = MCD(Numeratore, Denominatore);
            Numeratore /= mcd;
            Denominatore /= mcd;
            
        }

        public int MCD(int numeratore, int denominatore)
        {
            while (numeratore != denominatore)
                if (numeratore > denominatore)
                    numeratore -= denominatore;
                else if (denominatore > numeratore)
                    denominatore -= numeratore;
            return numeratore;
        }

        public override string ToString()
        {
            return $"{Numeratore}/{Denominatore}";
        }

        public static Frazione Parse(string stringa)
        {
            string[] index = stringa.Split('/');
            if (index.Length != 2 || !int.TryParse(index[0], out int numeratore) || !int.TryParse(index[1], out int denominatore))
            {
                throw new FormatException("Formato non valido per la frazione.");
            }
            return new Frazione(numeratore, denominatore);
        }
    }

    private static void Main(string[] args)
    {
        Console.WriteLine("Frazione 1:");
        int n1 = int.Parse(Console.ReadLine());
        int d1 = int.Parse(Console.ReadLine());
        Frazione frazione = new Frazione(n1, d1);
        Frazione frazione1 = Frazione.Parse(frazione.ToString());

        Console.WriteLine($"Frazione: {frazione1}");
        Console.ReadKey();
    }
}

/*
 internal class Program
{
    private static void Main(string[] args)
    {
        Frazione a1 = new Frazione(3, -5);
        Frazione a2 = new Frazione(-4, 7);

        Frazione rSomma = Frazione.FrazioneSomma(a1, a2);

        Console.WriteLine($"{rSomma}");

        Console.ReadKey();
    }
}

class Frazione
{
    public int Numeratore { get; set; }
    public int Denominatore { get; set; }

    public Frazione()
    {

    }

    public Frazione(int num, int den)
    {
        Numeratore = num;
        Denominatore = den;
    }

    public static int MCD(int num, int den)
    {
        num = Math.Abs(num);
        den = Math.Abs(den);

        while (num != den)
        {
            if (num > den)
            {
                num -= den;
            }
            else
            {
                den -= num;
            }
        }

        return num;
    }

    public static Frazione FrazioneSomma(Frazione a1, Frazione a2)
    {
        int n = a1.Numeratore * a2.Denominatore + a2.Numeratore * a1.Denominatore;
        int d = a1.Denominatore * a2.Denominatore;
        int mcd = MCD(n, d);

        if ((n > 0 && d > 0) || (n < 0 && d < 0))
        {
            return new Frazione(n / mcd, d / mcd);
        }

        if(n > 0 && d < 0)
        {
            return new Frazione(Math.Abs(n) / mcd, -(Math.Abs(d)) / mcd);
        }
        else
        {

            return new Frazione(-(Math.Abs(n)) / mcd, (Math.Abs(d)) / mcd);
        }
    }

    public override string ToString()
    {
        return $"{Numeratore} / {Denominatore}";
    }
}
*/