using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ApiAgiles.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Aula> Aula { get; set; }
        public virtual DbSet<Aula_Materia> Aula_Materia { get; set; }
        public virtual DbSet<Materia> Materia { get; set; }
        public virtual DbSet<Nota> Nota { get; set; }
        public virtual DbSet<Periodo> Periodo { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aula>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Aula>()
                .Property(e => e.Seccion)
                .IsUnicode(false);

            modelBuilder.Entity<Aula>()
                .Property(e => e.Anio)
                .IsUnicode(false);

            modelBuilder.Entity<Aula>()
                .HasMany(e => e.Usuario1)
                .WithOptional(e => e.Aula1)
                .HasForeignKey(e => e.Id_Aula);

            modelBuilder.Entity<Materia>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Nota>()
                .Property(e => e.Anio)
                .IsUnicode(false);

            modelBuilder.Entity<Periodo>()
                .HasMany(e => e.Nota)
                .WithOptional(e => e.Periodo)
                .HasForeignKey(e => e.Trimestre);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Clave)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Representante)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Telefono_Representante)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Documento)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Documento_Representante)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Aula)
                .WithOptional(e => e.Usuario)
                .HasForeignKey(e => e.Id_Usuario);
        }
    }
}
