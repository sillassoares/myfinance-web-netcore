using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using myfinance_web_netcore.Domain.Services;
using myfinance_web_netcore.Domain.Services.Interfaces;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Controllers
{
    [Route("[controller]")]
    public class PlanoContaController : Controller
    {
        private readonly ILogger<PlanoContaController> _logger;
        private readonly PlanoContaService _planoContaService;

        public PlanoContaController(ILogger<PlanoContaController> logger, PlanoContaService planoContaService)
        {
            _logger = logger;
            _planoContaService = planoContaService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {

            ViewBag.ListaPlanoConta = _planoContaService.ListarRegistros();
            return View();
        }

        [HttpGet]
        [Route("Cadastro")]
        [Route("Cadastro/{id}")]
        public IActionResult Cadastro(int? id)
        {

            if (id != null)
            {
                var registro = _planoContaService.RetornarRegistro((int)id);
                return View(registro);
            }
            return View();
        }


        [HttpPost]
        [Route("Cadastro")]
        [Route("Cadastro/{id}")]
        public IActionResult Cadastro(PlanoContaModel model)
        {
            _planoContaService.Salvar(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Excluir/{id}")]
        public IActionResult Excluir(int? id)
        {
            _planoContaService.Excluir((int)id);
            return RedirectToAction("Index");
        }


    }
}