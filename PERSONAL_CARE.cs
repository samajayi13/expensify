namespace Expensify
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PERSONAL CARE")]
    public partial class PERSONAL_CARE
    {
        public int tolietries { get; set; }

        [Column("household products")]
        public int household_products { get; set; }

        public int clothing { get; set; }

        public int other { get; set; }

        [Key]
        [StringLength(100)]
        public string username { get; set; }

        public int id { get; set; }

        public virtual user user { get; set; }
    }
}
