using Inteliventas.Erp.Clientes;
using Inteliventas.Erp.Pedidos;
using Inteliventas.Erp.Vendedores;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Inteliventas.Erp.EntityFrameworkCore
{
    public static class ErpDbContextModelCreatingExtensions
    {
        public static void ConfigureErp(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(ErpConsts.DbTablePrefix + "YourEntities", ErpConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});

            builder.Entity<Cliente>(c =>
            {
                c.ToTable(ErpConsts.DbTablePrefix + "Clientes", ErpConsts.DbSchema);

                c.ConfigureByConvention();

                c.Property(x => x.Nombre).IsRequired(true).HasMaxLength(50);

                c.Property(x => x.Ruc).IsFixedLength(true).HasMaxLength(11);
                
                c.Property(x => x.Dni).IsFixedLength(true).HasMaxLength(8);
                
                c.Property(x => x.Ce).IsFixedLength(true).HasMaxLength(12);
            });

            builder.Entity<Vendedor>(c =>
            {
                c.ToTable(ErpConsts.DbTablePrefix + "Vendedores", ErpConsts.DbSchema);

                c.ConfigureByConvention();

                c.Property(x => x.Nombre).IsRequired(true).HasMaxLength(50);

                c.Property(x => x.Ruc).IsFixedLength(true).HasMaxLength(11);

                c.Property(x => x.Dni).IsFixedLength(true).HasMaxLength(8);

                c.Property(x => x.Ce).IsFixedLength(true).HasMaxLength(12);
            });

            builder.Entity<Pedido>(p =>
            {
                p.ToTable(ErpConsts.DbTablePrefix + "Pedidos", ErpConsts.DbSchema);

                p.ConfigureByConvention();

                p.Property(x => x.Total).IsRequired(true).HasDefaultValue(0.0);

                p.Property(x => x.TotalProductos).IsRequired(true).HasDefaultValue(0.0);

                p.HasOne<Cliente>().WithMany().HasForeignKey(c => c.ClienteId).IsRequired();

                p.HasOne<Vendedor>().WithMany().HasForeignKey(c => c.VendedorId).IsRequired();
            });
        }
    }
}