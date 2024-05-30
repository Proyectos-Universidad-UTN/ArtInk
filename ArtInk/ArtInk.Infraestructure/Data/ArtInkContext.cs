using System;
using System.Collections.Generic;
using System.Data;
using ArtInk.Infraestructure.Models;
using Microsoft.EntityFrameworkCore;

namespace ArtInk.Infraestructure.Data;

public partial class ArtInkContext (DbContextOptions<ArtInkContext> options): DbContext(options)
{
    public virtual DbSet<Canton> Canton { get; set; }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<Cliente> Cliente { get; set; }

    public virtual DbSet<Contacto> Contacto { get; set; }

    public virtual DbSet<DetalleFactura> DetalleFactura { get; set; }

    public virtual DbSet<DetalleFacturaProducto> DetalleFacturaProducto { get; set; }

    public virtual DbSet<Distrito> Distrito { get; set; }

    public virtual DbSet<Factura> Factura { get; set; }

    public virtual DbSet<Feriado> Feriado { get; set; }

    public virtual DbSet<Genero> Genero { get; set; }

    public virtual DbSet<Horario> Horario { get; set; }

    public virtual DbSet<Impuesto> Impuesto { get; set; }

    public virtual DbSet<Inventario> Inventario { get; set; }

    public virtual DbSet<Producto> Producto { get; set; }

    public virtual DbSet<Proveedor> Proveedor { get; set; }

    public virtual DbSet<Provincia> Provincia { get; set; }

    public virtual DbSet<Reserva> Reserva { get; set; }

    public virtual DbSet<ReservaPregunta> ReservaPregunta { get; set; }

    public virtual DbSet<ReservaServicio> ReservaServicio { get; set; }

    public virtual DbSet<Rol> Rol { get; set; }

    public virtual DbSet<Servicio> Servicio { get; set; }

    public virtual DbSet<ServicioProducto> ServicioProducto { get; set; }

    public virtual DbSet<Sucursal> Sucursal { get; set; }

    public virtual DbSet<SucursalHorario> SucursalHorario { get; set; }

    public virtual DbSet<TipoPago> TipoPago { get; set; }

    public virtual DbSet<TipoServicio> TipoServicio { get; set; }

    public virtual DbSet<UnidadMedida> UnidadMedida { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    public virtual DbSet<UsuarioSucursal> UsuarioSucursal { get; set; }

    public IDbConnection Connection => Database.GetDbConnection();// esto por defecto pasa toda la info a la propiedad 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<Canton>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_canton");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasOne(d => d.IdProvinciaNavigation).WithMany(p => p.Canton)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Canton_Provincia");
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_categoria");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.Property(e => e.Activo).HasDefaultValue(true);

            entity.HasOne(d => d.IdDistritoNavigation).WithMany(p => p.Cliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cliente_Distrito");
        });

        modelBuilder.Entity<Contacto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_contacto");

