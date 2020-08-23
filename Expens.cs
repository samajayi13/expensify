namespace Expensify.Models 
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Expenses")]
    public partial class Expens
    {
        public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

        [Required]
        [StringLength(100)]
        public string category { get; set; }

        public int budget { get; set; }

        public int actual_amount { get; set; }

        public int month { get; set; }

        [Required]
        [StringLength(100)]
        public string username { get; set; }
    }
}
