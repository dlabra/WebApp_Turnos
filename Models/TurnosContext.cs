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
        }
    }
}