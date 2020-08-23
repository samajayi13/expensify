namespace Expensify
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user()
        {
            MISCELLANEOUS = new HashSet<MISCELLANEOU>();
            SAVINGS = new HashSet<SAVING>();
        }

        [Key]
        [StringLength(100)]
        public string username { get; set; }

        [Required]
        [StringLength(100)]
        public string password { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MISCELLANEOU> MISCELLANEOUS { get; set; }

        public virtual PERSONAL_CARE PERSONAL_CARE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SAVING> SAVINGS { get; set; }

        public virtual user users1 { get; set; }

        public virtual user user1 { get; set; }
    }
}
