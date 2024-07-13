using System.Data;
using ArtInk.Infraestructure.Enums;
using ArtInk.Infraestructure.Models;
using Microsoft.EntityFrameworkCore;

namespace ArtInk.Infraestructure.Data;

public partial class ArtInkContext(DbContextOptions<ArtInkContext> options) : DbContext(options)
{
    public virtual DbSet<Canton> Cantons { get; set; }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Contacto> Contactos { get; set; }

    public virtual DbSet<DetalleFactura> DetalleFacturas { get; set; }

    public virtual DbSet<DetalleFacturaProducto> DetalleFacturaProductos { get; set; }

    public virtual DbSet<Distrito> Distritos { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<Feriado> Feriados { get; set; }

    public virtual DbSet<Genero> Generos { get; set; }

    public virtual DbSet<Horario> Horarios { get; set; }

    public virtual DbSet<Impuesto> Impuestos { get; set; }

    public virtual DbSet<Inventario> Inventarios { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<InventarioProducto> InventarioProducto { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<Provincia> Provincia { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<ReservaPregunta> ReservaPregunta { get; set; }

    public virtual DbSet<ReservaServicio> ReservaServicios { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<Sucursal> Sucursals { get; set; }

    public virtual DbSet<SucursalHorario> SucursalHorarios { get; set; }

    public virtual DbSet<TipoPago> TipoPagos { get; set; }

    public virtual DbSet<TipoServicio> TipoServicios { get; set; }

    public virtual DbSet<UnidadMedida> UnidadMedida { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioSucursal> UsuarioSucursals { get; set; }

    public virtual DbSet<SucursalFeriado> SucursalFeriados { get; set; }

    public virtual DbSet<SucursalHorarioBloqueo> SucursalHorarioBloqueos { get; set; }

    public IDbConnection Connection => Database.GetDbConnection();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<Canton>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_canton");

            entity.ToTable("Canton");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Nombre).HasMaxLength(50);

            entity.HasOne(d => d.IdProvinciaNavigation).WithMany(p => p.Cantons)
                .HasForeignKey(d => d.IdProvincia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Canton_Provincia");
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_categoria");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Codigo).HasMaxLength(50);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(70);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(70);
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.ToTable("Cliente");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Apellidos).HasMaxLength(80);
            entity.Property(e => e.CorreoElectronico).HasMaxLength(150);
            entity.Property(e => e.DireccionExacta).HasMaxLength(250);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(80);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(70);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(70);

            entity.HasOne(d => d.IdDistritoNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdDistrito)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cliente_Distrito");
        });

        modelBuilder.Entity<Contacto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_contacto");

            entity.ToTable("Contacto");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Apellidos).HasMaxLength(80);
            entity.Property(e => e.CorreoElectronico).HasMaxLength(150);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModifiacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(80);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(70);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(70);

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.Contactos)
                .HasForeignKey(d => d.IdProveedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contacto_Proveedor");
        });

        modelBuilder.Entity<DetalleFactura>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_detalleFactura");

            entity.ToTable("DetalleFactura");

            entity.Property(e => e.MontoImpuesto).HasColumnType("money");
            entity.Property(e => e.MontoSubtotal).HasColumnType("money");
            entity.Property(e => e.MontoTotal).HasColumnType("money");
            entity.Property(e => e.TarifaServicio).HasColumnType("money");

            entity.HasOne(d => d.IdFacturaNavigation).WithMany(p => p.DetalleFacturas)
                .HasForeignKey(d => d.IdFactura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleFactura_Factura");

            entity.HasOne(d => d.IdServicioNavigation).WithMany(p => p.DetalleFacturas)
                .HasForeignKey(d => d.IdServicio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleFactura_Servicio");
        });

