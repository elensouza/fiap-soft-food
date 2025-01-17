﻿using System.Diagnostics;
using Application.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Enums;
using Core.Interfaces.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Interface.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PedidoController : ControllerBase
{
    private readonly IPedidoService _pedidoService;
    private readonly IMapper _mapper;

    public PedidoController(IMapper mapper, IPedidoService pedidoService)
    {
        _mapper = mapper;
        _pedidoService = pedidoService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<PedidoDto>> GetPedidos()
    {
        var pedidos = _pedidoService.ObtemPedidos();
        if (!pedidos.Any())
            return NotFound();

        return Ok(pedidos);
    }

    [HttpGet("{status}")]
    public ActionResult<IEnumerable<PedidoDto>> GetPedidosPorStatus(StatusPedido status)
    {
        var pedidos = _pedidoService.ObtemPedidosPorStatus(status);
        if (!pedidos.Any())
            return NotFound();

        return Ok(pedidos);
    }

    [HttpPost]
    public ActionResult<Guid> CheckoutPedido(Pedido pedido)
    {
        var id = _pedidoService.CheckoutPedido(pedido);
        return Ok(id);
    }

    [HttpPut("{id:Guid}/{status:int}")]
    public IActionResult AtualizaStatusPedido(Guid id, StatusPedido status)
    {
        _pedidoService.AtualizaPedidoStatus(id, status);
        
        return Ok();
    }

    [HttpPut("Update-Pagamento/{id:Guid}/{status:int}")]
    public ActionResult<Guid> UpdatePagamento(Guid id, StatusPagamento status)
    {
        _pedidoService.UpdatePagamento(id, status);
        return Ok();
    }
}