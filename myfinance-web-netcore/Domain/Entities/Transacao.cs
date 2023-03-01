namespace myfinance_web_netcore.Domain.Entities
{
    public class Transacao
    {
        public int? Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Valor { get; set; }
        public string? Historico { get; set; }
        public int PlanoContaId { get; set; }
        public PlanoConta PlanoConta { get; set; }
    }
}