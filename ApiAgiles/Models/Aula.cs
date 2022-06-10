namespace ApiAgiles.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Aula")]
    public partial class Aula
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Aula()
        {
            Aula_Materia = new HashSet<Aula_Materia>();
            Usuario1 = new HashSet<Usuario>();
        }

        [Key]
        public int Id_Aula { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(1)]
        public string Seccion { get; set; }

        [StringLength(4)]
        public string Anio { get; set; }

        public int? Id_Usuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Aula_Materia> Aula_Materia { get; set; }

        public virtual Usuario Usuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuario> Usuario1 { get; set; }
    }
}
