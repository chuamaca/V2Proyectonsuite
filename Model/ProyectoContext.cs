namespace Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ProyectoContext : DbContext
    {
        public ProyectoContext()
            : base("name=ProyectoContext")
        {
            Database.SetInitializer<ProyectoContext>(null);
        }

      
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Orden> Orden { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Sucursal> Sucursal { get; set; }

        public virtual DbSet<DetalleOrden> DetalleOrden { get; set; }
        public virtual DbSet<Hardware> Hardware { get; set; }

        public virtual DbSet<Events> Events { get; set; }
       

        public virtual DbSet<Liquidacion> Liquidacion { get; set; }

        public virtual DbSet<LiquidacionFacturacion> LiquidacionFacturacion { get; set; }

        public virtual DbSet<CatalogoPrecios> CatalogoPrecios { get; set; }

        public virtual DbSet<Servicio> Servicio { get; set; }
        public virtual DbSet<mesServicio> mesServicio { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empresa>()
                .HasMany(e => e.Sucursal)
                .WithRequired(e => e.Empresa)
                .HasForeignKey(e => e.empresa_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Empresa>()
                .HasMany(e => e.Cliente)
                .WithRequired(e => e.Empresa)
                .HasForeignKey(e => e.empresa_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Orden>()
                .HasMany(e => e.DetalleOrden)
                .WithRequired(e => e.Orden)
                .HasForeignKey(e => e.Orden_Id)
                 .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hardware>()
                .HasMany(e => e.DetalleOrden)
                .WithRequired(e => e.Hardware)
                .HasForeignKey(e => e.Hardware_Id)
                    .WillCascadeOnDelete(false);



            modelBuilder.Entity<Orden>()
             .HasMany(e => e.mesServicio)
             .WithRequired(e => e.Orden)
             .HasForeignKey(e => e.idorden)
              .WillCascadeOnDelete(false);

            modelBuilder.Entity<Servicio>()
           .HasMany(e => e.mesServicio)
           .WithRequired(e => e.Servicio)
           .HasForeignKey(e => e.idServicio)
            .WillCascadeOnDelete(false);




        }
    }
}
