﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.AccesoDatos.Configuracion
{
    public class ProductoConfiguracion : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x=> x.NumeroSerie).IsRequired().HasMaxLength(30);
            builder.Property(x=> x.Descripcion).IsRequired().HasMaxLength(100);
            builder.Property(x=> x.Estado).IsRequired();
            builder.Property(x => x.Precio).IsRequired();
            builder.Property(x => x.Costo).IsRequired();
            builder.Property(x => x.PapasId).IsRequired();
            builder.Property(x => x.ChurrosId).IsRequired();
            builder.Property(x=> x.ImagenUrl).IsRequired(false);
            builder.Property(x=> x.PadreId).IsRequired(false);


            //Hagamos las relaciones Fluent API

            builder.HasOne(x => x.Churros).WithMany()
                .HasForeignKey(x=>x.ChurrosId).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Papas).WithMany()
                .HasForeignKey(x => x.PapasId).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Padre).WithMany()
                .HasForeignKey(x => x.PadreId).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
