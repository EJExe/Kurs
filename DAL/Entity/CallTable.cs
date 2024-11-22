namespace DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CallTable")]
    public partial class CallTable
    {
        [Key]
        [Column("<<PK>>Kod_Call", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int C__PK__Kod_Call { get; set; }

        [Key]
        [Column("<<FK>>Number_Sender", Order = 1)]
        [StringLength(50)]
        public string C__FK__Number_Sender { get; set; }

        [Key]
        [Column("<<FK>>Number_Getter", Order = 2)]
        [StringLength(50)]
        public string C__FK__Number_Getter { get; set; }

        [Key]
        [Column("<<FK>>Type_Of_Call", Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int C__FK__Type_Of_Call { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "date")]
        public DateTime Data_Of_Call { get; set; }

        [Key]
        [Column(Order = 5)]
        public TimeSpan Time_Of_Call { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Amount { get; set; }

        public int? Cost { get; set; }
    }
}
