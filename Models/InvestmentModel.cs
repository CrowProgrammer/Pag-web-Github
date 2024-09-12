using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebII_Lab05_Paco_Ramos_Aaron_Pedro_Ejercicio.Models
{
    public class InvestmentModel
    {
        public decimal CapitalInicial { get; set; }
        public double TasaInteres { get; set; }
        public int NumeroAnios { get; set; }
        public string Frecuencia { get; set; } // "Mensual", "Trimestral", "Anual"

        public List<YearlyBreakdown> Breakdown { get; set; }
    }

    public class YearlyBreakdown
    {
        public int Year { get; set; }
        public decimal Capital { get; set; }
    }

}