using Microsoft.AspNetCore.Mvc;
using myfinance_web_netcore.Domain.Services.Interfaces;
using myfinance_web_netcore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace myfinance_web_netcore.Controllers
{
    [Route("[controller]")]
    public class TransacaoController : Controller
    {
        private readonly ILogger<TransacaoController> _logger;

        private readonly IPlanoContaService _planoContaservice;
        private readonly ITransacaoService _transacaoService;

        public TransacaoController(
            ILogger<TransacaoController> logger,
            IPlanoContaService planoContaservice,
            ITransacaoService transacaoService)
        {
            _logger = logger;
            _planoContaservice = planoContaservice;
            _transacaoService = transacaoService;
        }

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            ViewBag.Transacoes = _transacaoService.ListarRegistros();
            return View();
        }

        [HttpGet]
        [Route("Cadastro")]
        [Route("Cadastro/{id}")]
        public IActionResult Cadastro(int? id)
        {
            var model = new TransacaoModel();
            if (id != null)
            {
                model = _transacaoService.RetornarRegistro((int)id);
            }
            var lista = _planoContaservice.ListarRegistros();
            model.PlanoContas = new SelectList(lista, "Id", "Descricao");
            return View(model);
        }

        [HttpPost]
        [Route("Cadastro")]
        [Route("Cadastro/{id}")]
        public IActionResult Cadastro(TransacaoModel model)
        {
            _transacaoService.Salvar(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Excluir/{id}")]
        public IActionResult Excluir(int id)
        {
            _transacaoService.Excluir(id);
            return RedirectToAction("Index");
        }
    }
}