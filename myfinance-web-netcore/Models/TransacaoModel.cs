using Microsoft.AspNetCore.Mvc.Rendering;


namespace myfinance_web_netcore.Models
{
    public class TransacaoModel
    {
        public int? Id { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public string? Historico { get; set; }
        public int PlanoContaId { get; set; }
        // public IEnumerable<SelectListItem>? PlanoContas { set; get; }


        private IEnumerable<SelectListItem>? _planoContas = null;

        public IEnumerable<SelectListItem>? PlanoContas
        {
            get { return _planoContas; }
            set { _planoContas = value; }
        }
    }
}