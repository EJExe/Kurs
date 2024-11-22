namespace DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TarifTable")]
    public partial class TarifTable
    {
        [Key]
        [Column("<<PK>> Kod_Tarifa", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int C__PK___Kod_Tarifa { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Name { get; set; }

        public int? Cost_PerMonth { get; set; }

        public int? Cost_Of_Connection { get; set; }

        public int? Price_1minn_city { get; set; }

        public int? Price_1minn_mejgorod { get; set; }

        public int? Price_1minn_mejdunarod { get; set; }

        [Key]
        [Column("[<<FK>>]Kod_Type_Of_Tarif", Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int C___FK___Kod_Type_Of_Tarif { get; set; }

        public int? SMS_Per_Month { get; set; }

        public int? GB_Per_Month { get; set; }

        public int? Min_Per_Month { get; set; }
    }
}