            entity.Property(e => e.Activo).HasDefaultValue(true);

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.Contacto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contacto_Proveedor");
        });

        modelBuilder.Entity<DetalleFactura>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_detalleFactura");

            entity.HasOne(d => d.IdFacturaNavigation).WithMany(p => p.DetalleFactura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleFactura_Factura");

            entity.HasOne(d => d.IdServicioNavigation).WithMany(p => p.DetalleFactura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleFactura_Servicio");
        });

        modelBuilder.Entity<DetalleFacturaProducto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_[DetalleFacturaProducto");

            entity.HasOne(d => d.IdDetalleFacturaNavigation).WithMany(p => p.DetalleFacturaProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleFacturaProducto_DetalleFactura");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetalleFacturaProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleFacturaProducto_Producto");
        });

        modelBuilder.Entity<Distrito>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_distrito");

            entity.HasOne(d => d.IdCantonNavigation).WithMany(p => p.Distrito)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Distrito_Canton");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_factura");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Factura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Factura_Cliente");

            entity.HasOne(d => d.IdImpuestoNavigation).WithMany(p => p.Factura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Factura_Impuesto");

            entity.HasOne(d => d.IdTipoPagoNavigation).WithMany(p => p.Factura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Factura_TipoPago");

            entity.HasOne(d => d.IdUsuarioSucursalNavigation).WithMany(p => p.Factura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Factura_UsuarioSucursal");
        });

        modelBuilder.Entity<Feriado>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Activo).HasDefaultValue(true);

            entity.HasOne(d => d.IdSucursalNavigation).WithMany(p => p.Feriado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Feriado_Sucursal");
        });

        modelBuilder.Entity<Genero>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Horario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_horario");

            entity.HasOne(d => d.IdSucursalNavigation).WithMany(p => p.Horario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Horario_Sucursal");
        });

        modelBuilder.Entity<Impuesto>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Inventario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_inventario");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Inventario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inventario_Producto");

            entity.HasOne(d => d.IdSucursalNavigation).WithMany(p => p.Inventario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inventario_Sucursal");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_producto");

            entity.Property(e => e.Activo).HasDefaultValue(true);

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Producto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Producto_Categoria");

            entity.HasOne(d => d.IdUnidadMedidaNavigation).WithMany(p => p.Producto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Producto_UnidadMedida");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_proveedor");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Activo).HasDefaultValue(true);

            entity.HasOne(d => d.IdDistritoNavigation).WithMany(p => p.Proveedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Proveedor_Distrito");
        });

        modelBuilder.Entity<Provincia>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_provincia");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_reserva");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Estado)
                .HasDefaultValue("P")
                .IsFixedLength();

            entity.HasOne(d => d.IdSucursalHorarioNavigation).WithMany(p => p.Reserva)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reserva_SucursalHorario");
        });

        modelBuilder.Entity<ReservaPregunta>(entity =>
        {
            entity.Property(e => e.Activo).HasDefaultValue(true);

            entity.HasOne(d => d.IdReservaNavigation).WithMany(p => p.ReservaPregunta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReservaPregunta_Reserva");
        });

        modelBuilder.Entity<ReservaServicio>(entity =>
        {
            entity.HasOne(d => d.IdReservaNavigation).WithMany(p => p.ReservaServicio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReservaServicio_Reserva");

            entity.HasOne(d => d.IdServicioNavigation).WithMany(p => p.ReservaServicio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReservaServicio_Servicio");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_rol");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Activo).HasDefaultValue(true);
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_servicio");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Activo).HasDefaultValue(true);

            entity.HasOne(d => d.IdTipoServicioNavigation).WithMany(p => p.Servicio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Servicio_TipoServicio");
        });

        modelBuilder.Entity<ServicioProducto>(entity =>
        {
            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.ServicioProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ServicioProducto_Producto");

            entity.HasOne(d => d.IdServicioNavigation).WithMany(p => p.ServicioProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ServicioProducto_Servicio");
        });

        modelBuilder.Entity<Sucursal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_sucursal");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Activo).HasDefaultValue(true);

            entity.HasOne(d => d.IdDistritoNavigation).WithMany(p => p.Sucursal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sucursal_Distrito");
        });

        modelBuilder.Entity<SucursalHorario>(entity =>
        {
            entity.HasOne(d => d.IdHorarioNavigation).WithMany(p => p.SucursalHorario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SucursalHorario_Horario");

            entity.HasOne(d => d.IdSucursalNavigation).WithMany(p => p.SucursalHorario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SucursalHorario_Sucursal");
        });

        modelBuilder.Entity<TipoPago>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<TipoServicio>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<UnidadMedida>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Simbolo).IsFixedLength();
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_usuario");

            entity.Property(e => e.Activo).HasDefaultValue(true);

            entity.HasOne(d => d.IdDistritoNavigation).WithMany(p => p.Usuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuario_Distrito");

            entity.HasOne(d => d.IdGeneroNavigation).WithMany(p => p.Usuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuario_Genero");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuario_Rol");
        });

        modelBuilder.Entity<UsuarioSucursal>(entity =>
        {
            entity.HasOne(d => d.IdSucursalNavigation).WithMany(p => p.UsuarioSucursal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioSucursal_Sucursal");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.UsuarioSucursal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioSucursal_Usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
