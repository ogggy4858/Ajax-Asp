namespace Data.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Anh")]
    public partial class Anh
    {
        public int ID { get; set; }

        public byte[] IMAG { get; set; }

        [StringLength(400)]
        public string ThongTin { get; set; }
    }
}
