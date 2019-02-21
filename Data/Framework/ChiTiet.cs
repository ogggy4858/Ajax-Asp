namespace Data.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTiet")]
    public partial class ChiTiet
    {
        public int id { get; set; }

        public int? idSach { get; set; }

        public DateTime? CreateDate { get; set; }

        public virtual Sach Sach { get; set; }
    }
}
