namespace Expensify
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MISCELLANEOUS")]
    public partial class MISCELLANEOU
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int gifts { get; set; }

        public int other { get; set; }

        [Required]
        [StringLength(100)]
        public string username { get; set; }

        public virtual user user { get; set; }
    }
}
