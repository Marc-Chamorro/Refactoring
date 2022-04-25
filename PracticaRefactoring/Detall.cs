using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaRefactoring
{
    public class Detall
    {
        public string Producte { get; set; }
        public int quantitat { get; set; }
        public double preu { get; set; }
    }
    public class DadesComanda
    {
        public string ComandaNum { get; set; }
        public string Client { get; set; }
        public string ImportBrut { get; set; }
        public string IVA { get; set; }
        public string Despesa { get; set; }
        public string Descompte { get; set; }
        public string Estat { get; set; }
    }
}
