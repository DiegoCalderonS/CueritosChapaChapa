﻿using Microsoft.EntityFrameworkCore;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Configuracion
{
    public class CueritosConfiguracion : IEntityTypeConfiguration<Cueritos>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Cueritos> builder)
        {
            builder.Property(x => x.id).IsRequired();
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Descripcion).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Estado).IsRequired();
        }
    }
}
