﻿namespace OrcamentoFamiliar.API.Entity
{
    public class Despesas : BaseEntity
    {
        public string? Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
    }
}
