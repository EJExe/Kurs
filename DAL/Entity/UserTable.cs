namespace DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserTable")]
    public partial class UserTable
    {
        [Key]
        [Column("<<PK>> Number_Of_Phone", Order = 0)]
        [StringLength(50)]
        public string C__PK___Number_Of_Phone { get; set; }

        [Column("<<FK>> Kod_Tarifa")]
        public int? C__FK___Kod_Tarifa { get; set; }

        [Column("<<FK>> Kod_Type_Of_User")]
        public int? C__FK___Kod_Type_Of_User { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string FIO { get; set; }

        public int? Money_On_Bank { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string Loging { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string Password { get; set; }

        public int? Minuts_Left { get; set; }

        public int? Gb_Left { get; set; }

        public int? SMS_Left { get; set; }
    }
}
