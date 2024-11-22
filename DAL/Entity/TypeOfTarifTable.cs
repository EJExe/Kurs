namespace DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TypeOfTarifTable")]
    public partial class TypeOfTarifTable
    {
        [Key]
        [Column("<<PK>Kod_Type_Of_Tarif", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int C__PK_Kod_Type_Of_Tarif { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
