namespace ApiAgiles.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Usuario")]
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            Aula = new HashSet<Aula>();
            Nota = new HashSet<Nota>();
        }

        [Key]
        public int Id_Usuario { get; set; }

        [StringLength(75)]
        public string Nombre { get; set; }

        [StringLength(75)]
        public string Apellido { get; set; }

        [StringLength(25)]
        public string Username { get; set; }

        [StringLength(25)]
        public string Clave { get; set; }

        [StringLength(15)]
        public string Telefono { get; set; }

        [StringLength(150)]
        public string Direccion { get; set; }

        public DateTime? Fecha_Nacimiento { get; set; }

        public int? Tipo { get; set; }

        [StringLength(150)]
        public string Representante { get; set; }

        [StringLength(15)]
        public string Telefono_Representante { get; set; }

        [StringLength(15)]
        public string Documento { get; set; }

        [StringLength(15)]
        public string Documento_Representante { get; set; }

        public int? Id_Aula { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Aula> Aula { get; set; }

        public virtual Aula Aula1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Nota> Nota { get; set; }
    }
}
