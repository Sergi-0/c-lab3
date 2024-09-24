using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace lab3_3
{
    public class Currency
    {
        public Currency(double value) { Value = value; }
        public double Value { get; set; }
    }

    public class CurrencyUSD : Currency
    {
        private static double usdtorub;
        private static double usdtoeur;
        public CurrencyUSD(double value): base(value){}
        public void ConvertRate(double usdtorub, double usdtoeur)
        {
            CurrencyUSD.usdtoeur = usdtoeur;
            CurrencyUSD.usdtorub = usdtorub;
        }

        public static implicit operator CurrencyRUB(CurrencyUSD usd)
        {
            return new CurrencyRUB(usd.Value * usdtorub);
        }

        public static implicit operator CurrencyEUR(CurrencyUSD usd)
        {
            return new CurrencyEUR(usd.Value * usdtoeur);
        }
    }

    public class CurrencyEUR : Currency
    {
        private static double eurtousd;
        private static double eurtorub;
        public CurrencyEUR(double value): base(value) {}
    public void ConvertRate(double eurtousd, double eurtorub)
        {
            CurrencyEUR.eurtousd = eurtousd;
            CurrencyEUR.eurtorub = eurtorub;
        }

        public static implicit operator CurrencyUSD(CurrencyEUR eur)
        {
            return new CurrencyUSD(eur.Value * eurtousd);
        }

        public static implicit operator CurrencyRUB(CurrencyEUR eur)
        {
            return new CurrencyRUB(eur.Value * eurtorub);
        }
    }

    public class CurrencyRUB : Currency
    {
        private static double rubtousd;
        private static double rubtoeur;
        public CurrencyRUB(double value): base(value){}
    public void ConvertRate(double rubtousd, double rubtoeur)
        {
            CurrencyRUB.rubtousd = rubtousd;
            CurrencyRUB.rubtoeur = rubtoeur;
        }

        public static implicit operator CurrencyUSD(CurrencyRUB rub)
        {
            return new CurrencyUSD(rub.Value * rubtousd);
        }

        public static implicit operator CurrencyEUR(CurrencyRUB rub)
        {
            return new CurrencyEUR(rub.Value * rubtoeur);
        }
    }

    internal class Program3
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите курс валюты RUB по отношению к USD: "); // то, сколько за один рубль дают долларов
            double rubtousd = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите курс валюты RUB по отношению к EUR: ");
            double rubtoeur = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите курс валюты EUR по отношению к USD: ");
            double eurtousd = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите курс валюты USD по отношению к RUB: ");
            double usdtorub = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите курс валюты EUR по отношению к RUB: ");
            double eurtorub = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите курс валюты USD по отношению к EUR: ");
            double usdtoeur = Convert.ToDouble(Console.ReadLine());

            CurrencyUSD usd = new CurrencyUSD(100);
            usd.ConvertRate(usdtorub, usdtoeur);

            CurrencyEUR eur = new CurrencyEUR(88);
            eur.ConvertRate(eurtousd, eurtorub);

            CurrencyRUB rub = new CurrencyRUB(7412);
            rub.ConvertRate(rubtousd, rubtoeur);

            CurrencyRUB usdToRub = usd;
            Console.WriteLine($"100 USD = {usdToRub.Value} RUB");

            CurrencyEUR usdToEur = usd;
            Console.WriteLine($"100 USD = {usdToEur.Value} EUR");

            CurrencyUSD eurToUsd = eur;
            Console.WriteLine($"88 EUR = {eurToUsd.Value} USD");

            CurrencyRUB eurToRub = eur;
            Console.WriteLine($"88 EUR = {eurToRub.Value} RUB");

            CurrencyUSD rubToUsd = rub;
            Console.WriteLine($"7412 RUB = {rubToUsd.Value} USD");

            CurrencyEUR rubToEur = rub;
            Console.WriteLine($"7412 RUB = {rubToEur.Value} EUR");
        }
    }
}
