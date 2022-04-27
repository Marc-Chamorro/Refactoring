using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaRefactoring
{
    class Comanda
    {

        public double calcDespesa(List<Detall> linia, string client)
        {
            double despesa = 0.0;
            double importBrut = calcBrut(linia, client);

            if (client.EndsWith("B"))
            {
                if (importBrut > 500)
                {
                    despesa = 0.0;
                }
                else
                {
                    despesa = 5.0;
                }
            }
            else
            {
                if (client.EndsWith("C"))
                {
                    despesa = importBrut * 0.03;
                    if (despesa > 10)
                        despesa = 10;
                }
                if (client.EndsWith("A"))
                {
                    despesa = 0.0;
                }
            }
            return despesa;
        }

        public double calcDescompte(List<Detall> linia, string client)
        {
            double importBrut = calcBrut(linia, client);
            double descompte = 0.0;

            if (client.EndsWith("A"))
            {
                descompte = getDescompte(importBrut, 0.05);
            }
            if (client.EndsWith("B"))
            {
                descompte = getDescompte(importBrut, 0.03);
            }
            if (client.EndsWith("C"))
            {
                descompte = getDescompte(importBrut, 0.01);
            }
            return descompte;
        }

        public double calcIva(List<Detall> linia, string client)
        {
            double importBrut = calcBrut(linia, client);
            double iva = getIva(importBrut);
            return iva;
        }

        public double calcBrut(List<Detall> linia, string client)
        {
            double importBrut = 0.0;
            foreach (Detall lin in linia)
            {
                importBrut = importBrut + (lin.quantitat * lin.preu);
            }
            return importBrut;
        }

        public double calcTotal(List<Detall> linia, string client)
        {
            double importNet;
            double importBrut = calcBrut(linia, client);
            double despesa = calcDespesa(linia, client);
            double iva = getIva(importBrut);
            double descompte = calcDescompte(linia, client);
            importNet = importBrut + iva + despesa - descompte;
            return importNet;
        }

        public double getIva(double import)
        {
            const double IVA = 0.21;
            return import * IVA;
        }

        public double getDescompte(double import, double dto)
        {
            return import * dto;
        }

        public double FerCalculIRound(List<Detall> llista, string tipusCalcul, string client) 
        {
            double resultat = 0.0;
            resultat = Fercalculs(llista, tipusCalcul, client);
            resultat = Math.Round(resultat, 2, MidpointRounding.AwayFromZero);

            return resultat;
        }

        public double CalcularPreuTotal(DadesComanda dades)
        {
            double total = 0.0;
            total = double.Parse(dades.ImportBrut) + double.Parse(dades.IVA) + double.Parse(dades.Despesa) - double.Parse(dades.Descompte);
            return total;
        }
    }
}
