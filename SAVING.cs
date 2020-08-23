namespace Expensify
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SAVINGS")]
    public partial class SAVING
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int retirement { get; set; }

        [Column("brokerage accounts")]
        public int brokerage_accounts { get; set; }

        [Column("college fund")]
        public int college_fund { get; set; }

        public int savings { get; set; }

        [Required]
        [StringLength(100)]
        public string username { get; set; }

        public virtual user user { get; set; }
    }
}
