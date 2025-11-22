using MediTech.Domain.Entities;
using MediTech.Domain.Entities.Colaboradores_Entities;
using MediTech.Domain.Entities.Especialidad_Entities;
using MediTech.Domain.Entities.Recetas_Entities;
namespace MediTech.Infrastructure.DataContexts
{
    /// <summary>
    /// AppDbContext representa el contexto principal de la base de datos.
    /// Mapea todas las entidades del dominio y define las relaciones entre ellas.
    /// </summary>
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // =======================
        // DbSets (Tablas)
        // =======================

        // Módulo de usuarios y roles
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<DetalleModulo> DetalleModulo { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Modulos> Modulos { get; set; }

        // Pacientes
        public DbSet<Paciente> Pacientes { get; set; }

        // Colaboradores
        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<ColaboradorDetalle> ColaboradorDetalle { get; set; }
        public DbSet<TipoColaboradores> TipoColaboradores { get; set; }

        // Citas y disponibilidad
        public DbSet<Cita> Citas { get; set; }
        public DbSet<CitasEstadoDetalle> CitasEstadoDetalles { get; set; }
        public DbSet<EstatusCita> EstatusCitas { get; set; }
        public DbSet<Disponibilidad> Disponibilidad { get; set; }

        // Cedes y especialidades
        public DbSet<Cede> Cedes { get; set; }
        public DbSet<Especialidad> Especialidades { get; set; }

        // =======================
        // Configuración de la conexión
        // =======================
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("DefaultConnection"); // Cambiar por la cadena real en appsettings.json
            }
        }

        // =======================
        // Configuración de relaciones
        // =======================
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // --------------------------------------------------
            // RELACIONES DEL MÓDULO DE USUARIOS
            // --------------------------------------------------

            modelBuilder.Entity<Usuarios>()
                .HasOne(u => u.Modulo)
                .WithMany()
                .HasForeignKey(u => u.ID_Modulo)
                .HasConstraintName("FK_Usuarios_Modulos");

            modelBuilder.Entity<Usuarios>()
                .HasOne(u => u.Persona)
                .WithMany(c => c.Usuarios)
                .HasForeignKey(u => u.ID_Persona)
                .HasConstraintName("FK_Usuarios_Colaborador");

            modelBuilder.Entity<DetalleModulo>()
                .HasOne(dm => dm.Modulo)
                .WithMany(m => m.Detalles)
                .HasForeignKey(dm => dm.ID_Modulo)
                .HasConstraintName("FK_DetalleModulo_Modulos");

            modelBuilder.Entity<DetalleModulo>()
                .HasOne(dm => dm.Rol)
                .WithMany()
                .HasForeignKey(dm => dm.ID_Rol)
                .HasConstraintName("FK_DetalleModulo_Roles");

            // --------------------------------------------------
            // RELACIONES DE COLABORADORES
            // --------------------------------------------------

            modelBuilder.Entity<Colaborador>()
                .HasOne(c => c.Cede)
                .WithMany()
                .HasForeignKey(c => c.ID_Cede)
                .HasConstraintName("FK_Colaborador_Cedes");

            modelBuilder.Entity<Colaborador>()
                .HasOne(c => c.Especialidad)
                .WithMany()
                .HasForeignKey(c => c.ID_Especialidad)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Colaborador_Especialidad");

            modelBuilder.Entity<ColaboradorDetalle>()
                .HasOne(cd => cd.Colaborador)
                .WithMany(c => c.ColaboradorDetalles)
                .HasForeignKey(cd => cd.ID_Colaborador)
                .HasConstraintName("FK_ColaboradorDetalle_Colaborador");

            modelBuilder.Entity<ColaboradorDetalle>()
                .HasOne(cd => cd.TipoColaborador)
                .WithMany(tc => tc.ColaboradorDetalles)
                .HasForeignKey(cd => cd.ID_TipoColaborador)
                .HasConstraintName("FK_ColaboradorDetalle_TipoColaborador");

            // --------------------------------------------------
            // RELACIONES DE CITAS Y DISPONIBILIDAD
            // --------------------------------------------------

            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Paciente)
                .WithMany()
                .HasForeignKey(c => c.ID_Paciente)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Cede)
                .WithMany()
                .HasForeignKey(c => c.ID_Cede)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Disponibilidad)
                .WithMany()
                .HasForeignKey(c => c.ID_Disponible)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CitasEstadoDetalle>()
                .HasOne(ced => ced.Cita)
                .WithMany()
                .HasForeignKey(ced => ced.ID_Cita)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CitasEstadoDetalle>()
                .HasOne(ced => ced.EstatusCita)
                .WithMany()
                .HasForeignKey(ced => ced.ID_Estatus)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Disponibilidad>()
                .HasOne(d => d.Colaborador)
                .WithMany()
                .HasForeignKey(d => d.ID_Colaborador)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Disponibilidad>()
                .HasOne(d => d.Paciente)
                .WithMany()
                .HasForeignKey(d => d.ID_Paciente)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<SignosVitales> SignosVitales { get; set; }
        public DbSet<Recetas> Recetas { get; set; }


    }
}