        modelBuilder.Entity<DetalleFacturaProducto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_[DetalleFacturaProducto");

            entity.ToTable("DetalleFacturaProducto");

            entity.Property(e => e.Cantidad).HasColumnType("decimal(6, 2)");

            entity.HasOne(d => d.IdDetalleFacturaNavigation).WithMany(p => p.DetalleFacturaProductos)
                .HasForeignKey(d => d.IdDetalleFactura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleFacturaProducto_DetalleFactura");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetalleFacturaProductos)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleFacturaProducto_Producto");
        });

        modelBuilder.Entity<Distrito>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_distrito");

            entity.ToTable("Distrito");

            entity.Property(e => e.Nombre).HasMaxLength(50);

            entity.HasOne(d => d.IdCantonNavigation).WithMany(p => p.Distritos)
                .HasForeignKey(d => d.IdCanton)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Distrito_Canton");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_factura");

            entity.ToTable("Factura");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.MontoImpuesto).HasColumnType("money");
            entity.Property(e => e.MontoTotal).HasColumnType("money");
            entity.Property(e => e.NombreCliente).HasMaxLength(160);
            entity.Property(e => e.PorcentajeImpuesto).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.SubTotal).HasColumnType("money");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(70);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(70);

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Factura_Cliente");

            entity.HasOne(d => d.IdImpuestoNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.IdImpuesto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Factura_Impuesto");

            entity.HasOne(d => d.IdTipoPagoNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.IdTipoPago)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Factura_TipoPago");

            entity.HasOne(d => d.IdUsuarioSucursalNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.IdUsuarioSucursal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Factura_UsuarioSucursal");
        });

        modelBuilder.Entity<Feriado>(entity =>
        {
            entity.ToTable("Feriado");

            entity.Property(e => e.Mes).HasConversion(x => x.ToString(), y => (Mes)Enum.Parse(typeof(Mes), y));

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(80);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(70);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(70);
        });

        modelBuilder.Entity<Genero>(entity =>
        {
            entity.ToTable("Genero");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Nombre).HasMaxLength(25);
        });

        modelBuilder.Entity<Horario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_horario");

            entity.ToTable("Horario");
          
            entity.Property(a => a.Dia).HasConversion(m => m.ToString(), b => (DiaSemana)Enum.Parse(typeof(DiaSemana), b));

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(70);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(70);
        });

        modelBuilder.Entity<Impuesto>(entity =>
        {
            entity.ToTable("Impuesto");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Nombre).HasMaxLength(40);
            entity.Property(e => e.Porcentaje).HasColumnType("decimal(5, 2)");
        });

        modelBuilder.Entity<Inventario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_inventario");

            entity.ToTable("Inventario");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(70);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(70);

            entity.HasOne(d => d.IdSucursalNavigation).WithMany(p => p.Inventarios)
                .HasForeignKey(d => d.IdSucursal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inventario_Sucursal");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_producto");

            entity.ToTable("Producto");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Cantidad).HasColumnType("decimal(6, 2)");
            entity.Property(e => e.Costo).HasColumnType("money");
            entity.Property(e => e.Descripcion).HasMaxLength(150);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Marca).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(70);
            entity.Property(e => e.Sku)
                .HasMaxLength(50)
                .HasColumnName("SKU");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(70);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(70);

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Producto_Categoria");

            entity.HasOne(d => d.IdUnidadMedidaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdUnidadMedida)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Producto_UnidadMedida");
        });

        modelBuilder.Entity<InventarioProducto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_InventarioProducto");

            entity.ToTable("InventarioProducto");

            entity.HasOne(d => d.IdInventarioNavigation).WithMany(p => p.InventarioProductos)
                .HasForeignKey(d => d.IdInventario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InventarioProducto_Inventario");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.InventarioProductos)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InventarioProducto_Producto");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_proveedor");

            entity.ToTable("Proveedor");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.CedulaJuridica).HasMaxLength(20);
            entity.Property(e => e.CorreoElectronico).HasMaxLength(150);
            entity.Property(e => e.DireccionExacta).HasMaxLength(250);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(80);
            entity.Property(e => e.RasonSocial).HasMaxLength(150);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(70);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(70);

            entity.HasOne(d => d.IdDistritoNavigation).WithMany(p => p.Proveedors)
                .HasForeignKey(d => d.IdDistrito)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Proveedor_Distrito");
        });

        modelBuilder.Entity<Provincia>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_provincia");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_reserva");

            entity.ToTable("Reserva");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("P")
                .IsFixedLength();
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(70);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(70);

            entity.HasOne(d => d.IdSucursalNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdSucursal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reserva_Sucursal");

            entity.HasOne(d => d.IdUsuarioSucursalNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdUsuarioSucursal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reserva_UsuarioSucursal");
        });

        modelBuilder.Entity<ReservaPregunta>(entity =>
        {
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Pregunta).HasMaxLength(250);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(70);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(70);

            entity.HasOne(d => d.IdReservaNavigation).WithMany(p => p.ReservaPregunta)
                .HasForeignKey(d => d.IdReserva)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReservaPregunta_Reserva");
        });

        modelBuilder.Entity<ReservaServicio>(entity =>
        {
            entity.ToTable("ReservaServicio");

            entity.HasOne(d => d.IdReservaNavigation).WithMany(p => p.ReservaServicios)
                .HasForeignKey(d => d.IdReserva)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReservaServicio_Reserva");

            entity.HasOne(d => d.IdServicioNavigation).WithMany(p => p.ReservaServicios)
                .HasForeignKey(d => d.IdServicio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReservaServicio_Servicio");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_rol");

            entity.ToTable("Rol");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Descripcion).HasMaxLength(50);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Tipo).HasMaxLength(50);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(70);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(70);
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_servicio");

            entity.ToTable("Servicio");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Descripcion).HasMaxLength(150);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.Observacion).HasMaxLength(250);
            entity.Property(e => e.Tarifa).HasColumnType("money");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(70);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(70);

            entity.HasOne(d => d.IdTipoServicioNavigation).WithMany(p => p.Servicios)
                .HasForeignKey(d => d.IdTipoServicio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Servicio_TipoServicio");
        });

        modelBuilder.Entity<Sucursal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_sucursal");

            entity.ToTable("Sucursal");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.CorreoElectronico).HasMaxLength(50);
            entity.Property(e => e.Descripcion).HasMaxLength(150);
            entity.Property(e => e.DireccionExacta).HasMaxLength(250);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(80);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(70);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(70);

            entity.HasOne(d => d.IdDistritoNavigation).WithMany(p => p.Sucursals)
                .HasForeignKey(d => d.IdDistrito)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sucursal_Distrito");
        });

        modelBuilder.Entity<SucursalHorario>(entity =>
        {
            entity.ToTable("SucursalHorario");

            entity.HasOne(d => d.IdHorarioNavigation).WithMany(p => p.SucursalHorarios)
                .HasForeignKey(d => d.IdHorario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SucursalHorario_Horario");

            entity.HasOne(d => d.IdSucursalNavigation).WithMany(p => p.SucursalHorarios)
                .HasForeignKey(d => d.IdSucursal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SucursalHorario_Sucursal");
        });

        modelBuilder.Entity<TipoPago>(entity =>
        {
            entity.ToTable("TipoPago");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Descripcion).HasMaxLength(50);
        });

        modelBuilder.Entity<TipoServicio>(entity =>
        {
            entity.ToTable("TipoServicio");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<UnidadMedida>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Nombre).HasMaxLength(25);
            entity.Property(e => e.Simbolo)
                .HasMaxLength(5)
                .IsFixedLength();
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_usuario");

            entity.ToTable("Usuario");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Apellidos).HasMaxLength(80);
            entity.Property(e => e.Cedula).HasMaxLength(50);
            entity.Property(e => e.Contrasenna)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.CorreoElectronico).HasMaxLength(150);
            entity.Property(e => e.DireccionExacta).HasMaxLength(250);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(80);
            entity.Property(e => e.UrlFoto).HasMaxLength(200);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(70);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(70);

            entity.HasOne(d => d.IdDistritoNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdDistrito)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuario_Distrito");

            entity.HasOne(d => d.IdGeneroNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdGenero)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuario_Genero");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuario_Rol");
        });

        modelBuilder.Entity<UsuarioSucursal>(entity =>
        {
            entity.ToTable("UsuarioSucursal");

            entity.HasOne(d => d.IdSucursalNavigation).WithMany(p => p.UsuarioSucursals)
                .HasForeignKey(d => d.IdSucursal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioSucursal_Sucursal");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.UsuarioSucursals)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioSucursal_Usuario");
        });

        modelBuilder.Entity<SucursalFeriado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_SucursalFeriado");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.ToTable("SucursalFeriado");

            entity.HasOne(d => d.IdFeriadoNavigation).WithMany(p => p.SucursalFeriados)
                .HasForeignKey(d => d.IdFeriado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SucursalFeriado_Feriado");

            entity.HasOne(d => d.IdSucursalNavigation).WithMany(p => p.SucursalFeriados)
                .HasForeignKey(d => d.IdSucursal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SucursalFeriado_Sucursal");
        });

        modelBuilder.Entity<SucursalHorarioBloqueo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_SucursalHorarioBloqueo");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.ToTable("SucursalHorarioBloqueo");

            entity.Property(e => e.Activo).HasDefaultValue(true);

            entity.HasOne(d => d.IdSucursalHorarioNavigation).WithMany(p => p.SucursalHorarioBloqueos)
                .HasForeignKey(d => d.IdSucursalHorario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SucursalHorarioBloqueo_SucursalHorario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        OnBeforeSaving();

        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken)
    {
        OnBeforeSaving();
        return await base.SaveChangesAsync(acceptAllChangesOnSuccess);
    }

    private void OnBeforeSaving()
    {
        DefaultProperties();
    }

    //pone valores por defecto
    private void DefaultProperties()
    {
        DateTime FechaCreacion = DateTime.Now;
        DateTime FechaModificacion = DateTime.Now;
        const bool Activo = true;
        const string UsuarioCreacion = "ArtInkAPI";
        const string UsuarioModificacion = "ArtInkAPIModify";

        foreach (var entry in ChangeTracker.Entries())
        {
            if (entry.State == EntityState.Added)
            {
                if (entry.Entity.GetType().GetProperty(nameof(FechaCreacion)) != null && entry.Property(nameof(FechaCreacion)).CurrentValue != null) entry.Property(nameof(FechaCreacion)).CurrentValue = FechaCreacion;
                if (entry.Entity.GetType().GetProperty(nameof(Activo)) != null && !(bool)entry.Property(nameof(Activo)).CurrentValue!) entry.Property(nameof(Activo)).CurrentValue = Activo;

                if (entry.Entity.GetType().GetProperty(nameof(UsuarioCreacion)) != null && entry.Property(nameof(UsuarioModificacion)).CurrentValue != null)
                {
                    entry.Property(nameof(UsuarioCreacion)).CurrentValue = entry.Property(nameof(UsuarioModificacion)).CurrentValue;
                    entry.Property(nameof(UsuarioModificacion)).CurrentValue = null;
                }

                if (entry.Entity.GetType().GetProperty(nameof(UsuarioCreacion)) != null) entry.Property(nameof(UsuarioCreacion)).CurrentValue = UsuarioCreacion;
                if (entry.Entity.GetType().GetProperty(nameof(FechaModificacion)) != null) entry.Property(nameof(FechaModificacion)).IsModified = false;
                if (entry.Entity.GetType().GetProperty(nameof(UsuarioModificacion)) != null) entry.Property(nameof(UsuarioModificacion)).IsModified = false;
            }
            else
            {
                if (entry.State == EntityState.Modified)
                {
                    if (entry.Entity.GetType().GetProperty(nameof(FechaModificacion)) != null) entry.Property(nameof(FechaModificacion)).CurrentValue = FechaModificacion;

                    if (entry.Entity.GetType().GetProperty(nameof(UsuarioModificacion)) != null) entry.Property(nameof(UsuarioModificacion)).CurrentValue = UsuarioModificacion;
                    if (entry.Entity.GetType().GetProperty(nameof(FechaCreacion)) != null) entry.Property(nameof(FechaCreacion)).IsModified = false;
                    if (entry.Entity.GetType().GetProperty(nameof(UsuarioCreacion)) != null) entry.Property(nameof(UsuarioCreacion)).IsModified = false;
                }
            }
        }
    }
}