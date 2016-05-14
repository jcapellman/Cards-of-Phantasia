namespace mbs.cardlandia.userprofile.datalayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CardType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CardType()
        {
            Cards = new HashSet<Card>();
        }

        [Key]
        public Guid GUID { get; set; }

        public DateTime Modified { get; set; }

        public DateTime Created { get; set; }

        public bool Active { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        public double PercentageChance { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Card> Cards { get; set; }
    }
}
