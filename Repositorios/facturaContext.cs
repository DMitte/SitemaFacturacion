using System;
using System.Collections.Generic;
using Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Configuration;
using System.Collections.Specialized;

namespace Repositorios
{
    public partial class facturaContext : DbContext
    {
        public facturaContext()
        {
        }

        public facturaContext(DbContextOptions<facturaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorium> Categoria { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<DetalleFactura> DetalleFacturas { get; set; } = null!;
        public virtual DbSet<Factura> Facturas { get; set; } = null!;
        public virtual DbSet<ModoPago> ModoPagos { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseMySql("server=localhost;port=3306;database=factura;uid=root;pwd=123456", ServerVersion.Parse("8.0.30-mysql"));
                optionsBuilder.UseSqlServer("Server=ELMITTE\\SQLEXPRESS;Database=facturacion;Trusted_Connection=True;");
                //optionsBuilder.UseMySql(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString, Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.HasKey(e => e.CatCodigo)
                    .HasName("PK__categori__38ABB93F9E21AE12");

                entity.ToTable("categoria");

                entity.Property(e => e.CatCodigo).HasColumnName("cat_codigo");

                entity.Property(e => e.CatDescripcion)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("cat_descripcion");

                entity.Property(e => e.CatNombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("cat_nombre");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.CliCodigo)
                    .HasName("PK__cliente__9C28A245410AA648");

                entity.ToTable("cliente");

                entity.Property(e => e.CliCodigo).HasColumnName("cli_codigo");

                entity.Property(e => e.CliApellidos)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("cli_apellidos");

                entity.Property(e => e.CliCedula)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("cli_cedula");

                entity.Property(e => e.CliDireccion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("cli_direccion");

                entity.Property(e => e.CliFechaNacimiento)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cli_fecha_nacimiento");

                entity.Property(e => e.CliMail)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("cli_mail");

                entity.Property(e => e.CliNombres)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("cli_nombres");

                entity.Property(e => e.CliTelefono)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("cli_telefono");

                entity.Property(e => e.CliPassword)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("pass");
            });

            modelBuilder.Entity<DetalleFactura>(entity =>
            {
                entity.HasKey(e => e.DfaCodigo)
                    .HasName("PK__detalle___F0110EB436412CA8");

                entity.ToTable("detalle_factura");

                entity.Property(e => e.DfaCodigo)
                    .ValueGeneratedNever()
                    .HasColumnName("dfa_codigo");

                entity.Property(e => e.DfaCantidad).HasColumnName("dfa_cantidad");

                entity.Property(e => e.DfaPrecio)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("dfa_precio");

                entity.Property(e => e.FacCodigo).HasColumnName("fac_codigo");

                entity.Property(e => e.ProdCodigo).HasColumnName("prod_codigo");

                entity.HasOne(d => d.FacCodigoNavigation)
                    .WithMany(p => p.DetalleFacturas)
                    .HasForeignKey(d => d.FacCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__detalle_f__fac_c__4316F928");

                entity.HasOne(d => d.ProdCodigoNavigation)
                    .WithMany(p => p.DetalleFacturas)
                    .HasForeignKey(d => d.ProdCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__detalle_f__prod___440B1D61");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.FacCodigo)
                    .HasName("PK__factura__D53513B2D4989B8B");

                entity.ToTable("factura");

                entity.Property(e => e.FacCodigo).HasColumnName("fac_codigo");

                entity.Property(e => e.CliCodigo).HasColumnName("cli_codigo");

                entity.Property(e => e.FacFechaEmision)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("fac_fecha_emision");

                entity.Property(e => e.MpoCodigo).HasColumnName("mpo_codigo");

                entity.HasOne(d => d.CliCodigoNavigation)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.CliCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__factura__cli_cod__3A81B327");

                entity.HasOne(d => d.MpoCodigoNavigation)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.MpoCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__factura__mpo_cod__3B75D760");
            });

            modelBuilder.Entity<ModoPago>(entity =>
            {
                entity.HasKey(e => e.MpoCodigo)
                    .HasName("PK__modo_pag__E26C2FB0F253F3D1");

                entity.ToTable("modo_pago");

                entity.Property(e => e.MpoCodigo).HasColumnName("mpo_codigo");

                entity.Property(e => e.MpoDetalle)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("mpo_detalle");

                entity.Property(e => e.MpoNombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("mpo_nombre");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.ProdCodigo)
                    .HasName("PK__producto__098A8C679CC55192");

                entity.ToTable("producto");

                entity.Property(e => e.ProdCodigo).HasColumnName("prod_codigo");

                entity.Property(e => e.CatCodigo).HasColumnName("cat_codigo");

                entity.Property(e => e.ProdNombre)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("prod_nombre");

                entity.Property(e => e.ProdPrecio)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("prod_precio");

                entity.Property(e => e.ProdStock).HasColumnName("prod_stock");

                entity.HasOne(d => d.CatCodigoNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.CatCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__producto__cat_co__403A8C7D");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
