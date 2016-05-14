namespace mbs.cardlandia.userprofile.datalayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Players2Cards
    {
        [Key]
        public Guid GUID { get; set; }

        public DateTime Modified { get; set; }

        public DateTime Created { get; set; }

        public bool Active { get; set; }

        public Guid CardGUID { get; set; }

        public Guid PlayerGUID { get; set; }

        public virtual Card Card { get; set; }

        public virtual Player Player { get; set; }
    }
}
