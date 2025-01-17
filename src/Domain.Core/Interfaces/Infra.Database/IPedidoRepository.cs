﻿using Core.Entities;
using Core.Enums;

namespace Core.Interfaces.Infra.Database;

public interface IPedidoRepository
{
    IEnumerable<Pedido> ObtemPedidos();
    IEnumerable<Pedido> ObtemPedidosPorStatus(StatusPedido statusPedido);
    Guid CheckoutPedido(Pedido pedido);
    void AtualizaPedidoStatus(Guid id, StatusPedido status);
    void UpdatePagamento(Guid id, StatusPagamento status);
}