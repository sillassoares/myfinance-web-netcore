using Microsoft.EntityFrameworkCore;
using myfinance_web_netcore.Domain.Entities;
using myfinance_web_netcore.Domain.Services.Interfaces;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Domain.Services
{
    public class TransacaoService : ITransacaoService
    {
        private readonly MyFinanceDBContext _dbContext;

        public TransacaoService(MyFinanceDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<TransacaoModel> ListarRegistros()
        {
            var result = new List<TransacaoModel>();
            var dbSet = _dbContext.Transacao.Include(x => x.PlanoConta);

            foreach (var item in dbSet)
            {
                var itemTransacao = new TransacaoModel()
                {
                    Id = item.Id,
                    Data = item.Data,
                    Historico = item.Historico,
                    Valor = item.Valor,
                    ItemPlanoConta = new PlanoContaModel()
                    {
                        Id = item.PlanoConta.Id,
                        Descricao = item.PlanoConta.Descricao,
                        Tipo = item.PlanoConta.Tipo
                    },
                    PlanoContaId = item.PlanoContaId,
                };
                result.Add(itemTransacao);
            }
            return result;
        }
        public void Salvar(TransacaoModel model)
        {
            var dbSet = _dbContext.Transacao;

            var entidade = new Transacao()
            {
                Id = model.Id,
                Data = model.Data,
                Historico = model.Historico,
                Valor = model.Valor,
                PlanoContaId = model.PlanoContaId
            };

            if (entidade.Id == null)
            {
                dbSet.Add(entidade);
            }
            else
            {
                dbSet.Attach(entidade);
                _dbContext.Entry(entidade).State = EntityState.Modified;
            }
            _dbContext.SaveChanges();
        }

        public TransacaoModel RetornarRegistro(int id)
        {
            var item = _dbContext.Transacao.Where(x => x.Id == id).First();

            var itemTransacao = new TransacaoModel()
            {
                Id = item.Id,
                Data = item.Data,
                Historico = item.Historico,
                Valor = item.Valor,
                PlanoContaId = item.PlanoContaId,
            };
            return itemTransacao;
        }
        public void Excluir(int id)
        {
            var item = _dbContext.Transacao.Where(x => x.Id == id).First();

            _dbContext.Attach(item);
            _dbContext.Remove(item);
            _dbContext.SaveChanges();
        }
    }
}