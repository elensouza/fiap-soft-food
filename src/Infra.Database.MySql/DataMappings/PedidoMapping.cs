﻿using Infra.Database.MySql.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Database.MySql.DataMappings;

public class PedidoMapping : IEntityTypeConfiguration<Pedido>
{
    public void Configure(EntityTypeBuilder<Pedido> builder)
    {
        builder.ToTable("Pedidos");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.DataPedido).IsRequired();
        builder.Property(p => p.Status).IsRequired();
        builder.Property(p => p.ClienteId);
        builder.Property(p => p.PagamentoId).IsRequired();

        builder.HasOne(p => p.Cliente)
           .WithMany()
           .HasForeignKey(p => p.ClienteId)
           .OnDelete(DeleteBehavior.Restrict); 

        builder.HasOne(p => p.Pagamento)
           .WithMany()
           .HasForeignKey(p => p.PagamentoId)
           .OnDelete(DeleteBehavior.Restrict); 
    }
}
