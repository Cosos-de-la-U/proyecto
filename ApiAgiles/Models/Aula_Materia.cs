namespace ApiAgiles.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Aula_Materia
    {
        [Key]
        public int Id_Aula_Materia { get; set; }

        public int? Id_Aula { get; set; }

        public int? Id_Materia { get; set; }

        public virtual Aula Aula { get; set; }

        public virtual Materia Materia { get; set; }
    }
}
