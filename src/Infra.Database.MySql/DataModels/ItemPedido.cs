﻿namespace Infra.Database.MySql.DataModels;

public sealed record ItemPedido
{
    public Guid Id { get; set; }
    public Guid PedidoId { get; set; }
    public Guid ProdutoId { get; set; }
    public int Quantidade { get; set; }
    public Produto? Produto { get; set; }
}