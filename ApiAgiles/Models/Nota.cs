namespace ApiAgiles.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Nota")]
    public partial class Nota
    {
        [Key]
        public int Id_Nota { get; set; }

        public float? Valor_Nota { get; set; }

        [StringLength(4)]
        public string Anio { get; set; }

        public int? Trimestre { get; set; }

        public float? Porcentaje { get; set; }

        public int? Id_Materia { get; set; }

        public int? Id_Usuario { get; set; }

        public virtual Materia Materia { get; set; }

        public virtual Periodo Periodo { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
