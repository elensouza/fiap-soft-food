﻿namespace Core.Entities;

public sealed record  Cliente
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string CPF { get; set; }
    public string Email { get; set; }
}








