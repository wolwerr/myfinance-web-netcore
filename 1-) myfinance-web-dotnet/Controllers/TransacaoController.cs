using Microsoft.AspNetCore.Mvc;
using myfinance_web_dotnet_domain.Entities;
using myfinance_web_dotnet_service.Interfaces;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Controllers
{
    [Route("[controller]")]
    public class TransacaoController : Controller
    {
        private readonly ILogger<TransacaoController> _logger;
        private readonly ITransacaoService _transacaoService;

        public TransacaoController(
            ILogger<TransacaoController> logger,
            ITransacaoService transacaoService
            )
        {
            _logger = logger;
            _transacaoService = transacaoService;
        }

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            var listaTransacao = _transacaoService.ListarRegistro();
            List<TransacaoModel> listaTransacaoModel = new List<TransacaoModel>();

            foreach(var item in listaTransacao){
                var itemTransacao = new TransacaoModel(){
                    Id = item.Id,
                    Historico = item.Historico,
                    Data = item.Data,
                    Valor = item.Valor,
                    Tipo = item.PlanoConta.Tipo,
                    PlanoContaId = item.PlanoContaId                 
                };

                listaTransacaoModel.Add(itemTransacao);
            }

            ViewBag.ListaTransacao = listaTransacaoModel;

            return View();
        }

        [HttpGet]
        [Route("Cadastrar")]
        [Route("Cadastrar/{Id}")]
        public IActionResult Cadastrar(int? Id)
        {
            if (Id != null)
            {
                
            var transacao = _transacaoService.RetornarRegistro((int)Id);

            var itemTransacao = new TransacaoModel()
            {
                Id = transacao.Id,
                Historico = transacao.Historico,
                Data = transacao.Data,
                Valor = transacao.Valor,
                PlanoContaId = transacao.PlanoContaId
            };

            return View(itemTransacao);
            }else{
                return View();
            }
        }   
        
        [HttpPost]
        [Route("Cadastrar")]
        [Route("Cadastrar/{Id}")]
        public IActionResult Cadastrar(TransacaoModel model)
        {
            var transacao = new Transacao()
            {
                Id = model.Id,
                Historico = model.Historico,
                Data = model.Data,
                Valor = model.Valor,
                PlanoContaId = model.PlanoContaId,
            };

            _transacaoService.Cadastrar(transacao);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Excluir/{Id}")]
        public IActionResult Excluir(int? Id)
        {
            _transacaoService.Excluir((int)Id);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}