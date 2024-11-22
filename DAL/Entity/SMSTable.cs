namespace DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SMSTable")]
    public partial class SMSTable
    {
        [Key]
        [Column("<<PK>>Kod_SMS", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int C__PK__Kod_SMS { get; set; }

        [Key]
        [Column("<<FK>>Number_Poluchatela", Order = 1)]
        [StringLength(50)]
        public string C__FK__Number_Poluchatela { get; set; }

        [Key]
        [Column("<<FK>>Number_Otpravitela", Order = 2)]
        [StringLength(50)]
        public string C__FK__Number_Otpravitela { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "date")]
        public DateTime Data_Of_Sent { get; set; }

        [Key]
        [Column(Order = 4)]
        public TimeSpan Time { get; set; }
    }
}
