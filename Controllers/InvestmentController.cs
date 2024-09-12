using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebII_Lab05_Paco_Ramos_Aaron_Pedro_Ejercicio.Models;

namespace WebII_Lab05_Paco_Ramos_Aaron_Pedro_Ejercicio.Controllers
{
    public class InvestmentController : Controller
    {
        public ActionResult Index()
        {
            return View(new InvestmentModel());
        }

        [HttpPost]
        public ActionResult Calculate(InvestmentModel model)
        {
            if (ModelState.IsValid)
            {
                int compoundingFrequency = GetCompoundingFrequency(model.Frecuencia);
                model.Breakdown = CalculateCompoundInterest(model.CapitalInicial, model.TasaInteres, model.NumeroAnios, compoundingFrequency);
                return View("Result", model);
            }
            return View("Index", model);
        }

        private List<YearlyBreakdown> CalculateCompoundInterest(decimal capitalInicial, double tasaInteres, int numeroAnios, int compoundingFrequency)
        {
            var breakdown = new List<YearlyBreakdown>();
            decimal capital = capitalInicial;
            double tasaInteresCompuesta = tasaInteres / 100;

            for (int year = 1; year <= numeroAnios; year++)
            {
                capital = capitalInicial * (decimal)Math.Pow((1 + tasaInteresCompuesta / compoundingFrequency), compoundingFrequency * year);
                breakdown.Add(new YearlyBreakdown { Year = year, Capital = capital });
            }

            return breakdown;
        }

        private int GetCompoundingFrequency(string frecuencia)
        {
            switch (frecuencia.ToLower())
            {
                case "mensual":
                    return 12;
                case "trimestral":
                    return 4;
                case "anual":
                    return 1;
                default:
                    throw new ArgumentException("Frecuencia de capitalización no válida.");
            }
        }
    }

}