using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Models
{
    public class TarifClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? PricePerMonth { get; set; }
        public int? PriceGorod { get; set; }
        public int? PriceMejGorod { get; set; }
        public int? PriceMejNarod { get; set; }

        public TarifClass() { }

        public TarifClass(TarifTable tarif)
        {
            Id = tarif.C__PK___Kod_Tarifa;
            Name = tarif.Name;
            PricePerMonth = tarif.Cost_PerMonth;
            PriceGorod = tarif.Price_1minn_city;
            PriceMejGorod = tarif.Price_1minn_mejgorod;
            PriceMejNarod = tarif.Price_1minn_mejdunarod;
        }
    }
}
