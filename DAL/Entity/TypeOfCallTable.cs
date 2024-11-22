namespace DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TypeOfCallTable")]
    public partial class TypeOfCallTable
    {
        [Key]
        [Column("<<PK>>Kod_Type_Of_Call", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int C__PK__Kod_Type_Of_Call { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
