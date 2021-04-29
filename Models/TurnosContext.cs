using Microsoft.EntityFrameworkCore;
using Turnos.Models;

namespace Turnos.Models
{
    public class TurnosContext : DbContext
    {
        //Especificamos el constructor
        //Estamos pasando un parametros al construcot estamos un tipo opciones
        //la clase es del tipo dbcontextoptiones ya eso le estamos pasando la clase turnoscontext
        //le estamos pasnado las opciones base
        //con el base lo que hacemos es heredar las opciones base a la clase TurnosConext
        public TurnosContext(DbContextOptions<TurnosContext> opciones) : base(opciones)
        {

        }

        //Estamos definiendo un objecto especiliadad del tipo DbSet, es una entidad un tabla
        public DbSet<Especialidad> Especialidad { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Medico> Medico { get; set; }
        public DbSet<MedicoEspecialidad> MedicoEspecialidad { get; set; }
        public DbSet<Turno> Turno { get; set; }

        public DbSet<Login> Login { get; set; }

        //protected para que sea un metodo protegido, override le decimos al metodo base (OnModelCreating) sera sobreescribo por lo que estara abajo
        //OnModelCreating sirve para dar la estructura de la tabla en la BD al momento de crearle mediante migration
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Tabla Especialidad
            modelBuilder.Entity<Especialidad>(entidad =>
            {
                entidad.ToTable("Especialidad"); //este sera el nombre de la tabla en la bd
                entidad.HasKey(e => e.Id); //le indicamos que el campo Id sera el primary key
                entidad.Property(e => e.Descripcion).IsRequired().HasMaxLength(200).IsUnicode(false); //le especificamos que el campo descrtipcion es requerido
            });

            //TAbla Paciente
            modelBuilder.Entity<Paciente>(entidad =>
            {
                entidad.ToTable("Paciente");
                entidad.HasKey(e => e.IdPaciente);
                entidad.Property(e => e.Nombre).IsRequired().HasMaxLength(50).IsUnicode(false);
                entidad.Property(e => e.Apellido).IsRequired().HasMaxLength(50).IsUnicode(false);
                entidad.Property(e => e.Direccion).IsRequired().HasMaxLength(250).IsUnicode(false);
                entidad.Property(e => e.Telefono).IsRequired().HasMaxLength(20).IsUnicode(false);
                entidad.Property(e => e.Email).IsRequired().HasMaxLength(100).IsUnicode(false);


            });

            //TAbla Medico
            modelBuilder.Entity<Medico>(entidad =>
            {
                entidad.ToTable("Medico");
                entidad.HasKey(e => e.IdMedico);
                entidad.Property(e => e.Nombre).IsRequired().HasMaxLength(50).IsUnicode(false);
                entidad.Property(e => e.Apellido).IsRequired().HasMaxLength(50).IsUnicode(false);
                entidad.Property(e => e.Direccion).IsRequired().HasMaxLength(250).IsUnicode(false);
                entidad.Property(e => e.Telefono).IsRequired().HasMaxLength(20).IsUnicode(false);
                entidad.Property(e => e.Email).IsRequired().HasMaxLength(100).IsUnicode(false);
                entidad.Property(e => e.HorarioAtencionDesde).IsRequired().IsUnicode(false);
                entidad.Property(e => e.HorarioAtencionHasta).IsRequired().IsUnicode(false);


            });

            //tabla especialidad medico, relacion
            //establecemos las foreingkey entre medico y especialidad mediante migration
            modelBuilder.Entity<MedicoEspecialidad>().HasKey(x => new { x.IdMedico, x.IdEspecialidad });

            modelBuilder.Entity<MedicoEspecialidad>().HasOne(x => x.Medico)
            .WithMany(p => p.MedicoEspecialidad)
            .HasForeignKey(p => p.IdMedico);

            modelBuilder.Entity<MedicoEspecialidad>().HasOne(x => x.Especialidad)
            .WithMany(p => p.MedicoEspecialidad)
            .HasForeignKey(p => p.IdEspecialidad);


            modelBuilder.Entity<Turno>(entidad =>
            {
                entidad.ToTable("Turno");
                entidad.HasKey(e => e.IdTurno);
                entidad.Property(e => e.IdPaciente).IsRequired().IsUnicode(false);
                entidad.Property(e => e.IdMedico).IsRequired().IsUnicode(false);
                entidad.Property(e => e.FechaHoraInicio).IsRequired().IsUnicode(false);
                entidad.Property(e => e.FechaHoraFin).IsRequired().IsUnicode(false);
            });

            modelBuilder.Entity<Turno>().HasOne(x => x.Paciente)
           .WithMany(p => p.Turno)
           .HasForeignKey(p => p.IdPaciente);

            modelBuilder.Entity<Turno>().HasOne(x => x.Medico)
            .WithMany(p => p.Turno)
            .HasForeignKey(p => p.IdMedico);

            modelBuilder.Entity<Login>(
                entidad =>
                {
                    entidad.ToTable("Login");
                    entidad.HasKey(e => e.LoginId);
                    entidad.Property(e => e.Usuario).IsRequired().HasMaxLength(50).IsUnicode(false);
                    entidad.Property(e => e.Password).IsRequired().HasMaxLength(100).IsUnicode(false);
                }
            );
        }
    }
}